namespace RAFManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.log = new System.Windows.Forms.TextBox();
            this.logContainer = new System.Windows.Forms.GroupBox();
            this.rafContentView = new System.Windows.Forms.TreeView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToRAFPackerLeagueCraftTHreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.projectNameTb = new System.Windows.Forms.ToolStripTextBox();
            this.bigContainer = new System.Windows.Forms.SplitContainer();
            this.smallContainer = new System.Windows.Forms.SplitContainer();
            this.changesView = new System.Windows.Forms.DataGridView();
            this.shouldUseMod = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.localPathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickLocalPathColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rafPathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickRafPathColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.logContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bigContainer)).BeginInit();
            this.bigContainer.Panel1.SuspendLayout();
            this.bigContainer.Panel2.SuspendLayout();
            this.bigContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallContainer)).BeginInit();
            this.smallContainer.Panel1.SuspendLayout();
            this.smallContainer.Panel2.SuspendLayout();
            this.smallContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changesView)).BeginInit();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Location = new System.Drawing.Point(2, 15);
            this.log.Margin = new System.Windows.Forms.Padding(2);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(574, 123);
            this.log.TabIndex = 0;
            // 
            // logContainer
            // 
            this.logContainer.Controls.Add(this.log);
            this.logContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logContainer.Location = new System.Drawing.Point(0, 0);
            this.logContainer.Margin = new System.Windows.Forms.Padding(2);
            this.logContainer.Name = "logContainer";
            this.logContainer.Padding = new System.Windows.Forms.Padding(2);
            this.logContainer.Size = new System.Drawing.Size(578, 140);
            this.logContainer.TabIndex = 1;
            this.logContainer.TabStop = false;
            this.logContainer.Text = "Output";
            // 
            // rafContentView
            // 
            this.rafContentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rafContentView.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rafContentView.Location = new System.Drawing.Point(0, 0);
            this.rafContentView.Margin = new System.Windows.Forms.Padding(2);
            this.rafContentView.Name = "rafContentView";
            this.rafContentView.Size = new System.Drawing.Size(197, 285);
            this.rafContentView.TabIndex = 2;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.projectNameTb});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(578, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.packToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton1.Tag = "";
            this.toolStripDropDownButton1.Text = "Project";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // packToolStripMenuItem
            // 
            this.packToolStripMenuItem.Name = "packToolStripMenuItem";
            this.packToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.packToolStripMenuItem.Text = "Pack";
            this.packToolStripMenuItem.Click += new System.EventHandler(this.packToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem,
            this.goToRAFPackerLeagueCraftTHreadToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "Help";
            this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(446, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem
            // 
            this.goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem.Image")));
            this.goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem.Name = "goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem";
            this.goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem.Size = new System.Drawing.Size(446, 22);
            this.goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem.Text = "Go to RAF Packer League of Legends Thread (North American Forums)";
            // 
            // goToRAFPackerLeagueCraftTHreadToolStripMenuItem
            // 
            this.goToRAFPackerLeagueCraftTHreadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("goToRAFPackerLeagueCraftTHreadToolStripMenuItem.Image")));
            this.goToRAFPackerLeagueCraftTHreadToolStripMenuItem.Name = "goToRAFPackerLeagueCraftTHreadToolStripMenuItem";
            this.goToRAFPackerLeagueCraftTHreadToolStripMenuItem.Size = new System.Drawing.Size(446, 22);
            this.goToRAFPackerLeagueCraftTHreadToolStripMenuItem.Text = "Go to RAF Packer LeagueCraft Thread";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(265, 22);
            this.toolStripLabel1.Text = "Back up your LoL files before using this program!";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(85, 22);
            this.toolStripLabel2.Text = "Project Name: ";
            // 
            // projectNameTb
            // 
            this.projectNameTb.Name = "projectNameTb";
            this.projectNameTb.Size = new System.Drawing.Size(114, 23);
            // 
            // bigContainer
            // 
            this.bigContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigContainer.Location = new System.Drawing.Point(0, 25);
            this.bigContainer.Margin = new System.Windows.Forms.Padding(2);
            this.bigContainer.Name = "bigContainer";
            this.bigContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // bigContainer.Panel1
            // 
            this.bigContainer.Panel1.Controls.Add(this.smallContainer);
            // 
            // bigContainer.Panel2
            // 
            this.bigContainer.Panel2.Controls.Add(this.logContainer);
            this.bigContainer.Size = new System.Drawing.Size(578, 428);
            this.bigContainer.SplitterDistance = 285;
            this.bigContainer.SplitterWidth = 3;
            this.bigContainer.TabIndex = 4;
            // 
            // smallContainer
            // 
            this.smallContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallContainer.Location = new System.Drawing.Point(0, 0);
            this.smallContainer.Margin = new System.Windows.Forms.Padding(2);
            this.smallContainer.Name = "smallContainer";
            // 
            // smallContainer.Panel1
            // 
            this.smallContainer.Panel1.Controls.Add(this.rafContentView);
            // 
            // smallContainer.Panel2
            // 
            this.smallContainer.Panel2.Controls.Add(this.changesView);
            this.smallContainer.Size = new System.Drawing.Size(578, 285);
            this.smallContainer.SplitterDistance = 197;
            this.smallContainer.SplitterWidth = 3;
            this.smallContainer.TabIndex = 0;
            // 
            // changesView
            // 
            this.changesView.AllowUserToResizeColumns = false;
            this.changesView.AllowUserToResizeRows = false;
            this.changesView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.changesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.changesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shouldUseMod,
            this.localPathColumn,
            this.pickLocalPathColumn,
            this.rafPathColumn,
            this.pickRafPathColumn});
            this.changesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changesView.Location = new System.Drawing.Point(0, 0);
            this.changesView.Margin = new System.Windows.Forms.Padding(2);
            this.changesView.MultiSelect = false;
            this.changesView.Name = "changesView";
            this.changesView.RowHeadersVisible = false;
            this.changesView.RowTemplate.Height = 24;
            this.changesView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.changesView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.changesView.Size = new System.Drawing.Size(378, 285);
            this.changesView.TabIndex = 0;
            // 
            // shouldUseMod
            // 
            this.shouldUseMod.HeaderText = "Use?";
            this.shouldUseMod.MinimumWidth = 20;
            this.shouldUseMod.Name = "shouldUseMod";
            this.shouldUseMod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.shouldUseMod.Width = 101;
            // 
            // localPathColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.localPathColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.localPathColumn.HeaderText = "Local Path";
            this.localPathColumn.Name = "localPathColumn";
            this.localPathColumn.ReadOnly = true;
            this.localPathColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.localPathColumn.Width = 102;
            // 
            // pickLocalPathColumn
            // 
            this.pickLocalPathColumn.HeaderText = "";
            this.pickLocalPathColumn.Name = "pickLocalPathColumn";
            this.pickLocalPathColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.pickLocalPathColumn.Text = "...";
            this.pickLocalPathColumn.Width = 101;
            // 
            // rafPathColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rafPathColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.rafPathColumn.HeaderText = "RAF Path";
            this.rafPathColumn.Name = "rafPathColumn";
            this.rafPathColumn.ReadOnly = true;
            this.rafPathColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.rafPathColumn.Width = 102;
            // 
            // pickRafPathColumn
            // 
            this.pickRafPathColumn.HeaderText = "";
            this.pickRafPathColumn.Name = "pickRafPathColumn";
            this.pickRafPathColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.pickRafPathColumn.Text = "...";
            this.pickRafPathColumn.Width = 101;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 453);
            this.Controls.Add(this.bigContainer);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "RAF Manager";
            this.logContainer.ResumeLayout(false);
            this.logContainer.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.bigContainer.Panel1.ResumeLayout(false);
            this.bigContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bigContainer)).EndInit();
            this.bigContainer.ResumeLayout(false);
            this.smallContainer.Panel1.ResumeLayout(false);
            this.smallContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smallContainer)).EndInit();
            this.smallContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changesView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.GroupBox logContainer;
        private System.Windows.Forms.TreeView rafContentView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToRAFPackerLeagueOfLegendsThreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer bigContainer;
        private System.Windows.Forms.SplitContainer smallContainer;
        private System.Windows.Forms.DataGridView changesView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox projectNameTb;
        private System.Windows.Forms.ToolStripMenuItem goToRAFPackerLeagueCraftTHreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn shouldUseMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPathColumn;
        private System.Windows.Forms.DataGridViewButtonColumn pickLocalPathColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rafPathColumn;
        private System.Windows.Forms.DataGridViewButtonColumn pickRafPathColumn;
    }
}

