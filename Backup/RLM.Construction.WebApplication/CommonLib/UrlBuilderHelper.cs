using System;
using System.Collections.Generic;

using System.Web;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Configuration;
using System.IO;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.WebApplication.CommonLib
{
    public class UrlBuilderHelper
    {
        #region Get url

        public static string GetUrl(ResourceData item, NavigateAction action, ResourceDataContentType contentType)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.AddNew:
                        url = string.Format("~/Page/Staff/{0}AddNew.aspx?ResourceId={1}", contentType, item.ResourceId);
                        break;
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Staff/{0}AddNew.aspx?ItemId={1}&ResourceId={2}", contentType, item.ResourceDataId, item.ResourceId);
                        break;
                    case NavigateAction.List:
                        if (contentType == ResourceDataContentType.StaffAddress ||
                            contentType == ResourceDataContentType.StaffEmail ||
                            contentType == ResourceDataContentType.StaffPhone)
                        {
                            url = string.Format("~/Page/Staff/StaffContactInfo.aspx?ItemId={0}", item.ResourceId);
                        }
                        else
                        {
                            url = string.Format("~/Page/Staff/{0}Info.aspx?ItemId={1}", contentType, item.ResourceId);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Staff/StaffList.aspx";
            }
            return url;
        }


        public static string GetUrl(ResourceType resourceType, int resourceId, NavigateAction action)
        {
            switch (resourceType)
            {
                case ResourceType.Contactor:
                    return UrlBuilderHelper.GetUrl(new Contactor() { ContactorId = resourceId }, action);
                case ResourceType.Contract:
                    return UrlBuilderHelper.GetUrl(new Contract() { ContractId=resourceId},action);
                case ResourceType.ProjectGroup:
                    return UrlBuilderHelper.GetProjectGroupUrl(new Group() { GroupId = resourceId },action);

                case ResourceType.Project:
                    return UrlBuilderHelper.GetUrl(new Project() { ProjectId = resourceId }, action);
                case ResourceType.ProjectPhase:
                    return UrlBuilderHelper.GetUrl(new ProjectPhase() { ProjectPhaseId = resourceId }, action);
                case ResourceType.Task:
                    return UrlBuilderHelper.GetUrl(new Task() { ContractId = resourceId }, action);
                case ResourceType.Item:
                    return UrlBuilderHelper.GetUrl(new Item() { ItemId = resourceId }, action);
                case ResourceType.Role:
                    return UrlBuilderHelper.GetUrl(new Role() { RoleId= resourceId }, action);
                case ResourceType.Partner:
                    return UrlBuilderHelper.GetUrl(new Partner() { PartnerId = resourceId }, action);
                case ResourceType.Staff:
                    return UrlBuilderHelper.GetUrl(new Staff() { StaffId= resourceId }, action);
                case ResourceType.ItemIOTicket:
                    return UrlBuilderHelper.GetUrl(new ItemIOTicket() { IOTicketId = resourceId }, action);
                default:
                    throw new Exception("Function was not implemented:"+resourceType.ToString());
            }
        }

        private static string GetProjectGroupUrl(Group item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.AddNew:
                        url = "~/Page/Project/CategoryAddNew.aspx";
                        break;
                    case NavigateAction.ClientAddNew:
                        url = "Page/Project/CategoryAddNew.aspx";
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Project/CategoryAddNew.aspx?ItemId={0}", item.GroupId);
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Project/CategoryAddNew.aspx?ItemId={0}", item.GroupId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Project/CategoryList.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Project/CategoryList.aspx";
            }
            return url;
        }

        public static string GetUrl(ItemIOTicket item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Repository/ItemIOTicketView.aspx?ItemId={0}", item.IOTicketId);
                        break;
                    case NavigateAction.View:
                        url = string.Format("~/Page/Repository/ItemIOTicketView.aspx?ItemId={0}", item.IOTicketId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Repository/ItemIOTicketAddNew.aspx";
                        break;
                    case NavigateAction.ClientAddNew:
                        url = "Page/Repository/ItemIOTicketAddNew.aspx";
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Repository/ItemIOTicketAddNew.aspx?ItemId={0}", item.IOTicketId);
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Repository/ItemIOTicketAddNew.aspx?ItemId={0}", item.IOTicketId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Repository/RepositoryInput.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Repository/RepositoryInput.aspx";
            }
            return url;
        }
        public static string GetUrl(ItemIOItem item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.AddNew:
                        url =string.Format("~/Page/Repository/ItemIOItemAddNew.aspx?TicketId={0}",item.IOTicketId);
                        break;
                    case NavigateAction.List:
                        url = UrlBuilderHelper.GetUrl(new ItemIOTicket() { IOTicketId=item.IOTicketId},NavigateAction.View);
                        break;
                    case NavigateAction.ClientAddNew:
                        url = string.Format("Page/Repository/ItemIOItemAddNew.aspx?TicketId={0}", item.IOTicketId);
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Repository/ItemIOItemAddNew.aspx?ItemId={0}&TicketId={1}", item.ItemIOItemId, item.IOTicketId);
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Repository/ItemIOItemAddNew.aspx?ItemId={0}&TicketId={1}", item.ItemIOItemId,item.IOTicketId);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return url;
        }

        public static string GetUrl(Contract item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url =string.Format("Page/Contract/ContractView.aspx?ItemId={0}",item.ContractId);
                        break;
                    case NavigateAction.View:
                        url =string.Format("~/Page/Contract/ContractView.aspx?ItemId={0}",item.ContractId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Contract/ContractAddNew.aspx";
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url =string.Format("~/Page/Contract/ContractAddNew.aspx?ItemId={0}",item.ContractId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Contract/ContractList.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Contract/ContractList.aspx";
            }
            return url;
        }

        public static string GetUrl(ProjectPhase item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientCompare:
                        url = string.Format("Page/Project/ProjectPhaseCompare.aspx?FromProjectId={0}&FromProjectPhaseId={1}", item.ProjectId, item.ProjectPhaseId);
                        break;
                    case NavigateAction.Compare:
                        url = string.Format("~/Page/Project/ProjectPhaseCompare.aspx?FromProjectId={0}&FromProjectPhaseId={1}", item.ProjectId, item.ProjectPhaseId);
                        break;
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Project/ProjectPhaseView.aspx?itemId={0}", item.ProjectPhaseId);
                        break;
                    case NavigateAction.View:
                        url =string.Format("~/Page/Project/ProjectPhaseView.aspx?itemId={0}",item.ProjectPhaseId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Project/ProjectPhaseAddNew.aspx";
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Project/ProjectPhaseAddNew.aspx?ItemId={0}", item.ProjectPhaseId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Project/ProjectPhaseList.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Project/ProjectPhaseList.aspx";
            }
            return url;
        }

        public static string GetUrl(Project item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Project/ProjectView.aspx?itemId={0}", item.ProjectId);
                        break;
                    case NavigateAction.View:
                        url = string.Format("~/Page/Project/ProjectView.aspx?itemId={0}", item.ProjectId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Project/ProjectAddNew.aspx";
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Project/ProjectAddNew.aspx?ItemId={0}", item.ProjectId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Project/ProjectList.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Project/ProjectList.aspx";
            }
            return url;
        }

        public static string GetUrl(Partner item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Partner/PartnerView.aspx?itemId={0}", item.PartnerId);
                        break;
                    case NavigateAction.View:
                        url = string.Format("~/Page/Partner/PartnerView.aspx?itemId={0}", item.PartnerId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Partner/PartnerAddNew.aspx";
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Partner/PartnerAddNew.aspx?ItemId={0}", item.PartnerId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Partner/ItemList.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Partner/ItemList.aspx";
            }
            return url;
        }

        public static string GetUrl(Contactor item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Partner/ContactorView.aspx?itemId={0}", item.ContactorId);
                        break;
                    case NavigateAction.View:
                        url = string.Format("~/Page/Partner/ContactorView.aspx?itemId={0}", item.PartnerId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Partner/ContactorAddNew.aspx";
                        break;
                    case NavigateAction.Detail:
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Partner/ContactorAddNew.aspx?ItemId={0}", item.ContactorId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Partner/ContactorList.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Partner/ContactorList.aspx";
            }
            return url;
        }

        public static string GetUrl(Item item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Item/ItemView.aspx?itemId={0}", item.ItemId);
                        break;
                    case NavigateAction.View:
                        url = string.Format("~/Page/Item/ItemView.aspx?itemId={0}", item.ItemId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Item/ItemAddNew.aspx";
                        break;
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Item/ItemAddNew.aspx?ItemId={0}", item.ItemId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Item/ItemList.aspx";
                        break;
                    case NavigateAction.OriginalFile:
                    case NavigateAction.Big:
                    case NavigateAction.Thumnail:
                        AttachFile file = ServiceRepositoryHelper.AttachFileServiceHelper.GetByResource((int)item.ItemId, ResourceType.Item);
                        url = UrlBuilderHelper.GetUrl(file,action);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Item/ItemList.aspx";
            }
            return url;
        }

        private static string GetUrl(AttachFile item, NavigateAction action)
        {
            string url = string.Format("~/Resource/Image/NoPhoto/noimage_{0}.gif",action);
            if (item == null) { return url; }

            string path = Path.Combine(HttpContext.Current.Server.MapPath(RLMConfiguration.Storage.AttachFileFolderUrl),item.FilePath);
            if (!File.Exists(path)) { return url; }
            
            try
            {
                switch (action)
                {
                    case NavigateAction.Thumnail:
                    case NavigateAction.Big:
                        url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, StringHelper.GetFileNameByAction(item.FilePath, action.ToString()));
                        break;
                    case NavigateAction.OriginalFile:
                    default:
                        url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, item.FilePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, item.FilePath);
            }
            return url;
        }

        public static string GetUrl(UnitConvertor item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/System/UnitConvertor.aspx?itemId={0}&FromUnit={1}", item.UnitConvertorId, item.FromUnitId);
                        break;
                    case NavigateAction.AddNew:
                        url = string.Format("~/Page/System/UnitConvertor.aspx?FromUnit={0}",item.FromUnitId);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/System/UnitConvertor.aspx";
            }
            return url;
        }

        public static string GetUrl(Task item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Task/TaskView.aspx?itemId={0}", item.TaskId);
                        break;
                    case NavigateAction.View:
                        url = string.Format("~/Page/Task/TaskView.aspx?itemId={0}", item.TaskId);
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Task/TaskAddNew.aspx?itemId={0}", item.TaskId);
                        break;
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Task/TaskAddNew.aspx?itemId={0}", item.TaskId);
                        break;
                    case NavigateAction.ClientAddNew:
                        url = string.Format("Page/Task/TaskAddNew.aspx?resourceid={0}&resourcetype={1}", item.ResourceId, item.ResourceType);
                        break;
                    case NavigateAction.List:
                        url = string.Format("~/Page/Task/TaskList.aspx?ResourceType={0}&ResourceId={1}", item.ResourceType,item.ResourceId);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Task/TaskList.aspx";
            }
            return url;
        }

        public static string GetUrl(User item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Staff/StaffView.aspx?UserId={0}", item.UserId);
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Staff/StaffAddNew.aspx?UserId={0}", item.UserId);
                        break;
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Staff/StaffList.aspx";
            }
            return url;
        }

        public static string GetUrl(TaskMember item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Task/TaskMemberView.aspx?itemId={0}", item.TaskMemberId);
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Task/TaskMemberAddNew.aspx?itemId={0}", item.TaskMemberId);
                        break;
                    case NavigateAction.ClientAddNew:
                        url = string.Format("Page/Task/TaskMemberAddNew.aspx?resourceid={0}&resourcetype={1}", item.ResourceId, item.ResourceType);
                        break;
                    case NavigateAction.List:
                        url = string.Format("~/Page/Task/TaskMemberList.aspx?ResourceType={0}&ResourceId", item.ResourceType, item.ResourceId);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = string.Format("~/Page/Task/TaskMemberList.aspx?ResourceType={0}&ResourceId", item.ResourceType, item.ResourceId);
            }
            return url;
        }

        public static string GetUrl(Staff item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Staff/StaffView.aspx?itemId={0}", item.StaffId);
                        break;
                        // temporary hardcode, this will be changed when staff functions was implemented
                    case NavigateAction.Big:
                    case NavigateAction.Thumnail:
                        url = "~/Resource/Image/NoPhoto/noimage_"+action+".gif";
                        if (!string.IsNullOrEmpty(item.Photo))
                        {
                            url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, item.Photo);
                            string newFileName = action + Path.GetExtension(url);
                            url = url.Replace(Path.GetExtension(url), "_" + newFileName);
                        }
                        break;
                    case NavigateAction.View:
                        url = string.Format("~/Page/Staff/StaffView.aspx?itemId={0}", item.StaffId);
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Staff/StaffAddNew.aspx?itemId={0}", item.StaffId);
                        break;
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Staff/StaffAddNew.aspx?itemId={0}", item.StaffId);
                        break;
                    case NavigateAction.ClientAddNew:
                        url = "Page/Staff/StaffAddNew.aspx";
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Staff/StaffAddNew.aspx";
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Staff/StaffList.aspx";
                        break;
               }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Staff/StaffList.aspx";
            }
            return url;
        }

        public static string GetUrl(Role item, NavigateAction action)
        {
            string url = "";
            try
            {
                switch (action)
                {
                    case NavigateAction.ClientView:
                        url = string.Format("Page/Staff/RoleView.aspx?itemId={0}", item.RoleId);
                        break;
                    case NavigateAction.AddNew:
                        url = "~/Page/Staff/RoleAddNew.aspx";
                        break;
                    case NavigateAction.ClientAddNew:
                        url = "Page/Staff/RoleAddNew.aspx";
                        break;
                    case NavigateAction.ClientEdit:
                        url = string.Format("Page/Staff/RoleAddNew.aspx?ItemId={0}", item.RoleId);
                        break;
                    case NavigateAction.Edit:
                        url = string.Format("~/Page/Staff/RoleAddNew.aspx?ItemId={0}", item.RoleId);
                        break;
                    case NavigateAction.List:
                        url = "~/Page/Staff/RoleList.aspx";
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                url = "~/Page/Staff/RoleList.aspx";
            }
            return url;
        }
        #endregion
    }
}
