using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ItzWarty;

namespace RAFLib
{
    public class RAFStringTable
    {
        private RAFArchive raf = null; 
        private byte[] directoryFileContent = null;
        private List<String> strings = new List<string>();
        public RAFStringTable(RAFArchive raf, byte[] directoryFileContent, UInt32 offsetTable)
        {
            this.raf = raf;
            this.directoryFileContent = directoryFileContent;

            //Console.WriteLine("String Table Offset: " + offsetTable.ToString("x"));
            UInt32 sizeOfData = BitConverter.ToUInt32(directoryFileContent, (int)offsetTable);
            UInt32 stringCount = BitConverter.ToUInt32(directoryFileContent, (int)offsetTable+4);

            //Load strings in memory
            for (UInt32 i = 0; i < stringCount; i++)
            {
                UInt32 entryOffset = offsetTable + 8 + i * 8; //+8 because of table header { size, count }
                //Above value points to the actual entry

                UInt32 entryValueOffset = BitConverter.ToUInt32(directoryFileContent, (int)entryOffset);
                UInt32 entryValueSize = BitConverter.ToUInt32(directoryFileContent, (int)entryOffset + 4);

                //-1 seems necessary.  I'd assume some null padding ends strings...
                byte[] stringBytes = directoryFileContent.SubArray((int)(entryValueOffset + offsetTable), (int)entryValueSize - 1);
                strings.Add(Encoding.ASCII.GetString(stringBytes));
            }
        }
        public string this[UInt32 index] { get { return this.strings[(int)index]; } }
        /// <summary>
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The index of our added string in the table</returns>
        public UInt32 Add(string n)
        {
            this.strings.Add(n);
            return (UInt32)(this.strings.Count - 1);
        }
    }
}
