

/*
LOLViewer
Copyright 2011 James Lammlein 

 

This file is part of LOLViewer.

LOLViewer is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
any later version.

LOLViewer is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with LOLViewer.  If not, see <http://www.gnu.org/licenses/>.

*/

namespace LOLViewer
{
    partial class PreviewWindow
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
            this.glControlMain = new OpenTK.GLControl();
            this.PreviewWindowMenuStrip = new System.Windows.Forms.MenuStrip();
            this.filePreviewWindowMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPreviewWindowMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreviewWindowStatusStrip = new System.Windows.Forms.StatusStrip();
            this.PreviewWindowStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.glControlTabControlSplitContainer = new System.Windows.Forms.SplitContainer();
            this.optionsTabControl = new System.Windows.Forms.TabControl();
            this.renderOptionsTab = new System.Windows.Forms.TabPage();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.backgroundLabel = new System.Windows.Forms.Label();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.resetCameraButton = new System.Windows.Forms.Button();
            this.modelScaleLabel = new System.Windows.Forms.Label();
            this.modelScaleTrackbar = new System.Windows.Forms.TrackBar();
            this.yOffsetTrackbar = new System.Windows.Forms.TrackBar();
            this.VerticalOffsetLabel = new System.Windows.Forms.Label();
            this.animationOptionsTab = new System.Windows.Forms.TabPage();
            this.playAnimationButton = new System.Windows.Forms.Button();
            this.nextKeyFrameButton = new System.Windows.Forms.Button();
            this.previousKeyFrameButton = new System.Windows.Forms.Button();
            this.keyFrameControlLabel = new System.Windows.Forms.Label();
            this.currentAnimationComboBox = new System.Windows.Forms.ComboBox();
            this.currentAnimationLabel = new System.Windows.Forms.Label();
            this.enableAnimationCheckBox = new System.Windows.Forms.CheckBox();
            this.glTabModelListBoxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.PreviewWindowMenuStrip.SuspendLayout();
            this.PreviewWindowStatusStrip.SuspendLayout();
            this.glControlTabControlSplitContainer.Panel1.SuspendLayout();
            this.glControlTabControlSplitContainer.Panel2.SuspendLayout();
            this.glControlTabControlSplitContainer.SuspendLayout();
            this.optionsTabControl.SuspendLayout();
            this.renderOptionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelScaleTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yOffsetTrackbar)).BeginInit();
            this.animationOptionsTab.SuspendLayout();
            this.glTabModelListBoxSplitContainer.Panel1.SuspendLayout();
            this.glTabModelListBoxSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControlMain
            // 
            this.glControlMain.BackColor = System.Drawing.Color.Black;
            this.glControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControlMain.Location = new System.Drawing.Point(0, 0);
            this.glControlMain.Name = "glControlMain";
            this.glControlMain.Size = new System.Drawing.Size(612, 292);
            this.glControlMain.TabIndex = 6;
            this.glControlMain.VSync = true;
            // 
            // PreviewWindowMenuStrip
            // 
            this.PreviewWindowMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePreviewWindowMenuStrip,
            this.aboutPreviewWindowMenuStrip});
            this.PreviewWindowMenuStrip.Location = new System.Drawing.Point(10, 10);
            this.PreviewWindowMenuStrip.Name = "PreviewWindowMenuStrip";
            this.PreviewWindowMenuStrip.Size = new System.Drawing.Size(612, 24);
            this.PreviewWindowMenuStrip.TabIndex = 7;
            this.PreviewWindowMenuStrip.Text = "PreviewWindowMenuStrip";
            // 
            // filePreviewWindowMenuStrip
            // 
            this.filePreviewWindowMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripSeparator,
            this.closeToolStripMenuItem});
            this.filePreviewWindowMenuStrip.Name = "filePreviewWindowMenuStrip";
            this.filePreviewWindowMenuStrip.Size = new System.Drawing.Size(37, 20);
            this.filePreviewWindowMenuStrip.Text = "File";
            // 
            // fileToolStripSeparator
            // 
            this.fileToolStripSeparator.Name = "fileToolStripSeparator";
            this.fileToolStripSeparator.Size = new System.Drawing.Size(99, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // aboutPreviewWindowMenuStrip
            // 
            this.aboutPreviewWindowMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.aboutPreviewWindowMenuStrip.Name = "aboutPreviewWindowMenuStrip";
            this.aboutPreviewWindowMenuStrip.Size = new System.Drawing.Size(50, 20);
            this.aboutPreviewWindowMenuStrip.Text = "About";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.aboutToolStripMenuItem.Text = "About LOLViewer...";
            // 
            // PreviewWindowStatusStrip
            // 
            this.PreviewWindowStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreviewWindowStatusLabel});
            this.PreviewWindowStatusStrip.Location = new System.Drawing.Point(10, 418);
            this.PreviewWindowStatusStrip.Name = "PreviewWindowStatusStrip";
            this.PreviewWindowStatusStrip.Size = new System.Drawing.Size(612, 22);
            this.PreviewWindowStatusStrip.TabIndex = 8;
            this.PreviewWindowStatusStrip.Text = "statusStrip1";
            // 
            // PreviewWindowStatusLabel
            // 
            this.PreviewWindowStatusLabel.Name = "PreviewWindowStatusLabel";
            this.PreviewWindowStatusLabel.Size = new System.Drawing.Size(71, 17);
            this.PreviewWindowStatusLabel.Text = "Stop Feedin!";
            // 
            // glControlTabControlSplitContainer
            // 
            this.glControlTabControlSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControlTabControlSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.glControlTabControlSplitContainer.Name = "glControlTabControlSplitContainer";
            this.glControlTabControlSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // glControlTabControlSplitContainer.Panel1
            // 
            this.glControlTabControlSplitContainer.Panel1.Controls.Add(this.glControlMain);
            this.glControlTabControlSplitContainer.Panel1MinSize = 85;
            // 
            // glControlTabControlSplitContainer.Panel2
            // 
            this.glControlTabControlSplitContainer.Panel2.Controls.Add(this.optionsTabControl);
            this.glControlTabControlSplitContainer.Panel2MinSize = 85;
            this.glControlTabControlSplitContainer.Size = new System.Drawing.Size(612, 384);
            this.glControlTabControlSplitContainer.SplitterDistance = 292;
            this.glControlTabControlSplitContainer.TabIndex = 9;
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.Controls.Add(this.renderOptionsTab);
            this.optionsTabControl.Controls.Add(this.animationOptionsTab);
            this.optionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            this.optionsTabControl.Size = new System.Drawing.Size(612, 88);
            this.optionsTabControl.TabIndex = 0;
            // 
            // renderOptionsTab
            // 
            this.renderOptionsTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.renderOptionsTab.Controls.Add(this.backgroundColorButton);
            this.renderOptionsTab.Controls.Add(this.backgroundLabel);
            this.renderOptionsTab.Controls.Add(this.cameraLabel);
            this.renderOptionsTab.Controls.Add(this.resetCameraButton);
            this.renderOptionsTab.Controls.Add(this.modelScaleLabel);
            this.renderOptionsTab.Controls.Add(this.modelScaleTrackbar);
            this.renderOptionsTab.Controls.Add(this.yOffsetTrackbar);
            this.renderOptionsTab.Controls.Add(this.VerticalOffsetLabel);
            this.renderOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.renderOptionsTab.Name = "renderOptionsTab";
            this.renderOptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.renderOptionsTab.Size = new System.Drawing.Size(604, 62);
            this.renderOptionsTab.TabIndex = 0;
            this.renderOptionsTab.Text = "Rendering Options";
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Location = new System.Drawing.Point(523, 16);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(75, 23);
            this.backgroundColorButton.TabIndex = 7;
            this.backgroundColorButton.Text = "Color";
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Location = new System.Drawing.Point(529, 0);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(65, 13);
            this.backgroundLabel.TabIndex = 6;
            this.backgroundLabel.Text = "Background";
            // 
            // cameraLabel
            // 
            this.cameraLabel.AutoSize = true;
            this.cameraLabel.Location = new System.Drawing.Point(449, 0);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(43, 13);
            this.cameraLabel.TabIndex = 5;
            this.cameraLabel.Text = "Camera";
            // 
            // resetCameraButton
            // 
            this.resetCameraButton.Location = new System.Drawing.Point(433, 16);
            this.resetCameraButton.Name = "resetCameraButton";
            this.resetCameraButton.Size = new System.Drawing.Size(75, 23);
            this.resetCameraButton.TabIndex = 4;
            this.resetCameraButton.Text = "(R)eset";
            this.resetCameraButton.UseVisualStyleBackColor = true;
            // 
            // modelScaleLabel
            // 
            this.modelScaleLabel.AutoSize = true;
            this.modelScaleLabel.Location = new System.Drawing.Point(86, 3);
            this.modelScaleLabel.Name = "modelScaleLabel";
            this.modelScaleLabel.Size = new System.Drawing.Size(66, 13);
            this.modelScaleLabel.TabIndex = 3;
            this.modelScaleLabel.Text = "Model Scale";
            // 
            // modelScaleTrackbar
            // 
            this.modelScaleTrackbar.LargeChange = 50;
            this.modelScaleTrackbar.Location = new System.Drawing.Point(8, 16);
            this.modelScaleTrackbar.Maximum = 550;
            this.modelScaleTrackbar.Minimum = 10;
            this.modelScaleTrackbar.Name = "modelScaleTrackbar";
            this.modelScaleTrackbar.Size = new System.Drawing.Size(212, 40);
            this.modelScaleTrackbar.TabIndex = 2;
            this.modelScaleTrackbar.TickFrequency = 50;
            this.modelScaleTrackbar.Value = 110;
            // 
            // yOffsetTrackbar
            // 
            this.yOffsetTrackbar.LargeChange = 25;
            this.yOffsetTrackbar.Location = new System.Drawing.Point(226, 16);
            this.yOffsetTrackbar.Maximum = 800;
            this.yOffsetTrackbar.Minimum = 10;
            this.yOffsetTrackbar.Name = "yOffsetTrackbar";
            this.yOffsetTrackbar.Size = new System.Drawing.Size(201, 40);
            this.yOffsetTrackbar.TabIndex = 1;
            this.yOffsetTrackbar.TickFrequency = 25;
            this.yOffsetTrackbar.Value = 10;
            // 
            // VerticalOffsetLabel
            // 
            this.VerticalOffsetLabel.AutoSize = true;
            this.VerticalOffsetLabel.Location = new System.Drawing.Point(288, 3);
            this.VerticalOffsetLabel.Name = "VerticalOffsetLabel";
            this.VerticalOffsetLabel.Size = new System.Drawing.Size(77, 13);
            this.VerticalOffsetLabel.TabIndex = 0;
            this.VerticalOffsetLabel.Text = "Model Y Offset";
            // 
            // animationOptionsTab
            // 
            this.animationOptionsTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.animationOptionsTab.Controls.Add(this.playAnimationButton);
            this.animationOptionsTab.Controls.Add(this.nextKeyFrameButton);
            this.animationOptionsTab.Controls.Add(this.previousKeyFrameButton);
            this.animationOptionsTab.Controls.Add(this.keyFrameControlLabel);
            this.animationOptionsTab.Controls.Add(this.currentAnimationComboBox);
            this.animationOptionsTab.Controls.Add(this.currentAnimationLabel);
            this.animationOptionsTab.Controls.Add(this.enableAnimationCheckBox);
            this.animationOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.animationOptionsTab.Name = "animationOptionsTab";
            this.animationOptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.animationOptionsTab.Size = new System.Drawing.Size(604, 62);
            this.animationOptionsTab.TabIndex = 1;
            this.animationOptionsTab.Text = "Animation Options";
            // 
            // playAnimationButton
            // 
            this.playAnimationButton.Location = new System.Drawing.Point(255, 19);
            this.playAnimationButton.Name = "playAnimationButton";
            this.playAnimationButton.Size = new System.Drawing.Size(75, 23);
            this.playAnimationButton.TabIndex = 6;
            this.playAnimationButton.Text = "Play";
            this.playAnimationButton.UseVisualStyleBackColor = true;
            // 
            // nextKeyFrameButton
            // 
            this.nextKeyFrameButton.Location = new System.Drawing.Point(414, 19);
            this.nextKeyFrameButton.Name = "nextKeyFrameButton";
            this.nextKeyFrameButton.Size = new System.Drawing.Size(75, 23);
            this.nextKeyFrameButton.TabIndex = 5;
            this.nextKeyFrameButton.Text = "Next";
            this.nextKeyFrameButton.UseVisualStyleBackColor = true;
            // 
            // previousKeyFrameButton
            // 
            this.previousKeyFrameButton.Location = new System.Drawing.Point(333, 19);
            this.previousKeyFrameButton.Name = "previousKeyFrameButton";
            this.previousKeyFrameButton.Size = new System.Drawing.Size(75, 23);
            this.previousKeyFrameButton.TabIndex = 4;
            this.previousKeyFrameButton.Text = "Previous";
            this.previousKeyFrameButton.UseVisualStyleBackColor = true;
            // 
            // keyFrameControlLabel
            // 
            this.keyFrameControlLabel.AutoSize = true;
            this.keyFrameControlLabel.Location = new System.Drawing.Point(365, 1);
            this.keyFrameControlLabel.Name = "keyFrameControlLabel";
            this.keyFrameControlLabel.Size = new System.Drawing.Size(98, 13);
            this.keyFrameControlLabel.TabIndex = 3;
            this.keyFrameControlLabel.Text = "Key Frame Controls";
            // 
            // currentAnimationComboBox
            // 
            this.currentAnimationComboBox.FormattingEnabled = true;
            this.currentAnimationComboBox.Location = new System.Drawing.Point(128, 19);
            this.currentAnimationComboBox.Name = "currentAnimationComboBox";
            this.currentAnimationComboBox.Size = new System.Drawing.Size(121, 21);
            this.currentAnimationComboBox.TabIndex = 2;
            // 
            // currentAnimationLabel
            // 
            this.currentAnimationLabel.AutoSize = true;
            this.currentAnimationLabel.Location = new System.Drawing.Point(142, 3);
            this.currentAnimationLabel.Name = "currentAnimationLabel";
            this.currentAnimationLabel.Size = new System.Drawing.Size(90, 13);
            this.currentAnimationLabel.TabIndex = 1;
            this.currentAnimationLabel.Text = "Current Animation";
            // 
            // enableAnimationCheckBox
            // 
            this.enableAnimationCheckBox.AutoSize = true;
            this.enableAnimationCheckBox.Location = new System.Drawing.Point(7, 6);
            this.enableAnimationCheckBox.Name = "enableAnimationCheckBox";
            this.enableAnimationCheckBox.Size = new System.Drawing.Size(107, 17);
            this.enableAnimationCheckBox.TabIndex = 0;
            this.enableAnimationCheckBox.Text = "Enable Animation";
            this.enableAnimationCheckBox.UseVisualStyleBackColor = true;
            // 
            // glTabModelListBoxSplitContainer
            // 
            this.glTabModelListBoxSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glTabModelListBoxSplitContainer.Location = new System.Drawing.Point(10, 34);
            this.glTabModelListBoxSplitContainer.Name = "glTabModelListBoxSplitContainer";
            // 
            // glTabModelListBoxSplitContainer.Panel1
            // 
            this.glTabModelListBoxSplitContainer.Panel1.Controls.Add(this.glControlTabControlSplitContainer);
            this.glTabModelListBoxSplitContainer.Panel1MinSize = 400;
            this.glTabModelListBoxSplitContainer.Panel2Collapsed = true;
            this.glTabModelListBoxSplitContainer.Panel2MinSize = 150;
            this.glTabModelListBoxSplitContainer.Size = new System.Drawing.Size(612, 384);
            this.glTabModelListBoxSplitContainer.SplitterDistance = 458;
            this.glTabModelListBoxSplitContainer.TabIndex = 11;
            // 
            // PreviewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.glTabModelListBoxSplitContainer);
            this.Controls.Add(this.PreviewWindowStatusStrip);
            this.Controls.Add(this.PreviewWindowMenuStrip);
            this.MainMenuStrip = this.PreviewWindowMenuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "PreviewWindow";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "LOLViewer 1.1 Skin Previewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewWindow_FormClosing);
            this.PreviewWindowMenuStrip.ResumeLayout(false);
            this.PreviewWindowMenuStrip.PerformLayout();
            this.PreviewWindowStatusStrip.ResumeLayout(false);
            this.PreviewWindowStatusStrip.PerformLayout();
            this.glControlTabControlSplitContainer.Panel1.ResumeLayout(false);
            this.glControlTabControlSplitContainer.Panel2.ResumeLayout(false);
            this.glControlTabControlSplitContainer.ResumeLayout(false);
            this.optionsTabControl.ResumeLayout(false);
            this.renderOptionsTab.ResumeLayout(false);
            this.renderOptionsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelScaleTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yOffsetTrackbar)).EndInit();
            this.animationOptionsTab.ResumeLayout(false);
            this.animationOptionsTab.PerformLayout();
            this.glTabModelListBoxSplitContainer.Panel1.ResumeLayout(false);
            this.glTabModelListBoxSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControlMain;
        private System.Windows.Forms.MenuStrip PreviewWindowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem filePreviewWindowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPreviewWindowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip PreviewWindowStatusStrip;
        private System.Windows.Forms.SplitContainer glControlTabControlSplitContainer;
        private System.Windows.Forms.TabControl optionsTabControl;
        private System.Windows.Forms.TabPage renderOptionsTab;
        private System.Windows.Forms.TabPage animationOptionsTab;
        private System.Windows.Forms.SplitContainer glTabModelListBoxSplitContainer;
        private System.Windows.Forms.TrackBar yOffsetTrackbar;
        private System.Windows.Forms.Label VerticalOffsetLabel;
        private System.Windows.Forms.TrackBar modelScaleTrackbar;
        private System.Windows.Forms.Label modelScaleLabel;
        private System.Windows.Forms.CheckBox enableAnimationCheckBox;
        private System.Windows.Forms.Label currentAnimationLabel;
        private System.Windows.Forms.ComboBox currentAnimationComboBox;
        private System.Windows.Forms.Button previousKeyFrameButton;
        private System.Windows.Forms.Label keyFrameControlLabel;
        private System.Windows.Forms.Button nextKeyFrameButton;
        private System.Windows.Forms.Button playAnimationButton;
        private System.Windows.Forms.Label cameraLabel;
        private System.Windows.Forms.Button resetCameraButton;
        private System.Windows.Forms.ToolStripSeparator fileToolStripSeparator;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Label backgroundLabel;
        private System.Windows.Forms.ToolStripStatusLabel PreviewWindowStatusLabel;
    }
}

