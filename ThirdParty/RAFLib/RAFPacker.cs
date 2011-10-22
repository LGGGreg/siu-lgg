using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using zlib = ComponentAce.Compression.Libs.zlib;

using ItzWarty;

namespace RAFLib
{
    public class RAFPacker
    {
        private StreamWriter ostream = null;
        public RAFPacker()
        {
            this.ostream = (StreamWriter)Console.Out;
        }
        public RAFPacker(StreamWriter ostream)
        {
            this.ostream = ostream;
        }

        List<string> uncompressedFiles = null;
        //List<string>        archivedPaths   = null;
        
        public bool PackRAF(string sourceDirectory, string targetDirectory)
        {
            //RAFHashManager.Init(); //Inits if it needs to load the hashes dict...

            //archivedPaths = RAFHashManager.GetKeys();

            uncompressedFiles = new List<string>();
            uncompressedFiles.AddRange(File.ReadAllLines(Environment.CurrentDirectory + "\\nocompress.txt"));

            sourceDirectory = sourceDirectory.Replace("/", "\\");
            String[] files = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);

            ostream.WriteLine("Begin packing RAF");

            ostream.WriteLine("Count content bytes + file name bytes");

            UInt32 totalNameBytes = 0;
            List<UInt32> stringTableContentOffsets = new List<UInt32>();
            List<String> archivedPaths = new List<string>();        //Misnomer - name of the files once archived
            foreach (String filePath in files)
            {
                string archivePath = filePath.Replace(sourceDirectory, "").Replace("\\", "/");
                stringTableContentOffsets.Add((UInt32)totalNameBytes);
                totalNameBytes += (UInt32)(archivePath.Length + 1);
                archivedPaths.Add(archivePath);//raf uses / in storage name.
            }
            foreach (String archivePath in archivedPaths)
            {
                stringTableContentOffsets.Add((UInt32)totalNameBytes);
                totalNameBytes += (UInt32)(archivePath.Length + 1);
                //archivedPaths.Add(archivePath);//raf uses / in storage name.
            }

            //Calculate total bytes of header file: 
            // ulong magic = 0x18BE0EF0                             6*4
            // ulong version = 1
            // toc:
            // ulong mgrIndex = 0?
            // ulong fileListOffset 
            // ulong tableListOffset
            // ...filler...
            // @fileListOffset:
            //      header:
            //          ulong countFiles                            4
            //      ulong hashName                                  4*4*n
            //      ulong offsetInDataFile
            //      ulong size(Compressed/noncompressed)
            //      ulong name string @ string table
            // ....filler....
            // @tableListOffset
            //      header:                                         4*2
            //          ulong sizeOfData ( including header )
            //          ulong stringsContained
            //      ulong offsetOfDataAfterTableListOffset          4*2*n
            //      ulong stringLength (including null terminating char)

            //TODO: Check if string table contains strings other than filenames

            //List<byte> datBytes = new List<byte>();
            UInt32 totalDatBytes = 0;
            List<UInt32> datFileOffsets = new List<UInt32>();
            List<UInt32> fileSizes = new List<UInt32>();
            //We start by packing the files into the .dat... We just archive all files and remember their offsets for later

            PrepareDirectory(targetDirectory);
            FileStream datFileStream = File.Create(targetDirectory + "\\output.raf.dat");
            for(int i = 0; i < archivedPaths.Count; i++)
            {
                //datFileOffsets.Add((UInt32)datBytes.Count);

                //LoL_Audio.fev and LoL_Audio.fsb aren't compressed.  We write them raw.
                if (uncompressedFiles.Contains(archivedPaths[i].ToLower()))
                {
                    //Write raw
                    ostream.WriteLine("No Compress: " + archivedPaths[i]);
                    fileSizes.Add((UInt32)new FileInfo(sourceDirectory + archivedPaths[i]).Length);
                    datFileOffsets.Add((UInt32)totalDatBytes);
                    //datBytes.AddRange(File.ReadAllBytes(sourceDirectory + archivedPaths[i]));
                    byte[] content = File.ReadAllBytes(sourceDirectory + archivedPaths[i]);
                    datFileStream.Write(content, 0, content.Length);
                    totalDatBytes += (UInt32)content.Length;
                }
                else
                {
                    ostream.WriteLine("Compress: " + archivedPaths[i]);
                    //FileStream fStream = new FileStream(sourceDirectory + archivedPaths[i], FileMode.Open);
                    //fStream.Seek(0, SeekOrigin.Begin);
                    //ostreamWriteLine("FStream Length: " + fStream.Length);
                    byte[] fileContent = File.ReadAllBytes(sourceDirectory + archivedPaths[i]);
                    ostream.WriteLine("Original Size:" + fileContent.Length);
                    MemoryStream mStream = new MemoryStream();
                    zlib.ZOutputStream oStream = new zlib.ZOutputStream(mStream, zlib.zlibConst.Z_DEFAULT_COMPRESSION); //using default compression level
                    oStream.Write(fileContent, 0, fileContent.Length);
                    oStream.finish();
                    byte[] compressedContent = mStream.ToArray();
                    datFileOffsets.Add((UInt32)totalDatBytes);
                    datFileStream.Write(compressedContent, 0, compressedContent.Length);
                    //datBytes.AddRange(compressedContent);//contentBuffer.SubArray(0, length));
                    //count += (UInt32)length;
                    totalDatBytes += (UInt32)compressedContent.Length;
                    ostream.WriteLine("Done, {0} bytes".F(compressedContent.Length));
                    fileSizes.Add((UInt32)compressedContent.Length);
                }
            }

