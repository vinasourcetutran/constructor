
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

public partial class ContactorEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ContactorEdit.aspx?{0}", ContactorDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ContactorEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Contactor.aspx");
		FormUtil.SetDefaultMode(FormView1, "ContractId");
	}
	protected void GridViewItemInProject_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ItemInProjectId={0}", GridViewItemInProject.SelectedDataKey.Values[0]);
		Response.Redirect("ItemInProjectEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewProject_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProjectId={0}", GridViewProject.SelectedDataKey.Values[0]);
		Response.Redirect("ProjectEdit.aspx?" + urlParams, true);		
	}	
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["ContractId"] != null)
           {
               return string.Format("ContractId='{0}'", Request.QueryString["ContractId"].ToString());
           }
           return string.Empty;
       }
    }

}


