using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RAFLib;
using System.Text.RegularExpressions;

namespace ParticleReferenceForSIU
{
    public partial class ParticleReference : Form
    {
        public ParticleReference()
        {
            InitializeComponent();
        }

        private void ParticleReference_Load(object sender, EventArgs e)
        {
            
        }
        public Dictionary
                <String, Dictionary
                    <String, Dictionary
                        <RAFFileListEntry, List<RAFFileListEntry>>>> getParticleStructure(string rafPath)
        {

            List<RAFFileListEntry> fileList = new List<RAFFileListEntry>();
            String baseDir = rafPath;
            string[] files = Directory.GetFiles(baseDir, "*", SearchOption.AllDirectories);
            Directory.GetDirectories(baseDir);
            string[] array = files;
            List<String> rafFiles = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(array[i]);

                if (fileInfo.Extension == ".raf")
                {
                    if (File.Exists(fileInfo.FullName + ".dat"))
                    {
                        rafFiles.Add(fileInfo.FullName);//add raf files to read afterwards
                    }
                }
            }

            foreach (String file in rafFiles)
            {
                FileInfo rafFile = new FileInfo(file);
                //time to process the raf files
                RAFArchive raf = new RAFArchive(rafFile.FullName);
                fileList.AddRange(raf.GetDirectoryFile().GetFileList().GetFileEntries());
                raf.GetDataFileContentStream().Close();
            }

            Dictionary<String, Dictionary
                <String, Dictionary
                    <RAFFileListEntry, List<RAFFileListEntry>>>> particleDef = new Dictionary<String, Dictionary<String, Dictionary<RAFFileListEntry, List<RAFFileListEntry>>>>();
            List<String> exceptions = new List<String>();

            // Reference spellnames to champion names
            foreach ( RAFFileListEntry file in fileList)
            {
                // Only use spell icon files
                if (file.FileName.Contains("DATA/Spells/Icons2D"))
                {
                    // Make sure it is a champion icon
                    String iconFileName = file.FileName.Substring(file.FileName.LastIndexOf('/') + 1, file.FileName.Length - file.FileName.LastIndexOf('/') - 1);
                    if (char.IsLetter(iconFileName.Substring(0, 1).ToCharArray()[0]))
                    {
                        String championName = String.Empty;
                        String spell = String.Empty;
                        // Naming scheme: Word separations is either with underscores or camelcase letters
                        if (iconFileName.Contains("_"))
                        {
                            championName = iconFileName.Split('_')[0].ToLower();
                            // Change the name of Rumble's ult so code isn't lookin for "r" as a spell name
                            if (iconFileName == "Rumble_R.dds")
                            {
                                spell = "rumble_ult";
                            }
                            else
                            {
                                spell = iconFileName.Split('_')[1].Split('.')[0].ToLower().Replace(" ", "");
                            }
                        }
                        else

                        {
                            // Find index of second uppercase letter
                            int splitIndex = 0;
                            char[] charArray = iconFileName.ToCharArray();
                            for (int i = 1; i < charArray.Length; i++)
                            {
                                if (char.IsUpper(charArray[i]))
                                {
                                    splitIndex = i;
                                    break;
                                }
                            }

                            if (splitIndex == 0)
                            {
                                // Store exceptions for debugging purposes
                                exceptions.Add(iconFileName);
                                continue;
                            }

                            championName = iconFileName.Substring(0, splitIndex).ToLower();
                            // Ignore "IsPriate, IsNinja, etc. "
                            if (championName == "is")
                                continue;
                            spell = iconFileName.Substring(splitIndex, iconFileName.Length - splitIndex).Split('.')[0].ToLower().Replace(" ", "");
                        }

                        // Don't add passives to spell list because the name isn't unique
                        // All passives are named along with their champion name so no troybins should be skipped
                        if (spell == "passive")
                            continue;

                        // Create dictionary structure if it doesn't already exist
                        if (!particleDef.ContainsKey(championName))
                        {
                            particleDef[championName] = new Dictionary<String, Dictionary<RAFFileListEntry, List<RAFFileListEntry>>>();
                            particleDef[championName]["troybins"] = new Dictionary<RAFFileListEntry, List<RAFFileListEntry>>();
                        }
                        particleDef[championName][spell] = new Dictionary<RAFFileListEntry, List<RAFFileListEntry>>();
                    }
                    else
                    {
                        // Store exceptions for debugging purposes
                        exceptions.Add(iconFileName);
                    }
                }
            }

            List<RAFFileListEntry> missedTroybins = new List<RAFFileListEntry>();

