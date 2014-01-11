using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RelManLib
{
    public partial class ReleaseManifestEntryForm : Form
    {
        public ReleaseManifestEntryForm(RelFileEntry entry)
        {
            InitializeComponent();
            if (entry != null)
            {
                try
                {
                    this.Text = "Release Manifest Entry - "+entry.name.ToString(); 
                    this.textBox1namr.Text = entry.name.ToString();
                    this.textBox1folder.Text = entry.folder.getFullPath();
                    this.textBox2fullpath.Text = entry.getPathAndName();
                    this.textBox3version.Text = entry.version.ToString();
                    this.textBox4filesize.Text = entry.uncompressedFileSize.ToString();
                    this.textBox5compressedfilesize.Text = entry.compressedFileSize.ToString();
                    this.textBox6checksum.Text = entry.checkSum.ToString();
                    this.textBox7fileindex.Text = entry.fileIndex.ToString();
                    this.textBox8nameindex.Text = entry.nameIndex.ToString();
                    this.textBox9unknownA.Text = entry.unknownA.ToString();
                    this.textBox10unknownC.Text = entry.unknownC.ToString();
                    this.textBox11unknownD.Text = entry.unknownD.ToString();
                }
                catch (System.Exception ex)
                {
                	
                }

            }
            //entry.
        }
    }
}
