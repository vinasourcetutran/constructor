<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ItemDetailInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.ItemDetailInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<div>
    <fieldset>
        <legend id="legend" runat="server" meta:resourcekey="ItemDetail"></legend>
        <div class="EditFormWrapper">
            <div class="Row" id='divParentId' runat="server">
                <label class="Label">
                    <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                </label>
                <asp:Label ID='lblGroup' runat="server"></asp:Label>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                </label>
                <asp:Label ID='lblCode' runat="server"></asp:Label>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                </label>
                <asp:Label ID='lblName' runat="server"></asp:Label>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal1' runat="server" meta:resourcekey="ItemPhoto"></asp:Literal>
                </label>
                <div>
                    <a href="#" id='lnkItemFullPhoto' target="_blank" runat="server">
                    <asp:Image ID='itemPhoto' runat="server" />
                    </a>
                </div>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                </label>
                <div>
                    <Description>
                        <asp:Literal ID='ltrDescription' runat="server"></asp:Literal>
                    </Description>
                </div>
            </div>
            <div class="Row" id='div2' runat="server">
                <label class="Label">
                    <asp:Literal ID='Literal7' runat="server" meta:resourcekey="UsedUnit"></asp:Literal>
                </label>
                <asp:Label ID='lblUsedUnit' runat="server"></asp:Label>
            </div>
            <div class="Row" id='div1' runat="server">
                <label class="Label">
                    <asp:Literal ID='Literal6' runat="server" meta:resourcekey="BasedUnit"></asp:Literal>
                </label>
                <asp:Label ID='lblBaseUnit' runat="server"></asp:Label>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                </label>
                <span id='spActive' runat="server">&nbsp;</span>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                </label>
                <span id="spLastModificationDate" runat="server">(None)</span>
            </div>
        </div>
    </fieldset>
</div>
</asp:Content>
