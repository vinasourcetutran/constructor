using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Log;

namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class StaffPunish : System.Web.UI.Page
    {
        #region Variables
        int staffId;
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(Request.Params["ItemId"], out this.staffId);
                if (this.staffId <= 0) { return; }
                staffPunishInfo.ItemId = this.staffId;
            }
            catch (Exception ex)
            {
                Utility.ShowMessage(RLM.Construction.Entities.ErrorType.Error, Resources.Common.GenericException, ex);
                Logger.Error(ex);
            }
        }
        #endregion
    }
}
