namespace ParticleFinder
{
    partial class ParticleFinder
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
            this.components = new System.ComponentModel.Container();
            this.findParticles = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // findParticles
            // 
            this.findParticles.Location = new System.Drawing.Point(34, 25);
            this.findParticles.Name = "findParticles";
            this.findParticles.Size = new System.Drawing.Size(91, 32);
            this.findParticles.TabIndex = 0;
            this.findParticles.Text = "Find Particles";
            this.findParticles.UseVisualStyleBackColor = true;
            this.findParticles.Click += new System.EventHandler(this.findParticles_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(175, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(486, 32);
            this.progressBar1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(34, 89);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(626, 418);
            this.treeView1.TabIndex = 2;
            // 
            // ParticleFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 535);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.findParticles);
            this.Name = "ParticleFinder";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ParticleFinder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button findParticles;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Timer timer1;
    }
}

