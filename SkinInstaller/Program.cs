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

//uncomment bellow if you wanna play with http://www.skincrafter.com/
//#define SKINTHING
//#define USkin
namespace SkinInstaller
{
    using System;
    using System.IO;
    using System.Windows.Forms;
#if (SKINTHING)
    using DMSoft;
#endif

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
            string version = "3.296";
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

#if (SKINTHING)
                DMSoft.SkinCrafter.Init();
                DMSoft.SkinCrafter SkinOb = new DMSoft.SkinCrafter();
                SkinOb.InitLicenKeys("SKINCRAFTER","SKINCRAFTER.COM",
                "esupport@skincrafter.com","DEMOSKINCRAFTERLICENCE");
                SkinOb.InitDecoration(true);
                SkinOb.LoadSkinFromFile(Application.StartupPath + "\\guiskinning\\WindowSkin.skf");
                SkinOb.ApplySkin();
#endif
#if(USkin)
                /*string skinUPath = Application.StartupPath +
                    "\\guiskinning\\"+
                   // "ConcaveD.msstyles"
                   //"ClearLooks.msstyles" 
                   "DiyGreen.msstyles";
                USkinSDK.USkinInit("", "", skinUPath
                   );
                USkinSDK.USkinLoadSkin(skinUPath);*/
#endif
                Application.Run(new skinInstaller(appName, version, allArgs));
#if(USkin)
                USkinSDK.USkinExit();
#endif
#if (SKINTHING)
                SkinOb.DeInitDecoration();
                DMSoft.SkinCrafter.Terminate();
#endif
                

            }
            else
            {
                msg.bringAppToFront(hWnd);
            }
        }
    }
}

