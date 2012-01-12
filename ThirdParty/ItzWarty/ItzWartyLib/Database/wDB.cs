using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItzWarty.Database
{
    public static class wDB
    {
        private static string rootPath = "C:/wDB/";
        public static wDBDatabaseCollection Databases
        {
            get
            {
                return new wDBDatabaseCollection(rootPath);
            }
        }
        public static string RootPath
        {
            get
            {
                return rootPath;
            }
            set
            {
                rootPath = value;
            }
        }
    }
}
