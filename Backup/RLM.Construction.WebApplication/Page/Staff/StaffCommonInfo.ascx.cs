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
    public partial class StaffCommonInfo : System.Web.UI.UserControl
    {
        #region Variables
        RLM.Construction.Entities.Staff item;
        int itemId;
        #endregion

        #region Properties
        public RLM.Construction.Entities.Staff Item
        {
            get { return this.item; }
            set { this.item = value; }
        }
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //LoadData();
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
            lblMagnetic.Text = this.item.MagneticCardId;
            lblSex.Text = Utility.GetEnumValue<SexType>((SexType)NumberHelper.GetValue<int>(this.item.Sex));
            lblBirthday.Text = NumberHelper.GetValue<DateTime>(this.item.BirthDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

            Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.BirthPlaceId));
            lblBirthPlace.Text = string.Format("{0}, {1}", this.item.BirthdayPlace, group != null ? group.Name : string.Empty);

            group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.PermanentProvinceId));
            lblPerAddress.Text = string.Format("{0}, {1}", this.item.PermanentAddress, group != null ? group.Name : string.Empty);

            group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.CurrentProvinceId));
            lblTempAddress.Text = string.Format("{0}, {1}", this.item.PermanentAddress, group != null ? group.Name : string.Empty);

            group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.ReligiousId));
            lblReligious.Text = group != null ? group.Name : string.Empty;

            group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.PeopleId));
            lblPeople.Text = group != null ? group.Name : string.Empty;


            lblStartWorkingDay.Text = NumberHelper.GetValue<DateTime>(this.item.StartWorkingDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblWorkingDay.Text = NumberHelper.GetValue<DateTime>(this.item.WorkingDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

            group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.DeptId));
            lblDept.Text = group != null ? group.Name : string.Empty;

            Role role = ServiceRepositoryHelper.RoleServiceHelper.GetByRoleId(NumberHelper.GetValue<int>(this.item.JobTitleId));
            lblJobTitle.Text = role != null ? role.Name : string.Empty;

            spIsActive.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsActive) ? "OK" : "NotOK");
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = this.item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.StaffServiceHelper.GetByStaffId(this.itemId);
        }

        #endregion
    }
}