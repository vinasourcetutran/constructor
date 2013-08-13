
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

public partial class UserGroupEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UserGroupEdit.aspx?{0}", UserGroupDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UserGroupEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "UserGroup.aspx");
		FormUtil.SetDefaultMode(FormView1, "UserGroupId");
	}
	protected void GridViewUser_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("UserId={0}", GridViewUser.SelectedDataKey.Values[0]);
		Response.Redirect("UserEdit.aspx?" + urlParams, true);		
	}	
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["UserGroupId"] != null)
           {
               return string.Format("UserGroupId='{0}'", Request.QueryString["UserGroupId"].ToString());
           }
           return string.Empty;
       }
    }

}


