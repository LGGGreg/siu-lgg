using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty.Database
{
    public class wDBTableCollection
    {
        private string path = "";
        public wDBTableCollection(string path)
        {
            this.path = path;
        }
        public wDBTable this[string s]
        {
            get
            {
                return new wDBTable(path+"$t_"+s+"/"); //This might throw
            }
        }
    }
}
