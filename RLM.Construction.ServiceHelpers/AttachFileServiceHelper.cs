using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;
using RLM.Construction.Entities;
using RLM.Configuration;
using System.IO;
using RLM.Core.Framework.Utility;
using System.Web;

namespace RLM.Construction.ServiceHelpers
{
    public class AttachFileServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.AttachFile> GetList(int resourceId, RLM.Construction.Entities.ResourceType resourceType)
        {
            string whereClause = string.Format(
                    "[ResourceType]={0} AND [ResourceId]={1}",
                    (int)resourceType,
                    resourceId
                );
            int total;
            return ServiceRepository.AttachFileService.GetPaged(whereClause, AttachFileColumn.Name.ToString(), 0, 0, out total);
        }

        public string GetFilePath(AttachFile file, FileViewType viewType)
        {
            if (viewType == FileViewType.Full)
            {
                return Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, file.FilePath);
            }
            string fileUrl =Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl,StringHelper.GetFileNameByAction(file.FilePath,viewType.ToString()));
                
            
            string filePath=HttpContext.Current.Server.MapPath(fileUrl);
            if (!File.Exists(filePath) || !StringHelper.IsMatch(RLMConfiguration.Setting.ImageFilePattern,file.FilePath))
            {
                string ext = Path.GetExtension(file.FilePath).Trim('.')+"_"+viewType+".png";
                fileUrl = Path.Combine(RLMConfiguration.Storage.FileIconUrl,ext);
            }
            return fileUrl;

        }

        public void Delete(int attachFileId)
        {
            ServiceRepository.AttachFileService.Delete(attachFileId);
        }

        public AttachFile GetByResource(int resourceId, ResourceType resourceType)
        {
            return ServiceRepository.AttachFileService.GetItemByResourceIdAndType(resourceId,resourceType);
        }

        public void Update(AttachFile item)
        {
            ServiceRepository.AttachFileService.Update(item);
        }

        public void Insert(AttachFile item)
        {
            ServiceRepository.AttachFileService.Insert(item);
        }
    }
}
