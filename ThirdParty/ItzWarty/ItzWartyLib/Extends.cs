using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty
{
    public static class Extend
    {
        public static string ToHTTPTimestamp(this DateTime dt)
        {
            DateTime utc = dt.ToUniversalTime();
            string day = utc.Day.ToString().MltPad0();
            string dayOfWeek = utc.DayOfWeek.ToString().Substring(0, 3);
            string year = utc.Year.ToString();
            string mon = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }[utc.Month - 1];
            return dayOfWeek + ", " + day + " " + mon + " " + year + " " + utc.Hour.ToString().MltPad0() + ":" + utc.Minute.ToString().MltPad0() + ":" + utc.Second.ToString().MltPad0() + " GMT";
        }
        public static string MltPad0(this string s)
        {
            if (s.Length == 2) return s;
            if (s.Length == 1) return "0" + s;
            return s;
        }
        public static byte[] ToBytes(this string s)
        {
            return System.Text.Encoding.ASCII.GetBytes(s);
        }
        //http://dotnetperls.com/reverse-string
        public static string Reverse(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static string[] SplitAtIndex(this string s, int index)
        {
            if (index == s.Length) return new string[] { s };
            return new string[] { s.Substring(0, index), s.Substring(index + 1) };
        }

        public static string[][] ToStringArrayArray(this Dictionary<string, string> d)
        {
            List<string> keys = new List<string>(d.Keys);
            List<string[]> keyValues = new List<string[]>();
            for (int i = 0; i < keys.Count; i++)
            {
                keyValues.Add(new string[] { keys[i], d[keys[i]] });
            }
            return keyValues.ToArray();
        }
        public static string ToHex(this System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X").MltPad0()
                        + c.G.ToString("X").MltPad0()
                        + c.B.ToString("X").MltPad0();
        }

        public static string F(this string s, params object[] p)
        {
            return string.Format(s, p);
        }
        public static string Repeat(this string s, int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
                sb.Append(s);
            return sb.ToString();
        }

        public static string[] QASS(this string s, char delimiter)
        {
            StringBuilder curPartSB = new StringBuilder();
            List<string> finalParts = new List<string>();
            bool inDoubleQuotes = false;
            bool inSingleQuotes = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '"') 
                    if(!inSingleQuotes)
                        inDoubleQuotes = !inDoubleQuotes;
                    else
                        curPartSB.Append(s[i]);
                else if (s[i] == '\'')
                    if (!inDoubleQuotes)
                        inSingleQuotes = !inSingleQuotes;
                    else
                        curPartSB.Append(s[i]);
                else if (s[i] == delimiter)
                {
                    if (!inDoubleQuotes && !inSingleQuotes)
                    {
                        finalParts.Add(curPartSB.ToString());
                        curPartSB.Remove(0, curPartSB.Length);
                    }
                    else
                    {
                        curPartSB.Append(s[i]);
                    }
                }
                else
                    curPartSB.Append(s[i]);
            }
            if (curPartSB.ToString() != "")
            {
                finalParts.Add(curPartSB.ToString());
            }
            return finalParts.ToArray();
        }

        //http://stackoverflow.com/questions/943635/c-arrays-getting-a-sub-array-from-an-existing-array
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static string RemoveOuterQuote(this string s)
        {
            if (s.Length > 1)
            {
                if ((s[0] == '\'' && s.Last() == '\'') ||
                    (s[0] == '"' && s.Last() == '"')
                )
                    return s.Substring(1, s.Length - 2);
                else
                    return s;
            }
            else
                return s;
        }
        public static string[] Split(this string s, string delimiter)
        {
            return s.Split(new string[] { delimiter }, StringSplitOptions.None);
        }
        public static string[] Split(this string s, string delimiter, StringSplitOptions sso)
        {
            return s.Split(new string[] { delimiter }, sso);
        }
        public static string ToHex(this byte[] bArray)
        {
            return BitConverter.ToString(bArray).Replace("-", "");
        }
        public static string GetMD5(this string s)
        {
            return System.Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(
                Encoding.ASCII.GetBytes(s)
            ).ToHex();
        }

        public static bool EndsWithAny(this string s, string[] enders)
        {
            for (int i = 0; i < enders.Length; i++)
                if (s.EndsWith(enders[i])) return true;
            return false;
        }
        //http://stackoverflow.com/questions/128618/c-file-size-format-provider
        public static string ToFileSize(this long l)
        {
            return String.Format(new FileSizeFormatProvider(), "{0:fs}", l);
        }
    }
}
