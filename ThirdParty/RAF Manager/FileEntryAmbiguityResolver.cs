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
    public partial class FileEntryAmbiguityResolver : Form
    {
        Object[] values = null;

        /// <summary>
        /// Opens a generic ambiguity resolver
        /// 
        /// It takes in values of any type and provides a selection box for them.
        /// </summary>
        public FileEntryAmbiguityResolver(Object[] values, string reason)
        {
            InitializeComponent();
            this.values = values;
            for (int i = 0; i < values.Length; i++)
                optionsListBox.Items.Add(values[i].ToString());

            doneButton.Enabled = false;
            optionsListBox.SelectedIndexChanged += new EventHandler(optionsListBox_SelectedIndexChanged);
            doneButton.Click += new EventHandler(doneButton_Click);
            cancelButton.Click += new EventHandler(cancelButton_Click);

            reasonLabel.Text = "Reason: " + reason;

            this.Resize += new EventHandler(FileEntryAmbiguityResolver_Resize);
            this.ResizeEnd += new EventHandler(FileEntryAmbiguityResolver_ResizeEnd);
        }

        /// <summary>
        /// When the cancel button is clicked, deselect the current entry and close the form
        /// We deselect because the SelectedItem field
        /// returns the selected item...
        /// </summary>
        void cancelButton_Click(object sender, EventArgs e)
        {
            this.optionsListBox.ClearSelected();
            this.Close();
        }

        /// <summary>
        /// Manages the GUI when the window is resized
        /// </summary>
        void FileEntryAmbiguityResolver_Resize(object sender, EventArgs e)
        {
            this.optionsListBox.Width = this.ClientSize.Width - this.optionsListBox.Left * 2;
            this.cancelButton.Left = this.optionsListBox.Right - this.cancelButton.Width;
            this.doneButton.Left = this.cancelButton.Left - this.doneButton.Width - 6;

            this.doneButton.Top = this.ClientSize.Height - this.doneButton.Height - 6;
            this.cancelButton.Top = this.ClientSize.Height - this.doneButton.Height - 6;

            this.optionsListBox.Height = this.ClientSize.Height - this.optionsListBox.Top - this.doneButton.Height - 12;
        }

        /// <summary>
        /// Updates the GUI when the window is resized
        /// </summary>
        void FileEntryAmbiguityResolver_ResizeEnd(object sender, EventArgs e)
        {
            FileEntryAmbiguityResolver_Resize(sender, e);
        }

        /// <summary>
        /// When an item is selected, enable the "Done" button
        /// </summary>
        void optionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            doneButton.Enabled = true;
        }
        
        /// <summary>
        /// When the done button is clicked, close the form
        /// </summary>
        void doneButton_Click(object sender, EventArgs e)
        {
            if (optionsListBox.SelectedIndex != -1)
                Close();
        }

        /// <summary>
        /// GET: Yields the currently selected item or null
        /// </summary>
        public Object SelectedItem
        {
            get
            {
                if (this.optionsListBox.SelectedIndex == -1) return null;
                else return values[this.optionsListBox.SelectedIndex];
            }
        }
    }
}
