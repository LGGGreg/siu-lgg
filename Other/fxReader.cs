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
            List<long> offsetList = new List<long>();
            offsetList.Add(16);
            offsetList.Add(604);
            offsetList.Add(1192);
            offsetList.Add(1780);
            offsetList.Add(2368);
            offsetList.Add(2956);
            offsetList.Add(3544);
            offsetList.Add(4132);

            int currentOffset = 0;

            while (currentOffset < offsetList.Count)
            {
                String troyStr = ReadNullTerminatedString(ref inputStream, offsetList[currentOffset]);
                int troyExtIndex = troyStr.IndexOf(".tro");
                if (troyExtIndex>0)
                    troyList.Add((troyStr.Substring(0,troyExtIndex)+".troybin").ToLower());
                currentOffset++;
            }

            return troyList;
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
