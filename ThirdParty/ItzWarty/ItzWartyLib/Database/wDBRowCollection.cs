using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty.Database
{
    public class wDBRowCollection
    {
        private string path = "";
        private List<wDBRow> rows = new List<wDBRow>();
        public wDBRowCollection(string path)
        {
            this.path = path;

            this.LoadRows();
        }
        public wDBRowCollection(string path, ICollection<wDBRow> rows)
        {
            this.path = path;
            this.rows = new List<wDBRow>(rows);
        }
        private void LoadRows()
        {
            this.rows.Clear();

            int rowCount = Int32.Parse(File.ReadAllText(this.path + ".count"));
            for (int i = 0; i < rowCount; i++)
            {
                rows.Add(new wDBRow(this.path, i));
            }
        }
        public int Count
        {
            get
            {
                return this.rows.Count();
            }
        }
        public wDBRow this[int i]
        {
            get
            {
                return rows[i];
            }
        }
        public enum wDBComparison
        {
            Equals,
            Equals_NotCaseSensitive,
            NotEquals_NotCaseSensitive,
            NotEquals
        }
        public wDBRowCollection Where(string columnName, wDBComparison comparison, string what)
        {
            List<wDBRow> result = new List<wDBRow>();
            for(int i = 0; i < this.rows.Count; i++)
            {
                string value = this.rows[i][columnName];
                bool keep = false;
                switch (comparison)
                {
                    case wDBComparison.Equals:
                        if (value == what) keep = true;
                        break;
                    case wDBComparison.Equals_NotCaseSensitive:
                        if (value.ToLower() == what.ToLower())
                            keep = true;
                        break;
                    case wDBComparison.NotEquals_NotCaseSensitive:
                        if (value.ToLower() != what.ToLower())
                            keep = true;
                        break;
                    case wDBComparison.NotEquals:
                        if (value != what) keep = true;
                        break;
                }
                if (keep)
                    result.Add(this.rows[i]);
            }
            return new wDBRowCollection(this.path, result);
        }
    }
}