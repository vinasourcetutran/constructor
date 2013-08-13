using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.ServiceHelpers;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Utility;
using System.Web.UI.HtmlControls;
using RLM.Configuration;
using System.IO;


namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class StaffResponsibilityInfo : System.Web.UI.Page
    {
        #region Properties
        public int ItemId { get; set; }
        public ResourceData Item { get; set; }
        NavigateAction action;
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                LoadData();

                if (!this.IsPostBack)
                {
                    BindData();
                }
                lnkAddNewItem.HRef = UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.ItemId }, NavigateAction.AddNew, ResourceDataContentType.StaffResponsibility);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void rptItems_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }
                ResourceData dataItem = (ResourceData)e.Item.DataItem;
                XmlHash xmlHash = new XmlHash(dataItem.XMLContent);



                //Literal ltrOrder = (Literal)e.Item.FindControl("ltrOrder");
                //ltrOrder.Text = (e.Item.ItemIndex + 1).ToString().PadLeft(3,'0');

                //Literal ltrInfoType = (Literal)e.Item.FindControl("ltrInfoType");
                //ltrInfoType.Text = Utility.GetEnumValue<StaffContractType>((StaffContractType)dataItem.SubContentType);
                Literal ltrTitle = (Literal)e.Item.FindControl("ltrTitle");
                ltrTitle.Text = xmlHash.GetKeyFromHash(ResponsibilityField.Title.ToString());

                DateTime date;
                if (DateTime.TryParse(xmlHash.GetKeyFromHash(ResponsibilityField.FromDate.ToString()), out date))
                {
                    Literal ltrFromDate = (Literal)e.Item.FindControl("ltrFromDate");
                    ltrFromDate.Text = date.ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
                }

                if (DateTime.TryParse(xmlHash.GetKeyFromHash(ResponsibilityField.ToDate.ToString()), out date))
                {
                    Literal ltrToDate = (Literal)e.Item.FindControl("ltrToDate");
                    ltrToDate.Text = date.ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
                }

                bool isCurrentJob = bool.Parse(xmlHash.GetKeyFromHash(ResponsibilityField.IsCurrentJob.ToString()));
                if (isCurrentJob == true)
                {
                    HtmlGenericControl spIsCurrentJob = (HtmlGenericControl)e.Item.FindControl("spIsCurrentJob");
                    spIsCurrentJob.Attributes.Add("class", "OK");
                }

                Literal ltrLastUpdate = (Literal)e.Item.FindControl("ltrLastUpdate");
                ltrLastUpdate.Text = NumberHelper.GetValue<DateTime>(dataItem.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);


                Literal ltrComment = (Literal)e.Item.FindControl("ltrComment");
                ltrComment.Text = xmlHash.GetKeyFromHash(ResponsibilityField.Comment.ToString());

                HtmlAnchor lnkEdit = (HtmlAnchor)e.Item.FindControl("lnkEdit");
                lnkEdit.HRef = UrlBuilderHelper.GetUrl(dataItem, NavigateAction.Edit, ResourceDataContentType.StaffResponsibility);


                HtmlAnchor lnkDelete = (HtmlAnchor)e.Item.FindControl("lnkDelete");
                lnkDelete.HRef = UrlBuilderHelper.GetUrl(dataItem, NavigateAction.Delete, ResourceDataContentType.StaffResponsibility);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        #endregion

        #region Private
        private void LoadData()
        {
            int tempId = 0;
            if (int.TryParse(Request.Params["ItemId"], out tempId))
            {
                this.ItemId = tempId;
                ServiceRepositoryHelper.ResourceDataServiceHelper.GetByResourceDataId(this.ItemId);
            }
        }

        private void BindData()
        {
            TList<ResourceData> items = ServiceRepositoryHelper.ResourceDataServiceHelper.GetByResource(this.ItemId, ResourceType.Staff, ResourceDataContentType.StaffResponsibility);
            rptItems.DataSource = items;
            rptItems.DataBind();
        }
        #endregion
    }
}
