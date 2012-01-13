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
using System.Threading;

namespace ParticleFinder
{
    public partial class ParticleFinderNew : Form
    {
        public ParticleFinderNew()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            
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
                            case "executioners":
                            case "expiration":
                            case "facing":
                            case "feast_internal":
                            case "feel":
                            case "fiendish":
                            case "fireofthe":
                            case "flashfrost":
                            case "fleetof":
                            case "flurry":
                            case "focus":
                            case "forceof":
                            case "forcepulsechaos":
                            case "fortify":
                            case "from":
                            case "gemcraft":
                            case "h":
                            case "hardening":
                            case "haunting":
                            case "heart":
                            case "heightened":
                            case "hunter":
                            case "if":
                            case "individual":
                            case "infinity":
                            case "insta":
                            case "internal_15":
                            case "internal_20":
                            case "internal_30":
                            case "internal_35":
                            case "internal_40":
                            case "internal_50":
                            case "invulnerability":
                            case "ionian":
                            case "is":
                            case "jarvin":
                            case "kages":
                            case "katsudions":
                            case "kindlegem":
                            case "kriggers":
                            case "last":
                            case "lifesteal":
                            case "m":
                            case "madreds":
                            case "malady":
                            case "malice_marker":
                            case "malice_markertwo":
                            case "marker":
                            case "mastery":
                            case "mejais":
                            case "mercury":
                            case "minion":
                            case "nashors":
                            case "near":
                            case "negative":
                            case "nevershade":
                            case "nimbleness":
                            case "no":
                            case "non":
                            case "offensive":
                            case "passions":
                            case "personal":
                            case "philosophers":
                            case "positive":
                            case "potion_":
                            case "powerball":
                            case "promote":
                            case "puncturing":
                            case "pyromania":
                            case "pyromania_marker":
                            case "rageblade":
                            case "reinforce":
                            case "remove":
                            case "renewal":
                            case "resistant":
                            case "respawn":
                            case "revive":
                            case "ritual":
                            case "root":
                            case "rylais":
                            case "second":
                            case "set":
                            case "share":
                            case "shared":
                            case "shell":
                            case "silent":
                            case "sleep":
                            case "smite":
                            case "speed":
                            case "spider":
                            case "spiked":
                            case "stealth":
                            case "sting":
                            case "strength":
                            case "structure":
                            case "suppression":
                            case "swashbuckler":
                            case "sweep":
                            case "sweeping":
                            case "tailwind":
                            case "techmaturgical":
                            case "tosajiros":
                            case "toxicshotapplicator":
                            case "true":
                            case "turret":
                            case "unlock":
                            case "untargetable":
                            case "valkyrie":
                            case "visionary_":
                            case "visionary_marker":
                            case "was":
                            case "weapon":
                            case "wits":
                            case "wrathfire":
                            case "urf":
                                championName = "";
                                break;
                            // Nunu
                            case "absolute":
                            case "consume":
                            case "visionary":
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
                            case "frozen":
                            case "guardian":
                            case "hexdrinker":
                            case "hextech":
                            case "innervating":
                            case "leviathan":
                            case "lich":
                            case "lightning":
                            case "lightstriker":
                            case "manamune":
                            case "mourning":
                            case "muramasa":
                            case "odyns":
                            case "oracle":
                            case "pendantof":
                            case "potion":
                            case "pride":
                            case "purple":
                            case "quicksilver":
                            case "rallying":
                            case "randuins":
                            case "refresh":
                            case "rod":
                            case "sheen":
                            case "shurelyas":
                            case "sight":
                            case "soulsteal":
                            case "sunfire":
                            case "tear":
                            case "tears":
                            case "thornmail":
                            case "vision":
                            case "warmogs":
                            case "wizards":
                            case "wriggle":
                            case "youmus":
                            case "zhonyas":
                                championName = "items";
                                break;
                            // Malzahar
                            case "al":
                            case "voidportal":
                                championName = "malzahar";
                                break;
                            // Master Yi
                            case "alpha":
                            case "double":
                            case "haste":
                            case "highlander":
                            case "master":
                            case "meditate":
                            case "wuju":
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
                            case "exalted":
                            case "ghast":
                            case "giant":
                            case "golem":
                            case "golembuff":
                            case "halloween":
                            case "lesser":
                            case "lizard":
                            case "lizardbuff":
                            case "monster":
                            case "odin":
                            case "odin_":
                            case "order":
                            case "order_":
                            case "red_":
                            case "skeleton_":
                            case "small":
                            case "tutorial":
                            case "tutorial_":
                            case "waypoint":
                            case "wolf":
                            case "worm":
                            case "wraith":
                            case "wrath":
                            case "wrathofthe":
                            case "young":
                                championName = "map";
                                break;
                            // Ryze
                            case "arcane":
                            case "desperate":
                            case "overload":
                            case "rune":
                                championName = "ryze";
                                break;
                            // Jax
                            case "armsmaster":
                            case "counter":
                            case "empower":
                            case "leap":
                            case "relentless":
                                championName = "jax";
                                break;
                            // Rammus
                            case "armordillo":
                            case "defensive":
                            case "tremors2":
                                championName = "rammus";
                                break;
                            // Nidalee
                            case "aspect":
                            case "bushwhack":
                            case "javelin":
                            case "nidalee_":
                            case "pounce":
                            case "primal":
                            case "prowl":
                            case "swipe":
                            case "takedown":
                                championName = "nidalee";
                                break;
                            // Soraka
                            case "astral":
                            case "consecration":
                            case "infuse":
                            case "starcall":
                            case "wish":
                                championName = "soraka";
                                break;
                            // Amumu
                            case "auraof":
                            case "bandage":
                            case "curseofthe":
                            case "sad":
                            case "tantrum":
                                championName = "amumu";
                                break;
                            // Teemo
                            case "bantam":
                            case "blinding":
                            case "move":
                            case "sow":
                            case "toxic":
                            case "trailblazer":
                                championName = "teemo";
                                break;
                            // Black disambiguation
                            case "black":
                                if (shortFileName.ToLower().Contains("cleaver"))
                                {
                                    championName = "items";
                                    break;
                                }
                                else if (shortFileName.ToLower().Contains("omen"))
                                {
                                    championName = "";
                                    break;
                                }
                                championName = "morgana";
                                break;
                            // Lee Sin
                            case "blind":
                            case "lee":
                                championName = "leesin";
                                break;
                            // Blood disambiguation
                            case "blood":
                                if (shortFileName.ToLower().Contains("boil"))
                                {
                                    championName = "nunu";
                                    break;
                                }
                                championName = "warwick";
                                break;
                            // Tryndamere
                            case "bloodlust":
                            case "mocking":
                            case "undying":
                                championName = "tryndamere";
                                break;
                            // Blue disambiguation
                            case "blue":
                                if (shortFileName.ToLower().Contains("card"))
                                {
                                    championName = "twistedfate";
                                    break;
                                }
                                championName = "map";
                                break;
                            // Katarina
                            case "bouncing":
                            case "killer":
                            case "voracity":
                                championName = "katarina";
                                break;
                            // Burning disambiguation
                            case "burning":
                                if (shortFileName.ToLower().Contains("agony"))
                                {
                                    championName = "drmundo";
                                    break;
                                }
                                else if (shortFileName.ToLower().Contains("embers"))
                                {
                                    championName = "";
                                    break;
                                }
                                championName = "items";
                                break;
                            // Tristana
                            case "buster":
                            case "detonating":
                            case "rapid":
                                championName = "tristana";
                                break;
                            // Heimerdinger
                            case "c":
                            case "h28":
                            case "heimer":
                            case "upgrade":
                            case "ur":
                            case "explosive":
                                championName = "heimerdinger";
                                break;
                            // Sion
                            case "cannibalism":
                            case "cryptic":
                            case "deaths":
                            case "enrage":
                                championName = "sion";
                                break;
                            // Twisted Fate
                            case "card":
                            case "cardmaster":
                            case "destiny":
                            case "gate":
                            case "gold":
                            case "goldcardattack":
                            case "instagate":
                            case "pick":
                            case "pink":
                            case "red":
                            case "seal":
                            case "wild":
                                championName = "twistedfate";
                                break;
                            // Cho'Gath
                            case "carnivore":
                            case "feast":
                            case "feral":
                            case "rupture":
                            case "vorpal":
                                championName = "chogath";
                                break;
                            // Corki
                            case "g":
                            case "gatling":
                            case "missile":
                            case "phosphorus":
                                championName = "corki";
                                break;
                            // Global buffs/debuffs
                            case "chilled":
                            case "flask":
                            case "full":
                            case "grievous":
                            case "hamstring":
                            case "has":
                            case "ignore":
                            case "innate":
                            case "item":
                            case "landslide":
                            case "net":
                            case "obduracy":
                            case "pacified":
                            case "physical":
                            case "prilisas":
                            case "propel":
                            case "raise":
                            case "recall":
                            case "reveal":
                            case "silence":
                            case "slow":
                            case "stun":
                            case "suppress":
                            case "taunt":
                            case "fear":
                                championName = "global";
                                break;
                            // Zilean
                            case "chrono":
                            case "rewind":
                            case "time":
                                championName = "zilean";
                                break;
                            // Fiddlesticks
                            case "crowstorm":
                            case "drain":
                            case "fearmonger_marker":
                            case "fiddle":
                            case "terrify":
                                championName = "fiddlesticks";
                                break;
                            // Ashe
                            case "crystallize":
                            case "enchanted":
                            case "frost":
                            case "scouts":
                            case "volley":
                                championName = "ashe";
                                break;
                            // Rumble
                            case "carpet":
                            case "danger":
                                championName = "rumble";
                                break;
                            // Dark disambiguation
                            case "dark":
                                if (shortFileName.ToLower().Contains("binding"))
                                {
                                    championName = "morgana";
                                    break;
                                }
                                championName = "fiddlesticks";
                                break;
                            // Taric
                            case "dazzle":
                            case "imbue":
                            case "radiance":
                            case "shatter":
                                championName = "taric";
                                break;
                            // Twitch
                            case "deadly":
                            case "debilitating":
                            case "expunge":
                            case "hide":
                            case "spray":
                                championName = "twitch";
                                break;
                            // Death disambiguation
                            case "death":
                                if (shortFileName.ToLower().Contains("craze"))
                                {
                                    championName = "";
                                    break;
                                }
                                else if (shortFileName.ToLower().Contains("defied"))
                                {
                                    championName = "karthus";
                                    break;
                                }
                                championName = "katarina";
                                break;
                            // Shaco
                            case "deceive":
                            case "hallucinate":
                            case "jack":
                            case "two":
                                championName = "shaco";
                                break;
                            // Karthus
                            case "defile":
                            case "lay":
                            case "wall":
                            case "wallof":
                                championName = "karthus";
                                break;
                            // Annie
                            case "disintegrate":
                            case "incinerate":
                            case "infernal":
                            case "molten":
                                championName = "annie";
                                break;
                            // Dr Mundo
                            case "dr":
                            case "infected":
                            case "masochism":
                            case "sadism":
                                championName = "drmundo";
                                break;
                            // Morgana
                            case "empathize":
                            case "tormented":
                            case "fallen":
                                championName = "morgana";
                                break;
                            // Warwick
                            case "eternal":
                            case "hungering":
                            case "hunters":
                            case "infinite":
                            case "rabid":
                                championName = "warwick";
                                break;
                            //Janna 
                            case "eye":
                            case "howling":
                            case "reap":
                                championName = "janna";
                                break;
                            // Alistar
                            case "ferocious":
                            case "headbutt":
                            case "pulverize":
                            case "slash":
                            case "triumphant":
                                championName = "alistar";
                                break;
                            // Anivia
                            case "flash":
                            case "frostbite":
                            case "glacial":
                            case "rebirth":
                                championName = "anivia";
                                break;
                            // Singed
                            case "fling":
                            case "insanity":
                            case "mega":
                            case "poison":
                                championName = "singed";
                                break;
                            // Gangplank
                            case "bilgewater":
                            case "parley":
                            case "pirate":
                            case "scurvy":
                            case "cannon":
                                championName = "gangplank";
                                break;
                            // Nasus
                            case "godof":
                            case "siphoning":
                            case "spirit":
                            case "wither":
                                championName = "nasus";
                                break;
                            // Evelynn
                            case "hate":
                            case "maliceand":
                            case "maniacal":
                            case "ravage":
                                championName = "evelynn";
                                break;
                            // Ice disambiguation
                            case "ice":
                                if (shortFileName.ToLower().Contains("blast"))
                                {
                                    championName = "nunu";
                                    break;
                                }
                                championName = "anivia";
                                break;
                            // Kayle
                            case "judicator":
                                championName = "kayle";
                                break;
                            // Pantheon
                            case "pantheon_":
                                championName = "pantheon";
                                break;
                            // Kogmaw
                            case "kog":
                                championName = "kogmaw";
                                break;
                            // Mana disambiguation
                            case "mana":
                                if (shortFileName.ToLower().Contains("barrier"))
                                {
                                    championName = "blitzcrank";
                                    break;
                                }
                                championName = "items";
                                break;
                            // Miss Fortune
                            case "miss":
                                championName = "missfortune";
                                break;
                            // Wukong
                            case "monkey":
                                championName = "wukong";
                                break;
                            // Kassadin
                            case "nether":
                            case "null":
                            case "rift":
                            case "void":
                            case "force":
                                championName = "kassadin";
                                break;
                            // Sivir
                            case "on":
                            case "ricochet":
                            case "spiral":
                                championName = "sivir";
                                break;
                            // Orianna
                            case "oriana":
                                championName = "orianna";
                                break;
                            // Blitzcrank
                            case "overdrive":
                            case "rocket":
                            case "static":
                                championName = "blitzcrank";
                                break;
                            // Nocturne
                            case "paranoia":
                                championName = "nocturne";
                                break;
                            // Power disambiguation
                            case "power":
                                if (shortFileName.ToLower().Contains("ball"))
                                {
                                    championName = "rammus";
                                    break;
                                }
                                championName = "blitzcrank";
                                break;
                            // Brand
                            case "pyromania_particle":
                                championName = "brand";
                                break;
                            // Regeneration disambiguation
                            case "regeneration":
                                if (shortFileName.ToLower().Contains("potion"))
                                {
                                    championName = "items";
                                    break;
                                }
                                championName = "map";
                                break;
                            // Malphite
                            case "seismic":
                            case "unstoppable":
                                championName = "malphite";
                                break;
                            // Shadow disambiguation
                            case "shadow":
                                if (shortFileName.ToLower().Contains("step"))
                                {
                                    championName = "akali";
                                    break;
                                }
                                championName = "evelynn";
                                break;
                            // Soul disambiguation
                            case "soul":
                                if (shortFileName.ToLower().Contains("shackles"))
                                {
                                    championName = "morgana";
                                    break;
                                }
                                championName = "items";
                                break;
                            // Yorick
                            case "spectral":
                                championName = "yorick";
                                break;
                            // Spell Disambiguation
                            case "spell":
                                if (shortFileName.ToLower().Contains("flux"))
                                {
                                    championName = "ryze";
                                    break;
                                }
                                else if (shortFileName.ToLower().Contains("immunity"))
                                {
                                    championName = "global";
                                    break;
                                }
                                championName = "sivir";
                                break;
                            // Summoner
                            case "exhaust":
                            case "teleport":
                            case "teleport_":
                            case "zomg":
                                championName = "summoner";
                                break;
                            // Swain
                            case "swain_":
                                championName = "swain";
                                break;
                            // Trundle
                            case "trundledesecrate":
                                championName = "trundle";
                                break;
                            // Twisted disambiguation
                            case "twisted":
                                if (shortFileName.ToLower().Contains("fate"))
                                {
                                    championName = "twistedfate";
                                    break;
                                }
                                championName = "map";
                                break;
                            // U disambiguation
                            case "u":
                                if (shortFileName.ToLower().Contains("slash"))
                                {
                                    championName = "malphite";
                                    break;
                                }
                                championName = "heimerdinger";
                                break;
                            // Vladimir
                            case "vlad":
                                championName = "vladimir";
                                break;
                            // Will disambiguation
                            case "will":
                                if (shortFileName.ToLower().Contains("ancients"))
                                {
                                    championName = "items";
                                    break;
                                }
                                championName = "anivia";
                                break;
                            // Xin Zhao
                            case "xen":
                            case "xin":
                                championName = "xinzhao";
                                break;
                        }

                            
                        if (championName != "")
                        {
                            // Add to dictionary
                            if (!particleDef.ContainsKey(championName))
                            {
                                particleDef[championName] = new Dictionary<String, Dictionary<RAFFileListEntry, List<String>>>();
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
                                    // Create dictionary
                                    if (!particleDef[championName].ContainsKey(shortFileName))
                                    {
                                        particleDef[championName][shortFileName] = new Dictionary<RAFFileListEntry, List<String>>();
                                    }
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

        public void startGettingParticleStructure(SkinInstaller.skinInstaller source, string rafDirPath)
        {
            mySkinInstaller = source;
            ParticleReferenceWorker.RunWorkerAsync(rafDirPath);
        }

        private void ParticleReferenceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = getParticleStructure(e.Argument.ToString());
        }

        private void ParticleReferenceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (mySkinInstaller != null)
            {
                mySkinInstaller.recieveParticleProgress(e.ProgressPercentage);
            }
            if (this.Visible)
            {
                if (e.ProgressPercentage != progressBar1.Value)
                {
                    progressBar1.Value = e.ProgressPercentage;
                    progress_lbl.Text = e.ProgressPercentage.ToString();
                }
            }
        }

        private void ParticleReferenceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PStruct particleDef = (PStruct)e.Result;
            if (this.Visible)
            {
                progressBar1.Value = 0;

                // Creates a TextInfo based on the "en-US" culture.
                TextInfo usTxtInfo = new CultureInfo("en-US", false).TextInfo;


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

            if (mySkinInstaller != null)
            {
                mySkinInstaller.recieveNewParticleInformation(particleDef);
            }
        }


    }
}