            // 
            // Need to add exceptions for champions who's name spelling changes from icon to troybin
            // List so far: Orianna, Maokai, Xin Xhao, Tryndamere (?Dark champion?), Evelynn, 
            //
            // Figure out why 2 troybins are being missed (3011 vs 3013)
            //
            // Create "other" champion which will contain all the extra troybins, like nexus, summoner spells, general poison, et.
            //
            // Add exception for Trundle's bite vs. Anivia's Frostbite, Swain's torment vs. Morganna's tormented soul
            //
            // Delete champions: "eagleeye", "spiderqueen", "gw", "bantamsting", "toxicshot", "rod", "pet", "spell", "leblancmirrorimage", "storm", 
            //                   "odin", "crystal", 
            //
            // Add exception to champion/spell splitting for MonkeyKing
            //
            //
            //

            int troybinTotal = 0;

            // Search for troybins and inibins that correspond to the champion names
            foreach (RAFFileListEntry file in fileList)
            {
                if (file.FileName.Contains("DATA/Particles"))
                {
                    String particleFileName = file.FileName.ToLower();

                    // Only look for troybins and inibins
                    if (particleFileName.IndexOf("troybin") != -1 || particleFileName.IndexOf("inibin") != -1)
                    {
                        troybinTotal++; // For debugging purposes
                        Boolean matchFound = false;
                        foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<RAFFileListEntry>>>> championKVP in particleDef)
                        {
                            // Search for the champion's name in the troybin file name
                            if (particleFileName.Replace("_", "").IndexOf(championKVP.Key) != -1)
                            {
                                particleDef[championKVP.Key]["troybins"][file] = new List<RAFFileListEntry>();
                                matchFound = true;
                                break;
                            }
                        }
                        if(!matchFound)
                            missedTroybins.Add(file);
                    }
                }
            }

            List<RAFFileListEntry> leftoverTroybins = new List<RAFFileListEntry>();

            // Search for troybins and inibins that correspond to the champion spells
            foreach (RAFFileListEntry troybin in missedTroybins)
            {
                Boolean matchFound = false;
                foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<RAFFileListEntry>>>> championKVP in particleDef)
                {
                    // Only use spells not troybin list
                    if(championKVP.Key != "troybins")
                    {
                        // Search for spell names in the troybin file name
                        if (troybin.FileName.Replace("_", "").IndexOf(championKVP.Key.Replace("_", "")) != -1)
                        {
                            if (!particleDef[championKVP.Key]["troybins"].ContainsKey(troybin))
                            {
                                particleDef[championKVP.Key]["troybins"][troybin] = new List<RAFFileListEntry>();
                            }
                            matchFound = true;
                            break;
                        }
                    }
                }
                if (!matchFound)
                    leftoverTroybins.Add(troybin);
            }

            //foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<RAFFileListEntry>>>> championKVP in particleDef)
            //{
            //    foreach (KeyValuePair<RAFFileListEntry, List<RAFFileListEntry>> troybinKVP in particleDef[championKVP.Key]["troybins"])
            //    {
            //        // Search troybins for .dds, .sco, .scb, etc.
            //        // Create a new archive
            //        RAFArchive rafArchive = troybinKVP.Key.RAFArchive;

            //        // Get the data from the archive
            //        MemoryStream myInput = new MemoryStream(rafArchive.GetDirectoryFile().GetFileList().GetFileEntry(troybinKVP.Key.FileName).GetContent());
            //        StreamReader reader = new StreamReader(myInput);
            //        String result = reader.ReadToEnd();
            //        reader.Close();
            //        myInput.Close();

            //        // Release the archive
            //        rafArchive.GetDataFileContentStream().Close();
            //    }
            //}


            return particleDef;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary
                <String, Dictionary
                    <String, Dictionary
                        <RAFFileListEntry, List<RAFFileListEntry>>>>
                            particleDef = getParticleStructure("C:\\Riot Games\\League of Legends\\RADS\\projects\\lol_game_client\\filearchives\\");

            //int troybinCount = 0;
            // Display particleDef for debugging purposes
            foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<RAFFileListEntry>>>> championKVP in particleDef)
            {
                textBox.AppendText(championKVP.Key + "->>\n");
                textBox.AppendText("\tSpell->>\n");
                foreach (KeyValuePair<String, Dictionary<RAFFileListEntry, List<RAFFileListEntry>>> spellKVP in particleDef[championKVP.Key])
                {
                    if (spellKVP.Key != "troybins")
                    {
                        textBox.AppendText("\t\t" + spellKVP.Key + "\n");
                    }
                }
                textBox.AppendText("\tTroybins->>\n");
                foreach (KeyValuePair<RAFFileListEntry, List<RAFFileListEntry>> troybinKVP in particleDef[championKVP.Key]["troybins"])
                {
                    textBox.AppendText("\t\t" + troybinKVP.Key.FileName + "\n");
                    //troybinCount++;
                }
            }
            //int temp = troybinCount + leftoverTroybins.Count;
            textBox.AppendText("Troybins identified: ");// + troybinCount);

        }
    }
}
