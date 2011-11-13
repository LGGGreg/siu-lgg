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
using System.Drawing;
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

     public class HSLColor
     {
         // Private data members below are on scale 0-1
         // They are scaled for use externally based on scale
         private double hue = 1.0;
         private double saturation = 1.0;
         private double luminosity = 1.0;
  
         private const double scale = 1.0;
  
         public double Hue
         {
             get { return hue * scale; }
             set { hue = CheckRange(value / scale); }
         }
         public double Saturation
         {
             get { return saturation * scale; }
             set { saturation = CheckRange(value / scale); }
         }
         public double Luminosity
         {
             get { return luminosity * scale; }
             set { luminosity = CheckRange(value / scale); }
         }
  
         private double CheckRange(double value)
         {
             if (value < 0.0)
                 value = 0.0;
             else if (value > 1.0)
                 value = 1.0;
             return value;
         }
  
         public override string ToString()
         {
             return String.Format("H: {0:#0.##} S: {1:#0.##} L: {2:#0.##}",   Hue, Saturation, Luminosity);
         }
  
         public string ToRGBString()
         {
             Color color = (Color)this;
             return String.Format("R: {0:#0.##} G: {1:#0.##} B: {2:#0.##}", color.R, color.G, color.B);
         }
  
         #region Casts to/from System.Drawing.Color
         public static implicit operator Color(HSLColor hslColor)
         {
             double r = 0, g = 0, b = 0;
             if (hslColor.luminosity != 0)
             {
                 if (hslColor.saturation == 0)
                     r = g = b = hslColor.luminosity;
                 else
                 {
                     double temp2 = GetTemp2(hslColor);
                     double temp1 = 2.0 * hslColor.luminosity - temp2;
  
                     r = GetColorComponent(temp1, temp2, hslColor.hue + 1.0 / 3.0);
                     g = GetColorComponent(temp1, temp2, hslColor.hue);
                     b = GetColorComponent(temp1, temp2, hslColor.hue - 1.0 / 3.0);
                 }
             }
             return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
         }
  
         private static double GetColorComponent(double temp1, double temp2, double temp3)
         {
             temp3 = MoveIntoRange(temp3);
             if (temp3 < 1.0 / 6.0)
                 return temp1 + (temp2 - temp1) * 6.0 * temp3;
             else if (temp3 < 0.5)
                 return temp2;
             else if (temp3 < 2.0 / 3.0)
                 return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
             else
                 return temp1;
         }
         private static double MoveIntoRange(double temp3)
         {
             if (temp3 < 0.0)
                 temp3 += 1.0;
             else if (temp3 > 1.0)
                 temp3 -= 1.0;
             return temp3;
         }
         private static double GetTemp2(HSLColor hslColor)
         {
             double temp2;
             if (hslColor.luminosity < 0.5)  //<=??
                 temp2 = hslColor.luminosity * (1.0 + hslColor.saturation);
             else
                 temp2 = hslColor.luminosity + hslColor.saturation - (hslColor.luminosity * hslColor.saturation);
             return temp2;
         }
  
         public static implicit operator HSLColor(Color color)
         {
             HSLColor hslColor = new HSLColor();
             hslColor.hue = color.GetHue() / 360.0; // we store hue as 0-1 as opposed to 0-360 
             hslColor.luminosity = color.GetBrightness();
             hslColor.saturation = color.GetSaturation();
             return hslColor;
         }
         #endregion
  
         public void SetRGB(int red, int green, int blue)
         {
             HSLColor hslColor = (HSLColor)Color.FromArgb(red, green, blue);
             this.hue = hslColor.hue;
            this.saturation = hslColor.saturation;
            this.luminosity = hslColor.luminosity;
        }
 
        public HSLColor() { }
        public HSLColor(Color color)
        {
            SetRGB(color.R, color.G, color.B);
        }
        public HSLColor(int red, int green, int blue)
        {
            SetRGB(red, green, blue);
        }
        public HSLColor(double hue, double saturation, double luminosity)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Luminosity = luminosity;
        }
 
 
    }
}

