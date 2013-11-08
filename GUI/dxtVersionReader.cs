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
    public partial class dxtVersionReader : Form
    {
        private StringBuilder logb = new StringBuilder("");
        public dxtVersionReader()
        {
            InitializeComponent();
        }

        private void button1browsedds_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_ReadDDS_Click(object sender, EventArgs e)
        {
            btn_ReadDDS.Enabled = false;
            btn_ReadDDS.Text = "Reading DDS files";
            timer1.Start();
            ddsReaderWorker.RunWorkerAsync(new string[]{textBox2.Text,((int)0).ToString()});
        }
        

        private void ddsReaderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = (string[])e.Argument;
            string path = args[0];
            int start = int.Parse(args[1]);
            string[] files = Directory.GetFiles(path, "*.dds", SearchOption.AllDirectories);
            int numFiles = files.Length;
            int num = 0;
            int lastP = 0;
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);

                int dxt = commonOps.getDXTVersion(file);
                Size s = commonOps.getFileDimensions(file);
                              

                // progress stuffs
                int progress = (int)(Math.Floor(((double)(++num)) / ((double)(numFiles)) * 100.0));
                int rep = 0;
                if (lastP != progress)
                {
                    lastP=rep=progress;
                }
                string pathName = fi.FullName.Replace(path, "");
                ddsReaderWorker.ReportProgress(rep, "("+progress.ToString()+"%)"+num.ToString()+"/"+numFiles.ToString()+
                    ": Reading File: " + pathName + "===" + dxt.ToString() + "===" + s.Width.ToString() + "===" + s.Height.ToString());
            }

                
        }

        private void ddsReaderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //pdateProgressSafe(e.ProgressPercentage);
            if (e.UserState != null)
            {
                string info = e.UserState as string;
                //logb.Append(info + "\r\n");
               // (99%)5762/5763: Reading File: Akali_Circle_0.dds===DXT5
                string endPart = info.Substring(info.IndexOf("File:") + 6);
                string [] infos = endPart.Split(new string[1]{"==="},StringSplitOptions.RemoveEmptyEntries);
                //string name = endPart.Substring(0, endPart.IndexOf("==="));
                string name = infos[0];
                string dxt = infos[1];
                string width = infos[2];
                string height = infos[3];
                //string dxt=endPart.Substring(endPart.IndexOf("===")+3);
                logb.Append(name + "|" + dxt + "|" + width + "|" + height + "\r\n");
            }
            if (e.ProgressPercentage != 0)
            {
                this.toolStripProgressBar1.Value = e.ProgressPercentage;
            }

            
        }

        private void ddsReaderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_ReadDDS.Enabled = true;
            timer1.Stop();
            updateDisplay();
            btn_ReadDDS.Text = "Read DDS Versions";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateDisplay();
        }
        private void updateDisplay()
        {


            this.textBox1.Text = logb.ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
            textBox1.Refresh();
            this.toolStripProgressBar1.Increment(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(logb.Length>0)
            Clipboard.SetText(logb.ToString());
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            logb.Remove(0, logb.Length);
            updateDisplay();
        }
    }
}
