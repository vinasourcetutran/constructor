using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Entities;
using RLM.Construction.ServiceHelpers;
using Telerik.Web.UI;
using RLM.Core.Framework.Log;

namespace RLM.Construction.Web.UI.Combobox
{
    public class RoleComboBox : RadComboBox
    {
        #region Variables
        bool isActiveOnly = true;
        #endregion
        #region Properties
        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }

        public RoleType RoleType { get; set; }

        
        public bool IsActiveOnly { get { return this.isActiveOnly; } set { this.isActiveOnly = true; } }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                TList<Role> items;
                items = ServiceRepositoryHelper.RoleServiceHelper.GetRoleByType(this.RoleType, this.isActiveOnly);
                if (this.IsShowAll)
                {
                    Role item = new Role() { Name = this.ShowAllText, RoleId= this.ShowAllValue };
                    items.Insert(0, item);
                }
                this.DataTextField = RoleColumn.Name.ToString();
                this.DataValueField = RoleColumn.RoleId.ToString();
                this.DataSource = items;
                this.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}
