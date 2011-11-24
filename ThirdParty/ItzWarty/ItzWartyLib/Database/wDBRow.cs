using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty.Database
{
    public class wDBRow
    {
        private string pathToTable  = "";
        private int id              = -1;
        private string path         = "";
        public wDBRow(string pathToTable, int id)
        {
            this.pathToTable    = pathToTable;
            this.id             = id;
            this.path           = pathToTable + "/"+id.ToString()+"/";
        }
        public string this[string key]
        {
            get
            {
                if (File.Exists(this.path + key))
                {
                    string fileContent = File.ReadAllText(this.path + key);
                    return fileContent;
                }
                else
                {
                    throw new Exception("Invalid attempt to get Key '{0}' in accessing {1}".F(key, path));
                }
            }
            set
            {
                if (File.Exists(this.path + key))
                {
                    File.WriteAllText(this.path + key, value);
                }
                else
                {
                    throw new Exception("Invalid attempt to set Key '{0}' to '{1}' in accessing {2}".F(key, value, path));
                }
            }
        }
    }
}
