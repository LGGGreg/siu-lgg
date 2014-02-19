namespace SIU_Publish
{
    partial class PublishForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublishForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1Result = new System.Windows.Forms.Label();
            this.button1TestWebURL = new System.Windows.Forms.Button();
            this.textBox1WebURL = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1zipLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1OutDir = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2GeneratedFileName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1Location = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1Version = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1FileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1LookFor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1user = new System.Windows.Forms.TextBox();
            this.textBox1pass = new System.Windows.Forms.TextBox();
            this.button1Start = new System.Windows.Forms.Button();
            this.button1Stop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1StateUpload = new System.Windows.Forms.Label();
            this.label1CreateZip = new System.Windows.Forms.Label();
            this.label1StateCopyNew = new System.Windows.Forms.Label();
            this.label1stateDelete = new System.Windows.Forms.Label();
            this.label1Done = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.workerCopyFiles = new System.ComponentModel.BackgroundWorker();
            this.workerDeleteFiles = new System.ComponentModel.BackgroundWorker();
            this.workerCreateZip = new System.ComponentModel.BackgroundWorker();
            this.workerUpload = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 153);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1Result);
            this.panel5.Controls.Add(this.button1TestWebURL);
            this.panel5.Controls.Add(this.textBox1WebURL);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.textBox1zipLocation);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.textBox1OutDir);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.textBox2GeneratedFileName);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.textBox1Location);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.textBox1Version);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.textBox1FileName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.textBox1LookFor);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 58);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1103, 72);
            this.panel5.TabIndex = 4;
            // 
            // label1Result
            // 
            this.label1Result.AutoSize = true;
            this.label1Result.Location = new System.Drawing.Point(544, 53);
            this.label1Result.Name = "label1Result";
            this.label1Result.Size = new System.Drawing.Size(73, 13);
            this.label1Result.TabIndex = 17;
            this.label1Result.Text = "No Result Yet";
            // 
            // button1TestWebURL
            // 
            this.button1TestWebURL.Location = new System.Drawing.Point(463, 47);
            this.button1TestWebURL.Name = "button1TestWebURL";
            this.button1TestWebURL.Size = new System.Drawing.Size(75, 23);
            this.button1TestWebURL.TabIndex = 16;
            this.button1TestWebURL.Text = "Test";
            this.button1TestWebURL.UseVisualStyleBackColor = true;
            this.button1TestWebURL.Click += new System.EventHandler(this.button1TestWebURL_Click);
            // 
            // textBox1WebURL
            // 
            this.textBox1WebURL.Location = new System.Drawing.Point(77, 49);
            this.textBox1WebURL.Multiline = true;
            this.textBox1WebURL.Name = "textBox1WebURL";
            this.textBox1WebURL.ReadOnly = true;
            this.textBox1WebURL.Size = new System.Drawing.Size(379, 20);
            this.textBox1WebURL.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Web URL:";
            // 
            // textBox1zipLocation
            // 
            this.textBox1zipLocation.Location = new System.Drawing.Point(661, 3);
            this.textBox1zipLocation.Multiline = true;
            this.textBox1zipLocation.Name = "textBox1zipLocation";
            this.textBox1zipLocation.Size = new System.Drawing.Size(100, 20);
            this.textBox1zipLocation.TabIndex = 13;
            this.textBox1zipLocation.Text = "\\..\\..\\oldversion\\";
            this.textBox1zipLocation.TextChanged += new System.EventHandler(this.textBox1Location_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Zip Location";
            // 
            // textBox1OutDir
            // 
            this.textBox1OutDir.Location = new System.Drawing.Point(452, 24);
            this.textBox1OutDir.Multiline = true;
            this.textBox1OutDir.Name = "textBox1OutDir";
            this.textBox1OutDir.ReadOnly = true;
            this.textBox1OutDir.Size = new System.Drawing.Size(462, 20);
            this.textBox1OutDir.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(426, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Dir";
            // 
            // textBox2GeneratedFileName
            // 
            this.textBox2GeneratedFileName.Location = new System.Drawing.Point(321, 24);
            this.textBox2GeneratedFileName.Multiline = true;
            this.textBox2GeneratedFileName.Name = "textBox2GeneratedFileName";
            this.textBox2GeneratedFileName.ReadOnly = true;
            this.textBox2GeneratedFileName.Size = new System.Drawing.Size(100, 20);
            this.textBox2GeneratedFileName.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Generated File Name";
            // 
            // textBox1Location
            // 
            this.textBox1Location.Location = new System.Drawing.Point(102, 26);
            this.textBox1Location.Multiline = true;
            this.textBox1Location.Name = "textBox1Location";
            this.textBox1Location.Size = new System.Drawing.Size(100, 20);
            this.textBox1Location.TabIndex = 7;
            this.textBox1Location.Text = "\\..\\..\\";
            this.textBox1Location.TextChanged += new System.EventHandler(this.textBox1Location_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Publish Location";
            // 
            // textBox1Version
            // 
            this.textBox1Version.Location = new System.Drawing.Point(462, 3);
            this.textBox1Version.Multiline = true;
            this.textBox1Version.Name = "textBox1Version";
            this.textBox1Version.ReadOnly = true;
            this.textBox1Version.Size = new System.Drawing.Size(100, 20);
            this.textBox1Version.TabIndex = 5;
            this.textBox1Version.Text = "3.310";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Detected Version:";
            // 
            // textBox1FileName
            // 
            this.textBox1FileName.Location = new System.Drawing.Point(249, 3);
            this.textBox1FileName.Multiline = true;
            this.textBox1FileName.Name = "textBox1FileName";
            this.textBox1FileName.Size = new System.Drawing.Size(100, 20);
            this.textBox1FileName.TabIndex = 3;
            this.textBox1FileName.Text = "SIU [V]-Lite";
            this.textBox1FileName.TextChanged += new System.EventHandler(this.textBox1Location_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "File Name:";
            // 
            // textBox1LookFor
            // 
            this.textBox1LookFor.Location = new System.Drawing.Point(69, 3);
            this.textBox1LookFor.Multiline = true;
            this.textBox1LookFor.Name = "textBox1LookFor";
            this.textBox1LookFor.Size = new System.Drawing.Size(100, 20);
            this.textBox1LookFor.TabIndex = 1;
            this.textBox1LookFor.Text = "Base SIU";
            this.textBox1LookFor.TextChanged += new System.EventHandler(this.textBox1Location_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Look For:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.textBox1user);
            this.panel4.Controls.Add(this.textBox1pass);
            this.panel4.Controls.Add(this.button1Start);
            this.panel4.Controls.Add(this.button1Stop);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1103, 58);
            this.panel4.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(495, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "User:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(495, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Pass:";
            // 
            // textBox1user
            // 
            this.textBox1user.Location = new System.Drawing.Point(529, 4);
            this.textBox1user.Name = "textBox1user";
            this.textBox1user.Size = new System.Drawing.Size(100, 20);
            this.textBox1user.TabIndex = 4;
            this.textBox1user.Text = "LordGregGreg";
            // 
            // textBox1pass
            // 
            this.textBox1pass.Location = new System.Drawing.Point(529, 24);
            this.textBox1pass.Name = "textBox1pass";
            this.textBox1pass.PasswordChar = 'G';
            this.textBox1pass.Size = new System.Drawing.Size(100, 20);
            this.textBox1pass.TabIndex = 3;
            this.textBox1pass.Text = "Password";
            // 
            // button1Start
            // 
            this.button1Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Start.Location = new System.Drawing.Point(3, 3);
            this.button1Start.Name = "button1Start";
            this.button1Start.Size = new System.Drawing.Size(240, 42);
            this.button1Start.TabIndex = 1;
            this.button1Start.Text = "Start Publishing";
            this.button1Start.UseVisualStyleBackColor = true;
            this.button1Start.Click += new System.EventHandler(this.button1Start_Click);
            // 
            // button1Stop
            // 
            this.button1Stop.Enabled = false;
            this.button1Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Stop.Location = new System.Drawing.Point(249, 3);
            this.button1Stop.Name = "button1Stop";
            this.button1Stop.Size = new System.Drawing.Size(240, 42);
            this.button1Stop.TabIndex = 2;
            this.button1Stop.Text = "Stop Publishing";
            this.button1Stop.UseVisualStyleBackColor = true;
            this.button1Stop.Click += new System.EventHandler(this.button1Stop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 130);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1103, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 153);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxDebug);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1103, 433);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1StateUpload, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1CreateZip, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1StateCopyNew, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1stateDelete, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1Done, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 385);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1StateUpload
            // 
            this.label1StateUpload.AutoSize = true;
            this.label1StateUpload.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1StateUpload.ForeColor = System.Drawing.Color.Red;
            this.label1StateUpload.Location = new System.Drawing.Point(3, 231);
            this.label1StateUpload.Name = "label1StateUpload";
            this.label1StateUpload.Size = new System.Drawing.Size(267, 43);
            this.label1StateUpload.TabIndex = 3;
            this.label1StateUpload.Text = "Uploading Zip File";
            // 
            // label1CreateZip
            // 
            this.label1CreateZip.AutoSize = true;
            this.label1CreateZip.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1CreateZip.ForeColor = System.Drawing.Color.Red;
            this.label1CreateZip.Location = new System.Drawing.Point(3, 154);
            this.label1CreateZip.Name = "label1CreateZip";
            this.label1CreateZip.Size = new System.Drawing.Size(246, 43);
            this.label1CreateZip.TabIndex = 2;
            this.label1CreateZip.Text = "Creating Zip File";
            // 
            // label1StateCopyNew
            // 
            this.label1StateCopyNew.AutoSize = true;
            this.label1StateCopyNew.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1StateCopyNew.ForeColor = System.Drawing.Color.Red;
            this.label1StateCopyNew.Location = new System.Drawing.Point(3, 0);
            this.label1StateCopyNew.Name = "label1StateCopyNew";
            this.label1StateCopyNew.Size = new System.Drawing.Size(272, 43);
            this.label1StateCopyNew.TabIndex = 0;
            this.label1StateCopyNew.Text = "Copying New Files";
            // 
            // label1stateDelete
            // 
            this.label1stateDelete.AutoSize = true;
            this.label1stateDelete.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1stateDelete.ForeColor = System.Drawing.Color.Red;
            this.label1stateDelete.Location = new System.Drawing.Point(3, 77);
            this.label1stateDelete.Name = "label1stateDelete";
            this.label1stateDelete.Size = new System.Drawing.Size(272, 43);
            this.label1stateDelete.TabIndex = 1;
            this.label1stateDelete.Text = "Deleting Bad Files";
            // 
            // label1Done
            // 
            this.label1Done.AutoSize = true;
            this.label1Done.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Done.ForeColor = System.Drawing.Color.Red;
            this.label1Done.Location = new System.Drawing.Point(3, 308);
            this.label1Done.Name = "label1Done";
            this.label1Done.Size = new System.Drawing.Size(92, 43);
            this.label1Done.TabIndex = 4;
            this.label1Done.Text = "Done";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 48);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 43);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Stage";
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDebug.Location = new System.Drawing.Point(0, 43);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ReadOnly = true;
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDebug.Size = new System.Drawing.Size(732, 390);
            this.textBoxDebug.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(732, 43);
            this.panel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 43);
            this.label3.TabIndex = 6;
            this.label3.Text = "Info";
            // 
            // workerCopyFiles
            // 
            this.workerCopyFiles.WorkerReportsProgress = true;
            this.workerCopyFiles.WorkerSupportsCancellation = true;
            this.workerCopyFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerCopyFiles_DoWork);
            this.workerCopyFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progressChanged);
            this.workerCopyFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerCopyFiles_RunWorkerCompleted);
            // 
            // workerDeleteFiles
            // 
            this.workerDeleteFiles.WorkerReportsProgress = true;
            this.workerDeleteFiles.WorkerSupportsCancellation = true;
            this.workerDeleteFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerDeleteFiles_DoWork);
            this.workerDeleteFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progressChanged);
            this.workerDeleteFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerDeleteFiles_RunWorkerCompleted);
            // 
            // workerCreateZip
            // 
            this.workerCreateZip.WorkerReportsProgress = true;
            this.workerCreateZip.WorkerSupportsCancellation = true;
            this.workerCreateZip.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerCreateZip_DoWork);
            this.workerCreateZip.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progressChanged);
            this.workerCreateZip.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerCreateZip_RunWorkerCompleted);
            // 
            // workerUpload
            // 
            this.workerUpload.WorkerReportsProgress = true;
            this.workerUpload.WorkerSupportsCancellation = true;
            this.workerUpload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerUpload_DoWork);
            this.workerUpload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progressChanged);
            this.workerUpload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerUpload_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(661, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Custom Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PublishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 586);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PublishForm";
            this.Text = "Publish Form";
            this.Load += new System.EventHandler(this.PublishForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1Stop;
        private System.Windows.Forms.Button button1Start;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1StateUpload;
        private System.Windows.Forms.Label label1CreateZip;
        private System.Windows.Forms.Label label1StateCopyNew;
        private System.Windows.Forms.Label label1stateDelete;
        private System.Windows.Forms.Label label1Done;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox1FileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1LookFor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1Version;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1Location;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2GeneratedFileName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1OutDir;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker workerCopyFiles;
        private System.ComponentModel.BackgroundWorker workerDeleteFiles;
        private System.ComponentModel.BackgroundWorker workerCreateZip;
        private System.ComponentModel.BackgroundWorker workerUpload;
        private System.Windows.Forms.TextBox textBox1zipLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1user;
        private System.Windows.Forms.TextBox textBox1pass;
        private System.Windows.Forms.Label label1Result;
        private System.Windows.Forms.Button button1TestWebURL;
        private System.Windows.Forms.TextBox textBox1WebURL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

