using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
namespace RAFManager
{
    public class LogTextWriter : TextWriter
    {
        public Func<string, object> writeLineHandler;
        public LogTextWriter(Func<string, object> writeLineHandler)
        {
            this.writeLineHandler = writeLineHandler;
        }
        public override void WriteLine()
        {
            WriteLine("");
        }
        public override void WriteLine(string value)
        {
            writeLineHandler(value);
        }
        public override Encoding Encoding
        {
            get
            {
                return Encoding.ASCII;
            }
        }
    }
}
