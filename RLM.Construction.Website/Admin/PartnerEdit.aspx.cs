
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RLM.Construction.Web.UI;
#endregion

public partial class PartnerEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "PartnerEdit.aspx?{0}", PartnerDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "PartnerEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Partner.aspx");
		FormUtil.SetDefaultMode(FormView1, "PartnerId");
	}
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["PartnerId"] != null)
           {
               return string.Format("PartnerId='{0}'", Request.QueryString["PartnerId"].ToString());
           }
           return string.Empty;
       }
    }

}


