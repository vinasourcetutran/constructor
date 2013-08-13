<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="CategoryAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Department.CategoryAddNew" %>
<%@ Register src="~/UserControl/GroupAddNew.ascx" tagname="GroupAddNew" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <uc1:GroupAddNew ID="GroupAddNew1" GroupType="Department" runat="server" />
</asp:Content>

