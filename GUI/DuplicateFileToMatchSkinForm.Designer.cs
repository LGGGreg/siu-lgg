namespace SkinInstaller
{
    partial class DuplicateFileToMatchSkinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateFileToMatchSkinForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseDirectoryToCopyTo = new System.Windows.Forms.Button();
            this.textBoxDirectoryToCopyTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.browseFileToCopy = new System.Windows.Forms.Button();
            this.textBoxFileToCopy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.browseFilesToCopyLike = new System.Windows.Forms.Button();
            this.textBoxFilesToCopyLike = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCopyFileToLikeFiles = new System.Windows.Forms.Button();
            this.folderBrowserDirectoryToCopyTo = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogFilesToCopyLike = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFileToCopy = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerCopyFilesLike = new System.ComponentModel.BackgroundWorker();
            this.labelPercent = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseDirectoryToCopyTo);
            this.groupBox1.Controls.Add(this.textBoxDirectoryToCopyTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.browseFileToCopy);
            this.groupBox1.Controls.Add(this.textBoxFileToCopy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.browseFilesToCopyLike);
            this.groupBox1.Controls.Add(this.textBoxFilesToCopyLike);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 381);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directories";
            // 
            // browseDirectoryToCopyTo
            // 
            this.browseDirectoryToCopyTo.Location = new System.Drawing.Point(506, 100);
            this.browseDirectoryToCopyTo.Name = "browseDirectoryToCopyTo";
            this.browseDirectoryToCopyTo.Size = new System.Drawing.Size(75, 23);
            this.browseDirectoryToCopyTo.TabIndex = 8;
            this.browseDirectoryToCopyTo.Text = "Browse";
            this.browseDirectoryToCopyTo.UseVisualStyleBackColor = true;
            this.browseDirectoryToCopyTo.Click += new System.EventHandler(this.browseDirectoryToCopyTo_Click);
            // 
            // textBoxDirectoryToCopyTo
            // 
            this.textBoxDirectoryToCopyTo.Location = new System.Drawing.Point(132, 103);
            this.textBoxDirectoryToCopyTo.Name = "textBoxDirectoryToCopyTo";
            this.textBoxDirectoryToCopyTo.Size = new System.Drawing.Size(363, 20);
            this.textBoxDirectoryToCopyTo.TabIndex = 7;
            this.textBoxDirectoryToCopyTo.Text = "C:\\Users\\LGG\\Desktop\\o";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Directory To Copy Too";
            // 
            // browseFileToCopy
            // 
            this.browseFileToCopy.Location = new System.Drawing.Point(506, 60);
            this.browseFileToCopy.Name = "browseFileToCopy";
            this.browseFileToCopy.Size = new System.Drawing.Size(75, 23);
            this.browseFileToCopy.TabIndex = 5;
            this.browseFileToCopy.Text = "Browse";
            this.browseFileToCopy.UseVisualStyleBackColor = true;
            this.browseFileToCopy.Click += new System.EventHandler(this.browseFileToCopy_Click);
            // 
            // textBoxFileToCopy
            // 
            this.textBoxFileToCopy.Location = new System.Drawing.Point(132, 63);
            this.textBoxFileToCopy.Name = "textBoxFileToCopy";
            this.textBoxFileToCopy.Size = new System.Drawing.Size(363, 20);
            this.textBoxFileToCopy.TabIndex = 4;
            this.textBoxFileToCopy.Text = "C:\\Users\\LGG\\Desktop\\Grid1.dds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File to Copy";
            // 
            // browseFilesToCopyLike
            // 
            this.browseFilesToCopyLike.Location = new System.Drawing.Point(506, 23);
            this.browseFilesToCopyLike.Name = "browseFilesToCopyLike";
            this.browseFilesToCopyLike.Size = new System.Drawing.Size(75, 23);
            this.browseFilesToCopyLike.TabIndex = 2;
            this.browseFilesToCopyLike.Text = "Browse";
            this.browseFilesToCopyLike.UseVisualStyleBackColor = true;
            this.browseFilesToCopyLike.Click += new System.EventHandler(this.browseFilesToCopyLike_Click);
            // 
            // textBoxFilesToCopyLike
            // 
            this.textBoxFilesToCopyLike.Location = new System.Drawing.Point(132, 26);
            this.textBoxFilesToCopyLike.Name = "textBoxFilesToCopyLike";
            this.textBoxFilesToCopyLike.Size = new System.Drawing.Size(363, 20);
            this.textBoxFilesToCopyLike.TabIndex = 1;
            this.textBoxFilesToCopyLike.Text = resources.GetString("textBoxFilesToCopyLike.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Files To Copy Like";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPercent);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.buttonCopyFileToLikeFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 100);
            this.panel1.TabIndex = 1;
            // 
            // buttonCopyFileToLikeFiles
            // 
            this.buttonCopyFileToLikeFiles.Location = new System.Drawing.Point(42, 38);
            this.buttonCopyFileToLikeFiles.Name = "buttonCopyFileToLikeFiles";
            this.buttonCopyFileToLikeFiles.Size = new System.Drawing.Size(201, 23);
            this.buttonCopyFileToLikeFiles.TabIndex = 0;
            this.buttonCopyFileToLikeFiles.Text = "Copy File to Like Files in New Directory";
            this.buttonCopyFileToLikeFiles.UseVisualStyleBackColor = true;
            this.buttonCopyFileToLikeFiles.Click += new System.EventHandler(this.buttonCopyFileToLikeFiles_Click);
            // 
            // openFileDialogFilesToCopyLike
            // 
            this.openFileDialogFilesToCopyLike.FileName = "openFileDialog1";
            this.openFileDialogFilesToCopyLike.Multiselect = true;
            // 
            // openFileDialogFileToCopy
            // 
            this.openFileDialogFileToCopy.FileName = "openFileDialog1";
            this.openFileDialogFileToCopy.Multiselect = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 77);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(587, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // backgroundWorkerCopyFilesLike
            // 
            this.backgroundWorkerCopyFilesLike.WorkerReportsProgress = true;
            this.backgroundWorkerCopyFilesLike.WorkerSupportsCancellation = true;
            this.backgroundWorkerCopyFilesLike.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCopyFilesLike_DoWork);
            this.backgroundWorkerCopyFilesLike.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCopyFilesLike_ProgressChanged);
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(15, 86);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(13, 13);
            this.labelPercent.TabIndex = 2;
            this.labelPercent.Text = "0";
            // 
            // DuplicateFileToMatchSkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DuplicateFileToMatchSkinForm";
            this.Text = "DuplicateFileToMatchSkinForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseDirectoryToCopyTo;
        private System.Windows.Forms.TextBox textBoxDirectoryToCopyTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browseFileToCopy;
        private System.Windows.Forms.TextBox textBoxFileToCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseFilesToCopyLike;
        private System.Windows.Forms.TextBox textBoxFilesToCopyLike;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCopyFileToLikeFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDirectoryToCopyTo;
        private System.Windows.Forms.OpenFileDialog openFileDialogFilesToCopyLike;
        private System.Windows.Forms.OpenFileDialog openFileDialogFileToCopy;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCopyFilesLike;
        private System.Windows.Forms.Label labelPercent;
    }
}