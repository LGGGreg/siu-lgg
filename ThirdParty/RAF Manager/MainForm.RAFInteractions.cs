using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using System.Drawing;

using ItzWarty;

using RAFLib;

using System.IO;

namespace RAFManager
{
    partial class MainForm : Form
    {
        //Names of columns - For finding cells in rows
        private const string CN_USE = "shouldUseMod";
        private const string CN_LOCALPATH = "localPathColumn";
        private const string CN_LOCALPATHPICKER = "pickLocalPathColumn";
        private const string CN_RAFPATH = "rafPathColumn";
        private const string CN_RAFPATHPICKER = "pickRafPathColumn";

        /// <summary>
        /// Initializes the changes view - Sizes columns and sets an event handler for them to autosize
        /// </summary>
        private void InitializeChangesView()
        {
            UpdateChangesGUI();

            changesView.CellClick += new DataGridViewCellEventHandler(changesView_CellClick);
            changesView.CurrentCellChanged += new EventHandler(changesView_CurrentCellChanged);
            changesView.AllowDrop = true;
            changesView.DragOver += new DragEventHandler(changesView_DragOver);
            changesView.DragDrop += new DragEventHandler(changesView_DragDrop);
            changesView.RowsAdded += new DataGridViewRowsAddedEventHandler(changesView_RowsAdded);
            changesView.CurrentCellDirtyStateChanged += new EventHandler(changesView_CurrentCellDirtyStateChanged);

            rafContentView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(rafContentView_NodeMouseDoubleClick);
            rafContentView.AllowDrop = true;
            rafContentView.DragOver += new DragEventHandler(rafContentView_DragOver);

            this.Resize += delegate(object sender, EventArgs e) { UpdateChangesGUI(); };
        }

        /// <summary>
        /// When a cell is changed, commit the changes to the backend buffer
        /// so that saving doesn't read the previous value until we deselect the cell
        /// </summary>
        void changesView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (changesView.CurrentCell is DataGridViewCheckBoxCell)
            {
                //Commit cell changes to the back end data cache
                //This is so things using the save context is okay even if a cell is being edited
                //The current cell's state is saved.
                changesView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// When a row is added, add text to its select buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void changesView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < changesView.RowCount; i++)
            {
                changesView.Rows[i].Cells[CN_LOCALPATHPICKER].Value = "...";
                changesView.Rows[i].Cells[CN_RAFPATHPICKER].Value = "...";
            }
        }

        /// <summary>
        /// Event handler for when a DragDrop operation completed on top of the changesview
        /// </summary>
        void changesView_DragDrop(object sender, DragEventArgs e)
        {
            //Check if we have a file/list of filfes
            if (e.Data is DataObject && ((DataObject)e.Data).ContainsFileDropList())
            {
                DataObject dataObject = (DataObject)e.Data;
                StringCollection rootPaths = dataObject.GetFileDropList();

                //Iterate through all given files
                foreach(string rootPath in rootPaths)
                {
                    Console.WriteLine(rootPath);
                    //Get all files in path
                    string[] filePaths;

                    //If it's a directory, get a list of its files
                    FileAttributes atrib = File.GetAttributes(rootPath);
                    if ((atrib & FileAttributes.Directory)>0)
                        filePaths = Util.GetAllChildFiles(rootPath);//Directory.GetFiles(rootPath, "**", SearchOption.AllDirectories);
                    else //If it's a file, we have a list of 1 file
                        filePaths = new string[] { rootPath };

                    //Iterate through all files
                    for(int z = 0; z < filePaths.Length; z++)
                    {
                        SetTaskbarProgress(z * 100 / filePaths.Length);
                        string filePath = filePaths[z].Replace("\\", "/");
                        //Console.WriteLine(filePath);
                        int rowIndex = changesView.Rows.Add();

                        changesView.Rows[rowIndex].Cells[CN_LOCALPATH].Value = filePath;
                        changesView.Rows[rowIndex].Cells[CN_LOCALPATH].Tag = filePath;
                        //changesView.Rows[rowIndex].Cells[CN_LOCALPATH].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        //Split the path into pieces split by FSOs...  Search the RAF archives and see if we can link it to the raf path

                        string[] pathParts = filePath.Split("/");
                        RAFFileListEntry matchedEntry = null;
                        List<RAFFileListEntry> lastMatches = null;
                        bool done = false;

                        //Smart search insertion
                        for (int i = 1; i < pathParts.Length+1 && !done; i++)
                        {
                            string[] searchPathParts = pathParts.SubArray(pathParts.Length - i, i);
                            string searchPath = String.Join("/", searchPathParts);
                            Console.WriteLine(searchPath);
                            List<RAFFileListEntry> matches = new List<RAFFileListEntry>();
                            RAFArchive[] archives = rafArchives.Values.ToArray();
                            for (int j = 0; j < archives.Length; j++)
                            {
                                List<RAFFileListEntry> newmatches = archives[j].GetDirectoryFile().GetFileList().SearchFileEntries(searchPath);
                                matches.AddRange(newmatches);
                            }
                            if (matches.Count == 1)
                            {
                                matchedEntry = matches[0];
                                done = true;
                            }
                            else if (matches.Count == 0)
                            {
                                done = true;
                            }
                            else
                            {
                                lastMatches = matches;
                            }
                        }
                        if (matchedEntry == null)
                        {
                            if (lastMatches != null && lastMatches.Count > 0)
                            {
                                //Resolve ambiguity
                                FileEntryAmbiguityResolver ambiguityResolver = new FileEntryAmbiguityResolver(lastMatches.ToArray(), "!");
                                ambiguityResolver.ShowDialog();
                                RAFFileListEntry resolvedItem = (RAFFileListEntry)ambiguityResolver.SelectedItem;
                                if (resolvedItem != null)
                                {
                                    matchedEntry = resolvedItem;
                                }
                            }
                        }
                        if (matchedEntry != null) //If it's still not resolved
                        {
                            changesView.Rows[rowIndex].Cells[CN_RAFPATH].Value = matchedEntry.RAFArchive.GetID() + "/" + matchedEntry.FileName;
                            changesView.Rows[rowIndex].Cells[CN_RAFPATH].Tag = matchedEntry;
                        }
                        else
                        {
                            Log("Unable to link file '" + filePath + "' to RAF Archive.  Please manually select RAF path");
                        }
                    }
                }
                UpdateChangesGUI();
            }
            SetTaskbarProgress(0);
        }

