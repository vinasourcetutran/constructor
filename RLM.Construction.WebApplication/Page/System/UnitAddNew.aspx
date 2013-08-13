<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="UnitAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.SystemSetting.UnitAddNew" %>
<%@ Register Src="~/Page/System/UnitConvertorList.ascx" TagName="UnitConvertorList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <legend id="legend" runat="server">Add Product For Company</legend>
            <div class="EditFormWrapper">
                <div class="Row" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrParentGroup' runat="server" meta:resourcekey="UnitType"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                     <rlm:UnitTypeComboBox CssClass="Item AutoWidth" ID="drpUnitType" runat="server">
                    </rlm:UnitTypeComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtName' runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtDescription' TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="IsBaseUnit"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsBaseUnit' Checked="true" runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' Checked="true" runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset' runat="server" meta:resourcekey="Reset" />
                    <asp:Button ID='btnCancel' OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
                <div class='Row'>
                    <rlm:UnitConvertorList Visible="false" IsAllowEdit="true"  id='convertor'  runat='server' />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
