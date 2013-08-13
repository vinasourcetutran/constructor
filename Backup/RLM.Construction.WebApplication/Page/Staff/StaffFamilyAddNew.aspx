<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffFamilyAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffFamilyAddNew" %>
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
                        <rlm:FamilyTypeComboBox id='drpType' CssClass="AutoWidth" IsShowAll="false" runat='server' />
                        <rlm:FamilySideTypeComboBox IsShowAll="false"  CssClass="AutoWidth" id='drpSide' runat='server' />
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="FullName"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtContent' ValidationGroup="Validate" runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="PID"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtPID' ValidationGroup="Validate" runat="server"></asp:TextBox>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="Sex"></asp:Literal>
                    </label>
                    <rlm:SexTypeComboBox id='drpSex' CssClass="AutoWidth" runat='server' />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="Birthday"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radBirtday" runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldToDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
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
