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
            this.checkBox1sendstats = new System.Windows.Forms.CheckBox();
            this.checkBox1checkupdates = new System.Windows.Forms.CheckBox();
            this.checkBox1autoReplace = new System.Windows.Forms.CheckBox();
            this.checkBox1AddVerbose = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProgramLa = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1fixDDS = new System.Windows.Forms.CheckBox();
            this.comboBox1dxFormat = new System.Windows.Forms.ComboBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(0, 354);
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
            "* Install Air mods (Character Selection Icons, etc)",
            "* Install New Sounds",
            "* Install New Menu and Text Mods",
            "Show This Dialog on Every Skin Install",
            "Show Uninstall Warning for Starred Items"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 29);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(294, 167);
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
            this.splitContainer1.Size = new System.Drawing.Size(294, 354);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox1dxFormat);
            this.panel3.Controls.Add(this.checkBox1fixDDS);
            this.panel3.Controls.Add(this.checkBox1sendstats);
            this.panel3.Controls.Add(this.checkBox1checkupdates);
            this.panel3.Controls.Add(this.checkBox1autoReplace);
            this.panel3.Controls.Add(this.checkBox1AddVerbose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 132);
            this.panel3.TabIndex = 1;
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
            // FullPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 377);
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
	}
}