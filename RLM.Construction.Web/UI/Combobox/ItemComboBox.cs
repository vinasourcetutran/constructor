using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Web.UI;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using RLM.Core.Framework.Log;

namespace RLM.Construction.Web.UI.Combobox
{
    public class ItemComboBox : RadComboBox
    {
        #region Properties
        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }

        public bool IsShowActiveOnly { get; set; }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                int total;
                string whereClause = string.Format("[IsActive]=1 AND [Status] <> {0}", (int)ItemStatus.NotAvailabel);
                if (!this.IsShowActiveOnly)
                {
                    whereClause = "";
                }
                TList<Item> items = ServiceRepository.ItemService.GetPaged(whereClause, "[Name] ASC", 0, 0, out total);

                if (this.IsShowAll)
                {
                    Item item = new Item() { Name = this.ShowAllText, ItemId = this.ShowAllValue };
                    items.Insert(0, item);
                }
                this.DataTextField = ItemColumn.Name.ToString();
                this.DataValueField = ItemColumn.ItemId.ToString();
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
