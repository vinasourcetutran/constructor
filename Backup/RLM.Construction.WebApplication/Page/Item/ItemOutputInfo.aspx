<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ItemOutputInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.ItemOutputInfo" %>
<%@ Register Src="~/Page/Item/ItemIO.ascx" TagName="ItemIO" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="Row">
        <rlm:ItemIO type="Output" runat='server' id='itemIO' />
    </div>
</asp:Content>
