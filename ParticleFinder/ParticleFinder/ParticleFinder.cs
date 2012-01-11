using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAFLib;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ParticleFinder
{
    public partial class ParticleFinder : Form
    {
        public ParticleFinder()
        {
            InitializeComponent();
        }

        public class PStruct : Dictionary
                    <String, Dictionary
                        <String, Dictionary
                            <RAFFileListEntry, List<String>>>> { }
        public int lastProgress = 0;

        String lolDirectory = "C:\\Riot Games\\League of Legends";

        FolderBrowserDialog lolDirBrowser = new FolderBrowserDialog();

        private void ParticleFinder_Load(object sender, EventArgs e)
        {
            lolDirBrowser.Description = "Select your League of Legends game directory.\n(Example: C:\\Riot Games\\League of Legends)";
            lolDirBrowser.ShowNewFolderButton = false;
            lolDirBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            lolDirBrowser.Tag = "Particle Reference";
            if (!Directory.Exists(lolDirectory))
            {
                lolDirBrowser.ShowDialog();
                lolDirectory = lolDirBrowser.SelectedPath;
                this.Activate();
            }
        }

        //public void reportProgress(int p)
        //{
        //    if (p != lastProgress)
        //    {
        //        lastProgress = p;
                
        //        particleReaderWorker.ReportProgress(p);
        //    }
        //}
        public PStruct getParticleStructure(string rafPath)
        {
            PStruct particleDef = new PStruct();

            
                // Browse LoL directory and find .raf files
                List<RAFFileListEntry> fileList = new List<RAFFileListEntry>();
                String baseDir = rafPath;
                string[] files = Directory.GetFiles(baseDir, "*", SearchOption.AllDirectories);
                Directory.GetDirectories(baseDir);
                string[] array = files;
                int i = 0;
                List<String> rafFiles = new List<string>();
                //reportProgress(1);
                for (i = 0; i < array.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(array[i]);

                    if (fileInfo.Extension == ".raf")
                    {
                        if (File.Exists(fileInfo.FullName + ".dat"))
                        {
                            rafFiles.Add(fileInfo.FullName);//add raf files to read afterwards
                        }
                    }
                    //reportProgress((int)(((double)i * 10.0) / (double)array.Length) + 1);
                }
                //reportProgress(12);
                
                // Get file names out of .raf files
                i = 0;
                foreach (String file in rafFiles)
                {
                    i++;
                    FileInfo rafFile = new FileInfo(file);
                    //time to process the raf files
                    RAFArchive raf = new RAFArchive(rafFile.FullName);
                    fileList.AddRange(raf.GetDirectoryFile().GetFileList().GetFileEntries());
                    raf.GetDataFileContentStream().Close();
                    //reportProgress((int)(((double)i * 10.0) / (double)rafFiles.Count) + 12);
                }
                //reportProgress(25);

                // Create place for unreferenced troybins to live
                particleDef["other"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

                // Create place for item troybins to live
                particleDef["items"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

                // Create place for map troybins to live
                particleDef["map"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

                // Create place for summoner spell troybins to live
                particleDef["summoner spells"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

                List<String> champions = new List<String>();

                timer1.Start();

                // Search through DATA/Spells directory
                foreach (RAFFileListEntry file in fileList)
                {
                    i++;
                    //reportProgress((int)(((double)i / (double)fileList.Count) * (double)10.0) + 25);
                    // Only use spell files (exclude sub directories)
                    if (file.FileName.Contains("DATA/Spells") && !file.FileName.Contains("DATA/Spells/Icons2D") && !file.FileName.Contains("DATA/Spells/Textures"))
                    {
                        FileInfo fileInfo = new FileInfo(file.FileName);
                        if (fileInfo.Extension == ".luaobj" || fileInfo.Extension == ".inibin")
                        {
                            if (fileInfo.Extension == ".inibin")
                            {
                                ;
                            }
                            String shortFileName = file.FileName.Substring(file.FileName.LastIndexOf('/') + 1, file.FileName.Length - file.FileName.LastIndexOf('/') - 8);
                            String championName = String.Empty;

                            // Find index of second uppercase letter
                            int splitIndex = 0;
                            char[] charArray = shortFileName.ToCharArray();
                            for (int ii = 1; ii < charArray.Length; ii++)
                            {
                                if (char.IsUpper(charArray[ii]))
                                {
                                    splitIndex = ii;
                                    break;
                                }
                            }

                            if (splitIndex == 0)
                            {
                                championName = shortFileName.ToLower();
                            }
                            else
                            {
                                championName = shortFileName.Substring(0, splitIndex).ToLower();
                            }

                            switch (championName)
                            {
                                // Files to skip
                                case "200":
                                case "abpons":
                                case "a":
                                case "action":
                                    championName = "";
                                    break;
                                // Nunu
                                case "absolute":
                                    championName = "nunu";
                                    break;
                                // Items
                                case "abyssal":
                                case "aegisofthe":
                                    championName = "items";
                                    break;

                            }

                            
                            if (championName != "")
                            {
                                // Add to dictionary
                                if (!particleDef.ContainsKey(championName))
                                {
                                    particleDef[championName] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
                                }
                                

                                // Search luaobj's for .troy or .troybin
                                // Create a new archive
                                RAFArchive rafArchive = new RAFArchive(file.RAFArchive.RAFFilePath);

                                // Get the data from the archive
                                MemoryStream myInput = new MemoryStream(rafArchive.GetDirectoryFile().GetFileList().GetFileEntry(file.FileName).GetContent());
                                StreamReader reader = new StreamReader(myInput);
                                String result = reader.ReadToEnd();
                                reader.Close();
                                myInput.Close();
                                // Release the archive
                                rafArchive.GetDataFileContentStream().Close();

                                String cleanString = Regex.Replace(result, @"[^\u0000-\u007F]", "").Replace('\0', '?');
                                Regex captureFileNames = new Regex(@"([a-zA-z0-9\-_ ]+\.)(?:troy|troybin)", RegexOptions.IgnoreCase);
                                MatchCollection matches = captureFileNames.Matches(cleanString);
                                foreach (Match match in matches)
                                {
                                    // Get RAFFileListEntry for the troybin
                                    RAFFileListEntry troyEntry = null;
                                    String matchStr = match.Groups[1].ToString().ToLower() + "troybin";
                                    troyEntry = fileList.FirstOrDefault(m => m.FileName.ToLower().Contains(matchStr));

                                    if (troyEntry != null)
                                    {
                                        particleDef[championName][shortFileName] = new Dictionary<RAFFileListEntry, List<String>>();

                                        // Add to dictionary
                                        if (!particleDef[championName][shortFileName].ContainsKey(troyEntry))
                                        {
                                            particleDef[championName][shortFileName][troyEntry] = new List<String>();
                                        }

                                        // Search troybins for .dds, .sco, .scb, etc.
                                        // Create a new archive
                                        rafArchive = new RAFArchive(file.RAFArchive.RAFFilePath);

                                        // Get the data from the archive
                                        myInput = new MemoryStream(rafArchive.GetDirectoryFile().GetFileList().GetFileEntry(file.FileName).GetContent());
                                        reader = new StreamReader(myInput);
                                        result = reader.ReadToEnd();
                                        reader.Close();
                                        myInput.Close();
                                        // Release the archive
                                        rafArchive.GetDataFileContentStream().Close();

                                        cleanString = Regex.Replace(result, @"[^\u0000-\u007F]", "").Replace('\0', '?');
                                        captureFileNames = new Regex(@"([a-zA-z0-9\-_ ]+\.(?:tga|sco|scb|dds|png))", RegexOptions.IgnoreCase);
                                        MatchCollection troyMatches = captureFileNames.Matches(cleanString);
                                        foreach (Match particleMatch in troyMatches)
                                        {
                                            if (!particleDef[championName][shortFileName][troyEntry].Contains(particleMatch.Value))
                                            {
                                                particleDef[championName][shortFileName][troyEntry].Add(particleMatch.Value);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }

                timer1.Stop();

                // Creates a TextInfo based on the "en-US" culture.
                TextInfo usTxtInfo = new CultureInfo("en-US", false).TextInfo;

                TreeNode rootNode = new TreeNode("root");
                // Display particleDef for debugging purposes
                foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>> championKVP in particleDef)
                {
                    TreeNode champNode = rootNode.Nodes.Add(usTxtInfo.ToTitleCase(championKVP.Key));
                    foreach (KeyValuePair<String, Dictionary<RAFFileListEntry, List<String>>> abilityKVP in championKVP.Value)
                    {
                        TreeNode abilityNode = champNode.Nodes.Add(abilityKVP.Key);
                        foreach (KeyValuePair<RAFFileListEntry, List<String>> troybinKVP in abilityKVP.Value)
                        {
                            Match match = Regex.Match(troybinKVP.Key.FileName, "/(.+).troybin", RegexOptions.IgnoreCase);
                            TreeNode troybinNode = abilityNode.Nodes.Add(match.Groups[1].Value.Split('/')[1]);
                            foreach (String fileEntry in troybinKVP.Value)
                            {
                                troybinNode.Nodes.Add(fileEntry);
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(rootNode);
                treeView1.Sort();


            return particleDef;
        }

        private void findParticles_Click(object sender, EventArgs e)
        {
            getParticleStructure(lolDirectory + "\\RADS\\projects\\lol_game_client\\filearchives\\");
        }


    }
}
