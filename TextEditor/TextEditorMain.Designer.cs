namespace TextEditor
{
    partial class TextEditorMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textInstallButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.textUninstallButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.filter_txt = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.editedTextClearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textInstallButton
            // 
            this.textInstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textInstallButton.Location = new System.Drawing.Point(481, 3);
            this.textInstallButton.Name = "textInstallButton";
            this.textInstallButton.Size = new System.Drawing.Size(95, 36);
            this.textInstallButton.TabIndex = 0;
            this.textInstallButton.Text = "Install Text";
            this.textInstallButton.UseVisualStyleBackColor = true;
            this.textInstallButton.Visible = false;
            this.textInstallButton.Click += new System.EventHandler(this.textInstallButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(3, 4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(110, 36);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export Changes";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(337, 485);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OrigNodeMouseDoubleClick);
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Location = new System.Drawing.Point(0, 23);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(328, 485);
            this.treeView2.TabIndex = 3;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.treeView2.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.EditedNodeMouseDoubleClick);
            // 
            // textUninstallButton
            // 
            this.textUninstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textUninstallButton.Location = new System.Drawing.Point(579, 4);
            this.textUninstallButton.Name = "textUninstallButton";
            this.textUninstallButton.Size = new System.Drawing.Size(95, 36);
            this.textUninstallButton.TabIndex = 4;
            this.textUninstallButton.Text = "Uninstall Text";
            this.textUninstallButton.UseVisualStyleBackColor = true;
            this.textUninstallButton.Visible = false;
            this.textUninstallButton.Click += new System.EventHandler(this.textUninstallButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(119, 4);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(110, 36);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Import Changes";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // filter_txt
            // 
            this.filter_txt.Location = new System.Drawing.Point(242, 13);
            this.filter_txt.Name = "filter_txt";
            this.filter_txt.Size = new System.Drawing.Size(124, 20);
            this.filter_txt.TabIndex = 6;
            this.filter_txt.TextChanged += new System.EventHandler(this.filter_txt_TextChanged);
            this.filter_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filter_txt_KeyDown);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(368, 13);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(56, 20);
            this.filterButton.TabIndex = 7;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // editedTextClearButton
            // 
            this.editedTextClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editedTextClearButton.Location = new System.Drawing.Point(234, 0);
            this.editedTextClearButton.Name = "editedTextClearButton";
            this.editedTextClearButton.Size = new System.Drawing.Size(91, 23);
            this.editedTextClearButton.TabIndex = 8;
            this.editedTextClearButton.Text = "Clear changes";
            this.editedTextClearButton.UseVisualStyleBackColor = true;
            this.editedTextClearButton.Click += new System.EventHandler(this.editedTextClearButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textInstallButton);
            this.panel1.Controls.Add(this.importButton);
            this.panel1.Controls.Add(this.filterButton);
            this.panel1.Controls.Add(this.exportButton);
            this.panel1.Controls.Add(this.filter_txt);
            this.panel1.Controls.Add(this.textUninstallButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 43);
            this.panel1.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(673, 510);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(337, 23);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.editedTextClearButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 23);
            this.panel2.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "customText.txt";
            // 
            // TextEditorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "TextEditorMain";
            this.Text = "Text Editor";
            this.Load += new System.EventHandler(this.TextEditorMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button textInstallButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button textUninstallButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox filter_txt;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button editedTextClearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

