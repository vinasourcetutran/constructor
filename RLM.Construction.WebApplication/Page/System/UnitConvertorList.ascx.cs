using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Construction.ServiceHelpers;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Utility;
using System.Web.UI.HtmlControls;
using RLM.Configuration;
using RLM.Construction.Entities;

namespace RLM.Construction.WebApplication.Page.SystemSetting
{
    public partial class UnitConvertorList : System.Web.UI.UserControl
    {
        #region Properties
        public int FromUnitId { get; set; }
        public int ToUnitId { get; set; }
        public bool IsAllowEdit { get; set; }
        public DateTime FromEffectDate { get; set; }
        public DateTime ToEffectDate { get; set; }
        public RLM.Construction.Entities.UnitType Type { get; set; }

        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (this.IsAllowEdit)
                //{
                lnkAddNew.Visible = this.IsAllowEdit; ;
                lnkAddNew.NavigateUrl = UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.UnitConvertor(){FromUnitId=this.FromUnitId}, NavigateAction.AddNew);
                //}
                
                if (IsPostBack) { return; }
                BindItems();
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
                RLM.Construction.Entities.UnitConvertor itemData = (RLM.Construction.Entities.UnitConvertor)e.Item.DataItem;
                RLM.Construction.Entities.Unit toUnit=ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(itemData.ToUnitId);
                RLM.Construction.Entities.Unit fromUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(itemData.FromUnitId);

                if (toUnit == null) { return; }

                Literal ltrFromUnitName = (Literal)e.Item.FindControl("ltrFromUnitName");
                ltrFromUnitName.Text = string.Format("{0} ({1})", fromUnit.Name, Utility.GetEnumValue<RLM.Construction.Entities.UnitType>((RLM.Construction.Entities.UnitType)NumberHelper.GetValue<int>(fromUnit.Type)));

                Literal ltrToUnitName = (Literal)e.Item.FindControl("ltrToUnitName");
                ltrToUnitName.Text = string.Format("{0} ({1})", toUnit.Name, Utility.GetEnumValue<RLM.Construction.Entities.UnitType>((RLM.Construction.Entities.UnitType)NumberHelper.GetValue<int>(toUnit.Type)));
                //ltrName.Text = string.Format("{0} ({1})", toUnit.Name, toUnit.Description);

                //Literal ltrType = (Literal)e.Item.FindControl("ltrType");
                //ltrType.Text = Utility.GetEnumValue< RLM.Construction.Entities.UnitType>((RLM.Construction.Entities.UnitType)NumberHelper.GetValue<int>(toUnit.Type));

                Literal ltrQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                ltrQuantity.Text = NumberHelper.GetValue<double>(itemData.Quantity).ToString();

                HtmlGenericControl spIsActive = (HtmlGenericControl)e.Item.FindControl("spIsActive");
                spIsActive.Attributes.Add("class", NumberHelper.GetValue<bool>(itemData.IsActive)?"OK":"NotOK");

                Literal ltrEffectFrom = (Literal)e.Item.FindControl("ltrEffectFrom");
                ltrEffectFrom.Text = NumberHelper.GetValue<DateTime>(itemData.EffectFrom).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

                Literal ltrLastModificationDate = (Literal)e.Item.FindControl("ltrLastModificationDate");
                ltrLastModificationDate.Text = NumberHelper.GetValue<DateTime>(itemData.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                if (!this.IsAllowEdit || NumberHelper.GetValue<DateTime>(itemData.EffectFrom)<=DateTime.Now) { return; }

                HtmlAnchor lnkEdit = (HtmlAnchor)e.Item.FindControl("lnkEdit");
                lnkEdit.HRef = UrlBuilderHelper.GetUrl(itemData, NavigateAction.Edit);
                lnkEdit.Visible = this.IsAllowEdit;
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
                TList<RLM.Construction.Entities.UnitConvertor> items = null;
                if (this.FromUnitId > 0)
                {
                    items = ServiceRepositoryHelper.UnitConvertorServiceHelper.GetListByFromUnitId(this.FromUnitId);
                }
                if (this.ToUnitId > 0)
                {
                    items = ServiceRepositoryHelper.UnitConvertorServiceHelper.GetListByToUnitId(this.ToUnitId);
                }
                if (FromEffectDate != DateTime.MinValue && ToEffectDate != DateTime.MinValue && FromEffectDate <= ToEffectDate)
                {
                    ToEffectDate = FromEffectDate == ToEffectDate ? DateTime.Now : ToEffectDate;
                    items = ServiceRepositoryHelper.UnitConvertorServiceHelper.GetListByEffectDate(this.FromEffectDate,this.ToEffectDate, this.Type);
                }
                rptItems.DataSource = items;
                rptItems.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}