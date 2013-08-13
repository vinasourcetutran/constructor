using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.Contract
{
    public partial class AdvanceRequestList1 : System.Web.UI.UserControl
    {
        #region Properties
        public AdvanceRequestType ResourceType { get; set; }

        public int ResourceId { get; set; }

        public bool IsShowAddNewLink { get; set; }

        public bool IsShowDeleteButton { get; set; }

        public string PageTitle { get; set; }
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                lnkAddNewFile.Visible = IsShowAddNewLink;
                string addNewUrl = string.Format("Page/Contract/AdvanceRequestAddNew.aspx?ResourceId={0}&ResourceType={1}&PageTitle={2}", this.ResourceId, this.ResourceType, this.PageTitle);
                lnkAddNewFile.Url = addNewUrl;
                BindItems();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }


        protected void rptFiles_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }
                RLM.Construction.Entities.AdvanceRequest item = (RLM.Construction.Entities.AdvanceRequest)e.Item.DataItem;

                RLM.Construction.Entities.Contactor contactor = ServiceRepositoryHelper.ContactorServiceHelper.Get(NumberHelper.GetValue<int>(item.RequestContactorId));
                if (contactor != null)
                {
                    Literal ltrRequestContactor = (Literal)e.Item.FindControl("ltrRequestContactor");
                    ltrRequestContactor.Text = contactor.Name;
                }

                Literal ltrRequestContent = (Literal)e.Item.FindControl("ltrRequestContent");
                ltrRequestContent.Text = item.ResponseComment;


                Literal ltrRequestAmount = (Literal)e.Item.FindControl("ltrRequestAmount");
                ltrRequestAmount.Text =NumberHelper.GetValue<decimal>(item.RequestAmount).ToString(RLMConfiguration.Setting.MoneyFormat);

                RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.CurrencyUnitId));
                if (unit != null)
                {
                    Literal ltrCurrencyUnit = (Literal)e.Item.FindControl("ltrCurrencyUnit");
                    ltrCurrencyUnit.Text = unit.Name;
                }


                Literal ltrStatus = (Literal)e.Item.FindControl("ltrStatus");
                ltrStatus.Text = Utility.GetEnumValue<AdvanceRequestStatus>((AdvanceRequestStatus)item.Status);

                Literal ltrRequestDate = (Literal)e.Item.FindControl("ltrRequestDate");
                ltrRequestDate.Text = NumberHelper.GetValue<DateTime>(item.RequestDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                ImageButton btnPreview = (ImageButton)e.Item.FindControl("btnPreview");
                string url = string.Format("Page/Contract/AdvanceRequestView.aspx?itemId={0}", item.AdvanceRequestId);
                btnPreview.Attributes.Add("title", GetLocalResourceObject("AdvanceRequestViewDetail") as string);
                btnPreview.Attributes.Add("url", url);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Methods
        public void BindItems()
        {
            try
            {
                TList<RLM.Construction.Entities.AdvanceRequest> items = ServiceRepositoryHelper.AdvanceRequestServiceHelper.GetPaged(this.ResourceId, this.ResourceType);
                rptFiles.DataSource = items;
                rptFiles.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}