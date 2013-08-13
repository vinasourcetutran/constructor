

#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RLM.Construction.Web.UI;
#endregion

public partial class UnitConvertor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "UnitConvertor.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
    }

	protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("FromUnitId={0}&ToUnitId={1}", GridView1.SelectedDataKey.Values[0], GridView1.SelectedDataKey.Values[1]);
		Response.Redirect("UnitConvertorEdit.aspx?" + urlParams, true);
	}
}


