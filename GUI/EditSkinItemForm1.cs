using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkinInstaller
{
    public partial class EditSkinItemForm1 : Form
    {
        private skinInstaller p;
        private string SkinPath;
        public EditSkinItemForm1(skinInstaller you, string skinName, string skinAuthor, string numFiles,
            bool skinInstalled, string skinInfo, string imageName, DateTime added, DateTime installed)
        {
            p = you;
            InitializeComponent();
            if (imageName != "")
            {
                Bitmap m_bit = you.LGGDevilLoadImage(imageName);
                if (m_bit != null)
                {
                    pictureBox1.Image = m_bit;
                }
            }
            if (installed.Ticks == 0) installed = DateTime.Now;
            if (added.Ticks == 0) added = DateTime.Now;
            this.dateTimePicker1added.Value = added;
            this.dateTimePicker1installed.Value = installed;
            this.Text = "Edit Skin Information: " + skinName; ;
            this.SkinPath = imageName;
            this.textBox2name.Text = skinName;
            this.textBox1author.Text= skinAuthor;
            this.textBox1info.Text = skinInfo;
            this.textBox3filecount.Text = numFiles.ToString();
            this.comboBox1installed.SelectedIndex = skinInstalled ? 0 : 1;
            updateDateEnabled();
            
        }

        private void button1save_Click(object sender, EventArgs e)
        {
            //save!
            p.saveNewInfo(this.textBox2name.Text, this.textBox1author.Text,
                (this.comboBox1installed.SelectedIndex == 0),
                this.textBox1info.Text, this.SkinPath,
                this.dateTimePicker1added.Value,this.dateTimePicker1installed.Value);
            this.Close();

            
        }

        private void button1close_Click(object sender, EventArgs e)
        {
            //close
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "All Image Files(*.BMP;*.CUT;*.DCX;*.DDS;*.ICO;*.GIF;*.JPG;*.LBM;*.LIF;*.MDL;*.PCD;*.PCX;*.PIC;*.PNG;*.PNM;*.PSD;*.PSP;*.RAW;*.SGI;*.TGA;*.TIF;*.WAL;*.ACT;*.PAL;)|*.BMP;*.CUT;*.DCX;*.DDS;*.ICO;*.GIF;*.JPG;*.LBM;*.LIF;*.MDL;*.PCD;*.PCX;*.PIC;*.PNG;*.PNM;*.PSD;*.PSP;*.RAW;*.SGI;*.TGA;*.TIF;*.WAL;*.ACT;*.PAL|All files (*.*)|*.*";
            ofd.Filter += "|BMP files (*.BMP)|*.BMP";
            ofd.Filter += "|CUT files (*.CUT)|*.CUT";
            ofd.Filter += "|DCX files (*.DCX)|*.DCX";
            ofd.Filter += "|DDS files (*.DDS)|*.DDS";
            ofd.Filter += "|ICO files (*.ICO)|*.ICO";
            ofd.Filter += "|GIF files (*.GIF)|*.GIF";
            ofd.Filter += "|JPG files (*.JPG)|*.JPG";
            ofd.Filter += "|LBM files (*.LBM)|*.LBM";
            ofd.Filter += "|LIF files (*.LIF)|*.LIF";
            ofd.Filter += "|MDL files (*.MDL)|*.MDL";
            ofd.Filter += "|PCD files (*.PCD)|*.PCD";
            ofd.Filter += "|PCX files (*.PCX)|*.PCX";
            ofd.Filter += "|PIC files (*.PIC)|*.PIC";
            ofd.Filter += "|PNG files (*.PNG)|*.PNG";
            ofd.Filter += "|PNM files (*.PNM)|*.PNM";
            ofd.Filter += "|PSD files (*.PSD)|*.PSD";
            ofd.Filter += "|PSP files (*.PSP)|*.PSP";
            ofd.Filter += "|RAW files (*.RAW)|*.RAW";
            ofd.Filter += "|SGI files (*.SGI)|*.SGI";
            ofd.Filter += "|TGA files (*.TGA)|*.TGA";
            ofd.Filter += "|TIF files (*.TIF)|*.TIF";
            ofd.Filter += "|WAL files (*.WAL)|*.WAL";
            ofd.Filter += "|ACT files (*.ACT)|*.ACT";
            ofd.Filter += "|PAL files (*.PAL)|*.PAL";
            ofd.Filter += "|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap m_bmp = p.LGGDevilLoadImage(ofd.FileName);
                if (m_bmp != null)
                {
                    pictureBox1.Image = m_bmp;
                    this.SkinPath = ofd.FileName;
                }
            }
        }

        private void comboBox1installed_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDateEnabled();
        }
        private void updateDateEnabled()
        {
                dateTimePicker1installed.Enabled = (comboBox1installed.SelectedIndex == 0);

        }
    }
}
