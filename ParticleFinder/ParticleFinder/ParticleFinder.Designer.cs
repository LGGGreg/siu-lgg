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
            this.findParticles = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ParticleReferenceWorker = new System.ComponentModel.BackgroundWorker();
            this.progress_lbl = new System.Windows.Forms.Label();
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
            this.progressBar1.Location = new System.Drawing.Point(174, 25);
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
            // ParticleReferenceWorker
            // 
            this.ParticleReferenceWorker.WorkerReportsProgress = true;
            this.ParticleReferenceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ParticleReferenceWorker_DoWork);
            this.ParticleReferenceWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ParticleReferenceWorker_ProgressChanged);
            this.ParticleReferenceWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ParticleReferenceWorker_RunWorkerCompleted);
            // 
            // progress_lbl
            // 
            this.progress_lbl.AutoSize = true;
            this.progress_lbl.Location = new System.Drawing.Point(408, 35);
            this.progress_lbl.Name = "progress_lbl";
            this.progress_lbl.Size = new System.Drawing.Size(19, 13);
            this.progress_lbl.TabIndex = 3;
            this.progress_lbl.Text = "00";
            // 
            // ParticleFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 535);
            this.Controls.Add(this.progress_lbl);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.findParticles);
            this.Name = "ParticleFinder";
            this.Text = "Particle Finder";
            this.Load += new System.EventHandler(this.ParticleFinder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findParticles;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TreeView treeView1;
        private System.ComponentModel.BackgroundWorker ParticleReferenceWorker;
        private System.Windows.Forms.Label progress_lbl;
    }
}

