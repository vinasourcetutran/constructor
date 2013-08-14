<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.CategoryList" %>

<%@ Register src="~/UserControl/GroupList.ascx" tagname="GroupList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:GroupList ID="groupList" GroupType="Contract" runat="server" />
</asp:Content>
