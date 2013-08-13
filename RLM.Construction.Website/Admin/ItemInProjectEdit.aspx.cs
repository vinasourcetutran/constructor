
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

public partial class ItemInProjectEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ItemInProjectEdit.aspx?{0}", ItemInProjectDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ItemInProjectEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ItemInProject.aspx");
		FormUtil.SetDefaultMode(FormView1, "ItemInProjectId");
	}
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["ItemInProjectId"] != null)
           {
               return string.Format("ItemInProjectId='{0}'", Request.QueryString["ItemInProjectId"].ToString());
           }
           return string.Empty;
       }
    }

}


