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
    public class ProjectComboBox : RadComboBox
    {
        #region Properties
        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }

        public bool IsShowProjectNotFinished { get; set; }

        public bool IsShowActiveOnly { get; set; }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                int total;
                string whereClause = string.Format("[IsActive]={0} OR {0}=0",this.IsShowActiveOnly?"1":"0");
                TList<RLM.Construction.Entities.Project> items = ServiceRepository.ProjectService.GetPaged(whereClause, ProjectColumn.Name.ToString(), 0, 0, out total);

                if (this.IsShowAll)
                {
                    RLM.Construction.Entities.Project item = new RLM.Construction.Entities.Project() { Name = this.ShowAllText, ProjectId = this.ShowAllValue };
                    items.Insert(0, item);
                }
                this.DataTextField = ProjectColumn.Name.ToString();
                this.DataValueField = ProjectColumn.ProjectId.ToString();
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
