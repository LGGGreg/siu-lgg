using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SkinInstaller
{
	public partial class FullPreferencesForm: Form
	{
		public FullPreferencesForm()
		{
            Init();
		}
        public void Init()
        {
            InitializeComponent();
            this.comboBox1doneAdding.SelectedIndex =
                Properties.Settings.Default.optionDoneAdding + 1;
            this.comboBox1installAfter.SelectedIndex =
                Properties.Settings.Default.optionInstallAsWellOption + 1;
            this.comboBox2overwriteSkin.SelectedIndex =
                Properties.Settings.Default.optionReplaceSkinWarning + 1;
            this.comboBox3overwriteFolder.SelectedIndex =
                Properties.Settings.Default.optionReplaceFolderWarning + 1;


            this.checkBox1AddVerbose.Checked = Properties.Settings.Default.showAllWarnings;
            this.checkBox1autoReplace.Checked = Properties.Settings.Default.autoOverwrite;
            this.checkBox1checkupdates.Checked = Properties.Settings.Default.checkForUpdates;
            this.checkBox1sendstats.Checked = Properties.Settings.Default.sendStats;
            this.checkBox1fixDDS.Checked = Properties.Settings.Default.fixDDSFiles_1;
            this.checkBox1forceDDSSize.Checked = Properties.Settings.Default.ddsResizeToSD;
            this.checkBox2ForceDDSFormat.Checked = Properties.Settings.Default.ddsForceRiotFormat;
            this.checkBox1webIntegrate.Checked = Properties.Settings.Default.webURLHandleing;
            this.checkBox1drawLines.Checked = Properties.Settings.Default.drawGraficsLines;
            this.checkBox1graifcsGlow.Checked = Properties.Settings.Default.graficsGlow;
            this.checkBox1hideTempDir.Checked = Properties.Settings.Default.hideTempWarningMessage;
            this.checkBox1hideAddedFiles.Checked = Properties.Settings.Default.hideAddedFilesMessage;
            this.checkBoxShowCharSelection.Checked = Properties.Settings.Default.showCharSelection;

            this.trackBar1logostrenth.Value = Properties.Settings.Default.lgglogostrangth;

            this.comboBox1dxFormat.Text = Properties.Settings.Default.dxFormat;

            this.checkedListBox1.SetItemChecked(0,
                Properties.Settings.Default.ch3d);
            this.checkedListBox1.SetItemChecked(1,
                Properties.Settings.Default.chTx);
            this.checkedListBox1.SetItemChecked(2,
                Properties.Settings.Default.part3d);
            this.checkedListBox1.SetItemChecked(3,
                Properties.Settings.Default.partTx);
            this.checkedListBox1.SetItemChecked(4,
                Properties.Settings.Default.anims);
            this.checkedListBox1.SetItemChecked(5,
                Properties.Settings.Default.loadscreensinst);
            this.checkedListBox1.SetItemChecked(6,
                Properties.Settings.Default.iconcharinst);
            this.checkedListBox1.SetItemChecked(7,
                Properties.Settings.Default.spelliconsinst);
            this.checkedListBox1.SetItemChecked(8,
                Properties.Settings.Default.air);
            this.checkedListBox1.SetItemChecked(9,
                Properties.Settings.Default.sounds);
            this.checkedListBox1.SetItemChecked(10,
                Properties.Settings.Default.text);
            this.checkedListBox1.SetItemChecked(11,
                Properties.Settings.Default.showEveryTime);
            this.checkedListBox1.SetItemChecked(12,
                Properties.Settings.Default.showUninstallWarning);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.optionReplaceFolderWarning =
                this.comboBox3overwriteFolder.SelectedIndex - 1;
            Properties.Settings.Default.optionReplaceSkinWarning =
                this.comboBox2overwriteSkin.SelectedIndex - 1;
            Properties.Settings.Default.optionInstallAsWellOption =
                this.comboBox1installAfter.SelectedIndex - 1;
            Properties.Settings.Default.optionDoneAdding =
                this.comboBox1doneAdding.SelectedIndex - 1;

            Properties.Settings.Default.showAllWarnings =
                this.checkBox1AddVerbose.Checked;
            Properties.Settings.Default.autoOverwrite =
                this.checkBox1autoReplace.Checked;
            Properties.Settings.Default.checkForUpdates =
                this.checkBox1checkupdates.Checked;
            Properties.Settings.Default.sendStats =
                this.checkBox1sendstats.Checked;
            Properties.Settings.Default.fixDDSFiles_1 =
                this.checkBox1fixDDS.Checked;
            Properties.Settings.Default.webURLHandleing =
                this.checkBox1webIntegrate.Checked;
            Properties.Settings.Default.drawGraficsLines =
                this.checkBox1drawLines.Checked;
            Properties.Settings.Default.graficsGlow =
                this.checkBox1graifcsGlow.Checked;
            Properties.Settings.Default.hideTempWarningMessage =
                this.checkBox1hideTempDir.Checked;
            Properties.Settings.Default.hideAddedFilesMessage =
                this.checkBox1hideAddedFiles.Checked;
            Properties.Settings.Default.showCharSelection =
                this.checkBoxShowCharSelection.Checked;

            Properties.Settings.Default.lgglogostrangth =
                this.trackBar1logostrenth.Value;
            Properties.Settings.Default.dxFormat =
                this.comboBox1dxFormat.Text;
            Properties.Settings.Default.ddsResizeToSD =
                this.checkBox1forceDDSSize.Checked;
            Properties.Settings.Default.ddsForceRiotFormat =
                this.checkBox2ForceDDSFormat.Checked;

            Properties.Settings.Default.ch3d =
                checkedListBox1.GetItemChecked(0);
            Properties.Settings.Default.chTx =
                checkedListBox1.GetItemChecked(1);
            Properties.Settings.Default.part3d =
                checkedListBox1.GetItemChecked(2);
            Properties.Settings.Default.partTx =
                checkedListBox1.GetItemChecked(3);
            Properties.Settings.Default.anims =
                checkedListBox1.GetItemChecked(4);
            Properties.Settings.Default.loadscreensinst =
                 checkedListBox1.GetItemChecked(5);
            Properties.Settings.Default.iconcharinst =
                 checkedListBox1.GetItemChecked(6);
            Properties.Settings.Default.spelliconsinst =
                 checkedListBox1.GetItemChecked(7);
            Properties.Settings.Default.air =
                checkedListBox1.GetItemChecked(8);
            Properties.Settings.Default.sounds =
                checkedListBox1.GetItemChecked(9);
            Properties.Settings.Default.text =
                checkedListBox1.GetItemChecked(10);
            Properties.Settings.Default.showEveryTime =
                checkedListBox1.GetItemChecked(11);
            Properties.Settings.Default.showUninstallWarning =
                checkedListBox1.GetItemChecked(12);

            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.showUninstallWarning)
            {
                if (Properties.Settings.Default.sounds
                  //  || Properties.Settings.Default.air
                   || Properties.Settings.Default.text)
                {
                    /*InfoForm form = new InfoForm(
                        "The Starred Items you have selected for install\r\n" +
                        "have the potential to cause a error the next time\r\n" +
                        "your LoL client updates.\r\n\r\n" +
                        "This program does handle backups, but YOU must \r\n" +
                        "remember to uninstall your skin before the update\r\n" +
                        "download completes", new Size(270, 180), "HEADS UP");
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();*/
                }
            }

            this.Close();
        }
	}
}
