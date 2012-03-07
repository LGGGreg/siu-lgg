using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ItzWarty;

namespace RAFManager
{
    public partial class TextViewer : Form
    {
        /// <summary>
        /// Instantiates a TextViewer form which displays a string
        /// </summary>
        /// <param name="title">Title of the window</param>
        /// <param name="content">Content displayed</param>
        public TextViewer(string title, string content)
        {
            InitializeComponent();
            string[] lines = content.Split("\n");//Not sure what delim Riot uses. maybe crnl
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = i.ToString().PadLeft((lines.Length-1).ToString().Length) + "| " + lines[i];
            }

            this.Text = title;
            this.textBox1.Text = String.Join("\n", lines);
            this.textBox1.ReadOnly = true;

            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
        }
    }
}
