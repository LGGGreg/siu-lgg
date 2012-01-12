using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using zlib = ComponentAce.Compression.Libs.zlib;

namespace RAFLib
{
    /// <summary>
    /// 8 May 2011, Setters no longer actually write to RAF DIrectory file in memory copies
    /// Instead, you must call Archive.SaveDirectoryFile();
    /// 
    /// This would have been easier to do with c++ and double pointers... 
    /// Meh
    /// </summary>
    public class RAFFileListEntry
    {
        private byte[] directoryFileContent = null;
        private UInt32 offsetEntry = 0;
        private RAFArchive raf = null;

        private UInt32 fileOffset   = UInt32.MaxValue;  //It is assumed that LoL archive files will never reach 4 gigs of size.
        private UInt32 fileSize     = UInt32.MaxValue;
        private UInt32 stringTableIndex = UInt32.MaxValue;
        private string fileName     = null;


        /**
         * Defines whether or not this file entry is only in memory, and not
         * actually defined in the RAF Archives yet.
         * 
         * This is because can now choose to add files to the RAF Archives even if they don't
         * already exist.
         */
        private bool inMemory = false;

        //(string rafPath, UInt32 offset, UInt32 fileSize, UInt32 nameStringTableIndex)
        public RAFFileListEntry(RAFArchive raf, ref byte[] directoryFileContent, UInt32 offsetDirectoryEntry)
        {
            this.raf = raf;
            this.directoryFileContent = directoryFileContent;
            this.offsetEntry = offsetDirectoryEntry;

            this.fileOffset = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry + 4); ;
            this.fileSize = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry + 8);
            this.stringTableIndex = BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry + 12);
            this.fileName = null; // this.raf.GetDirectoryFile().GetStringTable()[this.stringTableIndex];
        }
        /// <summary>
        /// Creates an entry that only exists in memory.  
        /// </summary>
        public RAFFileListEntry(RAFArchive raf, string rafPath, UInt32 offsetDatFile, UInt32 fileSize, UInt32 nameStringTableIndex)
        {
            inMemory = true;
            this.raf = raf;
            this.fileName = rafPath;
            this.fileOffset = offsetDatFile;
            this.fileSize = fileSize;
            this.stringTableIndex = nameStringTableIndex;

        }
        /// <summary>
        /// Hash of the string name
        /// </summary>
        public UInt32 StringNameHash
        {
            get
            {
                return RAFHashManager.GetHash(FileName);
                //return BitConverter.ToUInt32(directoryFileContent, (int)offsetEntry);
            }
        }
        /// <summary>
        /// Offset to the start of the archived file in the data file
        /// </summary>
        public UInt32 FileOffset
        {
            get
            {
                if (inMemory)
                    if (fileOffset == UInt32.MaxValue)
                        throw new Exception("Invalid call to Get_FileOffset, this entry is only in memory, and has not been assigned a file offset yet.");
                    else
                        return fileOffset;
                else
                    return fileOffset;
            }
            set
            {
                if (inMemory)
                {
                    //byte[] valueBytes = BitConverter.GetBytes(value);
                    //Array.Copy(valueBytes, 0, directoryFileContent, offsetEntry + 4, 4);
                    this.fileOffset = value;
                }
                else
                    this.fileOffset = value;
                    //throw new Exception("Invalid call to Set_FileOffset, this entry is only in memory, and thus does not have an address to a file offset yet.");
            }
        }
        /// <summary>
        /// Size of this archived file
        /// </summary>
        public UInt32 FileSize
        {
            get
            {
                if (fileSize == UInt32.MaxValue)
                    throw new Exception("Invalid call to Get_FileSize, this entry is only in memory, and has not been assigned a file size yet.");
                return fileSize;
            }
            set
            {
                fileSize = value;
                //byte[] valueBytes = BitConverter.GetBytes(value);
                //Array.Copy(valueBytes, 0, directoryFileContent, offsetEntry + 8, 4);
            }
        }
        /// <summary>
        /// Index of the name of the archvied file in the string table
        /// </summary>
        public UInt32 FileNameStringTableIndex
        {
            get
            {
                if (stringTableIndex == UInt32.MaxValue)
                    throw new Exception("Invalid call to Get_FileNameStringTableIndex, this entry is only in memory, and has not been assigned a string table index yet.");
                return stringTableIndex;
            }
            set
            {
                stringTableIndex = value;
            }
        }

        /// <summary>
        /// Returns the internal raf path of this entry, not including the RafID
        /// </summary>
        public String FileName
        {
            get
            {
                if (this.fileName == null)
                    if (inMemory)
                        throw new Exception("Invalid call to Get_FileName, this entry is only in memory, and has not been assigned a file name yet.");
                    else
                        return raf.GetDirectoryFile().GetStringTable()[this.stringTableIndex];
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        /// <summary>
        /// Returns the content of the actual file (extracts from raf archive)
        /// </summary>
        public byte[] GetContent()
        {
            if (inMemory) throw new Exception("Invalid call to GetContent, this entry is only in memory, and has not been linked to the DAT file yet.");
            FileStream fStream = this.raf.GetDataFileContentStream();

            byte[] buffer = new byte[this.FileSize];            //Will contain compressed data
            fStream.Seek(this.FileOffset, SeekOrigin.Begin);
            fStream.Read(buffer, 0, (int)this.FileSize);

            try
            {
                MemoryStream mStream = new MemoryStream(buffer);
                zlib.ZInputStream zinput = new zlib.ZInputStream(mStream);

                List<byte> dBuffer = new List<byte>(); //decompressed buffer, arraylist to my knowledge...

                //This could be optimized in the future by reading a block and adding it to our arraylist..
                //which would be much faster, obviously
                int data = 0;
                while ((data = zinput.Read()) != -1)
                    dBuffer.Add((byte)data);
                //ComponentAce.Compression.Libs.zlib.ZStream a = new ComponentAce.Compression.Libs.zlib.ZStream();

                //File.WriteAllBytes((dumpDir + entry.FileName).Replace("/", "\\"), dBuffer.ToArray());
                return dBuffer.ToArray();
            }
            catch
            {
                //it's not compressed, just return original content
                return buffer;
            }
        }

        /// <summary>
        /// Returns the raw, uncompressed, content of the file
        /// </summary>
        /// <returns></returns>
        public byte[] GetRawContent()
        {
            FileStream fStream = this.raf.GetDataFileContentStream();

            byte[] buffer = new byte[this.FileSize];            //Will contain compressed data
            fStream.Seek(this.FileOffset, SeekOrigin.Begin);
            fStream.Read(buffer, 0, (int)this.FileSize);
            return buffer;
        }

        /// <summary>
        /// Returns the corresponding RAFArchive of this entry
        /// </summary>
        public RAFArchive RAFArchive
        {
            get
            {
                return raf;
            }
        }

        /// <summary>
        /// ToString is overrided to return our filename
        /// </summary>
        public override string ToString()
        {
            return FileName;
        }

        public bool IsMemoryEntry
        {
            get
            {
                return inMemory;
            }
            set
            {
                inMemory = value;
            }
        }
    }
}
