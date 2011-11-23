namespace SkinInstaller
{
    partial class ParticleReference
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.particleReaderWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(35, 65);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(704, 682);
            this.textBox.TabIndex = 1;
            this.textBox.Text = "";
            // 
            // particleReaderWorker
            // 
            this.particleReaderWorker.WorkerReportsProgress = true;
            this.particleReaderWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.particleReaderWorker_DoWork);
            this.particleReaderWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.particleReaderWorker_ProgressChanged);
            this.particleReaderWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.particleReaderWorker_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(102, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(528, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // ParticleReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 792);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button1);
            this.Name = "ParticleReference";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ParticleReference_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textBox;
        private System.ComponentModel.BackgroundWorker particleReaderWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

