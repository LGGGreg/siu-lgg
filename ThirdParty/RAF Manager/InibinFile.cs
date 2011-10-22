using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using ItzWarty;

namespace RAFManager
{
    //Everything that was static now isn't static...  This is because properties had to be cleared...
    //I don't want to mess with this code, so yeah....
    
    //The code needs a rewrite.  It's messy and it doesn't work
    //It was ported over from code that is probably outdated

    //Originally by Engberg

    /**
     * Character *.inibin data files are in: game/HeroPak_client.zip/DATA/Characters/*
     * Character names are in:  game/DATA/Menu/fontconfig_en_US.txt
     */
    public class InibinFile {

        bool DEBUG = false;

        long PROP_ID = 2921476548L;
        long PROP_HP = 742042233L;
        long PROP_HPL = 3306821199L;
        long PROP_MANA = 742370228L;
        long PROP_MANAL = 1003217290L;
        long PROP_MOVE = 1081768566L;
        long PROP_ARMOR = 2599053023L;
        long PROP_ARMORL = 1608827366L;
        long PROP_MR = 1395891205L;
        long PROP_MRL = 4032178956L;
        long PROP_HP5 = 4128291318L;
        long PROP_HP5L = 3062102972L;
        long PROP_MP5 = 619143803L;
        long PROP_MP5L = 1248483905L;
        long PROP_BASE_ASPD_MINUS = 2191293239L;
        long PROP_ASPDL = 770205030L;
        long PROP_AD = 1880118880L;
        long PROP_ADL = 1139868982L;
        long PROP_RANGE = 1387461685L;

        Dictionary<long, String> NAMES = new Dictionary<long, String>();
        Boolean hasInit = false;//added
        void Init()
        {
            if (hasInit) return;
            hasInit = true;
	        NAMES.Add(1091449537L, "Default skin ID");
	        NAMES.Add(2640183547L, "Default skin gfx file");
	        NAMES.Add(3939240930L, "Default skin model file");
	        NAMES.Add(769344815L, "Default skin skin file");
	        NAMES.Add(1895303501L, "Default skin skeleton file");
	        NAMES.Add(693474744L, "Default Skin weight file");
	        NAMES.Add(1350629540L, "Skin #2 ID");
	        NAMES.Add(1742464788L, "Skin #2 name");
	        NAMES.Add(664710616L, "Skin #2 gfx file");
	        NAMES.Add(1008195909L, "Skin #2 model file");
	        NAMES.Add(306040338L, "Skin #2 skin file");
	        NAMES.Add(599757744L, "Skin #2 skeleton file");
	        NAMES.Add(2823479707L, "Skin #2 weight file");
	        NAMES.Add(3726994531L, "Skin #3 ID");
	        NAMES.Add(1652845395L, "Skin #3 name");
	        NAMES.Add(4206390233L, "Skin #3 gfx file");
	        NAMES.Add(1380203140L, "Skin #3 model file");
	        NAMES.Add(525951185L, "Skin #3 skin file");
	        NAMES.Add(3575010799L, "Skin #3 skeleton file");
	        NAMES.Add(1264358234L, "Skin #3 weight file");
	        NAMES.Add(1808392226L, "Skin #4 ID");
	        NAMES.Add(73050088L, "Recommended Item #1");
	        NAMES.Add(73050089L, "Recommended Item #2");
	        NAMES.Add(73050090L, "Recommended Item #3");
	        NAMES.Add(73050091L, "Recommended Item #4");
	        NAMES.Add(73050092L, "Recommended Item #5");
	        NAMES.Add(73050093L, "Recommended Item #6");
	        NAMES.Add(4146314945L, "Attributes");
	        NAMES.Add(11266465L, "[R] Skill Name");
	        NAMES.Add(404599692L, "[R] Skill name (without whitespaces)");
	        NAMES.Add(2779212989L, "[R] Skill description");
	        NAMES.Add(3646501220L, "[Q] Skill name");
	        NAMES.Add(404599689L, "[Q] Skill name (without whitespaces)");
	        NAMES.Add(3655487418L, "[Q] Skill Description");
	        NAMES.Add(3866412067L, "[W] Skill name");
	        NAMES.Add(404599690L, "[W] Skill name (without whitespaces)");
	        NAMES.Add(500084411L, "[W] Skill Description");
	        NAMES.Add(4086322914L, "[E] Skill name");
	        NAMES.Add(404599691L, "[E] Skill name (without whitespaces)");
	        NAMES.Add(1639648700L, "[E] Skill description");
	        NAMES.Add(PROP_RANGE, "Range");
	        NAMES.Add(PROP_ASPDL, "ASpd/L");
	        NAMES.Add(PROP_BASE_ASPD_MINUS, "Base Attack speed % reduction");
	        NAMES.Add(PROP_AD, "AD");
	        NAMES.Add(PROP_ADL, "AD/L");
	        NAMES.Add(PROP_HP, "HP");
	        NAMES.Add(PROP_HPL, "HP/L");
	        NAMES.Add(PROP_MANA, "Mana");
	        NAMES.Add(PROP_MANAL, "Mana/L");
	        NAMES.Add(PROP_MOVE, "Move");
	        NAMES.Add(PROP_ARMOR, "Armor");
	        NAMES.Add(PROP_ARMORL, "Armor/L");
	        NAMES.Add(PROP_MR, "MR");
	        NAMES.Add(PROP_MRL, "MR/L");
	        NAMES.Add(PROP_HP5, "HP5");
	        NAMES.Add(PROP_HP5L, "HP5/L");
	        NAMES.Add(PROP_MP5, "MP5");
	        NAMES.Add(PROP_MP5L, "MP5/L");
	        NAMES.Add(82690155L, "Name");
	        NAMES.Add(PROP_ID, "Id");
        }

