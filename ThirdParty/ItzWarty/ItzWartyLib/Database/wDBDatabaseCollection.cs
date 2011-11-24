using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty.Database
{
    public class wDBDatabaseCollection
    {
        private string path = "";
        public wDBDatabaseCollection(string path)
        {
            this.path = path;
        }
        public wDBDatabase this[string s]
        {
            get
            {
                return new wDBDatabase(path + "#db_" + s + "/"); //This might throw
            }
        }
    }
}
