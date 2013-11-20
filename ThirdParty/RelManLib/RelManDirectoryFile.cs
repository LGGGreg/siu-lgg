﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ItzWarty;

using System.IO;
using System.Threading;
using System.Globalization;

namespace RelManLib
{
    public unsafe class RelManDirectoryFile
    {
        /// <summary>
        /// Magic value used to identify the file type, must be RLSM
        /// </summary>
        string magic = "";
        UInt32 magicInt = 0;
        /// <summary>
        /// // Version of the archive
        /// </summary>
        UInt32 version = 0;

        /// <summary>
        /// Must be 0x00010001
        /// </summary>
        string fileType = "";
        UInt32 fileTypeInt=0;

        /// <summary>
        /// Number of directories and files in the list
        /// </summary>
        UInt32 numberItems = 0;

        /// <summary>
        /// The file location this releasemanifest is at
        /// </summary>
        String myLocation = "";

        byte[] content = null;
        public RelDirectoryList dirList = null;
        public RelStringList strList = null;
        public RelFileList fileList = null;
        public RelManDirectoryFile(string location)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            myLocation = location;
            
            //this.RelMan = RelMan;
            content = System.IO.File.ReadAllBytes(location);
            magic = System.Text.Encoding.ASCII.GetString(content.SubArray(0, 4));
            magicInt = BitConverter.ToUInt32(content.SubArray(0, 4),0);
            fileType = BitConverter.ToString(content.SubArray(4, 4), 0);
            fileTypeInt= BitConverter.ToUInt32(content.SubArray(4, 4), 0);
            numberItems = BitConverter.ToUInt32(content.SubArray(8, 4), 0);
            version = BitConverter.ToUInt32(content.SubArray(12, 4), 0);
            uint dirHeaderLoc = 16;
            UInt32 dirCount1 = BitConverter.ToUInt32(content.SubArray((int)dirHeaderLoc, 4), 0);//test

            uint fileHeaderLoc = dirHeaderLoc + 4 + (dirCount1 * 20);
            UInt32 fileCount1 = BitConverter.ToUInt32(content.SubArray((int)fileHeaderLoc, 4), 0);//test

            uint totalEntriesTest = dirCount1 + fileCount1;
            uint stringHeaderLoc = fileHeaderLoc + 4 + (fileCount1 * 44);


            strList = new RelStringList(this, content, stringHeaderLoc);
            dirList = new RelDirectoryList(this, content, dirHeaderLoc);
            fileList = new RelFileList(this,content,fileHeaderLoc);
            //iterate through directories, add files and paths
            
