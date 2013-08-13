﻿using System;
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
    public partial class StaffPunishInfo : System.Web.UI.UserControl
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
                lnkAddNewItem.HRef = UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.ItemId }, NavigateAction.AddNew, ResourceDataContentType.StaffPunish);
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

                Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(dataItem.SubContentType));
                if (group != null)
                {
                    Literal ltrInfoType = (Literal)e.Item.FindControl("ltrInfoType");
                    ltrInfoType.Text = group.Name;
                }

                int form = 1;
                int.TryParse(xmlHash.GetKeyFromHash(PunishField.PunishForm.ToString()), out form);
                Literal ltrPunishForm = (Literal)e.Item.FindControl("ltrPunishForm");
                ltrPunishForm.Text = Utility.GetEnumValue<PunishFormType>((PunishFormType)form);

                decimal money = 0;
                decimal.TryParse(xmlHash.GetKeyFromHash(PunishField.Money.ToString()), out money);
                string moneyUnitName = "None";
                RLM.Construction.Entities.Unit moneyUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(int.Parse(xmlHash.GetKeyFromHash(PunishField.MoneyUnit.ToString())));
                if (moneyUnit != null)
                {
                    moneyUnitName = moneyUnit.Name;
                }
                Literal ltrMoney = (Literal)e.Item.FindControl("ltrMoney");
                ltrMoney.Text = string.Format("{0} ({1})", money, moneyUnitName);

                Literal ltrReason = (Literal)e.Item.FindControl("ltrReason");
                ltrReason.Text = xmlHash.GetKeyFromHash(PunishField.Reason.ToString());

                int ilevel;
                int.TryParse(xmlHash.GetKeyFromHash(PunishField.IssuedLevel.ToString()), out ilevel);
                Role role = ServiceRepositoryHelper.RoleServiceHelper.GetByRoleId(ilevel);
                if (role != null)
                {
                    Literal ltrIssuedLevel = (Literal)e.Item.FindControl("ltrIssuedLevel");
                    ltrIssuedLevel.Text = role.Name;
                }


                Literal ltrAssigedDate = (Literal)e.Item.FindControl("ltrAssigedDate");
                ltrAssigedDate.Text = xmlHash.GetKeyFromHash(PunishField.AssigedDate.ToString());

                Literal ltrFromDate = (Literal)e.Item.FindControl("ltrFromDate");
                ltrFromDate.Text = xmlHash.GetKeyFromHash(PunishField.FromDate.ToString());

                Literal ltrToDate = (Literal)e.Item.FindControl("ltrToDate");
                ltrToDate.Text = xmlHash.GetKeyFromHash(PunishField.ToDate.ToString());


                Literal ltrComment = (Literal)e.Item.FindControl("ltrComment");
                ltrComment.Text = xmlHash.GetKeyFromHash(PunishField.Comment.ToString());

                Literal ltrLastUpdate = (Literal)e.Item.FindControl("ltrLastUpdate");
                ltrLastUpdate.Text = NumberHelper.GetValue<DateTime>(dataItem.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                HtmlAnchor lnkAttachFile = (HtmlAnchor)e.Item.FindControl("lnkAttachFile");
                lnkAttachFile.HRef = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, xmlHash.GetKeyFromHash(PunishField.AttachFileUrl.ToString()));
                lnkAttachFile.Title = xmlHash.GetKeyFromHash(PunishField.AttachFileName.ToString());
                lnkAttachFile.Visible = !string.IsNullOrEmpty(xmlHash.GetKeyFromHash(PunishField.AttachFileName.ToString()));


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
        }

        private void BindData()
        {
            TList<ResourceData> items = ServiceRepositoryHelper.ResourceDataServiceHelper.GetByResource(this.ItemId,ResourceType.Staff,ResourceDataContentType.StaffPunish);
            rptItems.DataSource = items;
            rptItems.DataBind();
        }
        #endregion
    }
}