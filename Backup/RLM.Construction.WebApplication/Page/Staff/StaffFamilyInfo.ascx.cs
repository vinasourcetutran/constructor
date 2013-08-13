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
    public partial class StaffFamilyInfo : System.Web.UI.UserControl
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

                

                Literal ltrOrder = (Literal)e.Item.FindControl("ltrOrder");
                ltrOrder.Text = (e.Item.ItemIndex + 1).ToString().PadLeft(3,'0');

                Literal ltrInfoType = (Literal)e.Item.FindControl("ltrInfoType");
                ltrInfoType.Text = Utility.GetEnumValue<FamilyType>((FamilyType)NumberHelper.GetValue<int>(dataItem.SubContentType));


                int iside;
                int.TryParse(xmlHash.GetKeyFromHash(FamilyField.Side.ToString()), out iside);

                Literal ltrSide = (Literal)e.Item.FindControl("ltrSide");
                ltrSide.Text = Utility.GetEnumValue<FamilySideType>((FamilySideType)iside);

                Literal ltrFullName = (Literal)e.Item.FindControl("ltrFullName");
                ltrFullName.Text = dataItem.Content;// xmlHash.GetKeyFromHash(FamilyField.FullName.ToString());

                int isex;
                int.TryParse(xmlHash.GetKeyFromHash(FamilyField.Sex.ToString()), out isex);
                Literal ltrSex = (Literal)e.Item.FindControl("ltrSex");
                ltrSex.Text =Utility.GetEnumValue<SexType>((SexType)isex);

                Literal ltrBirthDay = (Literal)e.Item.FindControl("ltrBirthDay");
                DateTime birthday=DateTime.Parse(xmlHash.GetKeyFromHash(FamilyField.Birhday.ToString()));
                ltrBirthDay.Text = birthday.ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

                Literal ltrPID = (Literal)e.Item.FindControl("ltrPID");
                ltrPID.Text = xmlHash.GetKeyFromHash(FamilyField.PID.ToString());

                Literal ltrComment = (Literal)e.Item.FindControl("ltrComment");
                ltrComment.Text = xmlHash.GetKeyFromHash(FamilyField.Comment.ToString());

                Literal ltrLastUpdate = (Literal)e.Item.FindControl("ltrLastUpdate");
                ltrLastUpdate.Text = NumberHelper.GetValue<DateTime>(dataItem.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                HtmlAnchor lnkEdit = (HtmlAnchor)e.Item.FindControl("lnkEdit");
                lnkEdit.HRef = UrlBuilderHelper.GetUrl(dataItem,NavigateAction.Edit,this.ContentType);


                HtmlAnchor lnkDelete = (HtmlAnchor)e.Item.FindControl("lnkDelete");
                lnkDelete.HRef = UrlBuilderHelper.GetUrl(dataItem, NavigateAction.Delete, this.ContentType);
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
            lnkAddNewItem.HRef = UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.ItemId }, NavigateAction.AddNew, ResourceDataContentType.StaffFamily);
        }

        private void BindData()
        {
            TList<ResourceData> items = ServiceRepositoryHelper.ResourceDataServiceHelper.GetByResource(this.ItemId,ResourceType.Staff,ResourceDataContentType.StaffFamily);
            rptItems.DataSource = items;
            rptItems.DataBind();
        }
        #endregion
    }
}