            readRelDirEntry();
            ;
            
        }
        public bool adjustSizeByFile(string filename, string rafLocationName)
        {
            return adjustSizeByBytes(File.ReadAllBytes(filename),rafLocationName);
        }
        public bool adjustSizeByBytes(byte[] bytes,string rafLocationName)
        {
            int uncompressedSize = bytes.Length;

            MemoryStream mStream = new MemoryStream();
            ComponentAce.Compression.Libs.zlib.ZOutputStream oStream = new ComponentAce.Compression.Libs.zlib.ZOutputStream(mStream, ComponentAce.Compression.Libs.zlib.zlibConst.Z_DEFAULT_COMPRESSION); //using default compression level
            oStream.Write(bytes, 0, bytes.Length);
            oStream.finish();
            int compressedSize = mStream.ToArray().Length;
            return adjustSizeByLocation(rafLocationName, uncompressedSize, compressedSize);
        }
        public bool adjustSizeByLocation(string rafLocationName, int uncompressedSize, int compressedSize)
        {
            List<RelFileEntry> entries = fileList.SearchFileEntries(rafLocationName,true);
            if (entries.Count > 0)
            {
                RelFileEntry entry = entries[0];
                return adjustSize(entry, uncompressedSize, compressedSize);
            }
            return false;
        }
        public bool adjustSize(RelFileEntry entry, int uncompressedSize, int compressedSize)
        {
            entry.uncompressedFileSize = (UInt32)uncompressedSize;
            entry.compressedFileSize = (UInt32)compressedSize;
            return true;
        }
        public bool saveFile(bool debug=false,string filename = "")
        {
            if (filename == "") filename = this.myLocation;
            if(debug)filename += ".test";
            File.WriteAllBytes(filename, GetBytes());
            return true;

        }
        public byte[] GetBytes()
        {
            //Calls to bitconverter were avoided until the end... just to make code prettier
            List<UInt32> result = new List<UInt32>();
            //Header
            result.Add(magicInt);
            result.Add(fileTypeInt);
            result.Add(numberItems);
            result.Add(version);

            result.AddRange(dirList.GetUIntArray().ToArray());
            result.AddRange(fileList.GetUIntArray().ToArray());
            byte[] stringsBytes = strList.getBytes();
            
            byte[] resultOutput = new byte[(result.Count * 4)+stringsBytes.Length];
            for (int i = 0; i < result.Count; i++)
            {
                Array.Copy(
                    BitConverter.GetBytes(result[i]), 0, resultOutput, i * 4, 4
                );
            }
            Array.Copy(stringsBytes, 0, resultOutput, result.Count * 4, stringsBytes.Length);
            return resultOutput;
        }
        //hey look! we don't even use the directory file count
        public RelDirectoryEntry readRelDirEntry(int dirEntry = 0,RelDirectoryEntry lastDir = null)
        {
            RelDirectoryEntry entry = this.dirList.directoryEntries[(int)dirEntry];
            RelDirectoryEntry currentEntry = entry;
            string entryName = entry.name;//for debug
            UInt32 fileOffset = entry.fileStartOffset;
            if (lastDir != null)
            {
                UInt32 lastFileOffset = lastDir.fileStartOffset;
                string lastDirName = lastDir.name;
                string doing = (fileOffset - lastFileOffset).ToString() + " files going into " + lastDirName;
                for (UInt32 fiOffset = lastFileOffset; fiOffset < fileOffset; fiOffset++)
                {
                    RelFileEntry fileToSet = this.fileList.fileEntries[(int)fiOffset];
                    fileToSet.folder = lastDir;
                    lastDir.folderFiles.Add(fileToSet);
                }
            }
            int nextEntryIndex = dirEntry + 1;
            try
            {
                for (int dirOffset = 0; dirOffset < entry.subDirCount; dirOffset++)
                {
                    int innerDirEntry = (int)entry.subDirFirstIndex + dirOffset;
                    RelDirectoryEntry nextEntry = this.dirList.directoryEntries[innerDirEntry];
                    string nextEntryName = nextEntry.name;//for debug
                    nextEntry.subFolder = entry;
                    //fileOffset = nextFileOffset;
                    currentEntry = readRelDirEntry(innerDirEntry,currentEntry);
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
            return currentEntry;
        }
        public static RelManDirectoryFile RelManDirectoryFileFromRiotRoot(String riotRootLocation)
        {
            //C:\Riot Games\League of Legends
            FileInfo origFi = new FileInfo(riotRootLocation);
            if (origFi.Name == "releasemanifest") return new RelManDirectoryFile(riotRootLocation);

            string[] folders = (origFi.Directory + "/Riot Games/League of Legends").ToString().Split(new string[2] { "/", "\\" }, StringSplitOptions.RemoveEmptyEntries); 
            for(int i = folders.Length-1;i>-1;i--)
            {
                try
                {
                    string path = string.Join("/", folders, 0, i);
                    if (File.Exists(path + "/lol.launcher.exe") || File.Exists(path + "/League Of Legends.exe"))
                    {
                        //found riot folder

                        DirectoryInfo di = new DirectoryInfo(path + "/RADS/projects/lol_game_client/releases");
                        if(di.Exists)
                        {
                            DirectoryInfo[] versionFolders = di.GetDirectories();
                            foreach (DirectoryInfo idi in versionFolders)
                            {
                                //find the SOK
                                FileInfo sokfi = new FileInfo(idi.FullName + "/S_OK");
                                if (sokfi.Exists)
                                {
                                    FileInfo rmfi = new FileInfo(idi.FullName + "/releasemanifest");
                                    if (rmfi.Exists)
                                    {
                                        return new RelManDirectoryFile(rmfi.FullName);
                                    }
                                }
                            }
                        }
                    }else if(File.Exists(path + "/releasemanifest"))
                    {
                        return new RelManDirectoryFile(path+"/releasemanifest");
                    }
                }
                catch (System.Exception ex)
                {

                }
            }

            return new RelManDirectoryFile(riotRootLocation);
        }

        
    }
}