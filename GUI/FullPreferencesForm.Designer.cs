namespace SkinInstaller
{
	partial class FullPreferencesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxShowCharSelection = new System.Windows.Forms.CheckBox();
            this.checkBox1hideAddedFiles = new System.Windows.Forms.CheckBox();
            this.comboBox3overwriteFolder = new System.Windows.Forms.ComboBox();
            this.comboBox2overwriteSkin = new System.Windows.Forms.ComboBox();
            this.comboBox1installAfter = new System.Windows.Forms.ComboBox();
            this.checkBox1hideTempDir = new System.Windows.Forms.CheckBox();
            this.comboBox1doneAdding = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1graifcsGlow = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1logostrenth = new System.Windows.Forms.TrackBar();
            this.checkBox1drawLines = new System.Windows.Forms.CheckBox();
            this.checkBox1webIntegrate = new System.Windows.Forms.CheckBox();
            this.comboBox1dxFormat = new System.Windows.Forms.ComboBox();
            this.checkBox1fixDDS = new System.Windows.Forms.CheckBox();
            this.checkBox1sendstats = new System.Windows.Forms.CheckBox();
            this.checkBox1checkupdates = new System.Windows.Forms.CheckBox();
            this.checkBox1autoReplace = new System.Windows.Forms.CheckBox();
            this.checkBox1AddVerbose = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProgramLa = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1forceDDSSize = new System.Windows.Forms.CheckBox();
            this.checkBox2ForceDDSFormat = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1logostrenth)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(0, 672);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Install New Character 3d Models",
            "Install New Character Textures",
            "Install New Particle 3d Models",
            "Install New Particle Textures",
            "Install New Animations",
            "Install New LoadScreens",
            "Install New In-Game Character Icons",
            "Install New In-Game Spell Icons",
            "* Install Air mods (Character Selection Icons, etc)",
            "* Install New Sounds",
            "* Install New Menu and Text Mods",
            "Show This Dialog on Every Skin Install",
            "Show Uninstall Warning for Starred Items"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 29);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(294, 207);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(294, 672);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox2ForceDDSFormat);
            this.panel3.Controls.Add(this.checkBox1forceDDSSize);
            this.panel3.Controls.Add(this.checkBoxShowCharSelection);
            this.panel3.Controls.Add(this.checkBox1hideAddedFiles);
            this.panel3.Controls.Add(this.comboBox3overwriteFolder);
            this.panel3.Controls.Add(this.comboBox2overwriteSkin);
            this.panel3.Controls.Add(this.comboBox1installAfter);
            this.panel3.Controls.Add(this.checkBox1hideTempDir);
            this.panel3.Controls.Add(this.comboBox1doneAdding);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.checkBox1graifcsGlow);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.trackBar1logostrenth);
            this.panel3.Controls.Add(this.checkBox1drawLines);
            this.panel3.Controls.Add(this.checkBox1webIntegrate);
            this.panel3.Controls.Add(this.comboBox1dxFormat);
            this.panel3.Controls.Add(this.checkBox1fixDDS);
            this.panel3.Controls.Add(this.checkBox1sendstats);
            this.panel3.Controls.Add(this.checkBox1checkupdates);
            this.panel3.Controls.Add(this.checkBox1autoReplace);
            this.panel3.Controls.Add(this.checkBox1AddVerbose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 410);
            this.panel3.TabIndex = 1;
            // 
            // checkBoxShowCharSelection
            // 
            this.checkBoxShowCharSelection.AutoSize = true;
            this.checkBoxShowCharSelection.Location = new System.Drawing.Point(15, 366);
            this.checkBoxShowCharSelection.Name = "checkBoxShowCharSelection";
            this.checkBoxShowCharSelection.Size = new System.Drawing.Size(186, 17);
            this.checkBoxShowCharSelection.TabIndex = 21;
            this.checkBoxShowCharSelection.Text = "Show Character Selection Screen";
            this.checkBoxShowCharSelection.UseVisualStyleBackColor = true;
            // 
            // checkBox1hideAddedFiles
            // 
            this.checkBox1hideAddedFiles.AutoSize = true;
            this.checkBox1hideAddedFiles.Location = new System.Drawing.Point(149, 219);
            this.checkBox1hideAddedFiles.Name = "checkBox1hideAddedFiles";
            this.checkBox1hideAddedFiles.Size = new System.Drawing.Size(127, 17);
            this.checkBox1hideAddedFiles.TabIndex = 20;
            this.checkBox1hideAddedFiles.Text = "Hide Added Files Info";
            this.checkBox1hideAddedFiles.UseVisualStyleBackColor = true;
            // 
            // comboBox3overwriteFolder
            // 
            this.comboBox3overwriteFolder.FormattingEnabled = true;
            this.comboBox3overwriteFolder.Items.AddRange(new object[] {
            "Always Ask",
            "Always Yes",
            "Always No"});
            this.comboBox3overwriteFolder.Location = new System.Drawing.Point(149, 336);
            this.comboBox3overwriteFolder.Name = "comboBox3overwriteFolder";
            this.comboBox3overwriteFolder.Size = new System.Drawing.Size(121, 21);
            this.comboBox3overwriteFolder.TabIndex = 19;
            // 
            // comboBox2overwriteSkin
            // 
            this.comboBox2overwriteSkin.FormattingEnabled = true;
            this.comboBox2overwriteSkin.Items.AddRange(new object[] {
            "Always Ask",
            "Always No",
            "Always Yes"});
            this.comboBox2overwriteSkin.Location = new System.Drawing.Point(149, 313);
            this.comboBox2overwriteSkin.Name = "comboBox2overwriteSkin";
            this.comboBox2overwriteSkin.Size = new System.Drawing.Size(121, 21);
            this.comboBox2overwriteSkin.TabIndex = 18;
            // 
            // comboBox1installAfter
            // 
            this.comboBox1installAfter.FormattingEnabled = true;
            this.comboBox1installAfter.Items.AddRange(new object[] {
            "Always Ask",
            "Always Don\'t",
            "Always Install"});
            this.comboBox1installAfter.Location = new System.Drawing.Point(149, 289);
            this.comboBox1installAfter.Name = "comboBox1installAfter";
            this.comboBox1installAfter.Size = new System.Drawing.Size(121, 21);
            this.comboBox1installAfter.TabIndex = 17;
            // 
            // checkBox1hideTempDir
            // 
            this.checkBox1hideTempDir.AutoSize = true;
            this.checkBox1hideTempDir.Location = new System.Drawing.Point(12, 219);
            this.checkBox1hideTempDir.Name = "checkBox1hideTempDir";
            this.checkBox1hideTempDir.Size = new System.Drawing.Size(137, 17);
            this.checkBox1hideTempDir.TabIndex = 16;
            this.checkBox1hideTempDir.Text = "Hide Temp Dir Warning";
            this.checkBox1hideTempDir.UseVisualStyleBackColor = true;
            // 
            // comboBox1doneAdding
            // 
            this.comboBox1doneAdding.FormattingEnabled = true;
            this.comboBox1doneAdding.Items.AddRange(new object[] {
            "Always Ask",
            "Always Yes",
            "Always No"});
            this.comboBox1doneAdding.Location = new System.Drawing.Point(149, 265);
            this.comboBox1doneAdding.Name = "comboBox1doneAdding";
            this.comboBox1doneAdding.Size = new System.Drawing.Size(121, 21);
            this.comboBox1doneAdding.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Overwrite Folder?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Overwrite Skin?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Install After Adding to DB?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Done Adding Files?";
            // 
            // checkBox1graifcsGlow
            // 
            this.checkBox1graifcsGlow.AutoSize = true;
            this.checkBox1graifcsGlow.Location = new System.Drawing.Point(128, 195);
            this.checkBox1graifcsGlow.Name = "checkBox1graifcsGlow";
            this.checkBox1graifcsGlow.Size = new System.Drawing.Size(101, 17);
            this.checkBox1graifcsGlow.TabIndex = 10;
            this.checkBox1graifcsGlow.Text = "Draw Line Glow";
            this.checkBox1graifcsGlow.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Visibility of Logo";
            // 
            // trackBar1logostrenth
            // 
            this.trackBar1logostrenth.LargeChange = 25;
            this.trackBar1logostrenth.Location = new System.Drawing.Point(117, 237);
            this.trackBar1logostrenth.Maximum = 100;
            this.trackBar1logostrenth.Name = "trackBar1logostrenth";
            this.trackBar1logostrenth.Size = new System.Drawing.Size(104, 45);
            this.trackBar1logostrenth.SmallChange = 5;
            this.trackBar1logostrenth.TabIndex = 8;
            this.trackBar1logostrenth.TickFrequency = 25;
            // 
            // checkBox1drawLines
            // 
            this.checkBox1drawLines.AutoSize = true;
            this.checkBox1drawLines.Location = new System.Drawing.Point(12, 195);
            this.checkBox1drawLines.Name = "checkBox1drawLines";
            this.checkBox1drawLines.Size = new System.Drawing.Size(109, 17);
            this.checkBox1drawLines.TabIndex = 7;
            this.checkBox1drawLines.Text = "Draw Pretty Lines";
            this.checkBox1drawLines.UseVisualStyleBackColor = true;
            // 
            // checkBox1webIntegrate
            // 
            this.checkBox1webIntegrate.AutoSize = true;
            this.checkBox1webIntegrate.Location = new System.Drawing.Point(12, 171);
            this.checkBox1webIntegrate.Name = "checkBox1webIntegrate";
            this.checkBox1webIntegrate.Size = new System.Drawing.Size(185, 17);
            this.checkBox1webIntegrate.TabIndex = 6;
            this.checkBox1webIntegrate.Text = "Try to integrate with skin websites";
            this.checkBox1webIntegrate.UseVisualStyleBackColor = true;
            // 
            // comboBox1dxFormat
            // 
            this.comboBox1dxFormat.FormattingEnabled = true;
            this.comboBox1dxFormat.Items.AddRange(new object[] {
            "DXT1",
            "DXT2",
            "DXT3",
            "DXT4",
            "DXT5"});
            this.comboBox1dxFormat.Location = new System.Drawing.Point(188, 98);
            this.comboBox1dxFormat.Name = "comboBox1dxFormat";
            this.comboBox1dxFormat.Size = new System.Drawing.Size(82, 21);
            this.comboBox1dxFormat.TabIndex = 5;
            // 
            // checkBox1fixDDS
            // 
            this.checkBox1fixDDS.AutoSize = true;
            this.checkBox1fixDDS.Location = new System.Drawing.Point(12, 102);
            this.checkBox1fixDDS.Name = "checkBox1fixDDS";
            this.checkBox1fixDDS.Size = new System.Drawing.Size(170, 17);
            this.checkBox1fixDDS.TabIndex = 4;
            this.checkBox1fixDDS.Text = "Fix Skin Textures with Format :";
            this.checkBox1fixDDS.UseVisualStyleBackColor = true;
            // 
            // checkBox1sendstats
            // 
            this.checkBox1sendstats.AutoSize = true;
            this.checkBox1sendstats.Location = new System.Drawing.Point(12, 78);
            this.checkBox1sendstats.Name = "checkBox1sendstats";
            this.checkBox1sendstats.Size = new System.Drawing.Size(176, 17);
            this.checkBox1sendstats.TabIndex = 3;
            this.checkBox1sendstats.Text = "Send Anonymous Useage Stats";
            this.checkBox1sendstats.UseVisualStyleBackColor = true;
            // 
            // checkBox1checkupdates
            // 
            this.checkBox1checkupdates.AutoSize = true;
            this.checkBox1checkupdates.Location = new System.Drawing.Point(12, 54);
            this.checkBox1checkupdates.Name = "checkBox1checkupdates";
            this.checkBox1checkupdates.Size = new System.Drawing.Size(118, 17);
            this.checkBox1checkupdates.TabIndex = 2;
            this.checkBox1checkupdates.Text = "Check For Updates";
            this.checkBox1checkupdates.UseVisualStyleBackColor = true;
            // 
            // checkBox1autoReplace
            // 
            this.checkBox1autoReplace.AutoSize = true;
            this.checkBox1autoReplace.Location = new System.Drawing.Point(12, 30);
            this.checkBox1autoReplace.Name = "checkBox1autoReplace";
            this.checkBox1autoReplace.Size = new System.Drawing.Size(251, 17);
            this.checkBox1autoReplace.TabIndex = 1;
            this.checkBox1autoReplace.Text = "Auto Replace Duplicate Files On Database Add";
            this.checkBox1autoReplace.UseVisualStyleBackColor = true;
            // 
            // checkBox1AddVerbose
            // 
            this.checkBox1AddVerbose.AutoSize = true;
            this.checkBox1AddVerbose.Location = new System.Drawing.Point(12, 6);
            this.checkBox1AddVerbose.Name = "checkBox1AddVerbose";
            this.checkBox1AddVerbose.Size = new System.Drawing.Size(190, 17);
            this.checkBox1AddVerbose.TabIndex = 0;
            this.checkBox1AddVerbose.Text = "Show Message Box on Every Error";
            this.checkBox1AddVerbose.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ProgramLa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 22);
            this.panel2.TabIndex = 0;
            // 
            // ProgramLa
            // 
            this.ProgramLa.AutoSize = true;
            this.ProgramLa.Location = new System.Drawing.Point(1, 0);
            this.ProgramLa.Name = "ProgramLa";
            this.ProgramLa.Size = new System.Drawing.Size(106, 13);
            this.ProgramLa.TabIndex = 0;
            this.ProgramLa.Text = "Program Preferences";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 29);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Install Preferences";
            // 
            // checkBox1forceDDSSize
            // 
            this.checkBox1forceDDSSize.AutoSize = true;
            this.checkBox1forceDDSSize.Location = new System.Drawing.Point(12, 125);
            this.checkBox1forceDDSSize.Name = "checkBox1forceDDSSize";
            this.checkBox1forceDDSSize.Size = new System.Drawing.Size(192, 17);
            this.checkBox1forceDDSSize.TabIndex = 22;
            this.checkBox1forceDDSSize.Text = "Force All Textures to Standard Size";
            this.checkBox1forceDDSSize.UseVisualStyleBackColor = true;
            // 
            // checkBox2ForceDDSFormat
            // 
            this.checkBox2ForceDDSFormat.AutoSize = true;
            this.checkBox2ForceDDSFormat.Location = new System.Drawing.Point(12, 148);
            this.checkBox2ForceDDSFormat.Name = "checkBox2ForceDDSFormat";
            this.checkBox2ForceDDSFormat.Size = new System.Drawing.Size(219, 17);
            this.checkBox2ForceDDSFormat.TabIndex = 23;
            this.checkBox2ForceDDSFormat.Text = "Force All Textures to be Standard Format";
            this.checkBox2ForceDDSFormat.UseVisualStyleBackColor = true;
            // 
            // FullPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 695);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FullPreferencesForm";
            this.Text = "All Preferences";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1logostrenth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox1AddVerbose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ProgramLa;
        private System.Windows.Forms.CheckBox checkBox1autoReplace;
        private System.Windows.Forms.CheckBox checkBox1checkupdates;
        private System.Windows.Forms.CheckBox checkBox1sendstats;
        private System.Windows.Forms.ComboBox comboBox1dxFormat;
        private System.Windows.Forms.CheckBox checkBox1fixDDS;
        private System.Windows.Forms.CheckBox checkBox1webIntegrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1logostrenth;
        private System.Windows.Forms.CheckBox checkBox1drawLines;
        private System.Windows.Forms.CheckBox checkBox1graifcsGlow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1doneAdding;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1hideTempDir;
        private System.Windows.Forms.ComboBox comboBox1installAfter;
        private System.Windows.Forms.ComboBox comboBox3overwriteFolder;
        private System.Windows.Forms.ComboBox comboBox2overwriteSkin;
        private System.Windows.Forms.CheckBox checkBox1hideAddedFiles;
        private System.Windows.Forms.CheckBox checkBoxShowCharSelection;
        private System.Windows.Forms.CheckBox checkBox2ForceDDSFormat;
        private System.Windows.Forms.CheckBox checkBox1forceDDSSize;
	}
}