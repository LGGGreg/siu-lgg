using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SkinInstaller
{
    public partial class LCIntHelp : Form
    {
        private void registerProgram()
        {
            //run that other thing

            Process process = new Process();
            process.StartInfo.FileName = "sai.exe";
            process.StartInfo.Arguments = "";
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WorkingDirectory = Application.StartupPath;
            process.Start();
            process.WaitForExit();

            
        }
        public string getUserScriptName()
        {
            return Application.StartupPath + "//" + "LeagueOfLegendsSkinInstallerLeagueCraftIntegration.user.js";
        }
        public LCIntHelp()
        {
            if (Properties.Settings.Default.webURLHandleing)
            {
                registerProgram();
            }
            else
            {
                if (Cliver.Message.Show("Wait what?", SystemIcons.Error, "Your settings are set to not allow this program to work with web pages, for these next steps to work, you need to change that.\r\n\r\nWould you like to turn it on now?"
                                   , 0, new string[2] { "Yes", "No" }) == 0)
                {
                    Properties.Settings.Default.webURLHandleing = true;
                    Properties.Settings.Default.Save();
                    registerProgram();
                }
            }
            InitializeComponent();
            this.textBox3installInstructions.Text = "Install the user script located at\r\n" +
                getUserScriptName()+
                "\r\nor http://userscripts.org/scripts/source/105436.user.js \r\n\r\n if the button below doesn't work, just try dragging and dropping the script on top of your browser";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.mozilla.org/?product=firefox-5.0&os=win&lang=en-US");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                "https://addons.mozilla.org/firefox/downloads/latest/748/addon-748-latest.xpi?src=addon-detail");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://leaguecraft.com/skins/5324-jack-sparrow-as-gangplank-v1-2.xhtml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://userscripts.org/scripts/source/105436.user.js");
        }

        private void textBox3installInstructions_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
