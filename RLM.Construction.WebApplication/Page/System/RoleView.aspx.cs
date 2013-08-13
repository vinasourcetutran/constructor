using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using RLM.Core.Framework.Log;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.Entities;
using RLM.Core.Framework.Utility;
using RLM.Configuration;
using RLM.Construction.Services;

namespace RLM.Construction.WebApplication.Page.Partner
{
    public partial class RoleView : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Role item;
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
            Response.Redirect(UrlBuilderHelper.GetUrl(new Role(), NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }

            lblName.Text = this.item.Name;
            lblCode.Text = this.item.Code;
            lblType.Text =Utility.GetEnumValue<RoleType>((RoleType)NumberHelper.GetValue<int>(this.item.Type));
            spIsActive.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsActive) ? "OK" : "NotOK");
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.RoleService.GetByRoleId(this.itemId);
        }
        #endregion
    }
}
