using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using RLM.Core.Framework.Log;
using System.IO;

namespace RLM.Core.Framework.Utility
{
    public class IOHelper
    {
        public static bool SaveFileToFolder(HttpPostedFile postesFile, string filePath)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }
                postesFile.SaveAs(filePath);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }
        public static void DeleteFile(string[] filenames)
        {
            try
            {
                foreach (string item in filenames)
                {
                    try
                    {
                        System.IO.File.Delete(item);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static void DeleteFile(string filename)
        {
            try
            {
                System.IO.File.Delete(filename);
            }
            catch (Exception ex)
            {
            }
        }
        public static void EmptyFolder(string folderPath,bool createIfNotExist)
        {
            try
            {
                if (createIfNotExist && !System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                    return;
                }
                string[] files = IOHelper.GetFiles(folderPath);
                IOHelper.DeleteFile(files);
            }
            catch (Exception ex)
            {
            }
        }

        private static string[] GetFiles(string folderPath)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(folderPath);
                return files;
            }
            catch (Exception ex)
            {
                return new string[0];
                throw;
            }
        }
        public static void DeleteFolder(string folderPath)
        {
            try
            {
                EmptyFolder(folderPath,false);
                System.IO.Directory.Delete(folderPath);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
