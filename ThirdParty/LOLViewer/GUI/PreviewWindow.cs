
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

//
// Main GUI for the program.
//


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenTK;
using LOLViewer.IO;
using System.IO;

namespace LOLViewer
{
    public partial class PreviewWindow : Form
    {
        // Windowing variables
        private bool isGLLoaded;
        private Stopwatch timer;

        // Graphics abstraction
        private GLRenderer renderer;

        // Default Camera
        private const float FIELD_OF_VIEW = OpenTK.MathHelper.PiOver4;
        private const float NEAR_PLANE = 0.1f;
        private const float FAR_PLANE = 1000.0f;
        private GLCamera camera;

        // IO Variables
        public LOLDirectoryReader reader;
        
        // GUI Variables
        // converts from World Transform scale to trackbar units.
        private const float DEFAULT_SCALE_TRACKBAR = 1000.0f;

        // Animation Control Handle
        private AnimationController animationController;
       
        public PreviewWindow(string rootPath)
        {
            isGLLoaded = false;
            timer = new Stopwatch();

            camera = new GLCamera();
            camera.SetViewParameters(new Vector3(0.0f, 0.0f, 300.0f), Vector3.Zero);
            renderer = new GLRenderer();

            reader = new LOLDirectoryReader();
            reader.SetRoot(rootPath);

            InitializeComponent();
            modelScaleTrackbar.Value = (int) (GLRenderer.DEFAULT_MODEL_SCALE * DEFAULT_SCALE_TRACKBAR);
            yOffsetTrackbar.Value = -GLRenderer.DEFAULT_MODEL_YOFFSET;

            // Main window Callbacks
            this.Shown += new EventHandler(OnPreviewWindowShown);

            // GLControl Callbacks
            glControlMain.Load += new EventHandler(GLControlMainOnLoad);
            glControlMain.Resize += new EventHandler(GLControlMainOnResize);
            glControlMain.Paint += new PaintEventHandler(GLControlMainOnPaint);
            glControlMain.Disposed += new EventHandler(GLControlMainOnDispose);

            // Set mouse events
            glControlMain.MouseDown += new MouseEventHandler(GLControlOnMouseDown);
            glControlMain.MouseUp += new MouseEventHandler(GLControlOnMouseUp);
            glControlMain.MouseWheel += new MouseEventHandler(GLControlOnMouseWheel);
            glControlMain.MouseMove += new MouseEventHandler(GLControlOnMouseMove);

            // Set keyboard events
            glControlMain.KeyDown += new KeyEventHandler(GLControlMainOnKeyDown);
            glControlMain.KeyUp += new KeyEventHandler(GLControlMainOnKeyUp);

            // Menu Callbacks
            closeToolStripMenuItem.Click += new EventHandler(OnClose);
            aboutToolStripMenuItem.Click += new EventHandler(OnAbout);
            
            // Trackbars
            yOffsetTrackbar.Scroll += new EventHandler(YOffsetTrackbarOnScroll);
            modelScaleTrackbar.Scroll += new EventHandler(ModelScaleTrackbarOnScroll);

            // Buttons
            resetCameraButton.Click += new EventHandler(OnResetCameraButtonClick);
            backgroundColorButton.Click += new EventHandler(OnBackgroundColorButtonClick);

            // Animation Controller
            animationController = new AnimationController();

            // Set references
            animationController.enableAnimationCheckBox = enableAnimationCheckBox;
            animationController.currentAnimationComboBox = currentAnimationComboBox;
            animationController.nextKeyFrameButton = nextKeyFrameButton;
            animationController.playAnimationButton = playAnimationButton;
            animationController.previousKeyFrameButton = previousKeyFrameButton;
            animationController.glControlMain = glControlMain;

            animationController.renderer = renderer;

            // Set callbacks.
            enableAnimationCheckBox.Click += new EventHandler(animationController.OnEnableCheckBoxClick);
            previousKeyFrameButton.Click += new EventHandler(animationController.OnPreviousKeyFrameButtonClick);
            nextKeyFrameButton.Click += new EventHandler(animationController.OnNextKeyFrameButtonClick);
            playAnimationButton.Click += new EventHandler(animationController.OnPlayAnimationButtonClick);
            currentAnimationComboBox.SelectedIndexChanged += new EventHandler(animationController.OnCurrentAnimationComboBoxSelectedIndexChanged);

            animationController.DisableAnimation();
            //renderer.SetClearColor(System.Drawing.Color.LightGray);

            OnReadModels(null,null);
        }

        //
        // Main Window Handlers
        //

