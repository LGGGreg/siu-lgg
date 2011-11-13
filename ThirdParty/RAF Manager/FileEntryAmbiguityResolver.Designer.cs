namespace RAFManager
{
    partial class FileEntryAmbiguityResolver
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
            this.optionsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.doneButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // optionsListBox
            // 
            this.optionsListBox.FormattingEnabled = true;
            this.optionsListBox.ItemHeight = 16;
            this.optionsListBox.Location = new System.Drawing.Point(12, 67);
            this.optionsListBox.Name = "optionsListBox";
            this.optionsListBox.Size = new System.Drawing.Size(628, 164);
            this.optionsListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "RAFManager cannot resolve a certain ambiguity.\r\nSelect an appropriate option belo" +
                "w or click cancel to abort this operation.";
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(12, 43);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(65, 17);
            this.reasonLabel.TabIndex = 2;
            this.reasonLabel.Text = "Reason: ";
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(484, 237);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 3;
            this.doneButton.Text = "Done!";
            this.doneButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(565, 237);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // FileEntryAmbiguityResolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 266);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optionsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FileEntryAmbiguityResolver";
            this.Text = "Resolve File Ambiguity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox optionsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button cancelButton;
    }
}