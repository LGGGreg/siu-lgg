//********************************************************************************************
//Author: Sergey Stoyan, CliverSoft.com
//        http://cliversoft.com
//        stoyan@cliversoft.com
//        sergey.stoyan@gmail.com
//        03 January 2007
//Copyright: (C) 2007, Sergey Stoyan
//********************************************************************************************



using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Cliver
{
    partial class MessageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.silent_box = new System.Windows.Forms.CheckBox();
            this.button_sample = new System.Windows.Forms.Button();
            this.image_box = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).BeginInit();
            this.SuspendLayout();
            // 
            // silent_box
            // 
            this.silent_box.AutoSize = true;
            this.silent_box.Location = new System.Drawing.Point(12, 79);
            this.silent_box.Name = "silent_box";
            this.silent_box.Size = new System.Drawing.Size(31, 17);
            this.silent_box.TabIndex = 1;
            this.silent_box.Text = "g";
            this.silent_box.UseVisualStyleBackColor = false;
            // 
            // button_sample
            // 
            this.button_sample.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_sample.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_sample.Location = new System.Drawing.Point(40, 37);
            this.button_sample.Name = "button_sample";
            this.button_sample.Size = new System.Drawing.Size(74, 23);
            this.button_sample.TabIndex = 2;
            this.button_sample.Text = "button_sample";
            this.button_sample.UseVisualStyleBackColor = false;
            // 
            // image_box
            // 
            this.image_box.InitialImage = ((System.Drawing.Image)(resources.GetObject("image_box.InitialImage")));
            this.image_box.Location = new System.Drawing.Point(12, 6);
            this.image_box.Name = "image_box";
            this.image_box.Size = new System.Drawing.Size(27, 25);
            this.image_box.TabIndex = 4;
            this.image_box.TabStop = false;
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.SystemColors.Control;
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label.Location = new System.Drawing.Point(45, 12);
            this.label.Name = "label";
            this.label.ReadOnly = true;
            this.label.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.label.Size = new System.Drawing.Size(306, 19);
            this.label.TabIndex = 6;
            this.label.Text = "label";
            // 
            // MessageForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(391, 120);
            this.Controls.Add(this.label);
            this.Controls.Add(this.image_box);
            this.Controls.Add(this.button_sample);
            this.Controls.Add(this.silent_box);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MessageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private CheckBox silent_box;
        private Button button_sample;
        private PictureBox image_box;
        private RichTextBox label;
    }
}