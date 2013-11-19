
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ItzWarty;
using System.Threading;
using System.Globalization;

namespace RelManLib
{
    public class RelStringList
    {
        private RelManDirectoryFile rlsm = null; 
        private byte[] content = null;
        public UInt32 stringCount = 0;
        public UInt32 sizeOfData = 0;
        public List<String> strings = new List<string>();
        public RelStringList(RelManDirectoryFile rlsm, byte[] content, UInt32 offset)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            this.rlsm = rlsm;
            this.content = content;

            stringCount = BitConverter.ToUInt32(content, (int)offset);
            sizeOfData = BitConverter.ToUInt32(content, (int)offset+4);
            UInt32 total = offset + 8 + sizeOfData;
            byte[] stringBytes = content.SubArray((int)(offset+8), (int)(sizeOfData));
            string all = Encoding.ASCII.GetString(stringBytes);
            strings.AddRange(all.Split(new string[1] { "\0" }, StringSplitOptions.RemoveEmptyEntries));
        }
        public byte[] getBytes()
        {
            List<UInt32> result = new List<UInt32>();
            result.Add(stringCount);
            result.Add(sizeOfData);
            int sd4 = (int)sizeOfData/4;
            byte[] resultOutput = new byte[(result.Count * 4)+sizeOfData];
            for (int i = 0; i < result.Count; i++)
            {
                Array.Copy(
                    BitConverter.GetBytes(result[i]), 0, resultOutput, i * 4, 4
                );
            }
            string fullString = "\0"+string.Join("\0",strings.ToArray())+"\0";
            byte[] stringBytes = Encoding.ASCII.GetBytes(fullString);
            int sbl = stringBytes.Length;
            Array.Copy(
                stringBytes, 0, resultOutput, (result.Count) * 4, sizeOfData);
            return resultOutput;
        }

        public string this[UInt32 index] { get { return this.strings[(int)index]; } }
    }
}
