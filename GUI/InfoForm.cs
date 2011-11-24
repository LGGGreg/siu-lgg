using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SkinInstaller
{
	public partial class InfoForm: Form
	{
		public InfoForm()
		{
			InitializeComponent();
		}
        private delegate DialogResult InvokeDelegate(skinInstaller parent);
        public DialogResult CustShowDialog(skinInstaller parent)
        {
            InvokeDelegate d = new InvokeDelegate(CustShowDialog);
            object[] o = new object[] { parent };
            if (parent.InvokeRequired)
            {
                return (DialogResult)parent.Invoke(d, o);
            }
            return this.ShowDialog(parent);
        }
        public InfoForm(string text, Size s, string title)
        {
            InitializeComponent();
            this.textBox1.Text = text;
            this.Size = s;
            this.Text = title;
            //this.set
        }
        public InfoForm(string text, Size s, string title, bool scrollbar
            ):this(text, s, title)
        {
            
            if(scrollbar)this.textBox1.ScrollBars = ScrollBars.Vertical;
            //this.set
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
