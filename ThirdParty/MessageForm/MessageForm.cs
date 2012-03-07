//********************************************************************************************
//Author: Sergey Stoyan, CliverSoft.com
//        http://cliversoft.com
//        stoyan@cliversoft.com
//        sergey.stoyan@gmail.com
//        03 January 2008
//Copyright: (C) 2008, Sergey Stoyan
//********************************************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Cliver
{
    /// <summary>
    /// Dynamic dialog box with many answer cases
    /// </summary>
    public partial class MessageForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Vertical span in pixels between controls 
        /// </summary>
        public int SpanY = 12;

        /// <summary>
        /// Horizontal span in pixels between controls 
        /// </summary>
        public int SpanX = 16;

        /// <summary>
        /// Span between button horizontal bound and its text
        /// </summary>
        public int ButtonInternalMarginX = 6;

        /// <summary>
        /// Span between button vertical bound and its text
        /// </summary>
        public int ButtonInternalMarginY = 3;

        /// <summary>
        /// Desired proportion of the message label (not dialog window!) sides
        /// </summary>
        public float MessageBoxWidth2HeightDesiredRegard = 4;

        /// <summary>
        /// Max size of window.
        /// </summary>
        public Size MaxWindowSize = new Size((int)((float)SystemInformation.PrimaryMonitorMaximizedWindowSize.Width / 1.5), (int)((float)SystemInformation.PrimaryMonitorMaximizedWindowSize.Height / 1.5));

        /// <summary>
        /// Construct dynamic dialog box with many answer cases
        /// </summary>
        /// <param name="caption">window caption</param>
        /// <param name="message">message information</param>
        /// <param name="button_colors">button colors</param>
        /// <param name="answers">array of possible answers</param>
        /// <param name="default_answer">default answer zero-based index</param>
        /// <param name="silent_box_text">silent check box text; if null then check box will not be displayed</param>
        /// <param name="icon">icon to be displayed</param>
        public MessageForm(string caption, string message, Color[] button_colors, string[] answers, int default_answer, string silent_box_text, Icon icon)
        {
            InitializeComponent();

            Image image = null;
            if (icon != null)
                image = (Image)icon.ToBitmap();

            construct_form(caption, message, button_colors, answers, default_answer, silent_box_text, image);
        }

        /// <summary>
        /// Construct dynamic dialog box with many answer cases
        /// </summary>
        /// <param name="caption">window caption</param>
        /// <param name="message">message information</param>
        /// <param name="button_colors">button colors</param>
        /// <param name="answers">array of possible answers</param>
        /// <param name="default_answer">default answer zero-based index</param>
        /// <param name="silent_box_text">silent check box text; if null then check box will not be displayed</param>
        /// <param name="image">image to be displayed as the message icon</param>
        public MessageForm(string caption, string message, Color[] button_colors, string[] answers, int default_answer, string silent_box_text, Image image)
        {
            InitializeComponent();

            construct_form(caption, message, button_colors, answers, default_answer, silent_box_text, image);
        }

        //public class Answer
        //{
        //    public string ButtonText;
        //    public Color ButtonColor = Color.Empty;
        //}

        void construct_form(string caption, string message, Color[] button_colors, string[] answers, int default_answer, string silent_box_text, Image image)
        {
            this.Text = caption;

            if (answers == null || answers.Length < 1)
                answers = new string[1] { "OK" };

            if (button_colors == null)
                button_colors = new Color[0];

            if (default_answer <= 0)
                default_answer = 0;
            else if (default_answer >= answers.Length)
                default_answer = answers.Length - 1;

            Point next_point = new Point(0, 0);

            {//set icon
                if (image != null)
                {
                    this.image_box.Image = image;
                    this.image_box.Size = image.Size;
                    next_point.X = this.image_box.Right + SpanX;
                    next_point.Y = this.image_box.Bottom + SpanY;
                }
                else
                {
                    this.Controls.Remove(image_box);
                    image_box.Dispose();
                    image_box = null;
                    next_point.X = this.button_sample.Left;
                    next_point.Y = 0;
                }
            }

            {//calculate button size
                Size max_text_size = new Size(0, 0);
                using (Graphics graphics = button_sample.CreateGraphics())
                {
                    int button_max_width = MaxWindowSize.Width - button_sample.Left * 2;
                    foreach (string a in answers)
                    {
                        SizeF sf = graphics.MeasureString(a, button_sample.Font, button_max_width);
                        if (sf.Width > max_text_size.Width)
                            max_text_size.Width = (int)sf.Width;
                        if (sf.Height > max_text_size.Height)
                            max_text_size.Height = (int)sf.Height;
                    }
                }
                //button size cannot be decreased
                if (button_sample.Width < max_text_size.Width + 2 * ButtonInternalMarginX)
                    button_sample.Width = max_text_size.Width + 2 * ButtonInternalMarginX;
                if (button_sample.Height < max_text_size.Height + 2 * ButtonInternalMarginY)
                    button_sample.Height = max_text_size.Height + 2 * ButtonInternalMarginY;
            }

            bool locate_buttons_vertically = true;
            {//define whether buttons will be located vertically
                int width = button_sample.Left + button_sample.Width * answers.Length + SpanX * (answers.Length - 1) + button_sample.Left;
                if (width > MaxWindowSize.Width)
                {//locate buttons vertically
                    locate_buttons_vertically = true;
                    width = button_sample.Left + button_sample.Width + button_sample.Left;
                    if (width >= this.ClientSize.Width)
                        //this.Width = width;
                        this.ClientSize = new Size(width, this.ClientSize.Height);
                }
                else
                {//locate buttons horisontally
                    locate_buttons_vertically = false;
                    if (width >= this.ClientSize.Width)
                        //this.Width = width;
                        this.ClientSize = new Size(width, this.ClientSize.Height);
                }
            }

            {//calculate label size
                int label_right_margin = this.button_sample.Left; //this.Width - this.label.Right;//this.image.Right + SpanX;//
                if (image_box == null)
                    label_right_margin = this.button_sample.Left;
                label.Left = next_point.X;
                Graphics graphics = label.CreateGraphics();
                int label_min_width = this.ClientSize.Width - label.Left - label_right_margin;
                SizeF l_size = graphics.MeasureString(message, label.Font, label_min_width, StringFormat.GenericDefault);
                int label_desired_width = (int)Math.Sqrt(l_size.Width * l_size.Height * MessageBoxWidth2HeightDesiredRegard);
                if (label_desired_width > label_min_width)
                {
                    int label_max_width = MaxWindowSize.Width - label.Left - label_right_margin;
                    if (label_desired_width > label_max_width)
                        label_desired_width = label_max_width;
                    l_size = graphics.MeasureString(message, label.Font, label_desired_width, StringFormat.GenericDefault);
                    //int label_max_height = (int)(l_size.Width / MessageBoxWidth2HeightDesiredRegard);
                    if (l_size.Width > label_min_width)
                        this.label.Width = (int)l_size.Width;
                    else
                        this.label.Width = label_min_width;
                }
                else
                {
                    this.label.Width = label_min_width;
                }
                this.label.Height = (int)l_size.Height;

                //enhance window width
                this.ClientSize = new Size(label.Right + label_right_margin, this.ClientSize.Height);
                if (locate_buttons_vertically)
                    button_sample.Width = this.ClientSize.Width - button_sample.Left - button_sample.Left;
                else
                    button_sample.Left = (int)(((float)(this.ClientSize.Width - button_sample.Width * answers.Length - SpanX * (answers.Length - 1))) / 2);
            }

            int bottom_edge = this.ClientSize.Height - silent_box.Bottom;
            {//tune window height
                int general_height = image_box != null ? this.image_box.Bottom : next_point.Y;
                if (general_height < label.Top + this.label.Height)
                    general_height += label.Top + this.label.Height;
                if (locate_buttons_vertically)
                    general_height += answers.Length * (button_sample.Height + SpanY);
                else
                    general_height += button_sample.Height + SpanY;
                if (silent_box_text != null)
                    general_height += silent_box.Height;
                general_height += bottom_edge;
                if (general_height > MaxWindowSize.Height)
                {
                    int diff = general_height - MaxWindowSize.Height;
                    if (diff + 200 < this.label.Height)
                        this.label.Height -= diff;
                    else
                        this.label.Height = 200;
                }
                label.Text = message;
            }

            if (next_point.Y < label.Bottom + SpanY)
                next_point.Y = label.Bottom + SpanY;

            next_point.X = button_sample.Left;

            {//set buttons
                int ind = 0;
                foreach (string a in answers)
                {
                    Button b = new Button();
                    if (button_colors.Length > ind)
                        b.BackColor = button_colors[ind];
                    b.Name = "button" + ind.ToString();
                    b.Size = button_sample.Size;
                    b.TabIndex = ind + 2;
                    b.Text = a;
                    b.ForeColor = Color.Black;
                    //b.UseVisualStyleBackColor = false;
                    b.Click += new System.EventHandler(this.button_Click);
                    b.Tag = ind;
                    b.Location = next_point;
                    if (locate_buttons_vertically)
                        next_point.Y += b.Height + SpanY;
                    else
                        next_point.X += b.Width + SpanX;

                    this.Controls.Add(b);
                    ind++;
                }

                if (!locate_buttons_vertically)
                    next_point.Y += button_sample.Height + SpanY;

                this.Controls.Remove(button_sample);
                button_sample.Dispose();
                button_sample = null;
            }

            {//set silent checkbox
                if (silent_box_text != null)
                {
                    Graphics graphics = silent_box.CreateGraphics();
                    SizeF sf = graphics.MeasureString(silent_box_text, silent_box.Font, this.ClientRectangle.Width - SpanX - SpanX - silent_box.Width);
                    Size s_size = silent_box.Size;
                    silent_box.AutoSize = false;
                    silent_box.Width = s_size.Width + (int)sf.Width;
                    silent_box.Height = (int)sf.Height + 4;
                    silent_box.Left = (int)((float)(this.ClientRectangle.Width - silent_box.Width) / 2);
                    silent_box.Top = next_point.Y;
                    next_point.Y = silent_box.Bottom + bottom_edge;
                    silent_box.Text = silent_box_text;
                }
                else
                {
                    this.Controls.Remove(silent_box);
                    silent_box.Dispose();
                    silent_box = null;
                    next_point.Y += bottom_edge - SpanY;
                }
            }

            this.ClientSize = new Size(this.ClientSize.Width, next_point.Y);
            if (this.Height > MaxWindowSize.Height)
            {
                this.Size = new Size(this.Size.Width, MaxWindowSize.Height);
                this.AutoScroll = true;
            }

            this.Controls["button" + default_answer.ToString()].Select();
        }

        /// <summary>
        /// Zero-based index of chosen answer. Cancel = -1
        /// </summary>
        public int Answer = -1;

        /// <summary>
        /// Show MessageForm as a dialog box and get user's answer
        /// </summary>
        /// <returns>zero-based index of chosen answer. Cancel = -1</returns>
        public int GetAnswer()
        {
            if (this.Owner == null)
            {
                //this.ShowInTaskbar = true;
                Form f = new Form();//needed to bring message box to front
                f.Icon = this.Icon;
                f.BringToFront();
                this.ShowDialog(f);
            }
            else
                this.ShowDialog();
            return Answer;
        }

        /// <summary>
        /// Whether this answer should be repeated automatically
        /// </summary>
        public bool Silent = false;

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Answer = (int)b.Tag;
            if (silent_box != null)
                Silent = silent_box.Checked;
            this.Close();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
        }
    }
}