        void OnPreviewWindowShown(object sender, EventArgs e)
        {
            // Read model files.
            if(reader.models.Count<1)OnReadModels(sender, e);
        }

        //
        // Return the model name that uses the file name provided
        //
        string getModelNameFromFileName(string fileName)
        {
            return reader.GetModelNameFromFileName(fileName);
        }

        //
        // Return the model that uses some of the files given
        //
        LOLModel getModelFromFileNames(List<String> fileNames)
        {
            LOLModel result = null;
            foreach (String fileName in fileNames)
            {
                String modelName = getModelNameFromFileName(fileName);
                if (modelName != "")
                {
                    result= reader.GetModel(modelName);
                    string[] parts = modelName.Split('/');
                    if (parts.Length > 1)
                    {
                        if (parts[0] == parts[1])
                        {
                            // this is the default skin, like Shen/Shen
                            // keep it.
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        //
        // Make the display preview a modified skin
        // This expects that at least one of the files
        // name is the same as one of a LoL Model
        //
        public void previewModel(List<String> fileNames)
        {
            //make sure that we have read the models first..            
            if (reader.models.Count < 1) OnReadModels(null, null);
            //find out what model the files we have is mostly moding
            LOLModel model = getModelFromFileNames(fileNames);
            if (model == null) return;
            // we need to replace any of the normal files with any that we have changed
            bool replaceing = true;
            if (replaceing)
            {
                FileInfo sknFile = new FileInfo(model.skn.FileName);
                FileInfo sklFile = new FileInfo(model.skl.FileName);
                FileInfo txtFile = new FileInfo(model.texture.FileName);

                foreach (String fileName in fileNames)
                {
                    FileInfo fileNameInfo = new FileInfo(fileName);

                    if (sknFile.Name.Equals(fileNameInfo.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        model.skn.FileName = fileName;
                    }
                    if (sklFile.Name.Equals(fileNameInfo.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        model.skl.FileName = fileName;
                    }
                    if (txtFile.Name.Equals(fileNameInfo.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        model.texture.FileName = fileName;
                    }
                    //animations
                    foreach (KeyValuePair<String,RAFLib.RAFFileListEntry> kv in model.animations)
                    {
                        FileInfo animFile = new FileInfo(kv.Value.FileName);
                        if (animFile.Name.Equals(fileNameInfo.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            kv.Value.FileName = fileName;
                        }

                    }
                }
            }
            animationController.DisableAnimation();
            this.enableAnimationCheckBox.Checked = false;
            loadModel(model);
        }

        //
        // GLControl Handlers
        //
        #region GLControl Handlers

        public void GLControlMainOnPaint(object sender, PaintEventArgs e)
        {
            if (isGLLoaded == false)
                return;

            renderer.OnRender(camera);

            glControlMain.SwapBuffers();
        }

        public void GLControlMainOnResize(object sender, EventArgs e)
        {
            if (isGLLoaded == false)
                return;

            // Set up camera projection parameters based on window's size.
            camera.SetProjectionParameters(FIELD_OF_VIEW, (float)(glControlMain.ClientRectangle.Width - glControlMain.ClientRectangle.X),
                (float)(glControlMain.ClientRectangle.Height - glControlMain.ClientRectangle.Y),
                NEAR_PLANE, FAR_PLANE);

            renderer.OnResize(glControlMain.ClientRectangle.X, glControlMain.ClientRectangle.Y,
                glControlMain.ClientRectangle.Width, glControlMain.ClientRectangle.Height);

            GLControlMainOnUpdateFrame(sender, e);
        }

        public void GLControlMainOnLoad(object sender, EventArgs e)
        {
            isGLLoaded = true;

            // Set up renderer.
            bool result = renderer.OnLoad();
            if (result == false)
            {
                this.Close();
                return;
            }

            // Call an initial resize to get some camera and renderer parameters set up.
            GLControlMainOnResize(sender, e);
            timer.Start();
        }

        public void GLControlMainOnUpdateFrame(object sender, EventArgs e)
        {
            double elapsedTime = ComputeElapsedTime();

            // Update camera and animation controller.
            camera.OnUpdate((float) elapsedTime);
            animationController.OnApplicationIdle(sender, e);

            // Hacky, prevents double invalidation.
            if (animationController.isAnimating == false)
            {
                glControlMain.Invalidate();
            }
        }

        void GLControlMainOnDispose(object sender, EventArgs e)
        {
            renderer.ShutDown();
        }

        //
        // Mouse Handlers
        //

        private void GLControlOnMouseMove(object sender, MouseEventArgs e)
        {
            camera.OnMouseMove(e);
            GLControlMainOnUpdateFrame(sender, e);
        }

        private void GLControlOnMouseWheel(object sender, MouseEventArgs e)
        {
            camera.OnMouseWheel(e);
            GLControlMainOnUpdateFrame(sender, e);
        }

        private void GLControlOnMouseUp(object sender, MouseEventArgs e)
        {
            camera.OnMouseButtonUp(e);
            GLControlMainOnUpdateFrame(sender, e);
        }

        private void GLControlOnMouseDown(object sender, MouseEventArgs e)
        {
            camera.OnMouseButtonDown(e);
            GLControlMainOnUpdateFrame(sender, e);
        }

        //
        // Keyboard Handlers
        //

        void GLControlMainOnKeyUp(object sender, KeyEventArgs e)
        {
            camera.OnKeyUp(e);
            GLControlMainOnUpdateFrame(sender, e);
        }

        void GLControlMainOnKeyDown(object sender, KeyEventArgs e)
        {
            camera.OnKeyDown(e);
            GLControlMainOnUpdateFrame(sender, e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }
        #endregion
        //
        // Menu Strip Handlers
        //
        #region Menu Strip Handlers

        void OnAbout(object sender, EventArgs e)
        {
            AboutWindow aboutDlg = new AboutWindow();
            aboutDlg.ShowDialog();
        }

        void OnClose(object sender, EventArgs e)
        {
            this.Hide();
            //this.Close();
        }

        void OnReadModels(object sender, EventArgs e)
        {
            renderer.DestroyCurrentModels();
            glControlMain.Invalidate();

            LoadingModelsWindow loader = new LoadingModelsWindow();
            loader.reader = reader;
            loader.ShowDialog();

            DialogResult result = loader.result;
            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Unable to read models. If you installed League of legends" +
                                 " in a non-default location, change the default directory" +
                                 " to the 'League of Legends' folder by using the command in the 'Options' menu.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }

            List<String> modelNames = reader.GetModelNames();
            
        }
        #endregion
        //
        // Load a model with a correct name
        //
        public void loadModel(String modelName)
        {
            // TODO: Not really sure how to handle errors
            // if either of these functions fail.
            LOLModel model = reader.GetModel(modelName);
            loadModel(model);
        }
        public void loadModel(LOLModel model)
        {
            if (model != null)
            {
                bool result = renderer.LoadModel(model);

                currentAnimationComboBox.Items.Clear();
                foreach (var a in model.animations)
                {
                    currentAnimationComboBox.Items.Add(a.Key);
                }

                currentAnimationComboBox.Text = "";

                if (currentAnimationComboBox.Items.Count > 0)
                {
                    currentAnimationComboBox.SelectedIndex = 0;
                }
            }

            GLControlMainOnUpdateFrame(this, null);
        }

        //
        // Trackbar Handlers
        //
        void YOffsetTrackbarOnScroll(object sender, EventArgs e)
        {
            Matrix4 world = Matrix4.Scale(modelScaleTrackbar.Value / DEFAULT_SCALE_TRACKBAR);
            world.M42 = (float)-yOffsetTrackbar.Value;
            renderer.world = world;

            // Redraw.
            GLControlMainOnPaint(sender, null);
        }

        void ModelScaleTrackbarOnScroll(object sender, EventArgs e)
        {
            Matrix4 world = Matrix4.Scale(modelScaleTrackbar.Value / DEFAULT_SCALE_TRACKBAR);
            world.M42 = (float)-yOffsetTrackbar.Value;
            renderer.world = world;

            // Redraw.
            GLControlMainOnPaint(sender, null);
        }

        // Button Handlers
        void OnResetCameraButtonClick(object sender, EventArgs e)
        {
            camera.Reset();
            // Redraw.
            glControlMain.Invalidate();
        }

        void OnBackgroundColorButtonClick(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();

            Color iniColor = Color.FromArgb( (int) (renderer.clearColor.A * 255),
                (int) (renderer.clearColor.R * 255), (int) (renderer.clearColor.G * 255),
                (int) (renderer.clearColor.B * 255) );

            colorDlg.Color = iniColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                renderer.SetClearColor(colorDlg.Color);

                glControlMain.Invalidate();
            }
        }

        //
        // Helper Functions
        //

        public double ComputeElapsedTime()
        {
            timer.Stop();
            double elapsedTime = timer.Elapsed.TotalSeconds;
            timer.Reset();
            timer.Start();
            return elapsedTime;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void PreviewWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
