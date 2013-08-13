
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

public partial class GroupEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "GroupEdit.aspx?{0}", GroupDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "GroupEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Group.aspx");
		FormUtil.SetDefaultMode(FormView1, "GroupId");
	}
	protected void GridViewContract_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ContractId={0}", GridViewContract.SelectedDataKey.Values[0]);
		Response.Redirect("ContractEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewProject_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProjectId={0}", GridViewProject.SelectedDataKey.Values[0]);
		Response.Redirect("ProjectEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewItem_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ItemId={0}", GridViewItem.SelectedDataKey.Values[0]);
		Response.Redirect("ItemEdit.aspx?" + urlParams, true);		
	}	
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["GroupId"] != null)
           {
               return string.Format("GroupId='{0}'", Request.QueryString["GroupId"].ToString());
           }
           return string.Empty;
       }
    }

}


