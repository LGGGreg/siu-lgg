/*
 * Skin Installer Ultimate + LGG (SIU+LGG)
 * Copyright 2011 Greg Hendrickson
 * This file is part of SIU+LGG.
 * 
 * SIU+LGG is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * any later version.
 * 
 * SIU+LGG is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with LOLViewer.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
namespace SkinInstaller
{
    public struct skinInfo
    {
        public string name, author;

        public skinInfo(string n, string a)
        {
            name = n;
            author = a;
        }
    }
    public class fileLocReturn
    {
        public string folderName{get; set;}
        public string fileName{get; set;}
        public bool valid{get; set;}
        public List<string> moreOptions{get; set;}
        public fileLocReturn(string folder, string file, bool ok, List<string> extraOptions)
        {
            folderName = folder;
            fileName = file;
            valid = ok;
            moreOptions = extraOptions;
        }
        public fileLocReturn(string folder, string file)
        {
            folderName = folder;
            fileName = file;
            valid = true;
            moreOptions = null;
        }
        public fileLocReturn(List<string> extraOptions)
        {
            folderName = fileName = "";
            valid = false;
            moreOptions = extraOptions;
        }
        public static fileLocReturn retError = new fileLocReturn(null,null,false,null);
    }
    public class prettyDate : IComparable
    {
        private DateTime date;
        private bool valid = false;
        public prettyDate(DateTime dt)
        {
            setDate(dt);
        }
        public prettyDate(string exact)
        {
            setDate(exact);
        }
        public void setDate(DateTime dt)
        {
            this.date = dt;
            valid = true;
        }
        public void setDate(string exact)
        {
            valid = DateTime.TryParseExact(exact, "M/d/yyyy HH:mm:ss.f tt", CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out this.date);
            if (!valid)
            {
                //second try?
                valid = DateTime.TryParseExact(exact, "M.d.yyyy HH:mm:ss.f", CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out this.date);

            }
        }
        public override string ToString()
        {
            return valid ? date.ToString("M/d/yy") : "No";
        }
        public DateTime getDate()
        {
            return valid?date:new DateTime(0);
        }
        public string getStringDate()
        {
            return valid ? date.ToString("M/d/yyyy HH:mm:ss.f tt",CultureInfo.InvariantCulture) : "-";
        }
        public int CompareTo(object o)
        {
            prettyDate temp = (prettyDate)o;
            return temp.getDate().CompareTo(this.date);
        }
    }
    public class commonOps
    {
        static public int getDXTVersion(string file)
        {
            int toReturn = 0;
            try
            {
                StreamReader sr = new StreamReader(file);
                BinaryReader br = new BinaryReader(sr.BaseStream);
                System.Text.Encoding enc = System.Text.Encoding.ASCII;

                br.BaseStream.Position = 10;
                byte[] tvByteArray = new byte[100];
                tvByteArray = br.ReadBytes(100);

                string ins = enc.GetString(tvByteArray);//.Replace("\0", "").Trim();
                int st = ins.ToLower().IndexOf("dxt");
                if (st != -1)
                {
                    //s = ins.Substring(st, 4);
                    toReturn = int.Parse(ins.Substring(st + 3, 1));
                }
            }
            catch
            {
            }
            return toReturn;

        }
    }
}
