using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;


namespace SkinInstaller
{
    public partial class UpdateAvailiableForm1 : Form
    {
        public UpdateAvailiableForm1()
        {
            InitializeComponent();
        }
        private string downloadURL="";
        private skinInstaller parent=null;
        public void setData(string link, string info, Double version, Double myVersion)
        {
            
            textBox2updateurl.Text = downloadURL = link;
            textBox1updateinfo.Text = info;
            
            string[] changes = info.Split('\n');
            dataGridView1.Rows.Clear();
            Double latestChangeVersion = 0;
            foreach(string change in changes)
            {
                string [] parts = change.Split(':');
                int s = parts[0].IndexOf("(");
                int st = parts[0].IndexOf(")");
                if (s != -1 && st != -1)
                {
                    string parse = parts[0].Substring(s + 1, st - s-1);
                    Double changeVersion = double.Parse(parse, System.Globalization.NumberFormatInfo.InvariantInfo);
                    if (changeVersion > latestChangeVersion) latestChangeVersion = changeVersion;
                    bool installed = false;
                    if (changeVersion <= myVersion)
                    {
                        installed = true;
                    }
                    bool important = parts[1].Contains("*");                    
                    parts[1] = parts[1].Replace("*", "").Trim();
                    dataGridView1.Rows.Add(new object[] { installed, parts[1] });
                    DataGridViewCellStyle tempS = new DataGridViewCellStyle();
                    tempS.ForeColor=installed?Color.Green:Color.Red;
                    button2_autoUpdate.Enabled = !installed;
                    if(important)tempS.Font= new Font(this.dataGridView1.DefaultCellStyle.Font,FontStyle.Bold);
                    dataGridView1.Rows[dataGridView1.Rows.Count-2].DefaultCellStyle = tempS;
                    
                }
            }

            textBox1newVersio.Text = latestChangeVersion.ToString();
            textBox1currentVersion.Text = myVersion.ToString();
            if (myVersion <latestChangeVersion )
            {
                if(myVersion<version)
                    label1.Text = this.Text = "A New Update Is Availiable!";
                else label1.Text = this.Text = "Update Is Availiable! (Optional)";

                textBox1currentVersion.ForeColor = Color.Red;
                


            }
            else
            {
                textBox1currentVersion.ForeColor = Color.Green;
                label1.Text = this.Text = "You have the current version!";
            }
            this.dataGridView1.AllowUserToResizeRows = false;
        }
        private delegate DialogResult InvokeDelegate(skinInstaller _parent);
        public DialogResult CustShowDialog(skinInstaller _parent)
        {
            parent = _parent;
            InvokeDelegate d = new InvokeDelegate(CustShowDialog);
            object[] o = new object[] { _parent };
            if (parent.InvokeRequired)
            {
                return (DialogResult)_parent.Invoke(d, o);
            }
            return this.ShowDialog(_parent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox2updateurl.Text);
        }

        private void textBox2updateurl_MouseClick(object sender, MouseEventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cliver.Message.Inform("How to update this program manually!" +
                "\r\n\r\n1. Download the update from the link provided"+
                "\r\n2. Unzip the contents into a new folder"+
                "\r\n3. Close any open instances of this program"+
                "\r\n4. Copy all the files from the folder in step 2, into the directory of this program (the old version)"+
                "\r\n5. When it asks you to overwrite, say yes!"
                );
        }

        private void textBox1currentVersion_Enter(object sender, EventArgs e)
        {

            this.label1.Focus();
        }

        private void key(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void key(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void button4ignore_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ignoreUpdatesVersion = Double.Parse(textBox1newVersio.Text);
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void textBox2updateurl_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_autoUpdate_Click(object sender, EventArgs e)
        {
            this.progressBar1.Visible = true;
            this.button2_autoUpdate.Text = "Updating..please wait";
            int i = (int)new Random().Next(5);
            for (; i < 5; i++) this.button2_autoUpdate.Text += ".";
            if (!autoupdateWorker1.IsBusy)
               autoupdateWorker1.RunWorkerAsync();
        }

        private void button2allowAutoUpdate_Click(object sender, EventArgs e)
        {
            this.button2_autoUpdate.Enabled = !this.button2_autoUpdate.Enabled;
        }

        private void autoupdateWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Net.WebClient client = new WebClient();
            try
            {
                FileHandler SIFileOp = new FileHandler();
                    
                string dlDir = Application.StartupPath + "\\nextVersion\\";
                if (Directory.Exists(dlDir))
                {
                    SIFileOp.DirectoryDelete(dlDir, true);
                }
                Directory.CreateDirectory(dlDir);
                string unzipPath = dlDir + "unzipped\\";
                string zipFile = dlDir + "downloaded.zip";
                client.DownloadFile(downloadURL, zipFile);
                ZipUtil.UnZipFiles(zipFile, unzipPath, "", false);
                string[] files = Directory.GetFiles(unzipPath, "*.*", SearchOption.AllDirectories);
                string updaterFile = files.FirstOrDefault(m => m.ToLower() == "siu-updater.exe");
                //string updaterFile = unzipPath + "SIU-Updater.exe";
                if (File.Exists(updaterFile))
                {
                    //update updater first
                    SIFileOp.FileMove(updaterFile, Application.StartupPath + "\\SIU-Updater.exe");
                }


            }
            catch { }
        }

        private void autoupdateWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string updater = Application.StartupPath + "\\SIU-Updater.exe";
            if (File.Exists(updater))
            {
                Process.Start(updater);
                if (parent != null)
                    parent.Close();
            }

        }
    }
}
