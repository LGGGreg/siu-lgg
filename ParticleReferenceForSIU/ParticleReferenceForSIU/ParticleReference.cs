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
using SkinInstaller;
using System.Globalization;

namespace PartRef
{
    public partial class ParticleReference : Form
    {
        public ParticleReference()
        {
            InitializeComponent();
        }

        public class PStruct : Dictionary
                <String, Dictionary
                    <String, Dictionary
                        <RAFFileListEntry, List<String>>>> { }
        public SkinInstaller.skinInstaller mySkinInstaller = null;
        public int lastProgress = 0;

        String lolDirectory = "C:\\Riot Games\\League of Legends";

        FolderBrowserDialog lolDirBrowser = new FolderBrowserDialog();

        private void ParticleReference_Load(object sender, EventArgs e)
        {
            
            lolDirBrowser.Description = "Select your League of Legends game directory.\n(Example: C:\\Riot Games\\League of Legends)";
            lolDirBrowser.ShowNewFolderButton = false;
            lolDirBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            lolDirBrowser.Tag = "Particle Reference";
            if (!Directory.Exists(lolDirectory))
            {
                lolDirBrowser.ShowDialog();
                lolDirectory = lolDirBrowser.SelectedPath;
                this.Activate();
            }
        }
        public void reportProgress(int p)
        {
            if (p != lastProgress)
            {
                lastProgress = p;
                
                particleReaderWorker.ReportProgress(p);
            }
        }
        public PStruct getParticleStructure(string rafPath)
        {
            PStruct particleDef = new PStruct();

            try
            {
                List<RAFFileListEntry> fileList = new List<RAFFileListEntry>();
                String baseDir = rafPath;
                string[] files = Directory.GetFiles(baseDir, "*", SearchOption.AllDirectories);
                Directory.GetDirectories(baseDir);
                string[] array = files;
                int i = 0;
                List<String> rafFiles = new List<string>();
                reportProgress(1);
                for (i = 0; i < array.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(array[i]);

                    if (fileInfo.Extension == ".raf")
                    {
                        if (File.Exists(fileInfo.FullName + ".dat"))
                        {
                            rafFiles.Add(fileInfo.FullName);//add raf files to read afterwards
                        }
                    }
                    reportProgress((int)(((double)i * 10.0) / (double)array.Length) + 1);
                }
                reportProgress(12);
                i = 0;
                List<RAFFileList> listsToSearchLater = new List<RAFFileList>();
                foreach (String file in rafFiles)
                {
                    i++;
                    FileInfo rafFile = new FileInfo(file);
                    //time to process the raf files
                    RAFArchive raf = new RAFArchive(rafFile.FullName);
                    fileList.AddRange(raf.GetDirectoryFile().GetFileList().GetFileEntries());
                    listsToSearchLater.Add(raf.GetDirectoryFile().GetFileList());
                    raf.GetDataFileContentStream().Close();
                    reportProgress((int)(((double)i * 10.0) / (double)rafFiles.Count) + 12);
                }
                reportProgress(25);



                List<String> exceptions = new List<String>();
                i = 0;

                // Create place for unreferenced troybins to live
                particleDef["other"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
                particleDef["other"]["troybins"] = new Dictionary<RAFFileListEntry, List<String>>();

                // Create place for item troybins to live
                particleDef["items"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
                particleDef["items"]["troybins"] = new Dictionary<RAFFileListEntry, List<String>>();

                // Create place for map troybins to live
                particleDef["map"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
                particleDef["map"]["troybins"] = new Dictionary<RAFFileListEntry, List<String>>();

                // Create place for summoner spell troybins to live
                particleDef["summoner spells"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
                particleDef["summoner spells"]["troybins"] = new Dictionary<RAFFileListEntry, List<String>>();


                // Reference spellnames to champion names
                foreach (RAFFileListEntry file in fileList)
                {
                    i++;
                    reportProgress((int)(((double)i / (double)fileList.Count) * (double)10.0) + 25);
                    // Only use spell icon files
                    if (file.FileName.Contains("DATA/Spells/Icons2D"))
                    {
                        // Make sure it is a champion icon
                        String iconFileName = file.FileName.Substring(file.FileName.LastIndexOf('/') + 1, file.FileName.Length - file.FileName.LastIndexOf('/') - 1);
                        if (char.IsLetter(iconFileName.Substring(0, 1).ToCharArray()[0]))
                        {
                            String championName = String.Empty;
                            String spell = String.Empty;
                            // Manual spell fixes
                            // Fix for Nunu's absolute zero
                            if (iconFileName.ToLower() == "yeti_frostnova.dds")
                            {
                                championName = "yeti";
                                spell = "absolutezero";
                            }
                            // Fix for Master Yi's alpha strike
                            else if (iconFileName.ToLower().Contains("leapstrike"))
                            {
                                championName = "masteryi";
                                spell = "alphastrike";
                            }
                            // Fix for Master Yi's wuju style
                            else if (iconFileName.ToLower().Contains("sunderingstrikes"))
                            {
                                championName = "masteryi";
                                spell = "wujustyle";
                            }
                            else
                            {
                                // Naming scheme: Word separations is either with underscores or camelcase letters
                                if (iconFileName.Contains("_"))
                                {
                                    championName = iconFileName.Split('_')[0].ToLower();
                                    // Ignore chamion names that were incorrectly created by spellIcon algorithm
                                    if (championName == "eagleeye" || championName == "spiderqueen" || championName == "gw" || championName == "bantamsting" || championName == "toxicshot" || championName == "rod" || championName == "pet" || championName == "spell" || championName == "leblancmirrorimage" || championName == "storm" || championName == "odin" || championName == "crystal" || championName == "secondsight" || championName == "recall" || championName == "plantking" || championName == "summoner" || championName == "teleport" || championName == "gsb" || championName == "doublestrike" || championName == "waterwizard" || championName == "xinzhao" || championName == "destiny")
                                        continue;
                                    // Ignore fiddlestick as opposed to fiddlesticks
                                    if (championName == "fiddlestick")
                                        continue;
                                    // Fix referencing of Monkey King since his name is two words
                                    else if (championName == "monkey")
                                    {
                                        championName = "monkeyking";
                                        spell = iconFileName.Substring(10, iconFileName.Length - 10);
                                    }
                                    // Change the name of Rumble's ult so code isn't looking for "r" as a spell name
                                    else if (iconFileName == "Rumble_R.dds")
                                    {
                                        spell = "rumble_ult";
                                    }
                                    // Change Twisted Fate's spell names to prevent accidental matching
                                    else if (championName == "cardmaster" && iconFileName.Split('_')[1].Split('.')[0].ToLower().Replace(" ", "") == "red")
                                    {
                                        spell = "card_red";
                                    }
                                    else if (championName == "cardmaster" && iconFileName.Split('_')[1].Split('.')[0].ToLower().Replace(" ", "") == "blue")
                                    {
                                        spell = "card_blue";
                                    }
                                    else if (championName == "cardmaster" && iconFileName.Split('_')[1].Split('.')[0].ToLower().Replace(" ", "") == "gold")
                                    {
                                        spell = "card_yellow";
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
                                    for (int ii = 1; ii < charArray.Length; ii++)
                                    {
                                        if (char.IsUpper(charArray[ii]))
                                        {
                                            splitIndex = ii;
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
                                    // Ignore chamion names that were incorrectly created by spellIcon algorithm
                                    else if (championName == "eagleeye" || championName == "spiderqueen" || championName == "gw" || championName == "bantamsting" || championName == "toxicshot" || championName == "rod" || championName == "pet" || championName == "spell" || championName == "leblancmirrorimage" || championName == "storm" || championName == "odin" || championName == "crystal" || championName == "secondsight" || championName == "recall" || championName == "plantking" || championName == "summoner" || championName == "teleport" || championName == "gsb" || championName == "doublestrike" || championName == "waterwizard" || championName == "xinzhao" || championName == "destiny")
                                        continue;
                                    // Ignore fiddle's "paranoia" since it conflicts with nocturne's and fiddle's is extraneous anyways
                                    else if (championName == "fiddlesticks" && iconFileName.Substring(splitIndex, iconFileName.Length - splitIndex).Split('.')[0].ToLower().Replace(" ", "") == "paranoia")
                                        continue;
                                    // Fix referencing of Monkey King since his name is two words
                                    else if (championName == "monkey")
                                    {
                                        championName = "monkeyking";
                                        spell = iconFileName.Substring(10, iconFileName.Length - 10);
                                    }
                                    else
                                    {
                                        spell = iconFileName.Substring(splitIndex, iconFileName.Length - splitIndex).Split('.')[0].ToLower().Replace(" ", "");
                                    }
                                }
                            }

                            // Don't add passives to spell list because the name isn't unique
                            // All passives are named along with their champion name so no troybins should be skipped
                            if (spell == "passive")
                                continue;
                            // Don't use these as spell names because they mess up everything
                            // Damn you Trion for your naming
                            if (spell == "q" || spell == "w" || spell == "e" || spell == "r")
                            {
                                continue;
                            }

                            if (championName == "voidwalker")
                            {
                                championName = "kassadin";
                            }

                            // Create dictionary structure if it doesn't already exist
                            if (!particleDef.ContainsKey(championName))
                            {
                                particleDef[championName] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
                                particleDef[championName]["troybins"] = new Dictionary<RAFFileListEntry, List<String>>();
                            }
                            particleDef[championName][spell] = new Dictionary<RAFFileListEntry, List<String>>();
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
                // List so far: Xin Xhao, Tryndamere (?Dark champion?), Evelynn, 
                //
                // Figure out why 2 troybins are being missed (3011 vs 3013)
                //
                // Create "other" champion which will contain all the extra troybins, like nexus, summoner spells, general poison, et.
                //
                // Add exception for Trundle's bite vs. Anivia's Frostbite, Swain's torment vs. Morganna's tormented soul
                //
                //
                //

                int troybinTotal = 0;
                i = 0;
                reportProgress(36);
                // Search for troybins and inibins that correspond to the champion names
                foreach (RAFFileListEntry file in fileList)
                {
                    i++;
                    reportProgress((int)(((double)i * 10.0) / (double)fileList.Count) + 36);
                    if (file.FileName.Contains("DATA/Particles"))
                    {
                        String particleFileName = file.FileName.ToLower();

                        // Only look for troybins //// No longer looking for inibins as there are only 3 and all are irrelevant
                        if (particleFileName.IndexOf("troybin") != -1)
                        {
                            troybinTotal++; // For debugging purposes

                            // Check if it is an item
                            if (particleFileName.Contains("_itm") || particleFileName.Contains("zhonya") || particleFileName.Contains("yomu") || particleFileName.Contains("thornmail") || particleFileName.Contains("sword_of_the_divine") || particleFileName.Contains("sunfirecape") || particleFileName.Contains("shurelya") || particleFileName.Contains("randuinsomen") || particleFileName.Contains("quicksilversash") || particleFileName.Contains("odynsveil") || particleFileName.Contains("muramasablade") || particleFileName.Contains("mejai") || particleFileName.Contains("hextech") || particleFileName.Contains("guardianangel") || particleFileName.Contains("executionerscalling") || particleFileName.Contains("aegis"))
                            {
                                if (!particleDef["items"]["troybins"].ContainsKey(file))
                                {
                                    particleDef["items"]["troybins"][file] = new List<String>();
                                }
                                continue;
                            }
                            else if (particleFileName.Contains("nexus") || particleFileName.Contains("inhib") || particleFileName.Contains("shop") || particleFileName.Contains("turret") || particleFileName.Contains("odin") || particleFileName.Contains("tower") || particleFileName.Contains("capture_point") || particleFileName.Contains("chaos"))
                            {
                                if (!particleDef["map"]["troybins"].ContainsKey(file))
                                {
                                    particleDef["map"]["troybins"][file] = new List<String>();
                                }
                                continue;
                            }
                            else if (particleFileName.Contains("summoner_") || particleFileName.Contains("clairvoyance"))
                            {
                                if (!particleDef["summoner spells"]["troybins"].ContainsKey(file))
                                {
                                    particleDef["summoner spells"]["troybins"][file] = new List<String>();
                                }
                                continue;
                            }

                            Boolean matchFound = false;
                            foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>> championKVP in particleDef)
                            {
                                // Manual searching for special spellings/names of champions and/or spells
                                List<String> searchStrings = new List<String>();
                                searchStrings.Add(championKVP.Key);
                                switch (championKVP.Key)
                                {
                                    // Maokai
                                    case "maokai":
                                        searchStrings.Add("maoki");
                                        break;
                                    // Orianna
                                    case "orianna":
                                        searchStrings.Add("oriana");
                                        break;
                                    // Xen Zhao
                                    case "xenzhao":
                                        searchStrings.Add("xenziou");
                                        break;
                                    // Vladimir
                                    case "vladimir":
                                        searchStrings.Add("vlad");
                                        searchStrings.Add("vamp");
                                        break;
                                    // Cassiopeia
                                    case "cassiopeia":
                                        searchStrings.Add("cass");
                                        break;
                                    // Taric
                                    case "gemknight":
                                        searchStrings.Add("taric");
                                        break;
                                    // Alistar
                                    case "minotaur":
                                        searchStrings.Add("alistar");
                                        break;
                                    // Ashe
                                    case "bowmaster":
                                        searchStrings.Add("ashe");
                                        break;
                                    // Riven
                                    case "riven":
                                        searchStrings.Add("exile");
                                        break;
                                    // Chogath
                                    case "greenterror":
                                        searchStrings.Add("cho");
                                        searchStrings.Add("vorpal_spikes");
                                        searchStrings.Add("rupture");
                                        break;
                                    // Anivia
                                    case "cryophoenix":
                                        searchStrings.Add("cryo");
                                        break;
                                    // Tryndamere
                                    case "darkchampion":
                                        searchStrings.Add("tryndamere");
                                        searchStrings.Add("undyingrage");
                                        break;
                                    // Tristana
                                    case "tristana":
                                        searchStrings.Add("tristanna");
                                        break;
                                    // Twisted Fate
                                    case "cardmaster":
                                        searchStrings.Add("twistedfate");
                                        break;
                                    // Blitzcrank
                                    case "blitzcrank":
                                        searchStrings.Add("steamgolem");
                                        break;
                                    // Ryze
                                    case "ryze":
                                        searchStrings.Add("rhyze");
                                        break;
                                    // Renekton
                                    case "renekton":
                                        searchStrings.Add("renekhton");
                                        break;
                                    // Nasus
                                    case "nasus":
                                        searchStrings.Add("nassus");
                                        break;
                                    // Dr Mundo
                                    case "drmundo":
                                        searchStrings.Add("mundo");
                                        break;
                                    // Mordekaiser
                                    case "mordekaiser":
                                        searchStrings.Add("mordakaiser");
                                        break;
                                    // Kogmaw
                                    case "kogmaw":
                                        searchStrings.Add("kog");
                                        break;
                                    // Jax
                                    case "armsmaster":
                                        searchStrings.Add("jax");
                                        break;
                                    // JarvanIV
                                    case "jarvaniv":
                                        searchStrings.Add("jarvan");
                                        searchStrings.Add("jarvin");
                                        break;
                                    // Gangplank
                                    case "pirate":
                                        searchStrings.Add("gangplank");
                                        break;
                                    // Evelynn
                                    case "evelynn":
                                        searchStrings.Add("evelyn");
                                        searchStrings.Add("shadowwalk");
                                        break;
                                    // Chronokeeper
                                    case "chronokeeper":
                                        searchStrings.Add("chrono");
                                        searchStrings.Add("timebomb");
                                        break;
                                    // Malzahar
                                    case "alzahar": // Yes this *IS* how they spell it
                                        searchStrings.Add("voidling");
                                        break;
                                    // Udyr
                                    case "udyr":
                                        searchStrings.Add("pelt");
                                        searchStrings.Add("phoenixbreath");
                                        break;
                                    // Rammus
                                    case "armordillo":
                                        searchStrings.Add("tremors");
                                        break;
                                    // Teemo
                                    case "teemo":
                                        searchStrings.Add("toxicshot");
                                        searchStrings.Add("shroom");
                                        break;
                                    // Janna
                                    case "janna":
                                        searchStrings.Add("sowthewind");
                                        break;
                                    // Morgana
                                    case "fallenangel":
                                        searchStrings.Add("soulshackle");
                                        break;
                                    // Scion
                                    case "scion":
                                        searchStrings.Add("shadowcaress");
                                        break;
                                    // Fiddlesticks
                                    case "fiddlesticks":
                                        searchStrings.Add("party");
                                        break;
                                    // Kassadin
                                    case "kassadin":
                                        searchStrings.Add("nulllance");
                                        break;
                                }
                                // Search for the search strings in the troybin file name
                                foreach (String srchStr in searchStrings)
                                {
                                    if (particleFileName.Replace("_", "").ToLower().Contains(srchStr))
                                    {
                                        particleDef[championKVP.Key]["troybins"][file] = new List<String>();
                                        matchFound = true;
                                        break;
                                    }
                                }
                                if (matchFound)
                                    break;
                            }
                            if (!matchFound)
                                missedTroybins.Add(file);
                        }
                    }
                }

                String nonReferencedTroys = String.Empty;
                i = 0;
                reportProgress(47);
                // Search for troybins that correspond to the champion spells
                foreach (RAFFileListEntry troybin in missedTroybins)
                {
                    i++;
                    reportProgress((int)(((double)i * 10.0) / (double)missedTroybins.Count) + 47);
                    Boolean matchFound = false;
                    foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>> championKVP in particleDef)
                    {
                        foreach (KeyValuePair<String, Dictionary<RAFFileListEntry, List<String>>> spellKVP in championKVP.Value)
                        {
                            // Only use spells not troybin list
                            if (spellKVP.Key != "troybins")
                            {
                                // Search for spell names in the troybin file name
                                if (troybin.FileName.Replace("_", "").ToLower().IndexOf(spellKVP.Key.Replace("_", "").ToLower()) != -1)
                                {
                                    if (!particleDef[championKVP.Key]["troybins"].ContainsKey(troybin))
                                    {
                                        particleDef[championKVP.Key]["troybins"][troybin] = new List<String>();
                                    }
                                    matchFound = true;
                                    break;
                                }
                            }
                        }
                        if (matchFound)
                            break;
                    }
                    if (!matchFound)
                        if (!particleDef["other"]["troybins"].ContainsKey(troybin))
                        {
                            particleDef["other"]["troybins"][troybin] = new List<String>();
                            nonReferencedTroys += troybin.FileName + "\n";
                        }
                }

                reportProgress(58);
                i = 0;
                foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>> championKVP in particleDef)
                {
                    reportProgress((int)(((double)i * 40) / (double)particleDef.Count) + 58);
                    i++;
                    foreach (KeyValuePair<RAFFileListEntry, List<String>> troybinKVP in particleDef[championKVP.Key]["troybins"])
                    {
                        // Search troybins for .dds, .sco, .scb, etc.
                        // Create a new archive
                        RAFArchive rafArchive = new RAFArchive(troybinKVP.Key.RAFArchive.RAFFilePath);

                        // Get the data from the archive
                        MemoryStream myInput = new MemoryStream(rafArchive.GetDirectoryFile().GetFileList().GetFileEntry(troybinKVP.Key.FileName).GetContent());
                        StreamReader reader = new StreamReader(myInput);
                        String result = reader.ReadToEnd();
                        reader.Close();
                        myInput.Close();
                        // Release the archive
                        rafArchive.GetDataFileContentStream().Close();

                        String cleanString = Regex.Replace(result, @"[^\u0000-\u007F]", "").Replace('\0', '?');
                        Regex captureFileNames = new Regex(@"([a-zA-z0-9\-_ ]+\.(?:tga|sco|scb|dds|png))", RegexOptions.IgnoreCase);
                        MatchCollection matches = captureFileNames.Matches(cleanString);
                        foreach (Match match in matches)
                        {
                            particleDef[championKVP.Key]["troybins"][troybinKVP.Key].Add(match.Groups[1].Value);

                            //foreach (String file in rafFiles)
                            //{
                            //foreach(RAFFileList listToSearchNow in listsToSearchLater)
                            //{
                            //FileInfo rafFile = new FileInfo(file);
                            //time to process the raf files
                            //RAFArchive searchRaf = new RAFArchive(rafFile.FullName);

                            //searching takes forever, F that
                            //troybinKVP.Value.AddRange(listToSearchNow.SearchFileEntries(matchedFile));

                            //damnit this also takes freking forever!
                            /*
                            bool found = false;
                            RAFFileListEntry entry =
                                    listToSearchNow.GetFileEntry("DATA/Particles" + matchedFile);
                            if (entry != null)
                            {
                                troybinKVP.Value.Add(entry);
                                found = true;
                            }
                            if (matchedFile.ToLower().Contains(".tga"))
                            {
                                entry =
                                    listToSearchNow.GetFileEntry("DATA/Particles" + matchedFile.ToLower().Replace(".tga",".dds"));
                                if (entry != null)
                                {
                                    troybinKVP.Value.Add(entry);
                                    found = true;
                                }
                            }
                            if (!found)
                            {
                                //todo look at not found files and see whats up
                            }*/
                            //}

                            //screw it, just fake a entry :|
                            //in fact.. ill do the final search thingy when they actually export!
                            //RAFFileListEntry entry = new RAFFileListEntry(null, "DATA/Particles" + 
                            //    matchedFile.Replace(".tga",".dds").Replace(".TGA",".DDS"), 0,0,0);
                            //troybinKVP.Value.Add(entry);
                            //cleanString = matchedFile + "\r\n" + cleanString;
                            //searchRaf.GetDataFileContentStream().Close();

                        }
                        //if (textBox1.Text == "") textBox.AppendText(cleanString);



                    }
                }
                reportProgress(100);

            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("League of Legends directory not found. Please select your League of Legends folder.\n(Example: C:\\Riot Games\\League of Legends)", "Directory not found");
                return particleDef;
            }

            return particleDef;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            particleReaderWorker.RunWorkerAsync(lolDirectory + "\\RADS\\projects\\lol_game_client\\filearchives\\");
        }
        public void startGettingParticleStructure(skinInstaller source, string rafDirPath)
        {
            mySkinInstaller = source;
            particleReaderWorker.RunWorkerAsync(rafDirPath);       
        }

        private void particleReaderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = getParticleStructure((string)e.Argument);
        }

        private void particleReaderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (mySkinInstaller != null)
            {
                mySkinInstaller.recieveParticleProgress(e.ProgressPercentage);
            }
            if (this.Visible)
            {
                progressBar1.Value = e.ProgressPercentage;
                progressBar1.Refresh();
            }
        }

        private void particleReaderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            // Creates a TextInfo based on the "en-US" culture.
            TextInfo usTxtInfo = new CultureInfo("en-US", false).TextInfo;

            PStruct particleDef =(PStruct)e.Result;
            // If the directory is blank, an exception was thrown and the user needs to select their directory
            if (!(particleDef.Count > 0))
            {
                lolDirBrowser.ShowDialog();
                lolDirectory = lolDirBrowser.SelectedPath;
                button1.Enabled = true;
                return;
            }
            //int troybinCount = 0;
            if (this.Visible)
            {
                this.button1.Enabled = true;
                TreeNode rootNode = new TreeNode("root");
                // Display particleDef for debugging purposes
                foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>> championKVP in particleDef)
                {
                    TreeNode champNode = rootNode.Nodes.Add(usTxtInfo.ToTitleCase(championKVP.Key));
                    foreach (KeyValuePair<RAFFileListEntry, List<String>> troybinKVP in particleDef[championKVP.Key]["troybins"])
                    {
                        Match match = Regex.Match(troybinKVP.Key.FileName, "/(.+).troybin", RegexOptions.IgnoreCase);
                        TreeNode troybinNode = champNode.Nodes.Add(match.Groups[1].Value.Split('/')[1]);
                        //troybinCount++;
                        foreach (String fileEntry in troybinKVP.Value)
                        {
                            troybinNode.Nodes.Add(fileEntry);
                        }
                    }
                }
                treeView1.Nodes.Add(rootNode);
                treeView1.Sort();
            }
            if (mySkinInstaller != null)
            {
                mySkinInstaller.recieveParticleInformation(particleDef);
            }
            //int temp = troybinCount + leftoverTroybins.Count;
            //textBox.AppendText("Troybins identified: ");// + troybinCount);
        }
    }
}
