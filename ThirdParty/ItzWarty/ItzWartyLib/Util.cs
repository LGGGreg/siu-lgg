using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ItzWarty
{
    public static class Util
    {
        /// <summary>
        /// Gets all files in the given directory, and its subdirectories.
        /// This is used because apparently Directory.GetFiles("path", "*", SubDirectories) doesn't work with space
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllChildFiles(string path)
        {
            List<string> result = new List<string>();
            result.AddRange(Directory.GetFiles(path));

            string[] childDirs = Directory.GetDirectories(path);
            foreach (string dir in childDirs)
            {
                FileAttributes atribs = File.GetAttributes(dir);
                if ((atribs & FileAttributes.ReparsePoint) > 0)
                    result.AddRange(GetAllChildFiles(dir));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Creates the given directory and all directories leading up to it.
        /// </summary>
        public static void PrepareDirectory(string path)
        {
            path = path.Replace("/", "\\");
            String[] dirs = path.Split("\\");
            for (int i = 1; i < dirs.Length; i++)
            {
                String dirPath = String.Join("\\", dirs.SubArray(0, i)) + "\\";
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                //ostream.WriteLine(dirPath);
            }
        }

        /// <summary>
        /// Creates the given parent directory and all directories leading up to it.
        /// path should be a filename.
        /// </summary>
        public static void PrepareParentDirectory(string path)
        {
            path = path.Replace("/", "\\");
            String[] dirs = path.Split("\\");
            for (int i = 1; i < dirs.Length - 1; i++)
            {
                String dirPath = String.Join("\\", dirs.SubArray(0, i)) + "\\";
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                //ostream.WriteLine(dirPath);
            }
        }
    }
}
