<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffContractAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffContractAddNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <div>
                        <rlm:StaffContractTypeComboBox ID='drpType' runat="server" CssClass="AutoWidth"></rlm:StaffContractTypeComboBox>
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal16' runat="server" meta:resourcekey="FromDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar4" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal17' runat="server" meta:resourcekey="ToDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar5" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="IsCurentJob"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsCurentJob' runat="server" />
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" meta:resourcekey="ContractFile"></asp:Literal>
                    </label>
                    <div>
                        <a href='#' id='lnkContractFile' target="_blank" runat="server" class="Padding5"></a>
                        <input type=file id='fContractFile' runat="server" />
                    </div>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="JobDescriptionFile"></asp:Literal>
                    </label>
                    <div>
                        <a href='#' id='lnkJobDescriptionFile' target="_blank" runat="server" class="Padding5"></a>
                        <input type=file id='fJobDescriptionFile' runat="server" />
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtComment' runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnSave'  ValidationGroup="Validate" OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset'  runat="server" meta:resourcekey="Reset" />
                    <asp:Button ID='btnDelete' Visible="false" OnClick="btnDelete_OnClick" runat="server"
                        meta:resourcekey="Delete" />
                    <asp:Button ID='btnCancel' OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