        /// <summary>
        /// Event Handler for when a file is dragged over our ChangesView control
        /// </summary>
        void changesView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data is DataObject && ((DataObject)e.Data).ContainsFileDropList())
            {   //If we are dragging a file over, say that a copy operation is "rammus: ok"
                e.Effect = DragDropEffects.Copy;
                Application.DoEvents();
            }            
        }

        /// <summary>
        /// When a cell changes, we tell the project that it has been changed, so an asterisk
        /// is stuck next to the project name
        /// </summary>
        void changesView_CurrentCellChanged(object sender, EventArgs e)
        {
            HasProjectChanged = true;
            UpdateProjectGUI();
        }
        /// <summary>
        /// Sizes the columns in the modifications view
        /// </summary>
        private void UpdateChangesGUI()
        {
            changesView.Columns[0].Width = 50;
            changesView.Columns[1].Width = (changesView.Width - 110 - 20) / 2;
            changesView.Columns[2].Width = 30;
            changesView.Columns[3].Width = (changesView.Width - 110 - 20) / 2;
            changesView.Columns[4].Width = 30;
            changesView.ScrollBars = ScrollBars.Vertical;

            Graphics g = this.CreateGraphics();
            if (g != null)
            {
                //Measures the length of the cells so that we can fit our text into them
                for (int i = 0; i < changesView.Rows.Count-1; i++)
                {
                    DataGridViewCell localPathCell = changesView.Rows[i].Cells[CN_LOCALPATH];
                    localPathCell.Value = CutStringToWidth((string)localPathCell.Tag, (changesView.Width - 110 - 20) / 2 - 20, g, changesView.Font);

                    DataGridViewCell rafPathCell = changesView.Rows[i].Cells[CN_RAFPATH];
                    RAFFileListEntry entry = (RAFFileListEntry)rafPathCell.Tag;
                    if (entry == null)          //Will happen if we have a new row that hasn't had a RAF Path selected yet
                    {
                        rafPathCell.Value = "";
                    }
                    else
                    {
                        string displayedFullPath = entry.RAFArchive.GetID() + "/" + entry.FileName;
                        rafPathCell.Value = CutStringToWidth(displayedFullPath, (changesView.Width - 110 - 20) / 2 - 20, g, changesView.Font);
                    }
                }
                g.Dispose();
            }
        }

        /// <summary>
        /// Cuts the given string to the given width, cutting it so that its end always displays,
        /// while its start might be cut off and replaced with "..."
        /// </summary>
        private string CutStringToWidth(string s, int width, Graphics g, Font font)
        {
            if (s == null) return null;
            if (g.MeasureString(s, font).Width <= width) return s;

            string substring;
            for(int i = 0; i < s.Length; i++)
            {
                substring = s.Substring(i);
                if (g.MeasureString("..." + substring, font).Width < width) return "..."+substring;
            }
            return s;

        }

        /// <summary>
        /// When a cell is clicked on the changes view, finds out what was clicked and interacts appropriately
        /// IE: Opening file dialog for selecting a skin, or starting a raf file selection operation
        /// </summary>
        void changesView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //Column header was clicked.
            //if (e.RowIndex > 10000) return; //... No idea how else to detect clicking the column headers
            DataGridViewCell cell = changesView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataGridViewRow row = changesView.Rows[cell.RowIndex];

            if (cell.OwningColumn.Name == CN_RAFPATHPICKER)
            {
                string rafPath = PickRafPath();
                if (rafPath != "")
                {
                    Console.WriteLine(rafPath);
                    RAFFileListEntry entry = ResolveRAFPathToEntry(rafPath);
                    row.Cells[CN_RAFPATH].Value = entry.RAFArchive.GetID() + "/" + entry.FileName;
                    row.Cells[CN_RAFPATH].Tag = ResolveRAFPathToEntry(rafPath);
                    if (cell.RowIndex == changesView.Rows.Count - 1)
                    {
                        //Tell the view that the currently selected cell is "dirty", so it makes a
                        //new one under this one
                        changesView.NotifyCurrentCellDirty(true); //Gotta love these names...
                    }
                }
            }
            else if (cell.OwningColumn.Name == CN_LOCALPATHPICKER)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();

                if (ofd.FileName != "")
                {
                    row.Cells[CN_LOCALPATH].Value = ofd.FileName;
                    row.Cells[CN_LOCALPATH].Tag = ofd.FileName;
                    if (cell.RowIndex == changesView.Rows.Count - 1)
                    {
                        //Tell the view that the currently selected cell is "dirty", so it makes a
                        //new one under this one
                        changesView.NotifyCurrentCellDirty(true); //Gotta love these names...    
                    }
                }
            }
            UpdateChangesGUI();
        }

        /// <summary>
        /// When the RAF Content view has a dragover operation
        /// ???  Likely have an insert file operation, though
        /// I think this wouldn't be friendly to the user.
        /// 
        /// Dragging to the changesview is what the user wants more
        /// 
        /// Perhaps show a dialog if the user actually intends to
        /// add to the dragged over dialog
        /// </summary>
        void rafContentView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data is DataObject && ((DataObject)e.Data).ContainsFileDropList())
            {
                e.Effect = DragDropEffects.Copy;

                rafContentView.Select();
                TreeNode hoveredNode = rafContentView.GetNodeAt(rafContentView.PointToClient(new Point(e.X, e.Y)));
                rafContentView.SelectedNode = hoveredNode;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// When a RafContentView node is double clicked, extract and view its content
        /// </summary>
        void rafContentView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RAFInMemoryFileSystemObject node = (RAFInMemoryFileSystemObject)e.Node;
            string nodeInternalPath = node.GetRAFPath();
            if (node.GetFSOType() == RAFFSOType.FILE)
            {
                //We have double clicked a file... find out what file it was
                List<RAFFileListEntry> entries = this.rafArchives[node.GetTopmostParent().Name]
                    .GetDirectoryFile().GetFileList().GetFileEntries();

                //Find the RAF File entry that corresponds to the clicked file...
                RAFFileListEntry entry = entries.Where(
                    (Func<RAFFileListEntry, bool>)delegate(RAFFileListEntry theEntry)
                    {
                        return theEntry.FileName == nodeInternalPath;
                    }
                ).First();

                //Now select a viewer to use for the file.
                if (entry.FileName.ToLower().EndsWith("inibin") ||
                    entry.FileName.ToLower().EndsWith("troybin"))
                {
                    new TextViewer(this.baseTitle + " - inibin/troybin view - " + nodeInternalPath,
                        new InibinFile().main(entry.GetContent())
                    ).Show();
                }
                else if (entry.FileSize < 10000 || //If > 200, ask, then continue
                       MessageBox.Show("This file is quite large ({0} bytes).  Sure you want to read it?".F(entry.FileSize), "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (entry.GetContent().All(c => c >= ' ' && c <= '~') || 
                        entry.FileName.ToLower().EndsWith("cfg") ||
                        entry.FileName.ToLower().EndsWith("ini") ||
                        entry.FileName.ToLower().EndsWith("txt") ||
                        entry.FileName.ToLower().EndsWith("log") ||
                        entry.FileName.ToLower().EndsWith("list")
                    ) //All content is displayable text, likely
                    {
                        new TextViewer(this.baseTitle + " - Text View - " + nodeInternalPath,
                            Encoding.ASCII.GetString(entry.GetContent())
                        ).Show();
                    }
                    else //If all else fails, just use the binary viewer
                    {
                        new BinaryViewer(this.baseTitle + " - Binary View by Be.HexEditor http://sourceforge.net/projects/hexbox/- " + nodeInternalPath,
                            entry.GetContent()
                        ).Show();
                    }
                }
            }
        }
    }
}
