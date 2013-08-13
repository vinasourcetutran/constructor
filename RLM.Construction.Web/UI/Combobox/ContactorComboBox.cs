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
    public class ContactorComboBox : RadComboBox
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
                int total;
                TList<Contactor> items = ServiceRepository.ContactorService.GetPaged("", "[Name] ASC", 0, 0, out total);

                if (this.IsShowAll)
                {
                    Contactor item = new Contactor() { Name = this.ShowAllText, ContactorId = this.ShowAllValue };
                    items.Insert(0, item);
                }
                this.DataTextField = ContactorColumn.Name.ToString();
                this.DataValueField = ContactorColumn.ContactorId.ToString();
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
