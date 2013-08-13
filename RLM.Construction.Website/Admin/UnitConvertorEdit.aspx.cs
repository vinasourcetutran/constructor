
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

public partial class UnitConvertorEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UnitConvertorEdit.aspx?{0}", UnitConvertorDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UnitConvertorEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "UnitConvertor.aspx");
		FormUtil.SetDefaultMode(FormView1, "FromUnitId");
	}

}


