using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.Net;

namespace SIU_Publish
{
    public partial class PublishForm : Form
    {
        private string version = "";
        private string fileName = "";
        private string outDir = "";
        private string basePath = "";
        private string zipLocation = "";
        private string webURL = "";
        private string userName;
        public PublishForm()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        }

        private string password;
        private void button1Stop_Click(object sender, EventArgs e)
        {

            debugAdd("====Canceled Publish====");
            button1Stop.Enabled = false;
            button1Start.Enabled = true;
            if (workerCopyFiles.IsBusy)
                workerCopyFiles.CancelAsync();

            if (workerDeleteFiles.IsBusy)
                workerDeleteFiles.CancelAsync();

            if (workerCreateZip.IsBusy)
                workerCreateZip.CancelAsync();

            if (workerUpload.IsBusy)
                workerUpload.CancelAsync();

        }

        private void button1Start_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Pass = password=textBox1pass.Text;
            Properties.Settings.Default.Save();
            button1Stop.Enabled = true;
            button1Start.Enabled = false;
            label1Result.ForeColor = label1Done.ForeColor = label1StateCopyNew.ForeColor =
                label1stateDelete.ForeColor = label1StateUpload.ForeColor = Color.Red;
            label1StateCopyNew.ForeColor = Color.Yellow;
            debugAdd("====Started Publish====");
            workerCopyFiles.RunWorkerAsync();

        }

        private void PublishForm_Load(object sender, EventArgs e)
        {
            regenStart();
        }
        private void debugAdd(string s)
        {
            textBoxDebug.Text += s + "\r\n";
        }
        private void regenStart()
        {
            userName = textBox1user.Text;
            password = textBox1pass.Text = Properties.Settings.Default.Pass;
            textBox1Version.Text = version = Global_Info.SIUInfo.version;
            textBox2GeneratedFileName.Text = fileName = textBox1FileName.Text.Replace("[V]", textBox1Version.Text);
            FileInfo outFileInfo = new FileInfo(Application.StartupPath + textBox1Location.Text + fileName);
            textBox1OutDir.Text = outDir = outFileInfo.FullName+"\\";
            FileInfo outBaseInfo = new FileInfo(Application.StartupPath + textBox1Location.Text + textBox1LookFor.Text);
            basePath = outBaseInfo.FullName+"\\";
            FileInfo outZipInfo = new FileInfo(Application.StartupPath + textBox1zipLocation.Text);            
            zipLocation = outZipInfo.FullName+"";
            webURL = textBox1WebURL.Text="http://siu-lgg.googlecode.com/files/" + fileName.Replace(" ", "%20") + ".zip";
            debugAdd("====Generated Startup Info====");            
        }
        private void textBox1Location_TextChanged(object sender, EventArgs e)
        {
            regenStart();
        }
        private List<String> filesIWantToBeNew()
        {
            List<String> toReturn = new List<String>();
            toReturn.Add("fsb\\fsbext.exe");
            toReturn.Add("fsb\\map.bat");
            toReturn.Add("fsb\\reb.bat");
            toReturn.Add("fsb\\ext.bat");

            toReturn.Add("nvdxt.exe");
            toReturn.Add("nvddsinfo.exe");
            toReturn.Add("7-zip.dll");
            toReturn.Add("7z.dll");
            toReturn.Add("7z.exe");
            toReturn.Add("Be.Windows.Forms.HexBox.dll");
            toReturn.Add("ColorSlider.dll");
            toReturn.Add("DevIL.dll");
            toReturn.Add("Global Info.dll");
            toReturn.Add("ICSharpCode.SharpZipLib.dll");
            toReturn.Add("ILU.dll");
            toReturn.Add("Ionic.Zip.dll");
            toReturn.Add("LGGSIU1.bmp");
            toReturn.Add("LOLViewer.exe");
            toReturn.Add("LeagueOfLegendsSkinInstallerLeagueCraftIntegration.user.js");
            toReturn.Add("License - nvidia.txt");
            toReturn.Add("License - 7zip.txt");
            toReturn.Add("License - Be.HexBox.txt");
            toReturn.Add("License - ColorSlider.txt");
            toReturn.Add("License - Devil.txt");
            toReturn.Add("License - ICSharpCode.txt");
            toReturn.Add("License - Iconic Zip.txt");
            toReturn.Add("License - LoLViewer.txt");
            toReturn.Add("License - NantGoogleCode.txt");
            toReturn.Add("License - MessageForm.txt");
            toReturn.Add("License - OpenTK.txt");
            toReturn.Add("License - Skin Installer Ultimate.txt");
            toReturn.Add("License - SqLite.txt");
            toReturn.Add("License - Tao.txt");
            toReturn.Add("License - zlib.txt");
            toReturn.Add("MessageForm.dll");
            toReturn.Add("OpenTK.Compatibility.dll");
            toReturn.Add("OpenTK.GLControl.dll");
            toReturn.Add("OpenTK.dll");
            toReturn.Add("ParticleReferenceForSIU.exe");
            toReturn.Add("RAFLib.dll");
            toReturn.Add("RAF_Unpack_v1.00.exe");
            toReturn.Add("README Credits Info Instructions and License and change log.txt");
            toReturn.Add("SIU-Updater.exe");
            toReturn.Add("Skin Installer Ultimate.exe");
            toReturn.Add("Skin Installer Ultimate.exe.config");
            toReturn.Add("System.Data.SQLite.dll");
            toReturn.Add("Tao.DevIl.dll");
            toReturn.Add("TextEditor.exe");
            toReturn.Add("dxtVersion.ini");
            toReturn.Add("nocompress.txt");
            toReturn.Add("sai.exe");
            toReturn.Add("wLib.dll");
            toReturn.Add("zlib.net.dll");
            return toReturn;
        }
        #region completedWorkers
        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            int percentage = e.ProgressPercentage;
            if (percentage > 100) percentage = 100;
            if(percentage !=progressBar1.Value)
                progressBar1.Value = percentage;
            if ((string)e.UserState != "")
                debugAdd((String)e.UserState);
        }

        private void workerCopyFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                label1StateCopyNew.ForeColor = Color.LimeGreen;
            
                label1stateDelete.ForeColor = Color.Yellow;

                workerDeleteFiles.RunWorkerAsync();
            }
        }

        private void workerDeleteFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                label1stateDelete.ForeColor = Color.LimeGreen;
            
                label1CreateZip.ForeColor = Color.Yellow;
                workerCreateZip.RunWorkerAsync();
            }
        }

        private void workerCreateZip_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                label1CreateZip.ForeColor = Color.LimeGreen;
            
                label1StateUpload.ForeColor = Color.Yellow;
                workerUpload.RunWorkerAsync();
            }
        }

        private void workerUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1StateUpload.ForeColor = label1Done.ForeColor = Color.LimeGreen;
            //done
            button1Stop.Enabled = false;
            button1Start.Enabled = true;

            debugAdd("====Finished Publish====");

            button1TestWebURL_Click(sender, e);
        }
        #endregion
        #region workingWorkers
        private void workerDeleteFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            workerDeleteFiles.ReportProgress(0, "Starting Delete File State.");
            if (workerDeleteFiles.CancellationPending)
            {
                e.Result = false; return;
            }
            workerDeleteFiles.ReportProgress(100, "Done With Delete File State.");
            e.Result = true;

        }
        private void workerCopyFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            workerCopyFiles.ReportProgress(0, "Starting Copy File State.");
            if (Directory.Exists(outDir))
            {
                workerCopyFiles.ReportProgress(1, "Directory existed, deleting..");
                ForceDeleteDirectory(outDir);
            }
            Directory.CreateDirectory(outDir);
            Directory.CreateDirectory(outDir + "fsb");
            workerCopyFiles.ReportProgress(2, "Output Directory created.");


            workerCopyFiles.ReportProgress(2, "Looking for files in " + basePath);

            workerCopyFiles.ReportProgress(2, "To Copy to " + outDir);


            String[] files = Directory.GetFiles(basePath, "*.*", SearchOption.AllDirectories);
            //String programFile = files.FirstOrDefault(m => m.ToLower().Contains("skin installer ultimate.exe"));
            int i = 0;
            foreach (String file in files)
            {
                if (workerCopyFiles.CancellationPending)
                {
                    e.Result = false; return;
                }
                i++;
                int prog = ((int)(((float)i / (float)files.Length) * 58)) + 2;
                workerCopyFiles.ReportProgress(prog, "Copying Base File " + file);
                try
                {
                    //FileInfo fileToCopy = new FileInfo(file);
                    string dest = file.Replace(basePath, outDir);
                    File.Copy(file, dest, true);
                }
                catch (System.Exception ex)
                {
                    workerCopyFiles.ReportProgress(prog, "Error" + ex.ToString());
                }
            }

            workerCopyFiles.ReportProgress(60, "====Done Copying Base Files==== ");

            List<string> newFiles = filesIWantToBeNew();
            i = 0;
            foreach (string fileName in newFiles)
            {
                if (workerCopyFiles.CancellationPending)
                {
                    e.Result = false; return;
                }
                i++;
                int prog = ((int)(((float)i / (float)files.Length) * 40)) + 60;
                workerCopyFiles.ReportProgress(prog, "Copying New File " + fileName);
                try
                {
                    string fileSource = Application.StartupPath + "\\" + fileName;
                    //FileInfo fileToCopy = new FileInfo(file);
                    string dest = fileSource.Replace(Application.StartupPath, outDir);
                    File.Copy(fileSource, dest, true);
                }
                catch (System.Exception ex)
                {
                    workerCopyFiles.ReportProgress(prog, "Error" + ex.ToString());
                }

            }
            workerCopyFiles.ReportProgress(100, "Done With Copy File State.");
            if (workerCopyFiles.CancellationPending)
            {
                e.Result = false; return;
            }
            e.Result = true;
        }

        private void workerCreateZip_DoWork(object sender, DoWorkEventArgs e)
        {
            workerCreateZip.ReportProgress(0, "Starting Create Zip State.");
            string zipPathandName = zipLocation + fileName + ".zip";
            if (File.Exists(zipPathandName))
            {
                workerCreateZip.ReportProgress(1, "Zip already found, deleting.");
                File.Delete(zipPathandName);
            }
            bool success = ZipFiles(outDir, zipPathandName, "");
            if (workerCreateZip.CancellationPending || !success)
            {
                e.Result = false; return;
            }
            workerCreateZip.ReportProgress(100, "Done With Create Zip State.");

            e.Result = true;
        }

        private void workerUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            workerUpload.ReportProgress(0, "Starting Upload State.");
            NantGoogleCode.GoogleCodeUploadTask gut = new NantGoogleCode.GoogleCodeUploadTask();
            try
            {
                gut.FileName = zipLocation + fileName + ".zip";
                gut.ProjectName = "siu-lgg";
                gut.Password = password;
                gut.UserName = userName;
                gut.Summary = fileName;
                gut.TargetFileName = fileName + ".zip";

                gut.ExecuteTask();
            }
            catch (Exception ee)
            {
                workerUpload.ReportProgress(50, "Error:" + ee.ToString());
            }

            workerUpload.ReportProgress(100, "Done With Upload State.");
            if (workerUpload.CancellationPending)
            {
                e.Result = false; return;
            }
            e.Result = true;
        }

        #endregion
        #region helpers
        public static void ForceDeleteDirectory(string path)
        {
            DirectoryInfo root;
            Stack<DirectoryInfo> fols;
            DirectoryInfo fol;
            fols = new Stack<DirectoryInfo>();
            root = new DirectoryInfo(path);
            fols.Push(root);
            while (fols.Count > 0)
            {
                fol = fols.Pop();
                fol.Attributes = fol.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                foreach (DirectoryInfo d in fol.GetDirectories())
                {
                    fols.Push(d);
                }
                foreach (FileInfo f in fol.GetFiles())
                {
                    f.Attributes = f.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                    f.Delete();
                }
            }
            root.Delete(true);
        }

        private ArrayList GenerateFileList(string Dir)
        {
            ArrayList list = new ArrayList();
            bool flag = true;
            foreach (string str in Directory.GetFiles(Dir))
            {
                list.Add(str);
                flag = false;
            }
            if (flag && (Directory.GetDirectories(Dir).Length == 0))
            {
                list.Add(Dir + "/");
            }
            foreach (string str2 in Directory.GetDirectories(Dir))
            {
                foreach (object obj2 in GenerateFileList(str2))
                {
                    list.Add(obj2);
                }
            }
            workerCreateZip.ReportProgress(10, "Zip List Generated.");

            return list;
        }
        public bool ZipFiles(string inputFolderPath, string outputPathAndFile, string password)
        {
            ArrayList list = GenerateFileList(inputFolderPath);
            int count = Directory.GetParent(inputFolderPath).ToString().Length + 1;
            ZipOutputStream stream2 = new ZipOutputStream(File.Create(outputPathAndFile));
            if ((password != null) && (password != string.Empty))
            {
                stream2.Password = password;
            }
            stream2.SetLevel(9);
            int i = 0;
            foreach (string str2 in list)
            {
                int prog = ((int)(((float)i++ / (float)list.Count) * 85)) + 10;
                workerCreateZip.ReportProgress(prog, "Compressing " + str2);
                if (workerCreateZip.CancellationPending)
                {

                    stream2.Finish();
                    stream2.Close();
                    return false;
                    
                }
                ZipEntry entry = new ZipEntry(str2.Remove(0, count));
                stream2.PutNextEntry(entry);
                if (!str2.EndsWith("/"))
                {
                    FileStream stream = File.OpenRead(str2);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream2.Write(buffer, 0, buffer.Length);
                    stream.Close();
                }
            }
            stream2.Finish();
            stream2.Close();
            return true;
        }

        #endregion
        private void button1TestWebURL_Click(object sender, EventArgs e)
        {
            System.Net.WebClient client = new WebClient();
            string testDl = zipLocation + "test.zip";
            bool yes = false;
            try
            {
                client.DownloadFile(webURL, testDl);
                yes = true;
            }
            catch (System.Exception ex)
            {
                yes = false;
            }
            label1Result.ForeColor=yes?Color.LimeGreen:Color.Red;
            label1Result.Text = yes ? "URL Active!" : "URL Fails";
            if (yes)
            {
                Clipboard.SetText(webURL);
            }
            
        }
    }
}
