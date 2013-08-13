
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

public partial class ProjectEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ProjectEdit.aspx?{0}", ProjectDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ProjectEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Project.aspx");
		FormUtil.SetDefaultMode(FormView1, "ProjectId");
	}
	protected void GridViewItemInProject_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ItemInProjectId={0}", GridViewItemInProject.SelectedDataKey.Values[0]);
		Response.Redirect("ItemInProjectEdit.aspx?" + urlParams, true);		
	}	
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["ProjectId"] != null)
           {
               return string.Format("ProjectId='{0}'", Request.QueryString["ProjectId"].ToString());
           }
           return string.Empty;
       }
    }

}


