namespace SkinInstaller
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public class FileHandler
    {
        public void DirectoryDelete(string dirName, bool sub)
        {
            try
            {
                //Directory.Delete(dirName, sub);
                ForceDeleteDirectory(dirName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                //MessageBox.Show(exception.Message);
            }
        }
        public static void ForceDeleteDirectory(string path)
        {
            DirectoryInfo root;
            Stack<DirectoryInfo> fols;
            DirectoryInfo fol;
            fols = new Stack<DirectoryInfo>();
            root = new DirectoryInfo(path);
            fols.Push(root);
            while (fols.Count > 0)
            {
                fol = fols.Pop();
                fol.Attributes = fol.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                foreach (DirectoryInfo d in fol.GetDirectories())
                {
                    fols.Push(d);
                }
                foreach (FileInfo f in fol.GetFiles())
                {
                    f.Attributes = f.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                    f.Delete();
                }
            }
            root.Delete(true);
        }


        public void FileCopy(string fileName, string fileDest)
        {
            try
            {
                string[] strArray = fileDest.Split(new char[] { '\\' });
                string path = fileDest.Remove(fileDest.Length - strArray[strArray.Length - 1].Length);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.Copy(fileName, fileDest, true);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\r\n on the file " + fileName + "\r\ngoing to \r\n" + fileDest);
            }
        }

        public void FileDelete(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.SetAttributes(fileName,
                        FileAttributes.Normal);

                    File.Delete(fileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        public void FileMove(string fileName, string fileDest)
        {
            File.SetAttributes(fileName,
                    FileAttributes.Normal);
            this.FileCopy(fileName, fileDest);
        }
        public void DirectoryMove(string dirPath, string dirDest)
        {
            try
            {
                if (!Directory.Exists(dirDest))
                {
                   // Directory.CreateDirectory(dirDest);
                }
                Directory.Move(dirPath, dirDest);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

