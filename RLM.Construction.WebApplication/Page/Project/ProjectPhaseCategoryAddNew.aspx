<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectPhaseCategoryAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectPhaseCategoryAddNew" %>
<%@ Register src="~/UserControl/GroupAddNew.ascx" tagname="GroupAddNew" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <uc1:GroupAddNew ID="GroupAddNew1" GroupListUrl="~/Page/Project/ProjectPhaseCategoryList.aspx" GroupType="ProjectPhase" runat="server" />
</asp:Content>
