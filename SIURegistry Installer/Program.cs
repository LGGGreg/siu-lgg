using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SIURegistry_Installer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            if (args.Length > 0)
            {
                String allArgs = "";
                foreach (string a in args)
                {
                    allArgs += "" + a + "|";
                }
               // MessageBox.Show("got some args "+
                 //   allArgs);

                /*
                MessageHelper msg = new MessageHelper();
                int result = 0;
                //First param can be null
                int hWnd = msg.getWindowId(null, "My App Name");
                result = msg.sendWindowsStringMessage(hWnd, 0, “Some_String_Message”);
                //Or for an integer message
                result = msg.sendWindowsMessage(hWnd, MessageHelper.WM_USER, 123, 456);
                  return;*/
                Process process = new Process();
                process.StartInfo.FileName = "Skin Installer Ultimate.exe";
                process.StartInfo.Arguments = string.Concat(new string[]
						{
							" --webArgs \"",
                            allArgs
                            
                            +"\""
						});
                //process.StartInfo.UseShellExecute = false;
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WorkingDirectory = Application.StartupPath;
                process.Start();
                process.WaitForExit();
                return;
            }
            doRegistryStuff();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
        
        static void doRegistryStuff()
        {
            //first delete any old keys (portable fix)               
            try
            {
                Microsoft.Win32.Registry.LocalMachine.DeleteSubKeyTree(
               "SOFTWARE\\Classes\\skininstallerultimatelgg");
            }
            catch// (Exception ex)
            {
                //debugadd("Got expected error trying to delete reg key");
                //Cliver.Message.Inform("Its ok, but \n"+ex.ToString());
            }

            //try to register my key
            Microsoft.Win32.RegistryKey key;
           //Microsoft.Win32.RegistryKey dikey;
            Microsoft.Win32.RegistryKey shellkey;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\skininstallerultimatelgg");
            key.SetValue("", "URL:LoL Skin Installer LC LGG");
            key.SetValue("URL Protocol", "");
            //dikey = key.CreateSubKey("DefaultIcon");
            //dikey.SetValue("",""+Application.ExecutablePath+",0");
            shellkey = key.CreateSubKey("shell\\open\\command");
            //shellkey.SetValue("","\""+Application.ExecutablePath+"\" --url \"%1\"");
            shellkey.SetValue("","\""+Application.StartupPath+"\\Skin Installer Ultimate.exe"+"\" --url \"%1\"");
            shellkey.Close();
            //dikey.Close();

            key.Close();
        }
    }
}
