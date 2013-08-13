<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ContactorView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Partner.ContactorView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div>
        <fieldset>
            <legend id="legend" runat="server" meta:resourcekey="DetailView"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                    </label>
                    <asp:Label ID='lblGroup' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                    </label>
                    <asp:Label ID='lblName' runat="server"></asp:Label>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="JobTitle"></asp:Literal>
                    </label>
                    <asp:Label ID='lblJobTitle' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal15' runat="server" meta:resourcekey="Phone"></asp:Literal>
                    </label>
                    <asp:Label ID='lblPhone' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal16' runat="server" meta:resourcekey="Mobile"></asp:Literal>
                    </label>
                    <asp:Label ID='lblMobile' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal17' runat="server" meta:resourcekey="Email"></asp:Literal>
                    </label>
                    <asp:Label ID='lblEmail' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <Comment>
                        <div>
                            <asp:Literal ID='ltrComment' runat="server"></asp:Literal>
                        </div>
                    </Comment>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id='spIsActive' runat="server" class="NotOK"></span>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
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
