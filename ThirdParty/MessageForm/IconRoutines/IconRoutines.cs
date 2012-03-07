using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace Cliver
{
    /// <summary>
    /// Routines to extract icon from the binary (.NET ExtractAssociatedIcon does not get 16x16 icons)
    /// </summary>
    public class IconRoutines
    {
        /// <summary>
        /// Used as a parameter type for ExtractIconFromFile
        /// </summary>
        public enum IconSize : uint
        {
            /// <summary>
            /// 32x32
            /// </summary>
            Large = 0x0,
            /// <summary>
            /// 16x16
            /// </summary>
            Small = 0x1
        }

        /// <summary>
        /// Extracts the specified icon from the file.
        /// </summary>
        /// <param name="lpszFile">path of the icon file</param>
        /// <param name="nIconIndex">index of the icon with the file</param>
        /// <param name="phIconLarge">32x32 icon</param>
        /// <param name="phIconSmall">16x16 icon</param>
        /// <param name="nIcons">number of icons to extract</param>
        /// <returns>number of icons within the file</returns>
        [DllImport("Shell32", CharSet = CharSet.Auto)]
        extern static int ExtractIconEx(
            [MarshalAs(UnmanagedType.LPTStr)] 
            string lpszFile,
            int nIconIndex,
            IntPtr[] phIconLarge,
            IntPtr[] phIconSmall,
            int nIcons
            );

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        /// <summary>
        /// Extracts icon from the binary file like .exe, .dll, etc. (because of .NET ExtractAssociatedIcon does not get 16x16 icons)
        /// </summary>
        /// <param name="file">fiel path from where icon is to be extracted</param>
        /// <param name="size">size of the icon</param>
        /// <returns>extracted icon</returns>
        public static Icon ExtractIconFromLibrary(string file, IconSize size)
        {
            if (ExtractIconEx(file, -1, null, null, 0) < 1)
                return null;

            IntPtr[] icon_ptr = new IntPtr[1];
            if (size == IconSize.Small)
                ExtractIconEx(file, 0, null, icon_ptr, 1);
            else
                ExtractIconEx(file, 0, icon_ptr, null, 1);

            Icon unmanaged_icon = (Icon)Icon.FromHandle(icon_ptr[0]);
            Icon icon = (Icon)unmanaged_icon.Clone();
            DestroyIcon(unmanaged_icon.Handle);

            return icon;
        }

        /// <summary>
        /// Extract all icon images from the library file like .exe, .dll, etc. 
        /// .NET Icon Explorer (http://www.vbaccelerator.com/home/NET/Utilities/Icon_Extractor/article.asp) is used here.
        /// </summary>
        /// <param name="file">file where icon is extracted from</param>
        /// <returns>extracted icon</returns>
        public static Icon ExtractIconFromLibrary(string file)
        {
            Icon icon = null;
            try
            {
                vbAccelerator.Components.Win32.GroupIconResources gir = new vbAccelerator.Components.Win32.GroupIconResources(file);
                if (gir.Count < 0)
                    return icon;

                vbAccelerator.Components.Win32.IconEx i = new vbAccelerator.Components.Win32.IconEx();
                if (gir[0].IdIsNumeric)
                    i.FromLibrary(file, gir[0].Id);
                else
                    i.FromLibrary(file, gir[0].Name);

                icon = i.GetIcon();
            }
            catch (Exception e)
            {
                MessageForm mf = new MessageForm("", "Could not extract default icon for MessageForm!\n" + e.Message, null, null, 0, null, SystemIcons.Error);
                mf.GetAnswer();
                icon = null;
            }
            return icon;
        }
    }

    //    public static Icon ExtractAllIconsFromFile(string file)
    //    {
    //        Icon icon = null;
    //        try
    //        {
    //            byte[] header;
    //            byte[] directory1;
    //            byte[] directory2;
    //            byte[] ico1;
    //            byte[] ico2;

    //            using (MemoryStream ms = new MemoryStream())
    //            {//parse 1 icon
    //                icon = ExtractIconFromFile(file, IconSize.Small);
    //                icon.Save(ms);

    //                header = new byte[6];
    //                ms.Position = 0;
    //                ms.Read(header, 0, header.Length);

    //                directory1 = new byte[16];
    //                ms.Read(directory1, 0, directory1.Length);

    //                int ico1_length = BitConverter.ToInt32(directory1, 8);
    //                ico1 = new byte[ico1_length];
    //                ms.Read(ico1, 0, ico1.Length);
    //            }

    //            using (MemoryStream ms = new MemoryStream())
    //            {//parse 2 icon
    //                icon = ExtractIconFromFile(file, IconSize.Large);
    //                icon.Save(ms);

    //                ms.Position = 6;
    //                directory2 = new byte[16];
    //                ms.Read(directory2, 0, directory2.Length);

    //                int ico2_length = BitConverter.ToInt32(directory2, 8);
    //                ico2 = new byte[ico2_length];
    //                ms.Read(ico2, 0, ico2.Length);
    //            }

    //            using (MemoryStream ms = new MemoryStream())
    //            {//write 1,2 icons to a single file
    //                header[4] = 2;
    //                ms.Write(header, 0, header.Length);

    //                int ico1_position = header.Length + directory1.Length + directory2.Length;
    //                byte[] bs = BitConverter.GetBytes(ico1_position);
    //                bs.CopyTo(directory1, 12);
    //                ms.Write(directory1, 0, directory1.Length);

    //                int ico2_position = header.Length + directory1.Length + directory2.Length + ico1.Length;
    //                bs = BitConverter.GetBytes(ico2_position);
    //                bs.CopyTo(directory2, 12);
    //                ms.Write(directory2, 0, directory2.Length);

    //                ms.Write(ico1, 0, ico1.Length);

    //                ms.Write(ico2, 0, ico2.Length);

    //                //FileStream fs = new FileStream("1.ico", FileMode.Create);
    //                //ms.WriteTo(fs);
    //                //ms.Flush();
    //                //fs.Close();
    //                // return null;

    //                ms.Position = 0;
    //                icon = new Icon(ms);
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            MessageForm mf = new MessageForm("", "Could not extract default icon for MessageForm!\n" + e.Message, null, null, 0, null, SystemIcons.Error);
    //            mf.GetAnswer();
    //            icon = null;
    //        }
    //        return icon;
    //    }
    //}
}

