using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItzWarty;
using System.IO;

using System.Threading;
using System.Globalization;

namespace RelManLib
{
    public class RelFileEntry
    {
        public byte[] content = null;
        public UInt32 offsetEntry = 0;
        public RelManDirectoryFile rlfm = null;

        public UInt32 nameIndex = UInt32.MaxValue;
        public UInt32 version = UInt32.MaxValue;
        public string checkSum = "";
        public UInt32 []checkarray;
        public UInt32 unknownA = UInt32.MaxValue;
        public UInt32 uncompressedFileSize = UInt32.MaxValue;
        public UInt32 compressedFileSize = UInt32.MaxValue;
        public UInt32 unknownC = UInt32.MaxValue;
        public UInt32 unknownD = UInt32.MaxValue;
        public int fileIndex = 0;
        public string name = "";
        public RelDirectoryEntry folder = null;

        //(string rafPath, UInt32 offset, UInt32 fileSize, UInt32 nameStringTableIndex)
        public RelFileEntry(RelManDirectoryFile rlfm, ref byte[] content, UInt32 offset, int fileIndex)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            this.rlfm = rlfm;
            this.content = content;
            this.offsetEntry = offset;
            this.fileIndex = fileIndex;

            /*
             * # name string index
                int        nameIndex
                # release version (file location -> 0.0.0.version dir)
                int        version
                # md5 checksum of file content (16 octets)
                byte[16]    checksum
                # unknown int
                #   maybe a key to identify package directory
                #   (ie. releases/v/deploy, managedfiles/v/ or filearchives/v/)
                int        unknown1
                # file size in octet
                int        size
                # unknown int 2 (no idea)
                int        unknown2
                # unknown int? 3&4 (maybe some kind of hash?)
                int     unknown3
                int        unknown4*/
            this.nameIndex = BitConverter.ToUInt32(content, (int)offsetEntry + 0);
            this.name = rlfm.strList.strings[(int)nameIndex-1];
            this.version = BitConverter.ToUInt32(content, (int)offsetEntry + 4);
            this.checkSum = BitConverter.ToString(content.SubArray((Int32)offsetEntry+4+4, 16), 0);
            this.checkarray = new UInt32[4];
            this.checkarray[0] = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4);
            this.checkarray[1] = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4+4);
            this.checkarray[2] = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4+4+4);
            this.checkarray[3] = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4+4+4+4);
            this.unknownA = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4 + 16);
            this.uncompressedFileSize = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4 + 16 +4);
            this.compressedFileSize = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4 + 16 + 4 + 4);
            this.unknownC = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4 + 16 + 4 + 4 + 4);
            this.unknownD = BitConverter.ToUInt32(content, (int)offsetEntry + 4 + 4 + 16 + 4 + 4 + 4+4);
        }
        public List<UInt32> GetUIntArray()
        {
            //should be 20

            List<UInt32> result = new List<UInt32>();
            result.Add(nameIndex);
            result.Add(version);
            result.Add(checkarray[0]);
            result.Add(checkarray[1]);
            result.Add(checkarray[2]);
            result.Add(checkarray[3]);
            result.Add(unknownA);
            result.Add(uncompressedFileSize);
            result.Add(compressedFileSize);
            result.Add(unknownC);
            result.Add(unknownD);
            return result;

        }
        public string getPathAndName()
        {
            //returns like 		fullPath	"/LEVELS/Map1/Scene/Textures/WallOfGrass.dds"	string
            string path = "";
            if(this.folder!=null) path = this.folder.getFullPath();
            return path + "/"+name;
        }
        
    }
}
