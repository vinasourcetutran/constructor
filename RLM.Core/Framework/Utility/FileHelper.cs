using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Core.Framework.Enum;
using RLM.Core.Framework.Log;
using System.IO;

namespace RLM.Core.Framework.Utility
{
    public class FileHelper
    {
        public static FileTypeEnum GetFileType(string fileName)
        {
            try
            {
                FileTypeEnum type = FileTypeEnum.None;
                string ext = Path.GetExtension(fileName).ToLower();
                switch (ext)
                {
                    case ".txt":
                        type = FileTypeEnum.Text;
                        break;
                    case ".doc":
                        type = FileTypeEnum.Word;
                        break;
                    case ".xsl":
                    case ".xsls":
                        type = FileTypeEnum.Excel;
                        break;
                    case ".ppt":
                        type = FileTypeEnum.PowerPoint;
                        break;
                    case ".pdf":
                        type = FileTypeEnum.Pdf;
                        break;
                    case ".chm":
                        type = FileTypeEnum.Chm;
                        break;
                    case ".png":
                        type = FileTypeEnum.Png;
                        break;
                    case ".gif":
                        type = FileTypeEnum.Gif;
                        break;
                    case ".jpg":
                    case ".jpeg":
                        type = FileTypeEnum.Jpg;
                        break;
                    case ".zip":
                    case ".rar":
                    case ".7zip":
                        type = FileTypeEnum.Compressed;
                        break;
                }
                return type;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return FileTypeEnum.None;
            }
        }

        public static string CreateImage(string currentImagePath, string viewType, int width, int height)
        {
            try
            {
                string newFileName = viewType + Path.GetExtension(currentImagePath);
                newFileName = currentImagePath.Replace(Path.GetExtension(currentImagePath), "_" + newFileName);
                ImageHelper.SaveResizeFromStream(currentImagePath, newFileName, width, height);
                return Path.GetFileName(newFileName);
            }
            catch (Exception ex)
            {
                RLM.Core.Framework.Log.Logger.Error(ex);
                return string.Empty;
            }
        }
    }
}
