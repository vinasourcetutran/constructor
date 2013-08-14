<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ItemSubItemInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.ItemSubItemInfo" %>

<%@ Register Src="~/Page/Item/SubItemList.ascx" TagName="SubItemList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="Row">
        <rlm:SubItemList ID='subItemList' runat="server" />
    </div>
</asp:Content>
