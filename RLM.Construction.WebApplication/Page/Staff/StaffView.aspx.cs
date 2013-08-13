using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Core.Web.UI;
using RLM.Core.Web.UI.Notifier;
using RLM.Construction.Entities;
using RLM.Configuration;
using RLM.Construction.WebApplication.CommonLib;
using System.IO;
using RLM.Core.Framework.Utility;
using System.Threading;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class StaffView : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Staff item;
        int itemId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (!this.IsPostBack)
                {
                    BindGuid();
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericException, ex);
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Staff() { StaffId = 0 }, NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }

            lblStaffCode.Text = item.StaffCode;
            lblFullName.Text = this.item.FirstName;
            staffPhoto.ImageUrl = UrlBuilderHelper.GetUrl(this.item, NavigateAction.Thumnail);
            staffPhoto.AlternateText=this.item.FullName;

            Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.DeptId));
            lblDept.Text = group != null ? group.Name : string.Empty;

            Role role = ServiceRepositoryHelper.RoleServiceHelper.GetByRoleId(NumberHelper.GetValue<int>(this.item.JobTitleId));
            lblJobTitle.Text = role != null ? role.Name : string.Empty;

            iframeCommonInfo.Attributes.Add("src",Page.ResolveUrl(string.Format("~/Page/Staff/StaffCommonInfo.aspx?ItemId={0}", this.itemId)));
            
            tabStaffContactInfoFrame.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffContactInfo.aspx?ItemId={0}", this.itemId)));
            lnkContact.Attributes.Add("frameContent", tabStaffContactInfoFrame.ClientID);

            tabStaffIdentifycationInfoIframe.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffIdentifycationInfo.aspx?ItemId={0}", this.itemId)));
            lnkIdentification.Attributes.Add("frameContent", tabStaffIdentifycationInfoIframe.ClientID);

            tabStaffFamilyIframe.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffFamilyInfo.aspx?ItemId={0}", this.itemId)));
            lnkFamily.Attributes.Add("frameContent", tabStaffFamilyIframe.ClientID);

            tabStaffRewardIframe.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffRewardInfo.aspx?ItemId={0}", this.itemId)));
            lnkReward.Attributes.Add("frameContent", tabStaffRewardIframe.ClientID);

            tabStaffPunishIframe.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffPunishInfo.aspx?ItemId={0}", this.itemId)));
            lnkPunish.Attributes.Add("frameContent", tabStaffPunishIframe.ClientID);

            tabStaffContractIframe.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffContractInfo.aspx?ItemId={0}", this.itemId)));
            lnkContract.Attributes.Add("frameContent", tabStaffContractIframe.ClientID);

            tabStaffResponsibilityIframe.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffResponsibilityInfo.aspx?ItemId={0}", this.itemId)));
            lnkResponsibility.Attributes.Add("frameContent", tabStaffResponsibilityIframe.ClientID);
            //iframestaffFamily.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffFamily.aspx?ItemId={0}", this.itemId)));
            //iframeStaffReward.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffReward.aspx?ItemId={0}", this.itemId)));
            //iframeStaffPunish.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffPunish.aspx?ItemId={0}", this.itemId)));
            //iframeStaffContract.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffContract.aspx?ItemId={0}", this.itemId)));
            //iframeStaffJob.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffJob.aspx?ItemId={0}", this.itemId)));



            //iframeStaffResponsibility.Attributes.Add("src", Page.ResolveUrl(string.Format("~/Page/Staff/StaffResponsibility.aspx?ItemId={0}", this.itemId)));
            //lnkCommonInfo.NavigateUrl = string.Format("~/Page/Staff/StaffCommonInfo.aspx?ItemId={0}",this.itemId);
            //lnkContact.NavigateUrl = string.Format("~/Page/Staff/StaffContactInfo.aspx?ItemId={0}", this.itemId);
            //lnkIdentification.NavigateUrl = string.Format("~/Page/Staff/StaffIdentifycationInfo.aspx?ItemId={0}", this.itemId);
            //lnkFamily.NavigateUrl = string.Format("~/Page/Staff/StaffFamily.aspx?ItemId={0}", this.itemId);
            //lnkReward.NavigateUrl = string.Format("~/Page/Staff/StaffReward.aspx?ItemId={0}", this.itemId);
            //lnkPunish.NavigateUrl = string.Format("~/Page/Staff/StaffPunish.aspx?ItemId={0}", this.itemId);
            //lnkContract.NavigateUrl = string.Format("~/Page/Staff/StaffContract.aspx?ItemId={0}", this.itemId);
            //lnkJob.NavigateUrl = string.Format("~/Page/Staff/StaffJob.aspx?ItemId={0}", this.itemId);
            //lnkResponsibility.NavigateUrl = string.Format("~/Page/Staff/StaffResponsibility.aspx?ItemId={0}", this.itemId);
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.StaffServiceHelper.GetByStaffId(this.itemId);
        }

        #endregion
    }
}
