<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ItemIOItemAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Repository.ItemIOItemAddNew" %>

<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink"
    TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="Item"></asp:Literal>
                    </label>
                    <rlm:ItemComboBox IsShowAll="false" CssClass="AutoWidth" id='drpItem' runat='server' />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrName' runat="server" meta:resourcekey="Quantity"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtQuantity' Width="100px" runat="server"  Text="0"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="UnitId"></asp:Literal>
                    </label>
                    <rlm:UnitComboBox  ID='drpUnitId' IsLoadAll=true CssClass="AutoWidth" runat="server" IsShowAll="false" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="UnitPrice"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtUnitPrice' runat="server" Width="150px" Text="0"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="PriceUnitId"></asp:Literal>
                    </label>
                    <rlm:UnitComboBox  ID='drpPriceUnitId' Type="Money"  CssClass="AutoWidth" runat="server" IsShowAll="false" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtComment' TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
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
                    <asp:Button ID='btnCancel' OnClick="btnCancel_OnClick" runat="server" meta:resourcekey="Cancel" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
