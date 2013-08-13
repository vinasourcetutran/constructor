<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="AdvanceRequestAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.AdvanceRequestAddNew" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Contract"></asp:Literal>
                    </label>
                    <rlm:ContractComboBox ID='drpContract' runat="server"></rlm:ContractComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="RequestContactor"></asp:Literal>
                    </label>
                    <rlm:ContactorComboBox ID='drpContactor' runat="server"></rlm:ContactorComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Amount"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                   <telerik:RadNumericTextBox ID='txtAmount' runat="server" Width="200"></telerik:RadNumericTextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="CurrentcyUnit"></asp:Literal>
                    </label>
                    <rlm:UnitComboBox ID='drpUnitId' Width="200" Type="Money" runat="server"></rlm:UnitComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="RequestComment"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtRequestComment' runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <rlm:AdvanveRequestStatusComboBox ID='drpStatus' runat="server"></rlm:AdvanveRequestStatusComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="RequestDate"></asp:Literal>
                    </label>
                    <span id="spRequestDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='Button1' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='Reset1' runat="server" meta:resourcekey="Reset" />
                    <asp:Button ID='Button2' Visible="false" OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="true" ID='files' Visible="false" runat="server" ResourceType="AdvanceRequest" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>

