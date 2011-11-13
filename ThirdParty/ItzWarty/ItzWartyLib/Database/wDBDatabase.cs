using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItzWarty.Database
{
    public class wDBDatabase
    {
        private string path = "";
        public wDBDatabase(string path)
        {
            this.path = path;
        }
        public wDBValueCollection Values
        {
            get
            {
                return new wDBValueCollection(path);
            }
        }
        public wDBTableCollection Tables
        {
            get
            {
                return new wDBTableCollection(path);
            }
        }
        public wDBDatabaseCollection Databases
        {
            get
            {
                return new wDBDatabaseCollection(path);
            }
        }
    }
}
