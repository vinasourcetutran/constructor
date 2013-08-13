
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

public partial class AttachFileEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AttachFileEdit.aspx?{0}", AttachFileDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AttachFileEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AttachFile.aspx");
		FormUtil.SetDefaultMode(FormView1, "AttachFileId");
	}
    public String WhereClause
    {
       get 
       {
           if (Request.QueryString["AttachFileId"] != null)
           {
               return string.Format("AttachFileId='{0}'", Request.QueryString["AttachFileId"].ToString());
           }
           return string.Empty;
       }
    }

}


