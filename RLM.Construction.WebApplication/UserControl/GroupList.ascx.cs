using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using RLM.Core.Framework.Enum;
using RLM.Core.Framework.Log;
using Telerik.Web.UI;
using RLM.Construction.WebApplication.CommonLib;


namespace RLM.Construction.WebApplication.UserControl
{
    public partial class GroupList : System.Web.UI.UserControl
    {
        #region Properties
        public GroupType GroupType { get; set; }

        protected DataSourceItem<Group> DataSource
        {
            get
            {
                DataSourceItem<Group> items= GetGroupGromRepository();
                return items;
            }
        }

        public string EditPageUrl { get; set; }
        #endregion

        #region Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lnkAddNew.NavigateUrl = string.Format("~/Page/{0}/CategoryAddNew.aspx", this.GroupType.ToString());
                if (!string.IsNullOrEmpty(this.EditPageUrl))
                {
                    lnkAddNew.NavigateUrl = this.EditPageUrl;
                }
                if (IsPostBack) { return; }
                BindData();
            }
            catch (Exception ex)
            {
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
                Logger.Error(ex);
            }
        }

        protected void radGroupList_OnNeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radGroupList_OnItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != GridItemType.AlternatingItem && e.Item.ItemType != GridItemType.Item) { return; }
                Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                int id = (int)item.GetDataKeyValue("GroupId");

                // Edit group items
                if (e.CommandName == "Edit")
                {
                    string url = string.Format("~/Page/{0}/CategoryAddNew.aspx?ItemId={1}", this.GroupType.ToString(), id);
                    if (!string.IsNullOrEmpty(this.EditPageUrl))
                    {
                        url = string.Format(
                                "{0}?ItemId={1}",
                                this.EditPageUrl,
                                id
                            );
                    }
                    Response.Redirect(url,true);
                }
                // delete groupitem
                if (e.CommandName == "Delete")
                {
                    // delete selected item
                    ServiceRepository.GroupService.Delete(id);
                    // forece to reload data from db
                    //this.DataSource = null;
                    this.BindData();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Functions
        protected void BindData()
        {
            try
            {
                DataSourceItem<Group> dataSource = this.DataSource;
                radGroupList.DataSource = DataSource.Items;
                radGroupList.VirtualItemCount = dataSource.TotalItems;
                //radGroupList.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<Group> GetGroupGromRepository()
        {
            try
            {
                DataSourceItem<Group> item = new DataSourceItem<Group>(); ;
                int total;
                string whereClause = string.Format("[Type]={0}",(int)this.GroupType);
                item.Items = ServiceRepository.GroupService.GetPaged(whereClause,"[LastModificationDate] DESC",0,0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<Group>();
            }
        }
        #endregion
    }
}