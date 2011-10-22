using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty
{
    public static class Logger
    {
        private static string logPath = Environment.CurrentDirectory + "/log.log";
        private static string errorPath = Environment.CurrentDirectory + "/error.log";
        public static void Log(string wat)
        {
            if (!File.Exists(logPath))
            {
                File.Create(logPath).Dispose();
                File.WriteAllText(logPath, "==Log File==");
            }

            StreamWriter writer = File.AppendText(logPath);
            writer.Write("\r\n[" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "] " + wat);
            writer.Flush();
            writer.Close();
        }
    }
}
