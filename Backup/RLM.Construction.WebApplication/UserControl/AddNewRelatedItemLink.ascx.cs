using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Entities;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.WebApplication.UserControl
{
    public partial class AddNewRelatedItemLink : System.Web.UI.UserControl
    {
        #region Variables
        string cssClass = "AddItem Padding15 CenterBackground Margin3";
        bool isShowText = true;
        #endregion

        #region Properties
        public bool IsShowText
        {
            get { return this.isShowText; }
            set { this.isShowText = value; }
        }

        public string CssClass
        {
            get { return this.cssClass; }
            set { this.cssClass = value; }
        }
        public string OnClick { get; set; }

        public string TabId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }

        public int ResourceId { get; set; }

        public ResourceType ResourceType { get; set; }

        public NavigateAction Action { get; set; }

        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                if (this.ResourceId > 0)
                {
                    this.Text = this.Title = string.Format("{0}: {1}", this.ResourceType.ToString(), Utility.GetResourceName(this.ResourceType, this.ResourceId));
                    this.Url = UrlBuilderHelper.GetUrl(this.ResourceType, this.ResourceId, this.Action);
                }
                else
                {
                    this.Url =!string.IsNullOrEmpty(this.Url)?this.Url: UrlBuilderHelper.GetUrl(this.ResourceType, this.ResourceId, NavigateAction.ClientAddNew);
                    this.Text = this.Title = string.Format("{0}: {1}", this.ResourceType.ToString(), Resources.Common.AddNew);
                    this.cssClass =string.IsNullOrEmpty(cssClass)?"AddItem":cssClass;
                }
                
                
                this.TabId = string.Format("{0}_{1}", this.ResourceType.ToString(), this.Action.ToString());

                if (string.IsNullOrEmpty(this.OnClick))
                {
                    this.OnClick = "InnerPageHelper.addPageFromDOM($(this));return false;";
                }
                lnkAddNew.Attributes.Add("class", this.CssClass + " HoverUnderline");
                lnkAddNew.Attributes.Add("onclick", this.OnClick);
                lnkAddNew.Attributes.Add("tabid", this.TabId);
                lnkAddNew.Attributes.Add("url",this.Url);
                lnkAddNew.HRef=this.Url;
                lnkAddNew.Attributes.Add("title", this.Title);
                lnkAddNew.InnerHtml = this.isShowText ? this.Text : string.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}