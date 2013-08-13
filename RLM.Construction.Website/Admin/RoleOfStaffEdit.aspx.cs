
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

public partial class RoleOfStaffEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "RoleOfStaffEdit.aspx?{0}", RoleOfStaffDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "RoleOfStaffEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "RoleOfStaff.aspx");
		FormUtil.SetDefaultMode(FormView1, "RoleOfStaffId");
	}
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["RoleOfStaffId"] != null)
           {
               return string.Format("RoleOfStaffId='{0}'", Request.QueryString["RoleOfStaffId"].ToString());
           }
           return string.Empty;
       }
    }

}


