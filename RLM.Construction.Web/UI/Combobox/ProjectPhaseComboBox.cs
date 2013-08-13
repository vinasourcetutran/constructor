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
    public class ProjectPhaseComboBox : RadComboBox
    {
        #region Properties
        public bool IsShowAll { get; set; }

        public string ShowAllText { get; set; }

        public int ShowAllValue { get; set; }

        public bool IsShowActiveOnly { get; set; }


        public int ProjectId { get; set; }
        #endregion

        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                Bind();
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        public void Bind()
        {
            string whereClause = string.Format(" [IsActive]=1 AND [Status] not in ({0},{1})", (int)ProjectPhaseStatus.Closed, (int)ProjectPhaseStatus.Finished);
            if (!this.IsShowActiveOnly)
            {
                whereClause = "";
            }

            if (this.ProjectId > 0)
            {
                whereClause = string.Format("[ProjectId]={0} {1}", this.ProjectId, string.IsNullOrEmpty(whereClause) ? "" : " AND " + whereClause);
            }
            BindToDataSource(whereClause);
        }
        public void  BindToDataSource(string whereClause)
        {
            int total;
            TList<ProjectPhase> items = ServiceRepository.ProjectPhaseService.GetPaged(whereClause, "[Name] ASC", 0, 0, out total);

            if (this.IsShowAll)
            {
                ProjectPhase item = new ProjectPhase() { Name = this.ShowAllText, ProjectPhaseId = this.ShowAllValue };
                items.Insert(0, item);
            }
            this.DataTextField = ProjectPhaseColumn.Name.ToString();
            this.DataValueField = ProjectPhaseColumn.ProjectPhaseId.ToString();
            this.DataSource = items;
            this.DataBind();
        }
        #endregion
    }
}
