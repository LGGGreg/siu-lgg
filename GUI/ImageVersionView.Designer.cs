namespace SkinInstaller
{
    partial class ImageVersionView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinearSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MipMaps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BitCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageName,
            this.DXT,
            this.Width,
            this.Height,
            this.Depth,
            this.FileSize,
            this.LinearSize,
            this.MipMaps,
            this.BitCount});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1137, 409);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ImageName
            // 
            this.ImageName.HeaderText = "ImageName";
            this.ImageName.Name = "ImageName";
            this.ImageName.ReadOnly = true;
            this.ImageName.Width = 300;
            // 
            // DXT
            // 
            this.DXT.FillWeight = 20F;
            this.DXT.HeaderText = "DXT";
            this.DXT.Name = "DXT";
            this.DXT.ReadOnly = true;
            // 
            // Width
            // 
            this.Width.FillWeight = 30F;
            this.Width.HeaderText = "Width";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            // 
            // Height
            // 
            this.Height.FillWeight = 30F;
            this.Height.HeaderText = "Height";
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            // 
            // Depth
            // 
            this.Depth.HeaderText = "Depth";
            this.Depth.Name = "Depth";
            this.Depth.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "FileSize";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // LinearSize
            // 
            this.LinearSize.HeaderText = "LinearSize";
            this.LinearSize.Name = "LinearSize";
            this.LinearSize.ReadOnly = true;
            // 
            // MipMaps
            // 
            this.MipMaps.HeaderText = "MipMaps";
            this.MipMaps.Name = "MipMaps";
            this.MipMaps.ReadOnly = true;
            // 
            // BitCount
            // 
            this.BitCount.HeaderText = "BitCount";
            this.BitCount.Name = "BitCount";
            this.BitCount.ReadOnly = true;
            // 
            // ImageVersionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 409);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ImageVersionView";
            this.Text = "ImageVersionView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depth;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinearSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn MipMaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn BitCount;
    }
}