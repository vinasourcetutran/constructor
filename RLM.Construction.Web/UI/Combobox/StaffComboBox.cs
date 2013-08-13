using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Web.UI;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Log;

namespace RLM.Construction.Web.UI.Combobox
{
    public class StaffComboBox : RadComboBox
    {
        #region Properties
        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                TList<Staff> items;
                items = ServiceRepositoryHelper.StaffServiceHelper.GetAll();
                if (this.IsShowAll)
                {
                    Staff item = new Staff() { FirstName = this.ShowAllText,LastName=string.Empty, StaffId = this.ShowAllValue };
                    items.Insert(0, item);
                }
                this.DataTextField = "FullName";
                this.DataValueField = StaffColumn.StaffId.ToString();
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
