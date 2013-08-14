<%@ Page Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="RoleView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.RoleView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div>
        <fieldset>
            <legend id="legend" runat="server" meta:resourcekey="DetailView"></legend>
            <div class="EditFormWrapper DetailFormView">
             <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                    </label>
                    <asp:Label ID='lblCode' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrName' runat="server" meta:resourcekey="Name"></asp:Literal>
                    </label>
                    <asp:Label ID='lblName' runat="server"></asp:Label>
                </div>
                
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrType' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <asp:Label ID='lblType' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrIsActive' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id='spIsActive' runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrLastModificationDate' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server" meta:resourcekey="Back" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
