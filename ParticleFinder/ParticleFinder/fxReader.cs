using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ParticleFinder
{
    class fxReader
    {
        public static List<string> getTroysFromFxFile(MemoryStream inputStream)
        {
            List<String> troyList = new List<String>();
            long spacing = 588;
            long currentOffset = 16;

            long streamLen = inputStream.Length;

            while (currentOffset < streamLen)
            {
                troyList.Add(ReadNullTerminatedString(ref inputStream, currentOffset));
                currentOffset += spacing;
            }

            return new List<string>();
        }


        public static String ReadNullTerminatedString(ref MemoryStream s, long atOffset)
        {
            s.Seek(atOffset, SeekOrigin.Begin);

            StringBuilder sb = new StringBuilder();
            int c;
            while ((c = s.ReadByte()) > 0)
            {
                sb.Append((char)c);
            }

            return sb.ToString();
        }
    }
}
