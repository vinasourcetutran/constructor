using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.Entities;

namespace RLM.Construction.WebApplication.Page.Item
{
    public partial class ItemOutputInfo : System.Web.UI.Page
    {
        #region Variables
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
            itemIO.ItemId = this.itemId;
        }

        private void LoadData()
        {
            int.TryParse(Request.Params["ItemId"], out this.itemId);
        }

        #endregion
    }
}
