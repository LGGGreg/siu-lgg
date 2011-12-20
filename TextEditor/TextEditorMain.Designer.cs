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
            this.SuspendLayout();
            // 
            // textInstallButton
            // 
            this.textInstallButton.Location = new System.Drawing.Point(32, 29);
            this.textInstallButton.Name = "textInstallButton";
            this.textInstallButton.Size = new System.Drawing.Size(95, 36);
            this.textInstallButton.TabIndex = 0;
            this.textInstallButton.Text = "Install Text";
            this.textInstallButton.UseVisualStyleBackColor = true;
            this.textInstallButton.Click += new System.EventHandler(this.textInstallButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(298, 29);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(110, 36);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export Changes";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(32, 101);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(275, 425);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OrigNodeMouseDoubleClick);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(365, 101);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(275, 425);
            this.treeView2.TabIndex = 3;
            this.treeView2.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.EditedNodeMouseDoubleClick);
            // 
            // textUninstallButton
            // 
            this.textUninstallButton.Location = new System.Drawing.Point(165, 29);
            this.textUninstallButton.Name = "textUninstallButton";
            this.textUninstallButton.Size = new System.Drawing.Size(95, 36);
            this.textUninstallButton.TabIndex = 4;
            this.textUninstallButton.Text = "Uninstall Text";
            this.textUninstallButton.UseVisualStyleBackColor = true;
            this.textUninstallButton.Click += new System.EventHandler(this.textUninstallButton_Click);
            // 
            // importButton
            // 
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(446, 29);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(110, 36);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Import Changes";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // TextEditorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 553);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.textUninstallButton);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.textInstallButton);
            this.Name = "TextEditorMain";
            this.Text = "Text Editor";
            this.Load += new System.EventHandler(this.TextEditorMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button textInstallButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button textUninstallButton;
        private System.Windows.Forms.Button importButton;
    }
}

