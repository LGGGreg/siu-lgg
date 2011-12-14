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
    public partial class CharacterSelectionForm : Form
    {
        /*
        public List<installFileInfo> fileInfos;
        public CharacterSelectionForm(List<installFileInfo> filteredFileInfo)
        {
            fileInfos = filteredFileInfo;
            InitializeComponent();
        }
         * */
        public skinsOptions mySkinsOptions = new skinsOptions();
        private string getPart(string input, int p)
        {
            string[] parts = input.Split('/');
            if (parts.Length >p)
            {
                if (parts[0] == parts[p])
                    if (p > 0) return "Default";
                if (p > 0) return parts[p].Replace(parts[0], "");
                return parts[p];
            }
            return input;
        }
        public CharacterSelectionForm(skinsOptions inMySkinsOptions)
        {
            mySkinsOptions = inMySkinsOptions;
            InitializeComponent();
            string input = "";
            foreach (skinOptions mySkinOptions in mySkinsOptions)
            {
                input += mySkinOptions.skinName + "\r\n";
                foreach (skinOption option in mySkinOptions.options)
                {
                    input += "\t" + option.skinName + " - " + (option.skinSelected ? "Selected" : "Unselected")
                       +"\r\n";
                }
                input += "\r\n";
            }
            textBox1.Text = input;

            // ok make the form look right
            tableLayoutPanel1.ColumnCount = mySkinsOptions.Count;
            tableLayoutPanel1.ColumnStyles.Clear();
            int col = 0;
            for (; col < mySkinsOptions.Count;col++ )
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (float)100F/(float)mySkinsOptions.Count));
            
            tableLayoutPanel1.RowCount=1;
            
            // setup rows
            int maxRows = 0;
            foreach (skinOptions mySkinOptions in mySkinsOptions)
                if (mySkinOptions.options.Count > maxRows) maxRows = mySkinOptions.options.Count;
            int sizeNeeded = 50 * maxRows + 240;
            this.Size = new Size( (560 / 3) * mySkinsOptions.Count+100,sizeNeeded);
            float titleSize = 20;
            tableLayoutPanel1.RowCount = maxRows;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, titleSize));
            for (int rr=0; rr < maxRows; rr++)
            {
                float percent = (float)((100F - titleSize) / (float)maxRows);
                this.tableLayoutPanel1.RowStyles.Add(
                        new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent,
                            percent));
            }
            
            int row=1;
            col = 0;
            foreach (skinOptions mySkinOptions in mySkinsOptions)
            {
                Panel p = new Panel();
                p.Dock = DockStyle.Fill;

                Panel tp = new Panel();
                tp.Dock = DockStyle.Top;

                p.Controls.Add(tp);

                FlowLayoutPanel labelPanel = new FlowLayoutPanel();
                labelPanel.Dock = DockStyle.Left;
                Label l = new Label();
                l.Text = "This Custom Skin has a skin for";
                
                Label l1 = new Label();
                l1.Text = getPart(mySkinOptions.skinName,0)+"'s "
                    + getPart(mySkinOptions.skinName,1)+" skin.";
                l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
                Label l2 = new Label();
                l2.Text = "Please choose the skin bellow\r\n"+
                    "That you would like to replace."      ;
                
                l.AutoSize = true;
                l1.AutoSize = true;
                l2.AutoSize = true;

                labelPanel.Controls.Add(l);
                labelPanel.Controls.Add(l1);
                labelPanel.Controls.Add(l2);


                PictureBox pb = new PictureBox();
                pb.Size = new System.Drawing.Size(30, 30);
                pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                pb.Image = global::SkinInstaller.Properties.Resource.downarrow;

                pb.Dock = System.Windows.Forms.DockStyle.Right;


                tp.Controls.Add(pb);
                tp.Controls.Add(labelPanel);

                
                this.tableLayoutPanel1.Controls.Add(p, col, 0);
                row=1;
                

                foreach (skinOption option in mySkinOptions.options)
                {
                    Panel pp = new Panel();
                    pp.Dock = DockStyle.Fill;
                    pp.BackColor = Color.Black;

                    Label ll = new Label();
                    ll.Text = "Option: "+
                        (option.origonalSelected?"*":"")+
                        getPart(option.skinName,1);
                    ll.AutoSize = true;
                    ll.Dock = DockStyle.Top;

                    CheckBox cc = new CheckBox();
                    cc.Text = "Replace this skin";
                    cc.AutoSize = true;
                    cc.Checked = option.skinSelected;
                    cc.Tag = option;
                    ll.ForeColor = cc.ForeColor = option.skinSelected ? Color.Green : Color.Red;
                    //wow this is cool! i didn't know i could do this
                    cc.CheckedChanged+=new EventHandler(delegate(object s, EventArgs ee) {
                        skinOption checkOption = (skinOption)(((CheckBox)s).Tag);
                        checkOption.skinSelected = ((CheckBox)s).Checked;
                        ll.ForeColor = cc.ForeColor = checkOption.skinSelected ? Color.Green : Color.Red;
                    });
                    cc.Dock = DockStyle.Fill;
                    

                    pp.Controls.Add(ll);
                    pp.Controls.Add(cc);
                    this.tableLayoutPanel1.Controls.Add(pp, col, row);
                    row++;
                }
                //input += "\r\n";
                col++;
            }

        }
        public CharacterSelectionForm()
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

        private void button1Done_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1ShowAgain_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.showCharSelection = checkBox1ShowAgain.Checked;
        }

        private void CharacterSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CharacterSelectionForm_Load(object sender, EventArgs e)
        {
            checkBox1ShowAgain.Checked = Properties.Settings.Default.showCharSelection;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
