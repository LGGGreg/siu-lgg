using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ParticleFinder
{
    class fxReader
    {
        private int origonalOffset = 16;
        private int spacing = 588;

        public static List<string> getTroysFromFxFile(MemoryStream inputStream)
        {
            return new List<string>();
        }


        public static String ReadNulTerminatedString(ref MemoryStream s, int atOffset)
        {
            long oldPos = s.Position;
            s.Seek(atOffset, SeekOrigin.Begin);

            StringBuilder sb = new StringBuilder();
            int c;
            while ((c = s.ReadByte()) > 0)
            {
                sb.Append((char)c);
            }

            s.Seek(oldPos, SeekOrigin.Begin);
            return sb.ToString();
        }
    }
}
