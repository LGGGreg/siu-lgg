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
    public class RelFileList
    {
        /// <summary>
        /// Number of entries in the file list
        /// </summary>
        private UInt32 FileListCount = 0;
        private byte[] content = null;
        private UInt32 offset = 0;
        public List<RelFileEntry> fileEntries = null;
        private RelManDirectoryFile rlfm = null;
        public RelFileList(RelManDirectoryFile rlfm, byte[] content, UInt32 offset)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            this.rlfm = rlfm;
            this.content = content;
            this.offset = offset;
            //The file list starts with a uint stating how many files we have
            FileListCount = BitConverter.ToUInt32(content.SubArray((Int32)offset, 4), 0);

            //After the file list count, we have the actual data.
            UInt32 offsetEntriesStart = offset + 4;
            this.fileEntries = new List<RelFileEntry>();
            int count = 0;
            for (UInt32 currentOffset = offsetEntriesStart;
                currentOffset < offsetEntriesStart + 44 * FileListCount; currentOffset += 44)
            {
                RelFileEntry newEntry = new RelFileEntry(rlfm, ref content, currentOffset,count++);
               // List<RelFileEntry> matches = this.SearchFileEntries(newEntry.name,true);
              //  if (matches.ToArray().Length > 0)
               // {
               //     string matchedName = newEntry.name;
               // }
                this.fileEntries.Add(newEntry);
            }
        }
        public List<RelFileEntry> SearchFileEntries(string partialPath, bool strict=false)
        {
 
            string lowerPath = partialPath.ToLower();
            List<RelFileEntry> result = new List<RelFileEntry>();

            List<RelFileEntry> fileEntries = this.fileEntries;
            List<int> foundIndexs = new List<int>();
            for (int i = 0; i < fileEntries.Count; i++)
            {
                string lowerFilename = fileEntries[i].name.ToLower();
                if (lowerFilename.EndsWith(lowerPath))
                {
                    if (!strict || lowerFilename == lowerPath)
                    {
                        result.Add(fileEntries[i]);
                        foundIndexs.Add(i);
                    }
                }
            }
            for (int i = 0; i < fileEntries.Count; i++)
            {
                string lowerFilename = fileEntries[i].getPathAndName().ToLower();
                if (lowerFilename.EndsWith(lowerPath))
                {
                    if (!strict || lowerFilename == lowerPath || lowerFilename == ("/" + lowerPath))
                    {
                        if(!foundIndexs.Contains(i))
                            result.Add(fileEntries[i]);
                    }
                }
            }
            return result;
        }
        public List<UInt32> GetUIntArray()
        {
            List<UInt32> result = new List<UInt32>();
            //Header
            result.Add(FileListCount);
            foreach (RelFileEntry entry in fileEntries)
            {
                result.AddRange(entry.GetUIntArray().ToArray());
            }

            return result;
        }
    }
}
