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
using RLM.Core.Framework.Utility;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.Item
{
    public partial class ItemDetailInfo : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Item item;
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
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }

            lblCode.Text = item.Code;
            lblName.Text = this.item.Name;
            ltrDescription.Text = this.item.Description;
            spActive.Attributes.Add("class", NumberHelper.GetValue<bool>(item.IsActive) ? "OK" : "NotOK");
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
            Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(item.GroupId));
            if (group != null)
            {
                lblGroup.ToolTip = lblGroup.Text = group.Name;
            }

            RLM.Construction.Entities.Unit baseUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.BaseUnitId));
            if (baseUnit != null)
            {
                lblBaseUnit.ToolTip = lblBaseUnit.Text = baseUnit.Name;
            }

            RLM.Construction.Entities.Unit usedUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.UsedUnitId));
            if (usedUnit != null)
            {
                lblUsedUnit.ToolTip = lblUsedUnit.Text = usedUnit.Name;
            }

            lnkItemFullPhoto.Title = itemPhoto.AlternateText = this.item.Name;
            itemPhoto.ImageUrl = UrlBuilderHelper.GetUrl(this.item, NavigateAction.Thumnail);
            lnkItemFullPhoto.HRef = UrlBuilderHelper.GetUrl(this.item, NavigateAction.Big);
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ItemService.GetByItemId(this.itemId);
        }

        #endregion
    }
}
