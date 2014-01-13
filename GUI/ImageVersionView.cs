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
    public partial class ImageVersionView : Form
    {
        private Dictionary<String, Dictionary<String, int>> dxtVersions;
        public ImageVersionView(Dictionary<String, Dictionary<String, int>> indxtVersions)
        {
            InitializeComponent();
            this.dxtVersions = indxtVersions;
            populateGrid();
        }
        private void populateGrid()
        {
            foreach (KeyValuePair<String, Dictionary<String, int>> kvp in dxtVersions)
            {
                String imageName = kvp.Key;
                int dxtv = kvp.Value["dxtv"];
                int w = kvp.Value["width"];
                int h = kvp.Value["height"];
                this.dataGridView1.Rows.Add(imageName, dxtv, w, h,
                    kvp.Value["depth"],
                    kvp.Value["filesize"],
                    kvp.Value["linearsize"],
                    kvp.Value["mipmaps"],
                    kvp.Value["bitcount"]);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
