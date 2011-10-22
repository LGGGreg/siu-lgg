using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.IO;
using Cliver;

namespace Test
{
    static class Program
    {
        internal static Form1 f = new Form1();

        [STAThread]
        static void Main(string[] args)
        {
            goto Q;
        Q:
            //Program.f.Icon = null;// new Icon("../../_test.ico");
            //IconConverter d;d.
            //Icon t = IconHandler.ExtractIconFromFile("../../_test.ico", IconHandler.IconSize.Small);
            //Program.f.Icon = new Icon(typeof(Test.Program), "_test.ico");


            //test 2 threads
            Program.f.ShowDialog();

            /*string q = "qwerty";
            string c = "qwerty";
            for (int i = 0; i < 1000; i++)
                c += q + i.ToString();
            MessageBox.Show(c);*/

            //******************************************************************************
            //using Cliver.Message 
            //******************************************************************************

            ////toggle off coloring buttons
            //Cliver.Message.ButtonColors = null; 

            //set silent checkbox text once and for all
            Cliver.Message.SilentBoxText = "Repeat my answer for such cases during this backup session.";

            //show message box with ok button
            Cliver.Message.Inform("Message.Ok test");

            //Set message box caption once and for all
            Cliver.Message.Caption = "Backup Client";

            bool silent_box_state;
            int chosen_answer_index;

            //show message box with 3 buttons
            chosen_answer_index = Cliver.Message.Show(SystemIcons.Information, out silent_box_state, @"Local file c:\test.txt differs from the backup copy", 0,
                "Backup the newest file",
                "Download the backup copy",
                "Do nothing for now"
                );

            //show message box with 2 buttons
            do
            {
                chosen_answer_index = Cliver.Message.Show(SystemIcons.Error, "Connection lost", 0, "Try to reconnect", "Exit");
            }
            while (!silent_box_state && chosen_answer_index != 1);

            //show button non-clolored the next time
            Cliver.Message.NextTime_ButtonColors = null;
            if (Cliver.Message.YesNo("Do you like achromatic buttons?"))
                Cliver.Message.Inform("You are welcome using it!");
            else
                Cliver.Message.Inform("Great, then specify colors you like!");

            //message box with scrollbar
            string s = "Sometimes message box has to display an unpredictably long text (e.g. error stack). If the text requires too large space to be displayed completely, MessageForm automatically provides a scroll bar.\n";
            string m = "";
            for (int i = 0; i < 40; i++)
                m += s;
            Cliver.Message.Error(m);

            //does not show message box in taskbar
            Cliver.Message.ShowInTaskbar = false;
            Form1 f = new Form1();
            f.Show();
            //set owner for the next time
            Cliver.Message.NextTime_Owner = f;
            Cliver.Message.Inform("Owner is of my back.");
            f.Close();

            //message box without icon
            Cliver.Message.NextTime_ButtonColors = null;
            Cliver.Message.Show(null, "Message box without icon", 0, "OK");

            //******************************************************************************
            //using Cliver.MessageForm directly
            //******************************************************************************
            //Q:

            Image image = null;
            try
            {
                image = new Bitmap("../../copying2.jpg");
            }
            catch { }
            Cliver.MessageForm mf = new MessageForm(
                    "Using MessageForm directly",//caption
                    "Copying files from: 'c:\\test' to: 'c:\\test2'\nFile 'test.txt' already exists.",//message
                    new Color[6] {
                        Color.LightCoral,
                        Color.LightYellow,
                        Color.Empty,
                        Color.LightGreen,
                        Color.LightBlue,
                        Color.Empty,
                        },//button colors            
                    new string[6] { 
            "Overwrite",
            "Overwrite if older", 
            "Skip", 
            "Rename",
            "Append",
            "Cancel"
            },//array of answers
                    1,//default button
                    "Apply to all",//silent box text
                    image//message icon, can be set as an image
                );

            //set icon in the capture
            try
            {
                mf.Icon = new Icon("../../Globe.ico");
            }
            catch { }

            //show message form
            mf.GetAnswer();

            //getting state of silent checkbox
            bool silent = mf.Silent;
        }
    }
}
