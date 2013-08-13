<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ItemIOTicketView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Repository.ItemIOTicketView" %>
<%@ Register Src="~/Page/Repository/ItemInIOTicket.ascx" TagName="ItemInIOTicket" TagPrefix="rlm" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink"
    TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" meta:resourcekey="IteIOTicketDetail" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="IOType"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrType' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrName1' runat="server" meta:resourcekey="Name"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrName' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Staff"></asp:Literal>
                    </label>
                    <rlm:AddNewRelatedItemLink ID='lnkStaff' runat="server" Action=ClientView ResourceType=Staff CssClass="" />
                </div>
                <div class="Row" id='rowReceiver' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Receiver"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrReceiver' runat="server"></asp:Literal>
                </div>
                <div class="Row" id='rowSender' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="Sender"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrSender' runat="server"></asp:literal>
                </div>
                <div class="Row" id='rowFromRepository' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="FromRepository"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrFromRepository' runat="server"></asp:literal>
                </div>
                <div class="Row" id='rowToRepository' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="ToRepository"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrToRepository' runat="server"></asp:literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Project"></asp:Literal>
                    </label>
                    <rlm:AddNewRelatedItemLink ID='lnkProject' runat="server" Action=ClientView ResourceType=Project CssClass="" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal8" runat="server" meta:resourcekey="IODate"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrIODate' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="TotalAmount"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrTotalAmount' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="TaxPercent"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrTax' runat="server"></asp:Literal>
                    (%)
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                   <div>
                    <Comment">
                        <asp:Literal ID='ltrComment' runat="server"></asp:Literal>
                    </Comment>
                   </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal21' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <asp:Literal ID='ltrStatus' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id='spIsActive' runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="Row">
                    <rlm:ItemInIOTicket id='itemInTicket' runat='server' />
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnList' OnClick="btnList_OnClick" runat="server" meta:resourcekey="List" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
