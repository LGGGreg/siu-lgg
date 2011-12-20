using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class TextEditorMain : Form
    {
        public string menuFile = "C:\\League of Legends Mods\\fontconfig_en_US.txt";

        public TextEditorMain()
        {
            InitializeComponent();
        }
        public TextEditorMain(string _menuFile)
        {
            menuFile = _menuFile;
            InitializeComponent();
        }

        #region Variables

        public class TxtStruct : Dictionary<String, Dictionary<String, String>> { }

        TxtStruct origTextStruct = new TxtStruct();
        TxtStruct editedTextStruct = new TxtStruct();
        Dictionary<String, String> blankDict = new Dictionary<String, String>();

        // List of lines that are worth editing
        String[] usableTextLines = { "game_buff_tooltip", "game_character_description", "game_character_displayname", "game_character_lore", "game_character_passiveDescription", "game_character_opposing_tips", "game_character_passiveName", "game_character_skin_displayname", "game_spell_description", "game_character_tips", "game_spell_displayname", "game_spell_levelup", "game_spell_tooltip" };


        #endregion // Variables

        #region GUI

        private void TextEditorMain_Load(object sender, EventArgs e)
        {
            createOrigTextTreeView(menuFile);
        }

        private void createOrigTextTreeView (String fontConfigPath)
        {
            // Open fontConfig file
            FileStream fs = new FileStream(fontConfigPath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);

            String line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                String name = String.Empty;
                String text = String.Empty;

                // Make sure the dictionary is actually blank
                blankDict = new Dictionary<String, String>();

                // Interate through the list to find a match
                foreach (String type in usableTextLines)
                {
                    if (line.Contains(type))
                    {
                        // Split into key and value
                        String[] parts = line.Split('=');
                        int startIndex = parts[0].IndexOf(type) + type.Length + 1;
                        // Parse off the name of the object
                        name = parts[0].Substring(startIndex, parts[0].Length - startIndex - 2);
                        // Get the text that describes the object
                        text = parts[1].Substring(2, parts[1].Length - 3);
                        // Add it to the main dictionary
                        if (!origTextStruct.ContainsKey(type))
                            origTextStruct[type] = blankDict;
                        origTextStruct[type][name] = text;
                        // Break to save processing time
                        break;
                    }
                }
            }

            fs.Close();

            // Create original text TreeView
            TreeNode origRootNode = new TreeNode("Original Text");
            foreach (KeyValuePair<String, Dictionary<String, String>> typeKVP in origTextStruct)
            {
                TreeNode origTypeNode = origRootNode.Nodes.Add(typeKVP.Key);
                foreach (KeyValuePair<String, String> nameKVP in origTextStruct[typeKVP.Key])
                {
                    origTypeNode.Nodes.Add(nameKVP.Key);
                }
            }
            treeView1.Nodes.Add(origRootNode);
            treeView1.Sort();
            treeView1.Nodes[0].Expand();
        }

        private void OrigNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Only care about last child nodes
            if (this.treeView1.SelectedNode != null && this.treeView1.SelectedNode.Nodes.Count == 0)
            {
                String name = this.treeView1.SelectedNode.Text;
                String type = this.treeView1.SelectedNode.Parent.Text;

                // Create a dialog for the user to edit the text
                TextEditingBox textEditBox = new TextEditingBox(origTextStruct[type][name]);
                var result = textEditBox.ShowDialog();

                // Only care if the user presses ok AND there are actually changes
                if (result == DialogResult.OK)
                {
                    if (textEditBox.richTextBox.Text != origTextStruct[type][name])
                    {
                        // Again, make sure the dictionary is actually blank
                        blankDict = new Dictionary<String, String>();

                        // Add the edited text to the edited text struct
                        if (!editedTextStruct.ContainsKey(type))
                            editedTextStruct[type] = blankDict;
                        editedTextStruct[type][name] = textEditBox.richTextBox.Text;

                        // Update the edited text TreeView
                        TreeNode editedRootNode = new TreeNode("Edited Text");
                        foreach (KeyValuePair<String, Dictionary<String, String>> typeKVP in editedTextStruct)
                        {
                            TreeNode editedTypeNode = editedRootNode.Nodes.Add(typeKVP.Key);
                            foreach (KeyValuePair<String, String> nameKVP in editedTextStruct[typeKVP.Key])
                            {
                                editedTypeNode.Nodes.Add(nameKVP.Key);
                            }
                        }
                        treeView2.Nodes.Clear();
                        treeView2.Nodes.Add(editedRootNode);
                        treeView2.Sort();
                        treeView2.ExpandAll();
                        // Allow customText.txt to be created
                        exportButton.Enabled = true;
                    }
                }
            }
        }

        private void EditedNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Only care about last child nodes
            if (this.treeView2.SelectedNode.Nodes.Count == 0)
            {
                String name = this.treeView2.SelectedNode.Text;
                String type = this.treeView2.SelectedNode.Parent.Text;

                // Create a dialog for the user to edit the text
                TextEditingBox textEditBox = new TextEditingBox(editedTextStruct[type][name]);
                var result = textEditBox.ShowDialog();

                // Only care if the user presses ok AND there are actually changes
                if (result == DialogResult.OK)
                {
                    if (textEditBox.richTextBox.Text != editedTextStruct[type][name])
                    {
                        // Again, make sure the dictionary is actually blank
                        blankDict = new Dictionary<String, String>();

                        // Add the edited text to the edited text struct
                        if (!editedTextStruct.ContainsKey(type))
                            editedTextStruct[type] = blankDict;
                        editedTextStruct[type][name] = textEditBox.richTextBox.Text;

                        // Update the edited text TreeView
                        TreeNode editedRootNode = new TreeNode("Edited Text");
                        foreach (KeyValuePair<String, Dictionary<String, String>> typeKVP in editedTextStruct)
                        {
                            TreeNode editedTypeNode = editedRootNode.Nodes.Add(typeKVP.Key);
                            foreach (KeyValuePair<String, String> nameKVP in editedTextStruct[typeKVP.Key])
                            {
                                editedTypeNode.Nodes.Add(nameKVP.Key);
                            }
                        }
                        treeView2.Nodes.Clear();
                        treeView2.Nodes.Add(editedRootNode);
                        treeView2.Sort();
                        treeView2.ExpandAll();
                        // Allow customText.txt to be created
                        exportButton.Enabled = true;
                    }
                }
            }
        }

        private void filter()
        {
            if (filter_txt.Text == "")
                return;
            TreeNode origRootNode = new TreeNode("Original Text");
            foreach (KeyValuePair<String, Dictionary<String, String>> typeKVP in origTextStruct)
            {
                TreeNode origTypeNode = origRootNode.Nodes.Add(typeKVP.Key);
                foreach (KeyValuePair<String, String> nameKVP in origTextStruct[typeKVP.Key])
                {
                    if (nameKVP.Key.ToLower().Contains(filter_txt.Text.ToLower()))
                    {
                        origTypeNode.Nodes.Add(nameKVP.Key);
                    }
                }
                if (!(origTypeNode.Nodes.Count > 0))
                    origTypeNode.Remove();
            }
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(origRootNode);
            treeView1.Sort();
            treeView1.Nodes[0].Expand();
            treeView1.Focus();
        }

        private void editedTextClear()
        {
            editedTextStruct = new TxtStruct();
            treeView2.Nodes.Clear();
        }

        #endregion // GUI

        #region Buttons

        private void textInstallButton_Click(object sender, EventArgs e)
        {
            installText(menuFile, "C:\\League of Legends Mods\\customText.txt", "C:\\League of Legends Mods");
            MessageBox.Show("Successfully installed");
        }

        private void textUninstallButton_Click(object sender, EventArgs e)
        {
            uninstallText(menuFile, "C:\\League of Legends Mods\\customText.txt", "C:\\League of Legends Mods");
            MessageBox.Show("Successfully uninstalled");
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                exportTextFile(editedTextStruct, folderBrowserDialog1.SelectedPath);
                MessageBox.Show("Success creating customText.txt");
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(string file in openFileDialog1.FileNames)
                    importTextFile(file);
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void filter_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filter();
                e.SuppressKeyPress = true;
            }
        }

        #endregion // Buttons

        #region Work Functions

        private void exportTextFile(TxtStruct textStruct, String outputDir)
        {
            TextWriter dataWriter = new StreamWriter(outputDir+"\\customText.txt");

            foreach (KeyValuePair<String, Dictionary<String, String>> typeKVP in textStruct)
            {
                foreach (KeyValuePair<String, String> nameKVP in textStruct[typeKVP.Key])
                {
                    dataWriter.WriteLine(typeKVP.Key + "_" + nameKVP.Key + "=>" + nameKVP.Value);
                }
            }

            dataWriter.Close();
        }

        private void importTextFile(String inputDir)
        {
            FileStream fs = new FileStream(inputDir, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);

            String line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                String[] parts = line.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                String name = String.Empty;
                String text = String.Empty;

                // Make sure the dictionary is actually blank
                blankDict = new Dictionary<String, String>();

                // Interate through the list to find a match
                foreach (String type in usableTextLines)
                {
                    if (parts[0].Contains(type))
                    {
                        int startIndex = type.Length + 1;
                        // Parse off the name of the object
                        name = parts[0].Substring(startIndex);
                        // Get the text that describes the object
                        text = parts[1];
                        // Add it to the main dictionary
                        if (!editedTextStruct.ContainsKey(type))
                            editedTextStruct[type] = blankDict;
                        editedTextStruct[type][name] = text;
                        // Break to save processing time
                        break;
                    }
                }
            }

            reader.Close();
            fs.Close();

            // Update the edited text TreeView
            TreeNode editedRootNode = new TreeNode("Edited Text");
            foreach (KeyValuePair<String, Dictionary<String, String>> typeKVP in editedTextStruct)
            {
                TreeNode editedTypeNode = editedRootNode.Nodes.Add(typeKVP.Key);
                foreach (KeyValuePair<String, String> nameKVP in editedTextStruct[typeKVP.Key])
                {
                    editedTypeNode.Nodes.Add(nameKVP.Key);
                }
            }
            treeView2.Nodes.Clear();
            treeView2.Nodes.Add(editedRootNode);
            treeView2.Sort();
            treeView2.ExpandAll();
            // Allow customText.txt to be created
            exportButton.Enabled = true;
        }

        private void installText(String fontConfigPath, String customEditPath, String backupDir)
        {
            Dictionary<String, String> backup = new Dictionary<String, String>();
            Dictionary<String, String> edit = new Dictionary<String, String>();
            Dictionary<String, String> finish = new Dictionary<String, String>();
            
            if (File.Exists(backupDir + "\\backupText.txt"))
            {
                FileStream bakFS = new FileStream(backupDir + "\\backupText.txt", FileMode.Open, FileAccess.Read);
                StreamReader bakReader = new StreamReader(bakFS);

                String bakLine = String.Empty;
                while ((bakLine = bakReader.ReadLine()) != null)
                {
                    String[] parts = bakLine.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                    backup.Add(parts[0], parts[1]);
                }

                bakReader.Close();
                bakFS.Close();

            }

            FileStream editFS = new FileStream(customEditPath, FileMode.Open, FileAccess.Read);
            StreamReader editReader = new StreamReader(editFS);

            String editLine = String.Empty;
            while ((editLine = editReader.ReadLine()) != null)
            {
                String[] parts = editLine.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                edit.Add(parts[0], parts[1]);
            }

            editReader.Close();
            editFS.Close();

            TextWriter dataWriter = new StreamWriter(backupDir + "\\fontConfigOutput.txt");

            FileStream fs = new FileStream(fontConfigPath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);

            String line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                Boolean matched = false;
                foreach (KeyValuePair<String, String> editedTextKVP in edit)
                {
                    if (line.Contains(editedTextKVP.Key))
                    {
                        String[] parts = line.Split(new string[] { "\" = \"" }, StringSplitOptions.RemoveEmptyEntries);
                        String key = parts[0].Substring(4);
                        String value = parts[1].Substring(0, parts[1].Length - 1);
                        // Create backup
                        if(!backup.ContainsKey(key))
                            backup.Add(key, value);
                        // Write edited line
                        dataWriter.WriteLine("tr \"" + editedTextKVP.Key + "\" = \"" + editedTextKVP.Value + "\"");
                        matched = true;
                        break;
                    } 
                }
                if (!matched)
                    dataWriter.WriteLine(line);
            }

            dataWriter.Close();
            reader.Close();
            fs.Close();

            dataWriter = new StreamWriter(backupDir + "\\backupText.txt");

            foreach (KeyValuePair<String, String> backupKVP in backup)
            {
                dataWriter.WriteLine(backupKVP.Key + "=>" + backupKVP.Value);
            }

            dataWriter.Close();

            // Delete old file and move new file to replace it
            File.Delete(fontConfigPath);
            File.Move(backupDir + "\\fontConfigOutput.txt", fontConfigPath);
        }

        private void uninstallText(String fontConfigPath, String customEditPath, String backupDir)
        {
            Dictionary<String, String> backup = new Dictionary<String, String>();
            Dictionary<String, String> edit = new Dictionary<String, String>();
            Dictionary<String, String> finish = new Dictionary<String, String>();

            if (File.Exists(backupDir + "\\backupText.txt"))
            {
                FileStream bakFS = new FileStream(backupDir + "\\backupText.txt", FileMode.Open, FileAccess.Read);
                StreamReader bakReader = new StreamReader(bakFS);

                String bakLine = String.Empty;
                while ((bakLine = bakReader.ReadLine()) != null)
                {
                    String[] parts = bakLine.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                    backup.Add(parts[0], parts[1]);
                }

                bakReader.Close();
                bakFS.Close();

            }
            else
            {
                MessageBox.Show("There is no backup to uninstall from. Please repair your LoL.", "No backup found");
                return;
            }

            //Check that there is a backup for each edit to uninstall
            foreach (KeyValuePair<String, String> editedTextKVP in edit)
            {
                if (!backup.ContainsKey(editedTextKVP.Key))
                {
                    MessageBox.Show("There is no backup for " + editedTextKVP + ".Please repair your LoL", "No backup for edit");
                    return;
                }
            }

            FileStream editFS = new FileStream(customEditPath, FileMode.Open, FileAccess.Read);
            StreamReader editReader = new StreamReader(editFS);

            String editLine = String.Empty;
            while ((editLine = editReader.ReadLine()) != null)
            {
                String[] parts = editLine.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                edit.Add(parts[0], parts[1]);
            }

            editReader.Close();
            editFS.Close();

            TextWriter dataWriter = new StreamWriter(backupDir + "\\fontConfigOutput.txt");

            FileStream fs = new FileStream(fontConfigPath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);

            String line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                Boolean matched = false;
                foreach (KeyValuePair<String, String> editedTextKVP in edit)
                {
                    if (line.Contains(editedTextKVP.Key))
                    {
                        // Write original line from backup
                        dataWriter.WriteLine("tr \"" + editedTextKVP.Key + "\" = \"" + backup[editedTextKVP.Key] + "\"");
                        matched = true;
                        backup.Remove(editedTextKVP.Key);
                        break;
                    }
                }
                if (!matched)
                    dataWriter.WriteLine(line);
            }

            dataWriter.Close();
            reader.Close();
            fs.Close();

            dataWriter = new StreamWriter(backupDir + "\\backupText.txt");

            foreach (KeyValuePair<String, String> backupKVP in backup)
            {
                dataWriter.WriteLine(backupKVP.Key + "=>" + backupKVP.Value);
            }

            dataWriter.Close();

            // Delete old file and move new file to replace it
            File.Delete(fontConfigPath);
            File.Move(backupDir + "\\fontConfigOutput.txt", fontConfigPath);
        }

        #endregion // Work Functions

        private void editedTextClearButton_Click(object sender, EventArgs e)
        {
            editedTextClear();
        }

        private void filter_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


    }
}
