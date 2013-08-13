<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="UnitConvertor.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.SystemSetting.UnitConvertor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div>
        <fieldset>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                 <div class="Row" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="FromUnit"></asp:Literal>
                    </label>
                    <asp:Label ID='lblFromUnit' runat="server"></asp:Label>
                </div>
                <div class="Row" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrToUnit' runat="server" meta:resourcekey="ToUnit"></asp:Literal>
                    </label>
                     <rlm:UnitComboBox IsLoadAll="true" CssClass="Item AutoWidth" ID="drpUnit" runat="server">
                    </rlm:UnitComboBox>
                    <asp:Label ID='lblToUnit' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Quantity"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtQuantity' Text="1" CssClass=Width150 runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="EffectFrom"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <telerik:RadDatePicker ID="radEffectDate"  runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldFromDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
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
                    <asp:Button ID='btnCancel' runat="server"
                        meta:resourcekey="Cancel" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
