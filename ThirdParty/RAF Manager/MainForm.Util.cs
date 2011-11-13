using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using RAFLib;

namespace RAFManager
{
    partial class MainForm:Form
    {
        private string baseTitle = null;

        public void InitializeUtil()
        {
            this.baseTitle = this.Text;
        }
        /// <summary>
        /// Sets the title of our form
        /// </summary>
        /// <param name="s"></param>
        private void Title(string s) { this.Text = baseTitle + " - " + s; Application.DoEvents(); }

        /// <summary>
        /// Allows the user to pick a RAF file from the rafContentView control...
        /// 
        /// TODO: 5 second timer for stopping
        /// TODO: This needs to be made better.  it's pretty annoying to work with on the user-viewpoint
        /// </summary>
        /// <returns></returns>
        private string PickRafPath()
        {
            RAFInMemoryFileSystemObject[] nodes = new RAFInMemoryFileSystemObject[this.rafContentView.Nodes.Count];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = (RAFInMemoryFileSystemObject)this.rafContentView.Nodes[i].Clone();
            RAFPathSelector selectorDialog = new RAFPathSelector(nodes);
            selectorDialog.ShowDialog();
            return selectorDialog.SelectedNodePath;
        }
        /// <summary>
        /// In this case, rafpack includes the preceeding 0.0.0.xx/
        /// </summary>
        /// <param name="rafPath"></param>
        /// <returns></returns>
        private RAFFileListEntry ResolveRAFPathToEntry(string rafPath)
        {
            int firstSlash = rafPath.IndexOf("/");
            string archiveId = rafPath.Substring(0, firstSlash);  //Get everything before first slash
            string internalPath = rafPath.Substring(firstSlash + 1); //Get everything after first slash

            foreach (RAFArchive archive in rafArchives.Values)
            {
                if (archive.GetID() == archiveId)
                {
                    return archive.GetDirectoryFile().GetFileList().GetFileEntry(internalPath);
                }
            }
            return null;
        }
    }
}
