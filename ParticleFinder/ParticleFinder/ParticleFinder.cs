using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAFLib;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;

namespace ParticleFinder
{
    public partial class ParticleFinder : Form
    {
        public ParticleFinder()
        {
            InitializeComponent();
        }

        public class PStruct : Dictionary
                    <String, Dictionary
                        <String, Dictionary
                            <RAFFileListEntry, List<String>>>> { }
        public int lastProgress = 0;

        String lolDirectory = "C:\\Riot Games\\League of Legends";

        FolderBrowserDialog lolDirBrowser = new FolderBrowserDialog();

        Stopwatch totalTime = new Stopwatch();
        Stopwatch getRAFEntryTime = new Stopwatch();
        Stopwatch searchTroyTime = new Stopwatch();
        Stopwatch readTroyContent = new Stopwatch();

        private void ParticleFinder_Load(object sender, EventArgs e)
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
                
                ParticleReferenceWorker.ReportProgress(p);
            }
        }
        public PStruct getParticleStructure(string rafPath)
        {
            PStruct particleDef = new PStruct();

            // Browse LoL directory and find .raf files
            List<RAFFileListEntry> fileList = new List<RAFFileListEntry>();
            Dictionary<string, RAFFileListEntry> rafReference = new Dictionary<String,RAFFileListEntry>();
            List<RAFArchive> archiveList = new List<RAFArchive>();
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
                
            // Get file names out of .raf files
            i = 0;
            foreach (String file in rafFiles)
            {
                i++;
                FileInfo rafFile = new FileInfo(file);
                //time to process the raf files
                RAFArchive raf = new RAFArchive(rafFile.FullName);
                fileList.AddRange(raf.GetDirectoryFile().GetFileList().GetFileEntries());
                archiveList.Add(raf);
                reportProgress((int)(((double)i * 10.0) / (double)rafFiles.Count) + 12);
            }
            foreach (RAFFileListEntry entry in fileList)
            {
                String fileName = entry.FileName.Substring(entry.FileName.LastIndexOf('/') + 1, entry.FileName.Length - entry.FileName.LastIndexOf('/') - 1).ToLower();
                if (entry.FileName.Contains("Particles/") && !entry.FileName.Contains("Particles/override/") && !entry.FileName.Contains("Particles/YomuBKup/") && !rafReference.ContainsKey(fileName))
                {
                    rafReference.Add(fileName, entry);
                }
            }
            reportProgress(25);

            // Create place for unreferenced troybins to live
            particleDef["other"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

            // Create place for item troybins to live
            particleDef["items"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

            // Create place for map troybins to live
            particleDef["map"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

            // Create place for summoner spell troybins to live
            particleDef["summoner spells"] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();

            

            totalTime.Start();

            i = 0;
            // Search through DATA/Spells directory
            foreach (RAFFileListEntry file in fileList)
            {
                i++;
                reportProgress((int)(((double)i / (double)fileList.Count) * (double)74) + 25);
                // Only use spell files (exclude sub directories)
                if (file.FileName.Contains("DATA/Spells") && !file.FileName.Contains("DATA/Spells/Icons2D") && !file.FileName.Contains("DATA/Spells/Textures"))
                {
                    FileInfo fileInfo = new FileInfo(file.FileName);
                    if (fileInfo.Extension == ".luaobj" || fileInfo.Extension == ".inibin")
                    {
                        String shortFileName = file.FileName.Substring(file.FileName.LastIndexOf('/') + 1, file.FileName.Length - file.FileName.LastIndexOf('/') - 8);
                        String championName = String.Empty;

                        // Find index of second uppercase letter
                        int splitIndex = 0;
                        char[] charArray = shortFileName.ToCharArray();
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
                            championName = shortFileName.ToLower();
                        }
                        else
                        {
                            championName = shortFileName.Substring(0, splitIndex).ToLower();
                        }

                        switch (championName)
                        {
                            // Files to skip
                            case "200":
                            case "abpons":
                            case "a":
                            case "action":
                            case "archers":
                            case "ardor":
                            case "archangels":
                            case "atmas":
                            case "avarice":
                            case "backstab":
                            case "bandagetoss":
                            case "base":
                            case "battle":
                            case "beast":
                            case "bloodrazor":
                            case "boots":
                            case "bow":
                            case "brutalizer":
                            case "camouflage":
                            case "cant":
                            case "cast":
                            case "caster":
                            case "chalice":
                            case "champion":
                            case "charm":
                            case "colossal":
                            case "cripple":
                            case "cursed":
                            case "destealth":
                            case "destiny_marker":
                            case "disable":
                            case "disarm":
                            case "disconnect":
                            case "dragonbuff":
                            case "draw":
                            case "dummy":
                            case "duress":
                            case "eagleeye":
                            case "empowered":
                            case "end":
                            case "enhanced":
                            case "equipment":
                            case "doran":
                                championName = "";
                                break;
                            // Nunu
                            case "absolute":
                            case "consume":
                                championName = "nunu";
                                break;
                            // Items
                            case "abyssal":
                            case "aegisofthe":
                            case "arch":
                            case "banshees":
                            case "bloodthirster":
                            case "breathstealer":
                            case "catalyst":
                            case "deathfire":
                            case "emblem":
                            case "entropy":
                                championName = "items";
                                break;
                            // Malzahar
                            case "al":
                                championName = "malzahar";
                                break;
                            // Master Yi
                            case "alpha":
                            case "double":
                                championName = "masteryi";
                                break;
                            // Map
                            case "ancient":
                            case "beacon":
                            case "blessingofthe":
                            case "blue_":
                            case "call":
                            case "chaos":
                            case "crest":
                            case "crestof":
                            case "crestofthe":
                            case "dragon":
                                championName = "map";
                                break;
                            // Ryze
                            case "arcane":
                            case "desperate":
                                championName = "ryze";
                                break;
                            // Jax
                            case "armsmaster":
                            case "counter":
                            case "empower":
                                championName = "jax";
                                break;
                            // Rammus
                            case "armordillo":
                            case "defensive":
                                championName = "rammus";
                                break;
                            // Nidalee
                            case "aspect":
                            case "bushwhack":
                                championName = "nidalee";
                                break;
                            // Soraka
                            case "astral":
                            case "consecration":
                                championName = "soraka";
                                break;
                            // Amumu
                            case "auraof":
                            case "bandage":
                            case "curseofthe":
                                championName = "amumu";
                                break;
                            // Teemo
                            case "bantam":
                            case "blinding":
                                championName = "teemo";
                                break;
                            // Gankplank
                            case "bilgewater":
                                championName = "gankplank";
                                break;
                            // Black disambiguation
                            case "black":
                                if (shortFileName.Contains("cleaver"))
                                {
                                    championName = "items";
                                    break;
                                }
                                else if (shortFileName.Contains("omen"))
                                {
                                    championName = "";
                                    break;
                                }
                                championName = "morgana";
                                break;
                            // Lee Sin
                            case "blind":
                                championName = "leesin";
                                break;
                            // Blood disambiguation
                            case "blood":
                                if (shortFileName.Contains("boil"))
                                {
                                    championName = "nunu";
                                    break;
                                }
                                championName = "warwick";
                                break;
                            // Tryndamere
                            case "bloodlust":
                                championName = "tryndamere";
                                break;
                            // Blue disambiguation
                            case "blue":
                                if (shortFileName.Contains("card"))
                                {
                                    championName = "twistedfate";
                                    break;
                                }
                                championName = "map";
                                break;
                            // Katarina
                            case "bouncing":
                                championName = "katarina";
                                break;
                            // Burning disambiguation
                            case "burning":
                                if (shortFileName.Contains("agony"))
                                {
                                    championName = "drmundo";
                                    break;
                                }
                                else if (shortFileName.Contains("embers"))
                                {
                                    championName = "";
                                    break;
                                }
                                championName = "items";
                                break;
                            // Tristana
                            case "buster":
                            case "detonating":
                                championName = "tristana";
                                break;
                            // Heimerdinger
                            case "c":
                                championName = "heimerdinger";
                                break;
                            // Sion
                            case "cannibalism":
                            case "cryptic":
                            case "deaths":
                            case "enrage":
                                championName = "sion";
                                break;
                            // Cannon disambiguation
                            case "cannon":
                                if (shortFileName.Contains("barrage"))
                                {
                                    championName = "gangplank";
                                    break;
                                }
                                championName = "";
                                break;
                            // Twisted Fate
                            case "card":
                            case "cardmaster":
                            case "destiny":
                                championName = "twistedfate";
                                break;
                            // Cho'Gath
                            case "carnivore":
                                championName = "chogath";
                                break;
                            // Corki
                            case "carpet":
                                championName = "corki";
                                break;
                            // Global buffs/debuffs
                            case "chilled":
                                championName = "global";
                                break;
                            // Zilean
                            case "chrono":
                                championName = "zilean";
                                break;
                            // Fiddlesticks
                            case "crowstorm":
                            case "drain":
                                championName = "fiddlesticks";
                                break;
                            // Ashe
                            case "crystallize":
                            case "enchanted":
                                championName = "ashe";
                                break;
                            // Rumble
                            case "danger":
                                championName = "rumble";
                                break;
                            // Dark disambiguation
                            case "dark":
                                if (shortFileName.Contains("binding"))
                                {
                                    championName = "morgana";
                                    break;
                                }
                                championName = "fiddlesticks";
                                break;
                            // Taric
                            case "dazzle":
                                championName = "taric";
                                break;
                            // Twitch
                            case "deadly":
                            case "debilitating":
                                championName = "twitch";
                                break;
                            // Death disambiguation
                            case "death":
                                if (shortFileName.Contains("craze"))
                                {
                                    championName = "";
                                    break;
                                }
                                else if (shortFileName.Contains("defied"))
                                {
                                    championName = "karthus";
                                    break;
                                }
                                championName = "katarina";
                                break;
                            // Shaco
                            case "deceive":
                                championName = "shaco";
                                break;
                            // Karthus
                            case "defile":
                                championName = "karthus";
                                break;
                            // Annie
                            case "disintegrate":
                                championName = "annie";
                                break;
                            // Dr Mundo
                            case "dr":
                                championName = "drmundo";
                                break;
                            // Morgana
                            case "empathize":
                                championName = "morgana";
                                break;
                            // Warwick
                            case "eternal":
                                championName = "warwick";
                                break;
                            // 





                        }

                            
                        if (championName != "")
                        {
                            // Add to dictionary
                            if (!particleDef.ContainsKey(championName))
                            {
                                particleDef[championName] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
                            }
                            if (!particleDef[championName].ContainsKey(shortFileName))
                            {
                                particleDef[championName][shortFileName] = new Dictionary<RAFFileListEntry, List<String>>();
                            }

                            // Search luaobj's for .troy or .troybin
                            // Get the content from the luaobj's
                            MemoryStream myInput = new MemoryStream(file.GetContent());
                            StreamReader reader = new StreamReader(myInput);
                            String result = reader.ReadToEnd();
                            reader.Close();
                            myInput.Close();

                            String cleanString = Regex.Replace(result, @"[^\u0000-\u007F]", "").Replace('\0', '?');
                            Regex captureFileNames = new Regex(@"([a-zA-z0-9\-_ ]+\.)(?:troy|troybin)", RegexOptions.IgnoreCase);
                            MatchCollection matches = captureFileNames.Matches(cleanString);
                            foreach (Match match in matches)
                            {
                                // Get RAFFileListEntry for the troybin
                                RAFFileListEntry troyEntry = null;
                                String matchStr = match.Groups[1].ToString().ToLower() + "troybin";
                                getRAFEntryTime.Start();
                                if(rafReference.ContainsKey(matchStr))
                                {
                                    troyEntry = rafReference[matchStr];
                                }
                                getRAFEntryTime.Stop();

                                if (troyEntry != null)
                                {
                                    // Add to dictionary
                                    if (!particleDef[championName][shortFileName].ContainsKey(troyEntry))
                                    {
                                        particleDef[championName][shortFileName][troyEntry] = new List<String>();
                                    }

                                    searchTroyTime.Start();
                                    // Search troybins for .dds, .sco, .scb, etc.
                                    MemoryStream myInputTwo = new MemoryStream(troyEntry.GetContent());
                                    StreamReader readerTwo = new StreamReader(myInputTwo);
                                    String resultTwo = readerTwo.ReadToEnd();
                                    readerTwo.Close();
                                    myInputTwo.Close();

                                    cleanString = Regex.Replace(resultTwo, @"[^\u0000-\u007F]", "").Replace('\0', '?');
                                    captureFileNames = new Regex(@"([a-zA-z0-9\-_ ]+\.(?:tga|sco|scb|dds|png))", RegexOptions.IgnoreCase);
                                    MatchCollection troyMatches = captureFileNames.Matches(cleanString);

                                    foreach (Match particleMatch in troyMatches)
                                    {
                                        if (!particleDef[championName][shortFileName][troyEntry].Contains(particleMatch.Value))
                                        {
                                            particleDef[championName][shortFileName][troyEntry].Add(particleMatch.Value);
                                        }
                                    }

                                    searchTroyTime.Stop();
                                }
                            }
                        }
                    }
                }

            }

            foreach (RAFArchive archive in archiveList)
            {
                archive.GetDataFileContentStream().Close();
            }

            totalTime.Stop();

            reportProgress(100);

            return particleDef;
        }

        private void findParticles_Click(object sender, EventArgs e)
        {
            ParticleReferenceWorker.RunWorkerAsync(lolDirectory + "\\RADS\\projects\\lol_game_client\\filearchives\\");
        }

        private void ParticleReferenceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = getParticleStructure(e.Argument.ToString());
        }

        private void ParticleReferenceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != progressBar1.Value)
            {
                progressBar1.Value = e.ProgressPercentage;
                progress_lbl.Text = e.ProgressPercentage.ToString();
            }
        }

        private void ParticleReferenceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            // Creates a TextInfo based on the "en-US" culture.
            TextInfo usTxtInfo = new CultureInfo("en-US", false).TextInfo;

            PStruct particleDef = (PStruct)e.Result;

            TreeNode rootNode = new TreeNode("root");
            // Display particleDef for debugging purposes
            foreach (KeyValuePair<String, Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>> championKVP in particleDef)
            {
                TreeNode champNode = rootNode.Nodes.Add(usTxtInfo.ToTitleCase(championKVP.Key));
                foreach (KeyValuePair<String, Dictionary<RAFFileListEntry, List<String>>> abilityKVP in championKVP.Value)
                {
                    TreeNode abilityNode = champNode.Nodes.Add(abilityKVP.Key);
                    foreach (KeyValuePair<RAFFileListEntry, List<String>> troybinKVP in abilityKVP.Value)
                    {
                        Match match = Regex.Match(troybinKVP.Key.FileName, "/(.+).troybin", RegexOptions.IgnoreCase);
                        TreeNode troybinNode = abilityNode.Nodes.Add(match.Groups[1].Value.Split('/')[1]);
                        foreach (String fileEntry in troybinKVP.Value)
                        {
                            troybinNode.Nodes.Add(fileEntry);
                        }
                    }
                }
            }
            treeView1.Nodes.Add(rootNode);
            treeView1.Sort();
        }


    }
}
