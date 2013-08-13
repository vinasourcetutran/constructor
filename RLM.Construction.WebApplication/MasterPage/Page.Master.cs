using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.WebApplication.CommonLib;
using System.Threading;

namespace RLM.Construction.WebApplication.MasterPage
{
    public partial class Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            try
            {
                BindError();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            RLMContext.ErrorType = RLM.Construction.Entities.ErrorType.None;
            RLMContext.ErrorMessage = string.Empty;
            RLMContext.Error = null;
        }

        private void BindError()
        {
            if (RLMContext.Error != null && RLMContext.Error is ThreadAbortException) { return; }
            if (RLMContext.ErrorType != RLM.Construction.Entities.ErrorType.None)
            {
                messageIcon.InnerHtml = RLMContext.ErrorMessage;
                messageIcon.Attributes.Add("class",RLMContext.ErrorType.ToString());
                messageBox.Visible = RLMContext.ErrorType != RLM.Construction.Entities.ErrorType.None;
            }
        }
    }
}
