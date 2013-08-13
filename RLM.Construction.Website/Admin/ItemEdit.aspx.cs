
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

public partial class ItemEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ItemEdit.aspx?{0}", ItemDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ItemEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Item.aspx");
		FormUtil.SetDefaultMode(FormView1, "ItemId");
	}
	protected void GridViewItemInProject_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ItemInProjectId={0}", GridViewItemInProject.SelectedDataKey.Values[0]);
		Response.Redirect("ItemInProjectEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewItemMovement_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("RepositoryMovementId={0}", GridViewItemMovement.SelectedDataKey.Values[0]);
		Response.Redirect("ItemMovementEdit.aspx?" + urlParams, true);		
	}	
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["ItemId"] != null)
           {
               return string.Format("ItemId='{0}'", Request.QueryString["ItemId"].ToString());
           }
           return string.Empty;
       }
    }

}