            UInt32 finalLength = (UInt32)(2*4 + 3*4 + 4 + 4*4*archivedPaths.Count + 4*2 + 4*2*archivedPaths.Count + totalNameBytes);
            byte[] buffer = new byte[finalLength]; //0x18BE0EF0.. note that the settings to 0 aren't necessary, but they're
                                                    // for readability
            //Magic
            StoreUInt32InBuffer((UInt32)0x18BE0EF0, (UInt32)0, ref buffer);

            //Version
            StoreUInt32InBuffer((UInt32)0x00000001, (UInt32)4, ref buffer);

            //mgrIndex = 0
            StoreUInt32InBuffer((UInt32)0x00000000, (UInt32)8, ref buffer);
            
            //fileListOffset
            StoreUInt32InBuffer((UInt32)        20, (UInt32)12, ref buffer);
            
            //stringTableOffset
            StoreUInt32InBuffer((UInt32)(20+4+16*archivedPaths.Count), (UInt32)16, ref buffer);

            //Start file list
            UInt32 offset = 0x14; //20, header of file list

            //Store # entries in list
            StoreUInt32InBuffer((UInt32)archivedPaths.Count, offset, ref buffer);
            offset += 4;

            //Store entries
            for (int i = 0; i < archivedPaths.Count; i++)
            {
                ostream.WriteLine("Store Entry: " + archivedPaths[i]);
                //Hash of string name?  Get it from previous RAF files.
                StoreUInt32InBuffer(GetStringHash(archivedPaths[i]) , offset, ref buffer);

                // Offset to the start of the archived file in the data file
                ostream.WriteLine("  Dat Offset: " + datFileOffsets[i].ToString("x") + "; i="+i);
                StoreUInt32InBuffer(datFileOffsets[i]               , offset+4, ref buffer);

                // Size of this archived file
                StoreUInt32InBuffer(fileSizes[i]                    , offset+8, ref buffer);
                // Index of the name of the archvied file in the string table
                StoreUInt32InBuffer((UInt32)i                       , offset+12, ref buffer);
                offset += 16;
            }

            //Create String Tables
            UInt32 stringTableOffset = offset = (UInt32)(20 + 4 + 16 * archivedPaths.Count); //This should be equivalent to offset= offset at the moment...

            //Header: Uint32 size of all data including header
            //        UINT32 Number of strings in the table

            StoreUInt32InBuffer((UInt32)totalNameBytes, offset, ref buffer);
            offset += 4;
            StoreUInt32InBuffer((UInt32)archivedPaths.Count, offset, ref buffer);
            offset += 4;
            //Write entries: UINT32 Offset from start of table, UINT32 Size of String + NUL
            //Also write the actual string values
            for (int i = 0; i < archivedPaths.Count; i++)
            {
                ostream.WriteLine("Store String: " + archivedPaths[i]);
                //Write the offset for the string after the table's offset
                //               offset after table = header + entry count * 8 + [strings offset] * 8
                UInt32 offsetAfterTable = (UInt32)(8 + archivedPaths.Count * 8 + stringTableContentOffsets[i]);
                StoreUInt32InBuffer(offsetAfterTable, offset, ref buffer);
                offset += 4;
                
                //Length
                byte[] stringBytes = Encoding.ASCII.GetBytes(archivedPaths[i]);
                StoreUInt32InBuffer((UInt32)archivedPaths[i].Length + 1, offset, ref buffer);
                offset += 4;

                ostream.WriteLine("  STO:" + stringTableOffset.ToString("x"));
                ostream.WriteLine("  finalIndex:" + (stringTableOffset + 8 + archivedPaths.Count * 8 + stringTableContentOffsets[i]).ToString("x"));
                //Copy the string contents to where offsetAfterTable points to
                for (int j = 0; j < stringBytes.Length; j++)
                {
                    buffer[stringTableOffset+ 8 + archivedPaths.Count * 8 + stringTableContentOffsets[i] + j] = stringBytes[j];
                }
                //StoreUInt32InBuffer((UInt32)archivedPaths.Count, offset, ref buffer);
                //offset += 4;                
            }

            //We are done.  Write the files
            ostream.WriteLine("All files processed.  Writing to disk.");

            //buffer
            ostream.WriteLine("Prepare.");
            PrepareDirectory(targetDirectory);
            
            ostream.WriteLine("Write RAF Directory File.");
            File.WriteAllBytes(targetDirectory + "\\output.raf", buffer);

            ostream.WriteLine("Finalize");
            datFileStream.Flush();
            datFileStream.Close();
            //ostreamWriteLine("Write RAF Content File. Length:"+datBytes.Count);
            //File.WriteAllBytes(targetDirectory + "\\output.raf.dat", datBytes.ToArray());
            return true;
        }
        private static void PrepareDirectory(string path)
        {
            path = path.Replace("/", "\\");
            String[] dirs = path.Split("\\");
            for (int i = 1; i < dirs.Length; i++)
            {
                String dirPath = String.Join("\\", dirs.SubArray(0, i)) + "\\";
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                //ostreamWriteLine(dirPath);
            }
        }
        private void StoreUInt32InBuffer(UInt32 value, UInt32 offset, ref byte[] buffer)
        {
            buffer[offset+0] = (byte)(value & 0xFF);
            buffer[offset+1] = (byte)((value >>  8) & 0xFF);
            buffer[offset+2] = (byte)((value >> 16) & 0xFF);
            buffer[offset+3] = (byte)((value >> 24) & 0xFF);
        }
        private UInt32 GetStringHash(String s)
        {
            return RAFHashManager.GetHash(s.ToLower());
        }
    }
}
