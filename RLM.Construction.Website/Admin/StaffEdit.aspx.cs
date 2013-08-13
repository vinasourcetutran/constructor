
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

public partial class StaffEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "StaffEdit.aspx?{0}", StaffDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "StaffEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Staff.aspx");
		FormUtil.SetDefaultMode(FormView1, "StaffId");
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
           if (Request.QueryString["StaffId"] != null)
           {
               return string.Format("StaffId='{0}'", Request.QueryString["StaffId"].ToString());
           }
           return string.Empty;
       }
    }

}


