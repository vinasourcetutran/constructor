using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using Telerik.Web.UI;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.Web.UI.Combobox
{
    public class GroupComboBox : RadComboBox
    {
        #region Properties
        public GroupType Type { get; set; }

        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }
        public bool IsActiveOnly { get; set; }
        public int ParentId { get; set; }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        public void ReBindData()
        {
            BindData();
        }
        #region Private
        private void BindData()
        {
            TList<Group> items = ServiceRepositoryHelper.GroupServiceHelper.GetByType(this.ParentId, this.Type, this.IsActiveOnly);

            if (this.IsShowAll)
            {
                Group item = new Group() { Name = this.ShowAllText, GroupId = this.ShowAllValue };
                items.Insert(0, item);
            }
            this.DataTextField = GroupColumn.Name.ToString();
            this.DataValueField = GroupColumn.GroupId.ToString();
            this.DataSource = items;
            this.DataBind();
        }
        #endregion
    }
}
