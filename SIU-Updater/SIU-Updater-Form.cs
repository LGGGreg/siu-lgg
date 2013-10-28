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
using System.Diagnostics;

namespace SIU_Updater
{
    public partial class SIUUpdaterForm : Form
    {
        public SIUUpdaterForm()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        }
        public void debugadd(string what)
        {
            this.textBox1.Text +=what+ "\r\n";
        }
        public bool waitTillSIUClosed()
        {
            //MessageBox.Show("Waitng on\r\n" + Application.StartupPath +"\\skin installer ultimate.exe");
            debugadd("Waiting for siu to close");
            bool siuIsRunning = true;
            FileInfo f = new FileInfo(Application.StartupPath + "\\skin installer ultimate.exe");

            FileInfo f2 = new FileInfo(Application.StartupPath + "\\Skin Installer Ultimate.exe");

            while(siuIsRunning)
            {
                if (waitForSIUTOCLoseWorker1.CancellationPending)
                    return false;
                siuIsRunning = IsFileLocked(f)||IsFileLocked(f2);
            }
            return true;
            
        }
        protected virtual bool IsFileLocked(FileInfo file)
        {
            if (!File.Exists(file.FullName)) return false;
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }


        private void SIUUpdaterForm_Load(object sender, EventArgs e)
        {
            waitForSIUTOCLoseWorker1.RunWorkerAsync();
            timer1.Start();
        }

        private void waitForSIUTOCLoseWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (waitTillSIUClosed() == false)
            {
                debugadd("Error, unable to get access to program , please close it");
                return;
            }
            //SkinInstaller.FileHandler SIFileOp = new SkinInstaller.FileHandler();
            string dlDir = Application.StartupPath + "\\nextVersion\\";
            if (!Directory.Exists(dlDir))
            {
                debugadd("Error, no dl dir found at " + dlDir);
                return;
            }

            string unzipPath = dlDir + "unzipped\\";
            if (!Directory.Exists(unzipPath))
            {
                debugadd("Error, no unzippath found at " + unzipPath);
                return;
            }
            String[] files = Directory.GetFiles(unzipPath, "*.*", SearchOption.AllDirectories);
            String programFile = files.FirstOrDefault(m => m.ToLower().Contains("skin installer ultimate.exe"));
            if (programFile == null)
            {
                debugadd("unable to find siu program to get dir from");
                return;
            }
            FileInfo programFileInfo = new FileInfo(programFile);
            debugadd("Found program to run at " + programFile);
            foreach (string file in files)
            {
                debugadd("Working on file " + file);
                if (file.ToLower().Contains("siu-updater.exe"))
                {
                    debugadd("Found our updater, skipping @" + file);
                }
                else
                {
                    try
                    {
                        string destination = file.Replace(programFileInfo.Directory.FullName, Application.StartupPath);
                        debugadd("Installing file " + file + " to " + destination);
                    
                        bool toy = true;
                        FileInfo thisFile = new FileInfo(destination);
                        if (IsFileLocked(thisFile)) debugadd("Waiting on file use for " + destination);
                        while (IsFileLocked(thisFile)) { toy=!toy;}
                        File.Copy(file, destination,true);
                        debugadd("Success");
                    }
                    catch (System.Exception ex)
                    {
                        debugadd("Failed with " + ex.ToString());
                    }
                }
            }
            //done copying files, delete, start
            //SIFileOp.DirectoryDelete(dlDir, true);
            ForceDeleteDirectory(dlDir);
            e.Result = programFile;            
        }
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

        private void waitForSIUTOCLoseWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            using (StreamWriter outfile =
            new StreamWriter(Application.StartupPath + @"\UpdateLog.txt"))
            {
                outfile.Write(textBox1.Text);
            }

            if (e.Result != null)
            {
                //string prog = (string)e.Result;

                Process.Start(Application.StartupPath+"\\Skin Installer Ultimate.exe");
            }
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (waitForSIUTOCLoseWorker1.IsBusy)
            {
                waitForSIUTOCLoseWorker1.CancelAsync();
            }
        }
    }
}
