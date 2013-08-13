
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

public partial class UserEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UserEdit.aspx?{0}", UserDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UserEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "User.aspx");
		FormUtil.SetDefaultMode(FormView1, "UserId");
	}
	protected void GridViewStaff_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("StaffId={0}", GridViewStaff.SelectedDataKey.Values[0]);
		Response.Redirect("StaffEdit.aspx?" + urlParams, true);		
	}	
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["UserId"] != null)
           {
               return string.Format("UserId='{0}'", Request.QueryString["UserId"].ToString());
           }
           return string.Empty;
       }
    }

}


