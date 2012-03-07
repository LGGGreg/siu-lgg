namespace RAFManager
{
    partial class RAFPathSelector
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.bigContainer = new System.Windows.Forms.SplitContainer();
            this.selectedItemLabel = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bigContainer)).BeginInit();
            this.bigContainer.Panel1.SuspendLayout();
            this.bigContainer.Panel2.SuspendLayout();
            this.bigContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(436, 331);
            this.treeView.TabIndex = 0;
            // 
            // bigContainer
            // 
            this.bigContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigContainer.Location = new System.Drawing.Point(0, 0);
            this.bigContainer.Name = "bigContainer";
            this.bigContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // bigContainer.Panel1
            // 
            this.bigContainer.Panel1.Controls.Add(this.treeView);
            // 
            // bigContainer.Panel2
            // 
            this.bigContainer.Panel2.Controls.Add(this.selectedItemLabel);
            this.bigContainer.Panel2.Controls.Add(this.doneButton);
            this.bigContainer.Size = new System.Drawing.Size(436, 362);
            this.bigContainer.SplitterDistance = 331;
            this.bigContainer.TabIndex = 1;
            // 
            // selectedItemLabel
            // 
            this.selectedItemLabel.Location = new System.Drawing.Point(0, 4);
            this.selectedItemLabel.Name = "selectedItemLabel";
            this.selectedItemLabel.Size = new System.Drawing.Size(374, 22);
            this.selectedItemLabel.TabIndex = 1;
            this.selectedItemLabel.Text = "Select a node, then click \"Done\" ->";
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(372, 4);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(64, 23);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // RAFPathSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 362);
            this.Controls.Add(this.bigContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RAFPathSelector";
            this.Text = "RAF Archived File Path Selector";
            this.bigContainer.Panel1.ResumeLayout(false);
            this.bigContainer.Panel2.ResumeLayout(false);
            this.bigContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bigContainer)).EndInit();
            this.bigContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.SplitContainer bigContainer;
        private System.Windows.Forms.TextBox selectedItemLabel;
        private System.Windows.Forms.Button doneButton;
    }
}