using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ItzWarty;

using System.IO;

namespace RAFLib
{
    public unsafe class RAFDirectoryFile
    {
        /// <summary>
        /// Magic value used to identify the file type, must be 0x18BE0EF0
        /// </summary>
        UInt32 magic = 0;

        /// <summary>
        /// // Version of the archive format, must be 1
        /// </summary>
        UInt32 version = 0;

        /// <summary>
        /// An index that is used by the runtime, do not modify
        /// Have no idea what this really does, at the moment...
        /// </summary>
        UInt32 mgrIndex = 0;

        /// <summary>
        /// Offset to the table of contents from the start of the file
        /// </summary>
        UInt32 offsetFileList = 0;

        /// <summary>
        /// Offset to the string table from the start of the file
        /// </summary>
        UInt32 offsetStringTable = 0;

        byte[] content = null;
        RAFFileList fileList = null;
        RAFStringTable stringTable = null;
        RAFArchive raf = null;
        public RAFDirectoryFile(RAFArchive raf, string location)
        {
            this.raf = raf;
            content = System.IO.File.ReadAllBytes(location);
            magic = BitConverter.ToUInt32(content.SubArray(0, 4), 0);
            version = BitConverter.ToUInt32(content.SubArray(4, 4), 0);
            mgrIndex = BitConverter.ToUInt32(content.SubArray(8, 4), 0);
            offsetFileList = BitConverter.ToUInt32(content.SubArray(12, 4), 0);
            offsetStringTable = BitConverter.ToUInt32(content.SubArray(16, 4), 0);

            //UINT32 is casted to INT32.  This should be fine, since i doubt that the RAF will become
            //a size of 2^31-1 in bytes.

            fileList = new RAFFileList(raf, content, offsetFileList);
            
            //Now we load our string table
            stringTable = new RAFStringTable(raf, content, offsetStringTable);
        }

        /// <summary>
        /// Gets the list of files contained in this RAF archive
        /// </summary>
        /// <returns></returns>
        public RAFFileList GetFileList()
        {
            return this.fileList;
        }

        /// <summary>
        /// Gets the RAF Archive's string table.
        /// To the knowledge of the community, this currently only contains
        /// internal file paths.  
        /// </summary>
        /// <returns></returns>
        public RAFStringTable GetStringTable()
        {
            return this.stringTable;
        }

        /// <summary>
        /// Returns the DirectoryFile that is currently in memory.
        /// If it fileEntries have been changed, this will reflect those changes.
        /// 
        /// NOTE THAT THIS ONLY RETURNS CORRECT VALUES IF YOU HAVENT' CHANGED THE RAF FILE
        /// </summary>
        /// <returns></returns>
        [Obsolete("This method has been superceded by RAFDirectoryFile.GetBytes().  If you decide to call this, you will obtain "+
                  "an unmodified RAF Directory File.")]
        public byte[] GetContent()
        {
            Console.WriteLine(
                "NOTICE: GETCONTENT() IS DEPRECATED.  IT WILL ONLY BE CORRECT\r\n" +
                "IF THE CONTENT OF THE DIRECTORY FILE & RAF ARCHIVE DAT STAYS STATIC"
            );
            return content;
        }
        public byte[] GetBytes()
        {
            //Calls to bitconverter were avoided until the end... just to make code prettier

            List<RAFFileListEntry> fileListEntries = fileList.GetFileEntries();

            List<UInt32> result = new List<UInt32>();
            //Header
            result.Add(magic);
            result.Add(version);

            //Table of Contents
            result.Add(mgrIndex);
            result.Add(5 * 4);  //Offset of file list
            result.Add(
                (UInt32)(
                       5 * 4 + 4 + /*file list offset and entry itself*/
                       4 * 4 * fileListEntries.Count /* Size of all entries total */
                )//Offset to string table
            );

            //File List Header
            result.Add((UInt32)fileListEntries.Count); //F

            {   //File List Entries
                UInt32 i = 0;
                foreach(RAFFileListEntry entry in fileListEntries)
                {
                    result.Add(entry.StringNameHash);
                    result.Add(entry.FileOffset);
                    result.Add(entry.FileSize);
                    result.Add(i++);
                }
            }

            //String table Header.
            int stringTableHeader_SizeOffset = result.Count; //We will store this value later...
            result.Add(1337); //This value will be changed later to reflect the size of the string table
            result.Add((UInt32)fileListEntries.Count);  //# strings in table

            //UInt32[] offsets = new UInt32[fileListEntries.Count]; //Stores offsets for entries
            
            //Set currentOffset to point to where our strings will be stored
            UInt32 currentOffset = 4 * 2 /*StringTableHeader Size*/ + (UInt32)(4 * 2 * fileListEntries.Count);

            List<byte> stringTableContent = new List<byte>();
            {   //Insert entry, add filename to our string name bytes
                UInt32 i = 0;
                foreach(RAFFileListEntry entry in fileListEntries)
                {
                    result.Add(currentOffset); //offset to this string
                    result.Add((UInt32)entry.FileName.Length + 1);
                    currentOffset += (UInt32)entry.FileName.Length + 1;
                    stringTableContent.AddRange(
                        Encoding.ASCII.GetBytes(entry.FileName)
                    );
                    stringTableContent.Add(0);
                    i++;
                }
            }
            //Update string table header with size of all data
            result[stringTableHeader_SizeOffset] = currentOffset;

            byte[] resultOutput = new byte[result.Count * 4 + stringTableContent.Count];
            for (int i = 0; i < result.Count; i++)
            {
                Array.Copy(
                    BitConverter.GetBytes(result[i]), 0, resultOutput, i * 4, 4
                );
            }
            Array.Copy(stringTableContent.ToArray(), 0, resultOutput, result.Count * 4, stringTableContent.Count);
            return resultOutput;
        }

        public RAFFileListEntry CreateFileEntry(string rafPath, UInt32 offset, UInt32 fileSize, UInt32 nameStringTableIndex)
        {
            RAFFileListEntry result = new RAFFileListEntry(this.raf, rafPath, offset, fileSize, nameStringTableIndex);
            this.GetFileList().AddFileEntry(result);
            return result;
        }
        public void DeleteFileEntry(RAFFileListEntry entry)
        {
            this.GetFileList().DeleteFileEntry(entry);
        }
        /*
        private void PrintFileList()
        {
            Console.WriteLine("Begin PrintFileList.  FileListOffset:" + offsetFileList.ToString("x"));
            Console.WriteLine("File Count: " + fileListCount);
            UInt32 lastOffset = offsetFileList + 4;
            for(int i = 0; i < fileListCount; i++)
            {
                UInt32 newOffset = (UInt32)Array.IndexOf(content, (Byte)0x00, (int)lastOffset);
                byte[] fileNameBytes = content.SubArray((int)lastOffset, (int)(newOffset - lastOffset));
                Console.WriteLine("Name Length: " + fileNameBytes.Length);
                Console.WriteLine(
                    Encoding.ASCII.GetString(
                        fileNameBytes
                    )
                );
                lastOffset = newOffset;
            }
        }
         */
    }
}
