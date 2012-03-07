using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty.Database
{
    public class wDBValueCollection
    {
        private string path = "";
        public wDBValueCollection(string path)
        {
            this.path = path;
        }
        public string this[string s]
        {
            get
            {
                return File.ReadAllText(path + s);
            }
            set
            {
                File.WriteAllText(path + s, value);
            }
        }
    }
}
