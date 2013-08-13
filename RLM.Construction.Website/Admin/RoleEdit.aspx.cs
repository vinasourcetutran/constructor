
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

public partial class RoleEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "RoleEdit.aspx?{0}", RoleDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "RoleEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Role.aspx");
		FormUtil.SetDefaultMode(FormView1, "RoleId");
	}
	protected void GridViewRoleOfStaff_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("RoleOfStaffId={0}", GridViewRoleOfStaff.SelectedDataKey.Values[0]);
		Response.Redirect("RoleOfStaffEdit.aspx?" + urlParams, true);		
	}	
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["RoleId"] != null)
           {
               return string.Format("RoleId='{0}'", Request.QueryString["RoleId"].ToString());
           }
           return string.Empty;
       }
    }

}


