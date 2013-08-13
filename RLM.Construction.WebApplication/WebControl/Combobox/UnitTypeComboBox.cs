using System;
using System.Collections.Generic;

using System.Web;
using Telerik.Web.UI;
using RLM.Construction.Entities;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Log;

namespace RLM.Construction.WebApplication.WebControl.Combobox
{
    public class UnitTypeComboBox : GenericEnumCombobox<UnitType>
    {
        //#region Properties
        //public bool IsShowAll { get; set; }

        //public string ShowAllText { get; set; }

        //public string ShowAllValue { get; set; }

        //public bool IsBounded { get; set; }
        //#endregion

        //#region Event
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    try
        //    {
        //        this.DataValueField = "Value";
        //        this.DataTextField = "Name";
        //        TList<EnumPair> items = Utility.GetEnumToList<UnitType>(false);
        //        if (this.IsShowAll)
        //        {
        //            EnumPair item = new EnumPair() { Name = this.ShowAllText, Value = this.ShowAllValue };
        //            items.Insert(0, item);
        //        }

        //        this.DataSource = items;
        //        if (!this.IsBounded)
        //        {
        //            this.DataBind();
        //            this.IsBounded = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex);
        //    }
        //}
        //#endregion
    }
}
