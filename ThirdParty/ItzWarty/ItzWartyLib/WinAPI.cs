using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

using System.Drawing;
using System.Drawing.Drawing2D;

namespace ItzWarty
{
    //Pretty much everything copied from http://www.pinvoke.net
    public static class WinAPI
    {
        public delegate bool CallBackPtr(int hwnd, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(CallBackPtr callPtr, int lPar);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
        public static Rectangle GetWindowRect(IntPtr hWnd)
        {
            RECT rect = new RECT();
            GetWindowRect(hWnd, ref rect);

            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetFocus(IntPtr hwnd);

        public enum ShowWindowParam:int
        {
            SW_SHOWNORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3
        }

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowParam nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        //Stop flashing. The system restores the window to its original state. 
        public const UInt32 FLASHW_STOP = 0;
        //Flash the window caption. 
        public const UInt32 FLASHW_CAPTION = 1;
        //Flash the taskbar button. 
        public const UInt32 FLASHW_TRAY = 2;
        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;
        //Flash continuously, until the FLASHW_STOP flag is set. 
        public const UInt32 FLASHW_TIMER = 4;
        //Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12; 


        /// <summary>
        /// The MoveWindow function changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// </summary>
        /// <param name="hWnd">Handle to the window.</param>
        /// <param name="X">Specifies the new position of the left side of the window.</param>
        /// <param name="Y">Specifies the new position of the top of the window.</param>
        /// <param name="nWidth">Specifies the new width of the window.</param>
        /// <param name="nHeight">Specifies the new height of the window.</param>
        /// <param name="bRepaint">Specifies whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        
        //Extensions by me
        public static string GetWindowTextAsString(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetWindowText(hWnd, sb, 1024);
            return sb.ToString();
        }

        public static bool KeyPressed(System.Windows.Forms.Keys key)
        {
            return GetAsyncKeyState(key) > 0;
        }

    }
}
