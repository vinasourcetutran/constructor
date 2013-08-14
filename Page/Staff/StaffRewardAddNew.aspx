<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffRewardAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffRewardAddNew" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
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
                        <rlm:GroupComboBox ID='drpType' runat="server" Type=Reward CssClass="AutoWidth"></rlm:GroupComboBox>
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="IssuedId"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtIssuedId' ValidationGroup="Validate" runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="IssueDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radIssueDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="EffectFrom"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radEffectFrom" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Form"></asp:Literal>
                    </label>
                    <div>
                        <rlm:RewardFormTypeComboBox ID='drpForm' runat="server" CssClass="AutoWidth"></rlm:RewardFormTypeComboBox>
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="FormValue"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtFormValue' ValidationGroup="Validate" runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="FormUnit"></asp:Literal>
                    </label>
                    <rlm:UnitComboBox Type=Money runat="server" ID='drpUnit' CssClass="AutoWidth"></rlm:UnitComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="IsueLevel"></asp:Literal>
                    </label>
                    <rlm:RoleComboBox RoleType="JobTitle" runat="server" ID='drpIsueLevel' CssClass="AutoWidth"></rlm:RoleComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="IssuePerson"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtIssuePerson' ValidationGroup="Validate" runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="Reason"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtReason' runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtComment' runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" meta:resourcekey="AttachFile"></asp:Literal>
                    </label>
                    <div>
                        <a href='#' id='lnkAttachFile' target="_blank" runat="server" class="Padding5"></a>
                        <input type=file id='fphoto' runat="server" />
                    </div>
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
