using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RAFManager
{
    public partial class RAFPathSelector : Form
    {
        private static Size lastSize = Size.Empty;
        private static Point lastLocation = Point.Empty;
        /// <summary>
        /// Instantiated a new RAFPathSelector, which takes
        /// in a group of RAF In memory FSOs and allows the user to select
        /// a single node.
        /// </summary>
        /// <param name="nodes"></param>
        public RAFPathSelector(RAFInMemoryFileSystemObject[] nodes)
        {
            InitializeComponent();
            //Resizes layout and add handler for resizing
            ManageLayout();
            this.Resize += delegate(object s, EventArgs e){ ManageLayout(); };

            //Add event handler for form closing, to store last location
            this.FormClosing += new FormClosingEventHandler(TreeNodeSelector_FormClosing);

            //When a node is clicked, GUI is updated to show the path of the node
            this.treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseClick);

            //When we are loaded, we set our position
            this.Load += new EventHandler(TreeNodeSelector_Load);

            //Add the nodes we're supposed to view.
            treeView.Nodes.AddRange(nodes);
        }

        void TreeNodeSelector_Load(object sender, EventArgs e)
        {
            if (lastSize != Size.Empty) this.Size = lastSize;
            if (lastLocation != Point.Empty) this.Location = lastLocation;
        }

        /// <summary>
        /// When a node is clicked, update the selectedItemLabel's text
        /// </summary>
        void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.selectedItemLabel.Text = ((RAFInMemoryFileSystemObject)e.Node).GetRAFPath();
            this.selectedItemLabel.SelectionStart = this.selectedItemLabel.Text.Length;
        }

        /// <summary>
        /// When the form closes, store its location+size so upon opening again,
        /// we can place ourself there
        /// </summary>
        void TreeNodeSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastSize = this.Size;
            lastLocation = this.Location;
        }

        /// <summary>
        /// Manages the layout of this form
        /// </summary>
        private void ManageLayout()
        {
            bigContainer.SplitterDistance = this.ClientSize.Height - this.doneButton.Height;
            this.doneButton.Top = 0;
            this.doneButton.Left = this.bigContainer.Panel2.Width - this.doneButton.Width;
            this.selectedItemLabel.Left = 0;
            this.selectedItemLabel.Top = 0;
            this.selectedItemLabel.Width = this.ClientSize.Width - this.doneButton.Width;
            this.selectedItemLabel.ReadOnly = true;
        }

        /// <summary>
        /// GET - Gets the path of the selected node, including its RAFPath
        /// </summary>
        public string SelectedNodePath
        {
            get
            {
                if (this.treeView.SelectedNode != null)
                    return ((RAFInMemoryFileSystemObject)this.treeView.SelectedNode).GetRAFPath(true);
                else return null;
            }
        }

        /// <summary>
        /// When the done button is clicked, close
        /// </summary>
        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
