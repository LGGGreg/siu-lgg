namespace SkinInstaller
{
    partial class UpdateAvailiableForm1
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
            this.button2_autoUpdate = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1currentVersion = new System.Windows.Forms.TextBox();
            this.textBox1newVersio = new System.Windows.Forms.TextBox();
            this.textBox1updateinfo = new System.Windows.Forms.TextBox();
            this.textBox2updateurl = new System.Windows.Forms.TextBox();
            this.button4ignore = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Installed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2allowAutoUpdate = new System.Windows.Forms.Button();
            this.autoupdateWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Manual Download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2_autoUpdate
            // 
            this.button2_autoUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2_autoUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2_autoUpdate.Location = new System.Drawing.Point(12, 435);
            this.button2_autoUpdate.Name = "button2_autoUpdate";
            this.button2_autoUpdate.Size = new System.Drawing.Size(438, 40);
            this.button2_autoUpdate.TabIndex = 1;
            this.button2_autoUpdate.Text = "Automatic Update";
            this.button2_autoUpdate.UseVisualStyleBackColor = true;
            this.button2_autoUpdate.Click += new System.EventHandler(this.button2_autoUpdate_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 406);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "? How To Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "A New Update Is Availiable!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "New Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Latest Changes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Download Link";
            // 
            // textBox1currentVersion
            // 
            this.textBox1currentVersion.ForeColor = System.Drawing.Color.Red;
            this.textBox1currentVersion.Location = new System.Drawing.Point(97, 54);
            this.textBox1currentVersion.Name = "textBox1currentVersion";
            this.textBox1currentVersion.Size = new System.Drawing.Size(100, 20);
            this.textBox1currentVersion.TabIndex = 8;
            this.textBox1currentVersion.Text = "0.000";
            this.textBox1currentVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key);
            this.textBox1currentVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // textBox1newVersio
            // 
            this.textBox1newVersio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1newVersio.ForeColor = System.Drawing.Color.Green;
            this.textBox1newVersio.Location = new System.Drawing.Point(97, 87);
            this.textBox1newVersio.Name = "textBox1newVersio";
            this.textBox1newVersio.Size = new System.Drawing.Size(100, 20);
            this.textBox1newVersio.TabIndex = 9;
            this.textBox1newVersio.Text = "1.000";
            this.textBox1newVersio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key);
            this.textBox1newVersio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // textBox1updateinfo
            // 
            this.textBox1updateinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1updateinfo.Location = new System.Drawing.Point(3, 3);
            this.textBox1updateinfo.Multiline = true;
            this.textBox1updateinfo.Name = "textBox1updateinfo";
            this.textBox1updateinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1updateinfo.Size = new System.Drawing.Size(431, 209);
            this.textBox1updateinfo.TabIndex = 10;
            this.textBox1updateinfo.Text = "Not Provided";
            this.textBox1updateinfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key);
            this.textBox1updateinfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // textBox2updateurl
            // 
            this.textBox2updateurl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox2updateurl.Location = new System.Drawing.Point(95, 385);
            this.textBox2updateurl.Name = "textBox2updateurl";
            this.textBox2updateurl.Size = new System.Drawing.Size(255, 20);
            this.textBox2updateurl.TabIndex = 11;
            this.textBox2updateurl.Text = "http://www.google.com";
            this.textBox2updateurl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2updateurl_MouseClick);
            this.textBox2updateurl.TextChanged += new System.EventHandler(this.textBox2updateurl_TextChanged);
            this.textBox2updateurl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key);
            this.textBox2updateurl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // button4ignore
            // 
            this.button4ignore.Location = new System.Drawing.Point(203, 86);
            this.button4ignore.Name = "button4ignore";
            this.button4ignore.Size = new System.Drawing.Size(161, 23);
            this.button4ignore.TabIndex = 12;
            this.button4ignore.Text = "Ignore Updates for this Version";
            this.button4ignore.UseVisualStyleBackColor = true;
            this.button4ignore.Click += new System.EventHandler(this.button4ignore_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(445, 251);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(437, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Change Log Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Installed,
            this.Change});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(431, 219);
            this.dataGridView1.TabIndex = 0;
            // 
            // Installed
            // 
            this.Installed.HeaderText = "Installed";
            this.Installed.Name = "Installed";
            this.Installed.ReadOnly = true;
            this.Installed.Width = 50;
            // 
            // Change
            // 
            this.Change.HeaderText = "Change";
            this.Change.Name = "Change";
            this.Change.ReadOnly = true;
            this.Change.Width = 355;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1updateinfo);
            this.tabPage2.Controls.Add(this.button2allowAutoUpdate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(437, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raw Text Change Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2allowAutoUpdate
            // 
            this.button2allowAutoUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2allowAutoUpdate.Location = new System.Drawing.Point(3, 212);
            this.button2allowAutoUpdate.Name = "button2allowAutoUpdate";
            this.button2allowAutoUpdate.Size = new System.Drawing.Size(431, 10);
            this.button2allowAutoUpdate.TabIndex = 11;
            this.button2allowAutoUpdate.UseVisualStyleBackColor = true;
            this.button2allowAutoUpdate.Click += new System.EventHandler(this.button2allowAutoUpdate_Click);
            // 
            // autoupdateWorker1
            // 
            this.autoupdateWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.autoupdateWorker1_DoWork);
            this.autoupdateWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.autoupdateWorker1_RunWorkerCompleted);
            // 
            // UpdateAvailiableForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 480);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4ignore);
            this.Controls.Add(this.textBox2updateurl);
            this.Controls.Add(this.textBox1newVersio);
            this.Controls.Add(this.textBox1currentVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2_autoUpdate);
            this.Controls.Add(this.button1);
            this.Name = "UpdateAvailiableForm1";
            this.Text = "Update Availiable!";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2_autoUpdate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox1currentVersion;
        public System.Windows.Forms.TextBox textBox1newVersio;
        public System.Windows.Forms.TextBox textBox1updateinfo;
        public System.Windows.Forms.TextBox textBox2updateurl;
        private System.Windows.Forms.Button button4ignore;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Installed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Change;
        private System.Windows.Forms.Button button2allowAutoUpdate;
        private System.ComponentModel.BackgroundWorker autoupdateWorker1;
    }
}