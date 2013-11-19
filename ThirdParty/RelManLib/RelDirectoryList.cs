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
    public class RelDirectoryList
    {
        /// <summary>
        /// Number of entries in the file list
        /// </summary>
        private UInt32 DirectoryListCount = 0;
        private byte[] content = null;
        private UInt32 offsetDirectoryList = 0;
        public List<RelDirectoryEntry> directoryEntries = null;
        private RelManDirectoryFile rlfm = null;
        public RelDirectoryList(RelManDirectoryFile rlfm, byte[] directoryFileContent, UInt32 offsetDirectoryList)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            this.rlfm = rlfm;
            this.content = directoryFileContent;
            this.offsetDirectoryList = offsetDirectoryList;

            //The file list starts with a uint stating how many files we have
            DirectoryListCount = BitConverter.ToUInt32(content.SubArray((Int32)offsetDirectoryList, 4), 0);

            //After the file list count, we have the actual data.
            UInt32 offsetEntriesStart = offsetDirectoryList + 4;
            this.directoryEntries = new List<RelDirectoryEntry>();
            int entryNum = 0;
            for (UInt32 currentOffset = offsetEntriesStart;
                currentOffset < offsetEntriesStart + 20 * DirectoryListCount; currentOffset += 20)
            {
                this.directoryEntries.Add(new RelDirectoryEntry(rlfm, ref directoryFileContent, currentOffset,entryNum++));
            }
        }
        public List<UInt32> GetUIntArray()
        {
            List<UInt32> result = new List<UInt32>();
            //Header
            result.Add(DirectoryListCount);
            foreach (RelDirectoryEntry entry in directoryEntries)
            {
                result.AddRange(entry.GetUIntArray().ToArray());
            }
            
            return result;
        }
    }
}
