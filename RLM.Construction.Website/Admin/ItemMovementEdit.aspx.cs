
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

public partial class ItemMovementEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ItemMovementEdit.aspx?{0}", ItemMovementDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ItemMovementEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ItemMovement.aspx");
		FormUtil.SetDefaultMode(FormView1, "RepositoryMovementId");
	}
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["RepositoryMovementId"] != null)
           {
               return string.Format("RepositoryMovementId='{0}'", Request.QueryString["RepositoryMovementId"].ToString());
           }
           return string.Empty;
       }
    }

}


