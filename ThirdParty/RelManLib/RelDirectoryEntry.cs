using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using System.Threading;
using System.Globalization;

namespace RelManLib
{
    public class RelDirectoryEntry
    {
        public byte[] directoryFileContent = null;
        public UInt32 offsetEntry = 0;
        public RelManDirectoryFile rlfm = null;

        public UInt32 nameIndex = UInt32.MaxValue;
        public UInt32 subDirCount = UInt32.MaxValue;
        public UInt32 subDirFirstIndex = UInt32.MaxValue;
        public UInt32 fileStartOffset = UInt32.MaxValue;
        public UInt32 fileCount = UInt32.MaxValue;
        public string name = "";
        public RelDirectoryEntry subFolder = null;
        public List<RelFileEntry> folderFiles = null;
        public int entryNum = 0;

        //(string rafPath, UInt32 offset, UInt32 fileSize, UInt32 nameStringTableIndex)
        public RelDirectoryEntry(RelManDirectoryFile rlfm, ref byte[] directoryFileContent, UInt32 offset, int entryNum)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            this.rlfm = rlfm;
            this.entryNum = entryNum;
            this.directoryFileContent = directoryFileContent;
            this.offsetEntry = offset;
            this.nameIndex = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry); ;
            this.subDirFirstIndex = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry + 4);//start here, go that many subdirs
            this.subDirCount = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry + 4 + 4);
            this.fileStartOffset = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry + 4 + 4 + 4);
            this.fileCount = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry + 4 + 4 + 4 +4);
            if (nameIndex == 0) this.name = "";
            else
                this.name = rlfm.strList.strings[(int)nameIndex-1];
            folderFiles = new List<RelFileEntry>();
        }

        public List<UInt32> GetUIntArray()
        {
            //should be 20

            List<UInt32> result = new List<UInt32>();
            result.Add(nameIndex);
            result.Add(subDirFirstIndex);
            result.Add(subDirCount);
            result.Add(fileStartOffset);
            result.Add(fileCount);
            return result;

        }
        public string getFullPath()
        {
            if(this.subFolder!=null)return subFolder.getFullPath()+"/"+name;
            return name;
        }
        
    }
}
