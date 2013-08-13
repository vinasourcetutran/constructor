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
using Microsoft.Practices.EnterpriseLibrary.Data;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.ServiceHelpers;
using RLM.Construction.Web.UI.Combobox;
using RLM.Construction.WebApplication.UserControl;
using RLM.Core.Framework.Utility;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class StaffList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Staff> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Staff> items = GetItemFromRepository();
                return items;
            }
        }
        #endregion

        #region Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void radItems_OnNeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericLoaDataSourceException;
            }
        }

        protected void radItems_OnItemDataBound(object source, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != GridItemType.AlternatingItem && e.Item.ItemType != GridItemType.Item) { return; }
                RLM.Construction.Entities.Staff dataItem = (RLM.Construction.Entities.Staff)e.Item.DataItem;


                Image imgPhoto = (Image)e.Item.FindControl("imgPhoto");
                imgPhoto.AlternateText = dataItem.FullName;
                imgPhoto.ImageUrl = UrlBuilderHelper.GetUrl(dataItem, NavigateAction.Thumnail);

                Group department = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(dataItem.DeptId));
                if (department != null)
                {
                    Literal ltrDeptName = (Literal)e.Item.FindControl("ltrDeptName");
                    ltrDeptName.Text = department.Name;
                }
                Role jobTitle = ServiceRepositoryHelper.RoleServiceHelper.GetByRoleId(NumberHelper.GetValue<int>(dataItem.JobTitleId));
                if (jobTitle != null)
                {
                    Literal ltrJobTitleName = (Literal)e.Item.FindControl("ltrJobTitleName");
                    ltrJobTitleName.Text = jobTitle.Name;
                }

                Literal ltrSex = (Literal)e.Item.FindControl("ltrSex");
                ltrSex.Text = Utility.GetEnumValue<SexType>((SexType)NumberHelper.GetValue<int>(dataItem.Sex));

                Literal ltrStartWorkingDate = (Literal)e.Item.FindControl("ltrStartWorkingDate");
                ltrStartWorkingDate.Text = NumberHelper.GetValue<DateTime>(dataItem.WorkingDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);


                AddNewRelatedItemLink lnkPreview = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreview");
                lnkPreview.ResourceId = dataItem.StaffId;

                AddNewRelatedItemLink lnkEdit = (AddNewRelatedItemLink)e.Item.FindControl("lnkEdit");
                lnkEdit.ResourceId = dataItem.StaffId;
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
                DataSourceItem<RLM.Construction.Entities.Staff> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                //radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Staff> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Staff> item = new DataSourceItem<RLM.Construction.Entities.Staff>(); ;
                item.Items = ServiceRepositoryHelper.StaffServiceHelper.GetAll();
                item.TotalItems = item.Items.Count;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Staff>();
            }
        }
        #endregion
    }
}
