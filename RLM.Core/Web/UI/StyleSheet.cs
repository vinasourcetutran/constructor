using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Design;

namespace RLM.Core.Web.UI
{
    [DefaultProperty("Text"), ToolboxData("<{0}:StyleSheet runat=server></{0}:StyleSheet>")]
    public class StyleSheet : WebControl
    {

        #region  Construct
        public StyleSheet()
            : base("link")
        {
            base.Attributes["rel"] = "stylesheet";
            base.Attributes["type"] = "text/css";
            this.EnableViewState = false;
        }
        #endregion

        #region Properties
        [DefaultValue(""), Bindable(true), Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), UrlProperty]
        public string Href
        {
            get
            {
                return base.Attributes["href"];
            }
            set
            {
                base.Attributes["href"] = value;
            }
        }
        #endregion

        #region Render methods
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.Href != null)
            {
                this.Href = base.ResolveUrl(this.Href);
            }
            writer.WriteBeginTag(this.TagName);
            foreach (string str in base.Attributes.Keys)
            {
                writer.WriteAttribute(str, base.Attributes[str]);
            }
            writer.Write(" />");
        }
        #endregion
    }
}
