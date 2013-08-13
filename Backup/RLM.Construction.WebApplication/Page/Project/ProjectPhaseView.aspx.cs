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

namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ProjectPhaseView : System.Web.UI.Page
    {

        #region Variables
        RLM.Construction.Entities.ProjectPhase item;
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
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Project/ProjectPhaseList.aspx", true);
        }

        protected void btnCompare_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(this.item,NavigateAction.Compare));
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            unitConvertor.FromEffectDate =NumberHelper.GetValue<DateTime>(this.item.FromDate);
            unitConvertor.ToEffectDate = this.item.RealToDate.HasValue ? this.item.RealToDate.Value : DateTime.Now;
            //unitConvertor.ToUnitId = RLMConfiguration.Setting.VndUnitId;
            projectPhaseList.ProjectId = this.item.ProjectId;
            projectPhaseList.IgnoreId = this.item.ProjectPhaseId.ToString();
            //projectPhaseList.Visible = true;
            grantChart.ResourceId = this.item.ProjectPhaseId;

            itemGraph.ResourceId = this.item.ProjectPhaseId;

            taskList.ResourceId = this.item.ProjectPhaseId;
            taskList.Visible = true;

            lnkProject.ResourceId = this.item.ProjectId;
            /*RLM.Construction.Entities.Project project = ServiceRepository.ProjectService.GetByProjectId(this.item.ProjectId);
            if (project != null)
            {
                lnkProject.Title = lnkProject.Text = project.Name;
                lnkProject.Url = UrlBuilderHelper.GetUrl(project, NavigateAction.ClientView);

            }*/
            files.ResourceId = this.itemId;
            files.PageTitle = this.item.Name;

            lblName.Text = this.item.Name;
            // add reference to active project phase
            ltrDescription.Text = this.item.Description;

            RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(this.item.CurrencyUnitId));
            string unitName="None";
            if (unit != null)
            {
                unitName=unit.Name;
                //lblCurrentcyUnit.Text = unit.Name;
            }


            lblFirstPrice.Text = string.Format("{0} ({1})", NumberHelper.GetValue<decimal>(this.item.DesignPrice).ToString(RLMConfiguration.Setting.MoneyFormat),unitName);
            lblLastPrice.Text = string.Format("{0} ({1})", NumberHelper.GetValue<decimal>(this.item.AuctualPrice).ToString(RLMConfiguration.Setting.MoneyFormat), unitName);

            lblExchangeRate.Text = string.Format("1 {0} = {1} VND", unitName, NumberHelper.GetValue<int>(this.item.ExchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat));

            lblFromDate.Text = this.item.FromDate.Value.ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblToDate.Text = this.item.ToDate.Value.ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblRealFromDate.Text = this.item.RealFromDate.Value.ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblRealToDate.Text = this.item.RealToDate.Value.ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

            

            lblStatus.Text = Utility.GetEnumValue<ProjectPhaseStatus>((ProjectPhaseStatus)NumberHelper.GetValue<int>(this.item.Status));
            lblType.Text = Utility.GetEnumValue<ProjectPhaseType>((ProjectPhaseType)NumberHelper.GetValue<int>(this.item.Type));
            spIsCurrentPhase.Attributes.Add("class",NumberHelper.GetValue<bool>(this.item.IsCurrentProjectPhase)?"OK":"NotOK");
            spBillable.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsBillable) ? "OK" : "NotOK");
            spIsActive.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsActive) ? "OK" : "NotOK");
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }

            itemInProjectList.ProjectPhaseId = this.item.ProjectPhaseId;

        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ProjectPhaseService.GetByProjectPhaseId(this.itemId);
        }
        #endregion
    }
}
