<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage/Page.Master" CodeBehind="CategoryList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Repository.CategoryList" %>

<%@ Register src="~/UserControl/GroupList.ascx" tagname="GroupList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:GroupList ID="groupList" GroupType="Repository" runat="server" />
</asp:Content>
