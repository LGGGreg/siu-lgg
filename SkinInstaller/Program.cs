/*
 * Skin Installer Ultimate + LGG (SIU+LGG)
 * Copyright 2011 Greg Hendrickson
 * This file is part of SIU+LGG.
 * 
 * SIU+LGG is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * any later version.
 * 
 * SIU+LGG is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with LOLViewer.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace SkinInstaller
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main(string [] args)
        {
            String allArgs = "";
            foreach (string a in args)
            {
               allArgs += "" + a + "|";
            }
            string appName = "LoL Skin Installer +lgg v";
            string version = "3.295";
            string windowName = appName+version.ToString();
            MessageHelper msg = new MessageHelper();
            int result = 0;
            //First param can be null
            int hWnd = msg.getWindowId(null,windowName);
            //MessageBox.Show(hWnd.ToString());
            result = msg.sendWindowsStringMessage(hWnd, 0,allArgs);
            if (hWnd == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new skinInstaller(appName, version, allArgs));
            }
            else
            {
                msg.bringAppToFront(hWnd);
            }
        }
    }
}

