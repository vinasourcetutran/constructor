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
    public class ContractComboBox : RadComboBox
    {
        #region Properties
        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }

        public bool ShowContractHaveNoProjectOnly { get; set; }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                TList<Contract> items;
                if (!this.ShowContractHaveNoProjectOnly)
                {
                    items = ServiceRepository.ContractService.GetAll();
                }
                else
                {
                    int total;
                    items = ServiceRepository.ContractService.GetContractHaveNoProjectPaged("", ContractColumn.Name.ToString(), 0, 0, out total);
                }

                if (this.IsShowAll)
                {
                    Contract item = new Contract() { Name = this.ShowAllText, ContractId = this.ShowAllValue };
                    items.Insert(0, item);
                }
                this.DataTextField = ContractColumn.Name.ToString();
                this.DataValueField = ContractColumn.ContractId.ToString();
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