        //Originally a filestream, now a memorystream
        Stream fsin;
        Dictionary<long, Object> properties = new Dictionary<long, Object>();

        void debug(String label, String val) {
	        if (DEBUG) {
	            Console.WriteLine(label + ": " + val);
	        }
        }

        void debug(String label, float val) {
	        debug(label, val.ToString());
        }

        void debug(String label, Object val) {
	        debug(label, (val == null) ? "null" : val.ToString());
        }

        void debug(String label, long val) {
	        debug(label, "0x" + val.ToString("x") + " (" + val + ")");
        }

        int readU8()
        {
	        return fsin.ReadByte();
        }

        int readU16()
        {
	        int b1 = readU8();
	        int b2 = readU8();
	        return (short)(((0xff & b2) << 8) | (0xff & b1));
        }

        long readU32()
        {
	        long b1 = readU8();
	        long b2 = readU8();
	        long b3 = readU8();
	        long b4 = readU8();
	        return (0xff & b1) |
	            ((0xff & b2) << 8) |
	            ((0xff & b3) << 16) |
	            ((0xff & b4) << 24);
        }

        float readFloat() 
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(readU32()), 0);
	        //return Float.intBitsToFloat((int)readU32());
        }

        String readNulTerminatedString(int atOffset)
        {
	        long oldPos = fsin.Position;
	        fsin.Seek(atOffset, SeekOrigin.Begin);
	        StringBuilder sb = new StringBuilder();
	        int c;
	        while ((c = fsin.ReadByte()) > 0) {
	            sb.Append((char)c);
	        }
	        fsin.Seek(oldPos, SeekOrigin.Begin);
	        return sb.ToString();
        }

        long[] readSegmentKeys()
        {
	        int count = readU16();
	        debug("segment key count", count);
	        long[] result = new long[count];
	        for (int i = 0; i < count; ++i) {
	            result[i] = readU32();
	            debug("key[" + i + "]", result[i]);
	        }
	        return result;
        }

        //http://stackoverflow.com/questions/1130698/checking-if-an-object-is-a-number-in-c
        public bool IsNumber(object value)
        {
            if (value is sbyte) return true;
            if (value is byte) return true;
            if (value is short) return true;
            if (value is ushort) return true;
            if (value is int) return true;
            if (value is uint) return true;
            if (value is long) return true;
            if (value is ulong) return true;
            if (value is float) return true;
            if (value is double) return true;
            if (value is decimal) return true;
            return false;
        }
        float getProperty(long id, float defaultVal) {
            if (!properties.ContainsKey(id)) return defaultVal;//added
	        Object prop = properties[id];
	        if (prop == null) {
	            return defaultVal;
            }
            else if(IsNumber(prop))
            {
	            //} else if (prop instanceof Number) {
	            //    return ((Number)prop).floatValue();
                //float number;
                return float.Parse(Convert.ToString(prop, System.Globalization.CultureInfo.InvariantCulture), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo);
	        } else {
                try
                {
                    return float.Parse(prop.ToString());
                }
                catch
                {
                    Console.WriteLine("Couldn't parse:" + prop.ToString());
                    return defaultVal;
                }
	        }
        }

        String fmt(float val) {
            string s = val.ToString();
            string[] parts = s.Split(".");
            if(parts.Length == 1) return parts[0];
            else if(parts[1].Length > 3)
                return parts[0] + parts[1].Substring(0, 3);
            else return val.ToString();
	        //return (new DecimalFormat("#.###")).format(val);
        }


        //Changed from accepting string[]{filePath} to accepting file content...
        //Also changed it to return an output of its contents...
        public string main(byte[] fileContent)
        {
            Init();//replaced inline defining   

	        // uncomment this to dump out a lot of information
	        DEBUG=false;

	        //fsin = new RandomAccessFile(args[0], "r");
            fsin = new MemoryStream(fileContent);
            fsin.Seek(0, SeekOrigin.Begin);
	        //String name = args[1];
	        int version = readU8();
	        debug("version", version);
	        int fileLen = fileContent.Length;//(int)(new FileInfo(args[0])).Length;
	        debug("file length", fileLen);
	        int oldLen = readU16();
	        debug("old style length", oldLen);
	        int oldStyleOffset = fileLen - oldLen;
	        debug("old style offset", oldStyleOffset);
	        int format = readU16();
	        debug("format", format);
	
	        // U32 values
	        if ((format & 0x0001) == 0) {
	            debug("No U32 segment", "skipping");
	        } else {
	            debug("U32 properties start position", fsin.Position);
	            foreach (long key in readSegmentKeys()) {
		            long val = readU32();
		            debug("U32 prop(" + key + ")", val);
		            properties.Add(key, val);
	            }
	        }

	        // float values
	        if ((format & 0x0002) == 0) {
	            debug("No float segment", "skipping");
	        } else {
	            debug("Float properties start position", fsin.Position);
	            foreach (long key in readSegmentKeys()) {
		        float val = readFloat();
		        debug("float prop(" + key + ")", val);
		        properties.Add(key, val);
	            }
	        }

	        // U8 values
	        if ((format & 0x0004) == 0) {
	            debug("No U8/10 segment", "skipping");
	        } else {
	            debug("U8/10 properties start position", fsin.Position);
	            foreach (long key in readSegmentKeys()) {
		            float val = readU8() * 0.1F;
		            debug("U8/10 prop(" + key + ")", val);
		            properties.Add(key, val);
	            }
	        }

	        // U16 values
	        if ((format & 0x0008) == 0) {
	            debug("No U16 segment", "skipping");
	        } else {
	            debug("U16 properties start position", fsin.Position);
	            foreach (long key in readSegmentKeys()) {
		            int val = readU16();
		            debug("U16 prop(" + key + ")", val);
		            properties.Add(key, val);
	            }
	        }

	        // U8 values
	        if ((format & 0x0010) == 0) {
	            debug("No U8 segment", "skipping");
	        } else {
	            debug("U8 properties start position", fsin.Position);
	            foreach(long key in readSegmentKeys()) {
		            int val = 0xff & readU8();
		            debug("U8 prop(" + key + ")", val);
		            properties.Add(key, val);
	            }
	        }

	        // Boolean flags - single bit, ignoring
	        if ((format & 0x0020) == 0) {
	            debug("No boolean segment", "skipping");
	        } else {
	            debug("Boolean flags start position", fsin.Position);
	            long[] booleanKeys = readSegmentKeys();
	            debug("Boolean keys found", booleanKeys.Length);
	            int index = 0;
	            for (int i = 0; i < 1 + ((booleanKeys.Length - 1) / 8); ++i) {
		            int bits = readU8();
		            for (int b = 0; b < 8; ++b) {
		                long key = booleanKeys[index];
		                int val = 0x1 & bits;
		                debug("Boolean prop(" + key + ")", val);
		                properties.Add(key, val);
		                bits = bits >> 1;
		                if (++index == booleanKeys.Length) {
			            break;
		                }
		            }
	            }
	        }

	        // 4-byte color values or something?
	        if ((format & 0x0400) == 0) {
	            debug("No 4-byte color segment", "skipping");
	        } else {
	            debug("Color? properties start position", fsin.Position);
	            foreach (long key in readSegmentKeys()) {
		            long val = readU32();
		            debug("U32 color prop(" + key + ")", val);
		            properties.Add(key, val);
	            }
	        }

	        // Old-style offsets to strings
	        if ((format & 0x1000) == 0) {
	            debug("No offsets segment", "skipping");
	        } else {
	            debug("Old style data position", fsin.Position);
	            int lastOffset = -1;
	            foreach (long key in readSegmentKeys()) {
		            int offset = readU16();
		            debug("String offset(" + key + ")", offset);
		            String val = readNulTerminatedString(oldStyleOffset + offset);
		            debug("String prop(" + key + ")", val);
		            properties.Add(key, val);
		            lastOffset = offset;
	            }
	        }

	        debug("=== Properties found in file", properties.Count);
	        foreach (long key in properties.Keys) {
                if (NAMES.ContainsKey(key) && properties.ContainsKey(key))
	                debug(key + " (" +  NAMES[key] + ")", properties[key]);
	        }

	        int id = (int)getProperty(PROP_ID, 0);
	        float hp = getProperty(PROP_HP, 0);
	        float hpl = getProperty(PROP_HPL, 0);
	        float hp18 = hp + 18 * hpl;
	        float mana = getProperty(PROP_MANA, 0);
	        float manal = getProperty(PROP_MANAL, 0);
	        float mana18 = mana + 18 * manal;
	        float move = getProperty(PROP_MOVE, 0);
	        float armor = getProperty(PROP_ARMOR, 0);
	        float armorl = getProperty(PROP_ARMORL, 0);
	        float armor18 = armor + 18 * armorl;
	        float mr = getProperty(PROP_MR, 30);
	        float mrl = getProperty(PROP_MRL, 0);
	        float mr18 = mr + 18 * mrl;
	        float hp5 = 5 * getProperty(PROP_HP5, 0);
	        float hp5l = 5 * getProperty(PROP_HP5L, 0);
	        float hp5_18 = hp5 + 18 * hp5l;
	        float mp5 = 5 * getProperty(PROP_MP5, 0);
	        float mp5l = 5 * getProperty(PROP_MP5L, 0);
	        float mp5_18 = mp5 + 18 * mp5l;
	        float ad = getProperty(PROP_AD, 0);
	        float adl = getProperty(PROP_ADL, 0);
	        float ad18 = ad + 18 * adl;
	        float aspd = 0.625F * (1.0F - getProperty(PROP_BASE_ASPD_MINUS, 0));
	        float aspdl = 0.01F * getProperty(PROP_ASPDL, 0);
	        float aspd18 = aspd + 17 * aspdl * aspd;
	        float range = getProperty(PROP_RANGE, 0);

	        // DEBUG=true;

	        debug("Id", id);
	        debug("HP", fmt(hp));
	        debug("HP/L", hpl);
	        debug("HP@18", hp18);
	        debug("Mana", mana);
	        debug("Mana/L", manal);
	        debug("Mana@18", mana18);
	        debug("Move", move);
	        debug("Armor", armor);
	        debug("Armor/L", armorl);
	        debug("Armor@18", armor18);
	        debug("MR", mr);
	        debug("MR/L", mrl);
	        debug("MR@18", mr18);
	        debug("ASpd", aspd);
	        debug("ASpd/L (% base)", aspdl);
	        debug("ASpd@18", aspd18);
	        debug("HP5", hp5);
	        debug("HP5/L", hp5l);
	        debug("HP5@18", hp5_18);
	        debug("MP5", mp5);
	        debug("MP5L", mp5l);
	        debug("MP5@18", mp5_18);
	        debug("AD", ad);
	        debug("AD/L", adl);
	        debug("AD@18", ad18);
	        debug("Range", range);

            string output =
                    "INIBIN/TROYBIN 'interpreted' by code ported from Java to C#\r\n" +
                    "Original Code by user 'engberg' of LeagueCraft.com port by ItzWarty\r\n" +
                    "Original: http://www.evernote.com/pub/dave/lol#n=018287a2-120e-4e30-93bd-15f714cc7fb7&b=73dd92cc-6410-4643-bf8d-dfad1335d696\r\n" +
                    "                     Id: " + id + "\r\n" +
                    "                   Name: --NotListedCurrentlyByItzWarty" + "\r\n" +
                    "              HP (base):" + hp + "\r\n" +
                    "                 HP/Lvl:" + hpl + "\r\n" +
                    "             HP (Lvl18):" + hp18 + "\r\n" +
                    "                   Mana:" + mana + "\r\n" +
                    "               Mana/Lvl:" + manal + "\r\n" +
                    "           Mana (Lvl18):" + mana18 + "\r\n" +
                    "                   Move:" + move + "\r\n" +
                    "                  Armor:" + armor + "\r\n" +
                    "              Armor/Lvl:" + armorl + "\r\n" +
                    "          Armor (Lvl18):" + armor18 + "\r\n" +
                    "                     MR:" + mr + "\r\n" +
                    "                 MR/Lvl:" + mrl + "\r\n" +
                    "             MR (Lvl18):" + mr18 + "\r\n" +
                    "             HP/5s base:" + hp5 + "\r\n" +
                    "              HP/5s/Lvl:" + hp5l + "\r\n" +
                    "          HP/5s (Lvl18):" + hp5_18 + "\r\n" +
                    "           Mana/5s base:" + mp5 + "\r\n" +
                    "            Mana/5s/Lvl:" + mp5l + "\r\n" +
                    "        Mana/5s (Lvl18):" + mp5_18 + "\r\n" +
                    "                     AD:" + ad + "\r\n" +
                    "                 AD/Lvl:" + adl + "\r\n" +
                    "             AD (Lvl18):" + ad18 + "\r\n" +
                    "                  Range:" + range + "\r\n" +
                    "       Attacks/sec base:" + aspd + "\r\n" +
                    "   Attack speed %/level:" + aspdl + "\r\n" +
                    "   Attacks/sec (Lvl 18):" + aspd18 + "\r\n" +
                    "\r\n" +
                    "PROPERTIES DUMP:\r\n" + // lol@longstring...
                    "_______________KEY[hex]|VALUE______________________\r\n";
            foreach (long key in properties.Keys)
            {
                float result = getProperty(key, float.NaN);
                output += key.ToString("x").PadLeft("   Attacks/sec (Lvl 18)".Length)+"|"+result+"\r\n";
            }
            return output;

                    /*
                     * //originally was a syso(belowText);
                    Console.WriteLine("Id,Name,HP (base),HP/Lvl,HP (Lvl18),Mana,Mana/Lvl,Mana (Lvl18),Move,Armor,Armor/Lvl,Armor (Lvl18),MR,MR/Lvl,MR (Lvl18),HP/5s base,HP/5s/Lvl,HP/5s (Lvl18),Mana/5s base,Mana/5s/Lvl,Mana/5s (Lvl18),AD,AD/Lvl,AD (Lvl18),Range,Attacks/sec base,Attack speed %/level,Attacks/sec (Lvl 18)");
                    Console.WriteLine(id + "," + "[namegoeshere]" + "," +
			                   fmt(hp) + "," +
			                   fmt(hpl) + "," +
			                   fmt(hp18) + "," +
			                   fmt(mana) + "," +
			                   fmt(manal) + "," +
			                   fmt(mana18) + "," +
			                   fmt(move) + "," +
			                   fmt(armor) + "," +
			                   fmt(armorl) + "," +
			                   fmt(armor18) + "," +
			                   fmt(mr) + "," +
			                   fmt(mrl) + "," +
			                   fmt(mr18) + "," +
			                   fmt(hp5) + "," +
			                   fmt(hp5l) + "," +
			                   fmt(hp5_18) + "," +
			                   fmt(mp5) + "," +
			                   fmt(mp5l) + "," +
			                   fmt(mp5_18) + "," +
			                   fmt(ad) + "," +
			                   fmt(adl) + "," +
			                   fmt(ad18) + "," +
			                   fmt(range) + "," + 
			                   fmt(aspd) + "," +
			                   fmt(aspdl) + "," +
			                   fmt(aspd18));
                     */
            }
    }
}
