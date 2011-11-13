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
	public partial class ImagePreviewForm: Form
	{
		public ImagePreviewForm()
		{
			InitializeComponent();
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void ImagePreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
	}
}
