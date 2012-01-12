namespace SkinInstaller
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FileLocForm : Form
    {
        private Label badFileName;
        private IContainer components;
        private ComboBox possibleLocs;
        public string fileLoc = string.Empty;
        private Label label1;
        private Button ok;
        private Label origLoc;
        private Label text1;
        private Panel panel1;
        private Panel panel2;
        private Label text2;

        public FileLocForm(skinInstaller siparent)
        {
            this.InitializeComponent();
            this.badFileName.Text = siparent.FileName;
            this.origLoc.Text = siparent.FileLoc;
            for (int i = 0; i < (siparent.FilePossibles.Length); i++)
            {
                if (siparent.FilePossibles[i] != null)
                {
                    this.possibleLocs.Items.Add(siparent.FilePossibles[i]);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FileLocForm_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();            
            this.possibleLocs = new System.Windows.Forms.ComboBox();
            this.badFileName = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.text1 = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.origLoc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // possibleLocs
            // 
            this.possibleLocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.possibleLocs.FormattingEnabled = true;
            this.possibleLocs.Location = new System.Drawing.Point(0, 98);
            this.possibleLocs.Name = "possibleLocs";
            this.possibleLocs.Size = new System.Drawing.Size(686, 21);
            this.possibleLocs.TabIndex = 0;
            // 
            // badFileName
            // 
            this.badFileName.AutoSize = true;
            this.badFileName.Location = new System.Drawing.Point(3, 20);
            this.badFileName.Name = "badFileName";
            this.badFileName.Size = new System.Drawing.Size(35, 13);
            this.badFileName.TabIndex = 1;
            this.badFileName.Text = "label1";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(335, 9);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(3, 7);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(224, 13);
            this.text1.TabIndex = 3;
            this.text1.Text = "The following file was found in multiple folders:";
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Location = new System.Drawing.Point(3, 74);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(222, 13);
            this.text2.TabIndex = 4;
            this.text2.Text = "Please specify the correct location for this file:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Original location was:";
            // 
            // origLoc
            // 
            this.origLoc.AutoSize = true;
            this.origLoc.Location = new System.Drawing.Point(3, 52);
            this.origLoc.Name = "origLoc";
            this.origLoc.Size = new System.Drawing.Size(35, 13);
            this.origLoc.TabIndex = 6;
            this.origLoc.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.origLoc);
            this.panel1.Controls.Add(this.badFileName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.text1);
            this.panel1.Controls.Add(this.text2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 98);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 35);
            this.panel2.TabIndex = 8;
            // 
            // FileLocForm
            // 
            this.ClientSize = new System.Drawing.Size(686, 173);
            this.Controls.Add(this.possibleLocs);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FileLocForm";
            this.Text = "Select File Location";
            this.Load += new System.EventHandler(this.FileLocForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (this.possibleLocs.Text != string.Empty)
            {
                this.fileLoc = this.possibleLocs.Text;
            }
            base.Hide();
        }
    }
}

