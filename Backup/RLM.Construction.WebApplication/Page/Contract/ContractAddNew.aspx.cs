using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Core.Web.UI;
using RLM.Core.Web.UI.Notifier;
using RLM.Construction.Entities;
using RLM.Configuration;
using RLM.Construction.WebApplication.CommonLib;
using System.IO;
using RLM.Core.Framework.Utility;
using System.Threading;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.Contract
{
    public partial class ContractAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Contract item;
        int itemId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //radFromDate.Attributes.Add("onchange","alert('test')");
                radFromDate.Attributes.Add("onchange", string.Format("DateTimeHelper.addDays('{0}','{1}',parseInt($('#{2}').val()));return true;", radFromDate.ClientID, radToDate.ClientID, txtTotalDays.ClientID));
                radRealFromDate.Attributes.Add("onchange", string.Format("DateTimeHelper.addDays('{0}','{1}',parseInt($('#{2}').val()));return true;", radRealFromDate.ClientID, radRealToDate.ClientID, txtRealTotalDays.ClientID));

                radToDate.Attributes.Add("onchange", string.Format("parseInt($('#{2}').val(DateTimeHelper.getNumberOfDays('{0}','{1}')));", radFromDate.ClientID, radToDate.ClientID, txtTotalDays.ClientID));
                radRealToDate.Attributes.Add("onchange", string.Format("parseInt($('#{2}').val(DateTimeHelper.getNumberOfDays('{0}','{1}')));", radRealFromDate.ClientID, radRealToDate.ClientID, txtRealTotalDays.ClientID));

                txtRealTotalDays.Attributes.Add("onkeyup", string.Format("DateTimeHelper.addDays('{0}','{1}',parseInt(this.value));", radRealFromDate.ClientID, radRealToDate.ClientID));
                txtTotalDays.Attributes.Add("onkeyup", string.Format("DateTimeHelper.addDays('{0}','{1}',parseInt(this.value));", radFromDate.ClientID, radToDate.ClientID));
                lnkSelectPartner.HRef = Page.ResolveUrl("~/Page/Partner/ItemList.aspx?width=970&height=500&IsPopup=true&KeepThis=true&TB_iframe=true");   
                txtCode.Text = Utility.GetNewContractCode();
                Validation();
                LoadData();
                //radToDate.SelectedDate = radFromDate.SelectedDate = radRealFromDate.SelectedDate = radRealToDate.SelectedDate = DateTime.Now;
                //drpType.SelectedValue = 
                
                if (!this.IsPostBack)
                {
                    drpUnit.SelectedValue = RLMConfiguration.Setting.VndUnitId.ToString();
                    radFromDate.SelectedDate = radRealFromDate.SelectedDate = DateTime.Now;
                    BindGuid();
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;   
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                Save();
                Response.Redirect("~/Page/Contract/ContractList.aspx", true);
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Contract/ContractList.aspx", true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.Contract();
                this.item.CreationDate = DateTime.Now;
                this.item.SignedDate = this.item.FromDate = this.item.ToDate = this.item.RealFromDate = this.item.RealToDate = DateTime.Now.AddYears(-2);
                this.item.Type = int.Parse(drpType.SelectedValue);
            }
            this.item.LastModificationDate = DateTime.Now;

            this.item.Number = Request.Params[txtContractNumber.UniqueID];
            this.item.Code = txtCode.Text;// Request.Params[txtCode.UniqueID];
            this.item.Name = Request.Params[txtName.UniqueID];
            //this.item.FromContactorId = int.Parse(drpFromContactor.SelectedValue);
            this.item.ToContactorId = int.Parse(drpToContactor.SelectedValue);
            this.item.FromContactName = Request.Params[txtFromRepresentative.UniqueID];
            this.item.ToContactName = Request.Params[txtContractRepresentative.UniqueID];
            this.item.Description = Request.Params[txtDescription.UniqueID];

            this.item.Days = int.Parse(StringHelper.Replace("([,.]*)", "", Request.Params[txtTotalDays.UniqueID]));
            this.item.RealDays = int.Parse(StringHelper.Replace("([,.]*)", "", Request.Params[txtRealTotalDays.UniqueID]));
            this.item.InitPrice = decimal.Parse(Request.Params[txtFirstPrice.UniqueID]);
            this.item.LastPrice = decimal.Parse(Request.Params[txtLastPrice.UniqueID]);
            this.item.ExchangeRate = int.Parse(StringHelper.Replace("([,.]*)","", Request.Params[txtExchangRate.UniqueID]));

            this.item.VATTax = double.Parse(Request.Params[txtVAT.UniqueID]);
            this.item.PITTax = double.Parse(Request.Params[txtPITTax.UniqueID]);
            this.item.CITTax = double.Parse(Request.Params[txtCITTax.UniqueID]);

            this.item.FromDate = radFromDate.SelectedDate;
            this.item.ToDate = radToDate.SelectedDate;
            this.item.RealToDate = radRealToDate.SelectedDate;
            this.item.SignedDate = radSignedDate.SelectedDate;
            this.item.RealFromDate = radRealFromDate.SelectedDate;
            item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            item.IsApprove = Request.Params[chkIsApprove.UniqueID] != null;

            int parentId;
            if (int.TryParse(drpGroup.SelectedValue, out parentId))
            {
                this.item.GroupId = parentId;
            }

            if (int.TryParse(drpConstruct.SelectedValue, out parentId))
            {
                this.item.ConstructDeptId = parentId;
            }

            if (int.TryParse(drpDesign.SelectedValue, out parentId))
            {
                this.item.DesignDeptId = parentId;
            }

            if (int.TryParse(drpStatus.SelectedValue, out parentId))
            {
                this.item.Status = parentId;
            }
            if (int.TryParse(drpUnit.SelectedValue, out parentId))
            {
                this.item.CurrencyUnitId = parentId;
            }

            //if (int.TryParse(drpPartner.SelectedValue, out parentId))
            //{
            //    this.item.PartnerId = parentId;
            //}

            if (int.TryParse(hddContractPartnerId.Value, out parentId))
            {
                this.item.PartnerId = parentId;
            }
            if (this.item.ContractId > 0)
            {
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ContractId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ContractService.Update(this.item);
            }
            else
            {
                ServiceRepository.ContractService.Insert(this.item);
                Utility.UpdateNewContractCode();
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ContractId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ContractService.Update(this.item);

                if (this.item.Type == (int)ContractType.Electromechanical)
                {
                    CreateProjectForContract(this.item);
                }
            }
            //if (contractFile.PostedFile != null && !string.IsNullOrEmpty(contractFile.PostedFile.FileName.Trim()) && contractFile.PostedFile.ContentLength > 0)
            //{
            //    Utility.UploadFile(contractFile.PostedFile, this.item.ContractId, AttachFileResourceType.Contract,false);
            //    //UploadFile();
            //}
        }

        private void CreateProjectForContract(Entities.Contract contract)
        {
            RLM.Construction.Entities.Project item = new Entities.Project();
            item.ContractId = contract.ContractId;
            item.GroupId = RLMConfiguration.Setting.DefaultProjectGroupId;

            item.CreationDate = DateTime.Now;
            item.CreationUserId = Utility.GetCurrentUserId();
            item.IsApprove = true;

            item.LastModificationDate = DateTime.Now;
            item.LastModificationUserId = Utility.GetCurrentUserId();


            item.Code = string.Empty;
            item.Name = contract.Name;
            item.DesignedPrice = contract.InitPrice;
            item.AuctualPrice = contract.LastPrice;
            item.ExchangeRate = contract.ExchangeRate;
            item.CurrencyUnitId = contract.CurrencyUnitId;

            item.Description = contract.Description;
            item.IsActive = true;

            ServiceRepository.ProjectService.Insert(item);
            if (string.IsNullOrEmpty(item.Code)) { item.Code = item.ProjectId.ToString().PadLeft(5, '0'); }
            ServiceRepository.ProjectService.Update(item);
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            Logger.Info(this.item.ProjectCollection.Count);
            drpType.Enabled = false;
            btnCancel.Visible = true;
            files.Visible = true;
            files.ResourceId = this.itemId;
            files.PageTitle = this.item.Name;
            files.ResourceType = ResourceType.Contract;

            txtContractNumber.Text = this.item.Number;
            txtCode.Text = item.Code;
            txtName.Text = this.item.Name;
            txtTotalDays.Text = this.item.Days.ToString();
            txtRealTotalDays.Text = this.item.RealDays.ToString();
            txtExchangRate.Text = NumberHelper.GetValue<int>(this.item.ExchangeRate).ToString();
            //drpFromContactor.SelectedValue = NumberHelper.GetValue<int>(this.item.FromContactorId).ToString();
            drpToContactor.SelectedValue = NumberHelper.GetValue<int>(this.item.ToContactorId).ToString();
            txtContractRepresentative.Text = this.item.ToContactName;
            txtFromRepresentative.Text = this.item.FromContactName;
            int partnerId = NumberHelper.GetValue<int>(this.item.PartnerId);
            hddContractPartnerId.Value = partnerId.ToString();
            RLM.Construction.Entities.Partner partner = ServiceRepositoryHelper.PartnerServiceHelper.GetByPartnerId(partnerId);
            if (partner != null)
            {
                lblPartnerName.InnerHtml = partner.Name;
            }

            txtDescription.Text = this.item.Description;
            drpType.SelectedValue = NumberHelper.GetValue<int>(this.item.Type).ToString();
            chkIsActive.Checked = (bool)this.item.IsActive;
            chkIsApprove.Checked = (bool)this.item.IsApprove;
            //chkIsActive.Enabled = chkIsApprove.Enabled = !(bool)this.item.IsApprove;
            chkIsApprove.Visible = true;
            spIsApprove.Visible = false;
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
            drpGroup.SelectedValue = ((int)this.item.GroupId).ToString();
            drpConstruct.SelectedValue = this.item.ConstructDeptId.Value.ToString();
            drpDesign.SelectedValue = this.item.DesignDeptId.Value.ToString();
            //drpPartner.SelectedValue = ((int)this.item.PartnerId).ToString();
            drpUnit.SelectedValue=NumberHelper.GetValue<int>(this.item.CurrencyUnitId).ToString();
            //drpPartner.SelectedValue = this.item.pa.Value.ToString();
            drpStatus.SelectedValue = ((int)this.item.Status).ToString();
            txtFirstPrice.Text = this.item.InitPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);
            txtLastPrice.Text = this.item.LastPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);
            txtVAT.Text =NumberHelper.GetValue<double>(this.item.VATTax).ToString();
            txtPITTax.Text =NumberHelper.GetValue<double>(this.item.PITTax).ToString();
            txtCITTax.Text = NumberHelper.GetValue<double>(this.item.CITTax).ToString();
            if (this.item.FromDate.HasValue)
            {
                radFromDate.SelectedDate = this.item.FromDate;
            }
            if (this.item.ToDate.HasValue)
            {
                radToDate.SelectedDate = this.item.ToDate;
            }
            if (this.item.RealFromDate.HasValue)
            {
                radRealFromDate.SelectedDate = NumberHelper.GetValue<DateTime>(this.item.RealFromDate);
            }
            if (this.item.RealToDate.HasValue)
            {
                radRealToDate.SelectedDate = NumberHelper.GetValue<DateTime>(this.item.RealToDate);
            }
            if (this.item.SignedDate.HasValue)
            {
                radSignedDate.SelectedDate = this.item.SignedDate;
            }

            //RLM.Construction.Entities.AttachFile attachFile = ServiceRepository.AttachFileService.GetItemByResourceIdAndType(this.item.ContractId, AttachFileResourceType.Contract);
            //Utility.SetFileUpLoadControl(lnkContractFile, this.item.ContractId, AttachFileResourceType.Contract);

            RLM.Construction.Entities.Project project = ServiceRepository.ProjectService.GetItemByContractId(this.item.ContractId);
            lnkAddNewProject.Url = string.Format("Page/Project/ProjectAddNew.aspx?ContractId={0}", this.item.ContractId);
            if (project != null)
            {
                lnkProject.InnerHtml = lnkProject.Title = project.Name;
                lnkProject.HRef = string.Format("~/Page/Project/ProjectAddNew.aspx?itemid={0}", project.ProjectId);
                lnkAddNewProject.Visible = false;
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ContractService.GetByContractId(this.itemId);
        }

        private void Validation()
        {
            //validationManager.AddRule(
            //   new PatternMatchedRule(
            //       drpPartner,
            //       Resources.ValidationRule.RequiredPattern,
            //       Resources.ValidationRule.RequiredErrorMessage,
            //       Resources.ValidationRule.RequiredErrorHint
            //   ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtFromRepresentative,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            //validationManager.AddRule(
            //    new PatternMatchedRule(
            //        txtContractRepresentative,
            //        Resources.ValidationRule.RequiredPattern,
            //        Resources.ValidationRule.RequiredErrorMessage,
            //        Resources.ValidationRule.RequiredErrorHint
            //    ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtCode,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtName,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtFirstPrice,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtFirstPrice,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtLastPrice,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtLastPrice,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));

            validationManager.AddRule(
               new PatternMatchedRule(
                   txtExchangRate,
                   Resources.ValidationRule.RequiredPattern,
                   Resources.ValidationRule.RequiredErrorMessage,
                   Resources.ValidationRule.RequiredErrorHint
               ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtExchangRate,
                    Resources.ValidationRule.NumberPattern,
                    Resources.ValidationRule.NumberErrorMessage,
                    Resources.ValidationRule.NumberErrorHint
                ));


            validationManager.AddRule(
                new PatternMatchedRule(
                    txtTotalDays,
                    Resources.ValidationRule.NumberPattern,
                    Resources.ValidationRule.NumberErrorMessage,
                    Resources.ValidationRule.NumberErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtRealTotalDays,
                    Resources.ValidationRule.NumberPattern,
                    Resources.ValidationRule.NumberErrorMessage,
                    Resources.ValidationRule.NumberErrorHint
                ));


            validationManager.AddRule(
                new PatternMatchedRule(
                    txtVAT,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtVAT,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtPITTax,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtPITTax,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtCITTax,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtCITTax,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));
            /*validationManager.AddRule(
                new PatternMatchedRule(
                    radFromDate,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    radToDate,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    radRealFromDate,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    radRealToDate,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));*/

            validationManager.Notifier = new BalloonNotifier();

            if (IsPostBack && !validationManager.Validate())
            {
                return;
            }
        }
        #endregion
    }
}
