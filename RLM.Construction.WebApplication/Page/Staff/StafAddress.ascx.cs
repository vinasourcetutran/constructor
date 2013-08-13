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

namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class StafAddress : System.Web.UI.UserControl
    {
        #region Properties
        public ResourceDataContentType ContentType { get; set; }
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
                lnkAddNewItem.HRef = UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.ItemId }, NavigateAction.AddNew, ResourceDataContentType.StaffAddress);
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

                Literal ltrOrder = (Literal)e.Item.FindControl("ltrOrder");
                ltrOrder.Text = (e.Item.ItemIndex + 1).ToString().PadLeft(3,'0');

                Literal ltrInfoType = (Literal)e.Item.FindControl("ltrInfoType");
                ltrInfoType.Text = Utility.GetEnumValue<AddressType>((AddressType)NumberHelper.GetValue<int>(dataItem.SubContentType));

                string countryName="(None)";
                string provinceName="(None)";
                XmlHash xmlHash = new XmlHash(dataItem.XMLContent);
                try
                {

                    Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(int.Parse(xmlHash.GetKeyFromHash(AddressField.Country.ToString())));
                    countryName = group != null ? group.Name : countryName;

                    group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(int.Parse(xmlHash.GetKeyFromHash(AddressField.Province.ToString())));
                    provinceName = group != null ? group.Name : countryName;
                }
                catch (Exception)
                {
                }

                Literal ltrAddress = (Literal)e.Item.FindControl("ltrAddress");
                ltrAddress.Text =string.Format("{0}, {1}, {2}",dataItem.Content, provinceName,  countryName);

                Literal ltrLastUpdate = (Literal)e.Item.FindControl("ltrLastUpdate");
                ltrLastUpdate.Text = NumberHelper.GetValue<DateTime>(dataItem.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                HtmlAnchor lnkEdit = (HtmlAnchor)e.Item.FindControl("lnkEdit");
                lnkEdit.HRef = UrlBuilderHelper.GetUrl(dataItem,NavigateAction.Edit,this.ContentType);


                //HtmlAnchor lnkDelete = (HtmlAnchor)e.Item.FindControl("lnkDelete");
                //lnkDelete.HRef = UrlBuilderHelper.GetUrl(dataItem, NavigateAction.Delete, this.ContentType);
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
            TList<ResourceData> items = ServiceRepositoryHelper.ResourceDataServiceHelper.GetByResource(this.ItemId,ResourceType.Staff,ResourceDataContentType.StaffAddress);
            rptItems.DataSource = items;
            rptItems.DataBind();
        }
        #endregion
    }
}