//#define USkin
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

#if(USkin)
namespace SkinInstaller
{
    class USkinSDK
    {
        public const string DLLNAME = "USkin.dll";
        [DllImport(DLLNAME)]
        public static extern int USkinInit(string userName, string sn, string skinFileName);
        [DllImport(DLLNAME)]
        public static extern int USkinExit();
        [DllImport(DLLNAME)]
        public static extern int USkinLoadSkin(string skinFileName);
    }
}
#endif