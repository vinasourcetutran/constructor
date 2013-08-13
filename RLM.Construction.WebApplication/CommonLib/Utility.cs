using System;
using System.Collections.Generic;

using System.Web;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Core.Framework.Utility;
using System.IO;
using RLM.Configuration;
using System.Web.UI.HtmlControls;
using RLM.Core.Framework.Enum;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.CommonLib
{
    public class Utility
    {
        #region Enum to TList
        public static string GetEnumValue<T>(T value) where T:struct
        {
            try
            {
                 if (!typeof(T).IsEnum) { throw new Exception("Invalid enum type"); }
                 string resourceKey = string.Format("{0}_{1}", typeof(T).Name, value);
                 return Resources.Enumeration.ResourceManager.GetString(resourceKey);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public static TList<EnumPair> GetContractStatus(bool isShowAll)
        {
            try
            {
                TList<EnumPair> items = UtilityService.GetEnumValues<ContractStatus>(typeof(ContractStatus), delegate(Type type, string value)
                {
                    string resourceKey = string.Format("{0}_{1}", type.Name, value);
                    return Resources.Enumeration.ResourceManager.GetString(resourceKey);
                });
                if (isShowAll)
                {
                    EnumPair all = new EnumPair();
                    all.Value = "";
                    all.Name = Resources.Enumeration.ResourceManager.GetString("ContractStatus_All");
                    items.Insert(0, all);
                }
                return items;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new TList<EnumPair>();
            }
        }
        public static TList<EnumPair> GetEnumToList<T>(bool isShowAll) where T : struct
        {
            try
            {
                if (!typeof(T).IsEnum) { throw new Exception("Invalid enum type"); }
                TList<EnumPair> items = UtilityService.GetEnumValues<T>(typeof(T), delegate(Type type, string value)
                {
                    string resourceKey = string.Format("{0}_{1}", type.Name, value);
                    return Resources.Enumeration.ResourceManager.GetString(resourceKey);
                });
                if (isShowAll)
                {
                    EnumPair all = new EnumPair();
                    all.Value = "";
                    all.Name = Resources.Enumeration.ResourceManager.GetString(string.Format("{0}_All", typeof(T).Name));
                    items.Insert(0, all);
                }
                return items;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new TList<EnumPair>();
            }
        }
        #endregion

        #region Current Logged User
        // for testing returnd efault user id : 1
        public static int GetCurrentUserId()
        {
            try
            {
                return RLMContext.CurrentUser != null ? RLMContext.CurrentUser.UserId : 1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 1;
            }
        }
        #endregion

        #region File upload
        public static void SetFileUpLoadControl(HtmlAnchor link, int resourceId, ResourceType resourceType)
        {
            try
            {
                AttachFile file = ServiceRepository.AttachFileService.GetItemByResourceIdAndType(resourceId, resourceType);
                if (file == null) { return; }
                link.HRef = string.Format("{0}{1}", RLMConfiguration.Storage.AttachFileFolderUrl, file.FilePath);
                link.InnerHtml = link.Title = file.Name;
                link.Attributes.Add("class", ((FileTypeEnum)file.Type).ToString());
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public static AttachFile UploadFile(HttpPostedFile postedFile, int resourceId, ResourceType resourceType, bool isAlwayAddNew,params FileViewTypeInfo[] types)
        {
            try
            {
                if (postedFile == null || string.IsNullOrEmpty(postedFile.FileName.Trim()) || postedFile.ContentLength == 0)
                {
                    return null;
                }
                string fileName = StringHelper.FileNameFormat(postedFile.FileName);
                fileName = Path.Combine(StringHelper.GetGuid(), fileName);
                string folder = Path.Combine(HttpContext.Current.Server.MapPath(RLMConfiguration.Storage.AttachFileFolderUrl), fileName);
                //folder = Path.Combine(folder, fileName);

                IOHelper.SaveFileToFolder(postedFile, folder);
                if (types != null && types.Length > 0 && StringHelper.IsMatch(RLMConfiguration.Setting.ImageFilePattern, folder))
                {
                    foreach (FileViewTypeInfo info in types)
                    {
                        try
                        {
                            FileHelper.CreateImage(folder, info.Type.ToString(), info.Width, info.Height);
                        }
                        catch (Exception typeEx)
                        {
                            Logger.Error(typeEx);
                        }
                    }
                }

                AttachFile attachFile = null;
                if (!isAlwayAddNew)
                {
                    attachFile = ServiceRepository.AttachFileService.GetItemByResourceIdAndType(resourceId, resourceType);
                }
                if (attachFile == null)
                {
                    attachFile = new AttachFile();
                    attachFile.CreationDate = DateTime.Now;
                    attachFile.CreationUserId = Utility.GetCurrentUserId();
                }
                else
                {
                    // delete exist file
                    string path = Path.Combine(HttpContext.Current.Server.MapPath(RLMConfiguration.Storage.AttachFileFolderUrl), attachFile.FilePath);
                    try
                    {
                        File.Delete(path);
                        Directory.Delete(Path.GetDirectoryName(path));
                    }
                    catch (Exception) { }
                }
                attachFile.ResourceId = resourceId;
                attachFile.ResourceType = (int)resourceType;
                attachFile.FilePath = fileName;
                attachFile.Name = Path.GetFileName(fileName);
                attachFile.Type = (int)FileHelper.GetFileType(fileName);
                attachFile.LastModificationDate = DateTime.Now;
                attachFile.LastModificationUserId = Utility.GetCurrentUserId();

                if (attachFile.AttachFileId > 0)
                {
                    ServiceRepository.AttachFileService.Update(attachFile);
                }
                else
                {
                    ServiceRepository.AttachFileService.Insert(attachFile);
                }
                return attachFile;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }
        public static string UploadFile(HttpPostedFile postedFile, params FileViewTypeInfo[] types)
        {
            try
            {
                if (postedFile == null || string.IsNullOrEmpty(postedFile.FileName.Trim()) || postedFile.ContentLength == 0)
                {
                    return string.Empty;
                }
                string fileName = StringHelper.FileNameFormat(postedFile.FileName);
                fileName = Path.Combine(StringHelper.GetGuid(), fileName);
                string folder = Path.Combine(HttpContext.Current.Server.MapPath(RLMConfiguration.Storage.AttachFileFolderUrl), fileName);

                IOHelper.SaveFileToFolder(postedFile, folder);
                if (types != null && types.Length > 0 && StringHelper.IsMatch(RLMConfiguration.Setting.ImageFilePattern, folder))
                {
                    foreach (FileViewTypeInfo info in types)
                    {
                        if (info.Type == FileViewType.None) { continue; }
                        try
                        {
                            FileHelper.CreateImage(folder, info.Type.ToString(), info.Width, info.Height);
                        }
                        catch (Exception typeEx)
                        {
                            Logger.Error(typeEx);
                        }
                    }
                }
                return fileName;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return string.Empty;
            }
        }
        #endregion

        public static string GetResourceName(ResourceType resourceType, int resourceId)
        {
            switch (resourceType)
            {
                case ResourceType.ProjectGroup:
                    Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(resourceId);
                    return group.Name;
                case ResourceType.Contactor:
                    Contactor contactor = ServiceRepositoryHelper.ContactorServiceHelper.Get(resourceId);
                    return contactor.Name;

                case ResourceType.ProjectPhase:
                    ProjectPhase projectPhase = ServiceRepositoryHelper.ProjectPhaseServiceHelper.GetByProjectPhaseId(resourceId);
                    return projectPhase.Name;

                case ResourceType.Task:
                    Task task = ServiceRepositoryHelper.TaskServiceHelper.GetByTaskId(resourceId);
                    return task.Name;

                case ResourceType.Contract:
                    Contract contract = ServiceRepositoryHelper.ContractServiceHelper.Get(resourceId);
                    return contract.Name;

                case ResourceType.Project:
                    Project project = ServiceRepositoryHelper.ProjectServiceHelper.GetByProjectId(resourceId);
                    return project.Name;
                case ResourceType.Item:
                    Item item = ServiceRepositoryHelper.ItemServiceHelper.GetItemByItemId((long)resourceId);
                    return item.Name;
                case ResourceType.Role:
                    Role role = ServiceRepositoryHelper.RoleServiceHelper.GetByRoleId(resourceId);
                    return role.Name;
                case ResourceType.Partner:
                    Partner partner = ServiceRepositoryHelper.PartnerServiceHelper.GetByPartnerId(resourceId);
                    return partner.Name;
                case ResourceType.Staff:
                    Staff staff = ServiceRepositoryHelper.StaffServiceHelper.GetByStaffId(resourceId);
                    return staff.FullName;
                case ResourceType.ItemIOTicket:
                    ItemIOTicket itemIOTicket = ServiceRepositoryHelper.ItemIOTicketServiceHelper.GetByIOTicketId(resourceId);
                    return itemIOTicket.Name;
                default:
                    throw new Exception("Function was not implemented for "+ resourceType.ToString());
            }
        }

        #region Mask
        public static string GetNewContractCode()
        {
            int number = 1;
            string maskFormat = RLMConfiguration.Setting.ContractCodeMask;
            string maskKey = "ContractNumber_" + DateTime.Now.Year;
            AppConfig appConfig = ServiceRepositoryHelper.AppConfigServiceHelper.GetByAppConfigName(maskKey);
            if (appConfig == null)
            {
                appConfig = new AppConfig();
                appConfig.AppConfigName = maskKey;
                appConfig.AppConfigValue = number.ToString();
                appConfig.CreationDate = DateTime.Now;
                appConfig.LastModificationDate = DateTime.Now;
                appConfig.LastModificationUserId = appConfig.CreationUserId = Utility.GetCurrentUserId();
                appConfig.ApplicationId = 1;
                appConfig.IsVisible = false;
                ServiceRepositoryHelper.AppConfigServiceHelper.Insert(appConfig);
            }
            number=int.Parse(appConfig.AppConfigValue);
                //number = int.Parse(appConfig.AppConfigValue);
                //number += 1;
                //appConfig.AppConfigValue = number.ToString();
                //appConfig.LastModificationUserId = Utility.GetCurrentUserId();
                //appConfig.LastModificationDate = DateTime.Now;
                //ServiceRepositoryHelper.AppConfigServiceHelper.Update(appConfig);
            return string.Format(RLMConfiguration.Setting.ContractCodeMask,DateTime.Now.Year,number);
        }

        public static void UpdateNewContractCode()
        {
            int number = 1;
            string maskFormat = RLMConfiguration.Setting.ContractCodeMask;
            string maskKey = "ContractNumber_" + DateTime.Now.Year;
            AppConfig appConfig = ServiceRepositoryHelper.AppConfigServiceHelper.GetByAppConfigName(maskKey);
            if(appConfig!=null)
            {
                number = int.Parse(appConfig.AppConfigValue);
                number += 1;
                appConfig.AppConfigValue = number.ToString();
                appConfig.LastModificationUserId = Utility.GetCurrentUserId();
                appConfig.LastModificationDate = DateTime.Now;
                ServiceRepositoryHelper.AppConfigServiceHelper.Update(appConfig);
            }
            //return string.Format(RLMConfiguration.Setting.ContractCodeMask, DateTime.Now.Year, number);
        }
        #endregion

        #region Exception
        public static void ShowMessage(ErrorType type, string message, Exception ex)
        {
            Logger.Error(ex);
            RLMContext.Error = ex;
            RLMContext.ErrorType = type;
            RLMContext.ErrorMessage = message;
        }
        #endregion

    }
}
