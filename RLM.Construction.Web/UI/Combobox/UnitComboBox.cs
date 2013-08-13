using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using Telerik.Web.UI;

namespace RLM.Construction.Web.UI.Combobox
{
    public class UnitComboBox : RadComboBox
    {
        #region Properties
        public RLM.Construction.Entities.UnitType Type { get; set; }

        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }

        public bool IsLoadAll { get; set; }

        bool isActiveOnly = true;
        public bool IsActiveOnly { get { return this.isActiveOnly; } set { this.isActiveOnly = value; } }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                TList<RLM.Construction.Entities.Unit> items;
                if (this.IsLoadAll)
                {
                    int total;
                    string whereClause = string.Format(" ([IsActive]={0} OR {0}=0)", this.isActiveOnly ? "1" : "0");
                    items = ServiceRepository.UnitService.GetPaged(whereClause, UnitColumn.Name.ToString(), 0, 0, out total);
                }
                else
                {
                    items = ServiceRepository.UnitService.GetByType(this.Type, this.IsActiveOnly);
                }

                if (this.IsShowAll)
                {
                    RLM.Construction.Entities.Unit item = new RLM.Construction.Entities.Unit() { Name = this.ShowAllText, UnitId = this.ShowAllValue };
                    items.Insert(0, item);
                }
                this.DataTextField = UnitColumn.Name.ToString();
                this.DataValueField = UnitColumn.UnitId.ToString();
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
