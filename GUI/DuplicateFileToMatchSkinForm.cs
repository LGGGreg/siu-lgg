using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SkinInstaller
{
    public partial class DuplicateFileToMatchSkinForm : Form
    {
        public List<String> filesToCopyLike = new List<String>();
        public FileInfo fileToCopy;
        public DirectoryInfo folderToCopyTo;
        private SkinInstaller.skinInstaller si;
        public DuplicateFileToMatchSkinForm(skinInstaller isi)
        {
            si = isi;
            InitializeComponent();
        }
        #region browse
        private void browseFilesToCopyLike_Click(object sender, EventArgs e)
        {
            if (openFileDialogFilesToCopyLike.ShowDialog() == DialogResult.OK)
            {
                textBoxFilesToCopyLike.Text = string.Join("|",openFileDialogFilesToCopyLike.FileNames);
            }                        
        }

        private void browseFileToCopy_Click(object sender, EventArgs e)
        {
            if (openFileDialogFileToCopy.ShowDialog() == DialogResult.OK)
            {
                textBoxFileToCopy.Text = openFileDialogFileToCopy.FileName;
            }
        }

        private void browseDirectoryToCopyTo_Click(object sender, EventArgs e)
        {
            if (folderBrowserDirectoryToCopyTo.ShowDialog() == DialogResult.OK)
            {
                textBoxDirectoryToCopyTo.Text = folderBrowserDirectoryToCopyTo.SelectedPath;
            }
        }
        #endregion browse
        private void buttonCopyFileToLikeFiles_Click(object sender, EventArgs e)
        {
            filesToCopyLike.Clear();
            filesToCopyLike.AddRange(textBoxFilesToCopyLike.Text.Split(new string[]{"|"},StringSplitOptions.RemoveEmptyEntries));
            fileToCopy = new FileInfo(textBoxFileToCopy.Text);
            folderToCopyTo = new DirectoryInfo(textBoxDirectoryToCopyTo.Text);
            backgroundWorkerCopyFilesLike.RunWorkerAsync();
        }

        private void backgroundWorkerCopyFilesLike_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, int> origonalInfo = commonOps.readDDSInfoNvidia(fileToCopy.FullName);
            int origFile_dxtv = origonalInfo["dxtv"];
            int origFile_width = origonalInfo["width"];
            int origFile_height = origonalInfo["height"];
            int origFile_mipMaps = origonalInfo["mipmap count"];
            int origFile_bitCount = origonalInfo["bit count"];
            long origFile_fileSize = fileToCopy.Length;
            int prog = 0;
            int len = filesToCopyLike.Count;
            foreach (String fileToCopyLike in filesToCopyLike)
            {
                prog++;
                int newProg = (int)Math.Floor(((double)prog / (double)len) * 99.99);
                backgroundWorkerCopyFilesLike.ReportProgress(newProg);

                FileInfo fileToCopyLikeInfo = new FileInfo(fileToCopyLike);

                Dictionary<string, int> copyLikeInfo = commonOps.readDDSInfoNvidia(fileToCopyLikeInfo.FullName);
                int copyLikeFile_dxtv = copyLikeInfo["dxtv"];
                int copyLikeFile_width = copyLikeInfo["width"];
                int copyLikeFile_height = copyLikeInfo["height"];
                int copyLikeFile_mipMaps = copyLikeInfo["mipmap count"];
                int copyLikeFile_bitCount = copyLikeInfo["bit count"];
                long copyLikeFile_fileSize = fileToCopyLikeInfo.Length;
                Bitmap bb = null;

                bb = si.LGGDevilLoadImage(fileToCopy.FullName);
                bb = commonOps.ResizeImage(bb, new System.Drawing.Size(copyLikeFile_width, copyLikeFile_height));
                string destination = folderToCopyTo.FullName + "\\" + fileToCopyLikeInfo.Name;
                si.LGGImageSave(bb, destination, copyLikeFile_dxtv, copyLikeFile_mipMaps, copyLikeFile_bitCount);
            }
        }

        private void backgroundWorkerCopyFilesLike_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int value = e.ProgressPercentage;
            if (value > this.progressBar1.Maximum) value = this.progressBar1.Maximum;
            this.progressBar1.Value = value;
            this.labelPercent.Text = ((value!=0)?value.ToString() + "%":"");
            this.progressBar1.Refresh();
        }
    }
}
