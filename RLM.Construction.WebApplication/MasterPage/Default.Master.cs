using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;

namespace RLM.Construction.WebApplication.MasterPage
{
    public partial class Default : ContructionDefaultMasterPage
    {
        #region Override
        public override string PageTitle
        {
            get
            {
                return base.PageTitle;
            }
            set
            {
                base.PageTitle = value;
            }
        }

        public override string Description
        {
            get
            {
                return base.Description;
            }
            set
            {
                base.Description = value;
            }
        }
        #endregion
    }
}
