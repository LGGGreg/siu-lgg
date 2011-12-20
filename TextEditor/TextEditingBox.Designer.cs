namespace TextEditor
{
    partial class TextEditingBox
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.TextDiscardButton = new System.Windows.Forms.Button();
            this.textAcceptButton = new System.Windows.Forms.Button();
            this.editTips_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(21, 22);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(754, 236);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // TextDiscardButton
            // 
            this.TextDiscardButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.TextDiscardButton.Location = new System.Drawing.Point(475, 270);
            this.TextDiscardButton.Name = "TextDiscardButton";
            this.TextDiscardButton.Size = new System.Drawing.Size(123, 37);
            this.TextDiscardButton.TabIndex = 1;
            this.TextDiscardButton.Text = "Discard Changes";
            this.TextDiscardButton.UseVisualStyleBackColor = true;
            // 
            // textAcceptButton
            // 
            this.textAcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.textAcceptButton.Location = new System.Drawing.Point(625, 270);
            this.textAcceptButton.Name = "textAcceptButton";
            this.textAcceptButton.Size = new System.Drawing.Size(123, 37);
            this.textAcceptButton.TabIndex = 2;
            this.textAcceptButton.Text = "Accept Changes";
            this.textAcceptButton.UseVisualStyleBackColor = true;
            // 
            // editTips_lbl
            // 
            this.editTips_lbl.AutoSize = true;
            this.editTips_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTips_lbl.ForeColor = System.Drawing.Color.Black;
            this.editTips_lbl.Location = new System.Drawing.Point(18, 268);
            this.editTips_lbl.Name = "editTips_lbl";
            this.editTips_lbl.Size = new System.Drawing.Size(431, 39);
            this.editTips_lbl.TabIndex = 3;
            this.editTips_lbl.Text = "Do not edit any of the tags. Ex: <titleLeft>\r\nAnything enclosed with @ are dynami" +
                "c values in-game. Use them how you \r\n    wish, but I can\'t guarantee them workin" +
                "g out of context.";
            // 
            // TextEditingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 319);
            this.Controls.Add(this.editTips_lbl);
            this.Controls.Add(this.textAcceptButton);
            this.Controls.Add(this.TextDiscardButton);
            this.Controls.Add(this.richTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TextEditingBox";
            this.Text = "Text Editing Box";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button TextDiscardButton;
        private System.Windows.Forms.Button textAcceptButton;
        private System.Windows.Forms.Label editTips_lbl;
    }
}