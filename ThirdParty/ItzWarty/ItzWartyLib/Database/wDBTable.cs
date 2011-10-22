using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty.Database
{
    public class wDBTable
    {
        private string path = "";
        public wDBTable(string path)
        {
            this.path = path;
            if (!Directory.Exists(this.path))
                throw new Exception("Table of path '{0}' did not exist!".F(path));
        }
        public wDBRowCollection Rows
        {
            get
            {
                return new wDBRowCollection(path);
            }
        }
    }
}
