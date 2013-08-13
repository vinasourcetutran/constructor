<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectPhaseCategoryList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectPhaseCategoryList" %>

<%@ Register src="~/UserControl/GroupList.ascx" tagname="GroupList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:GroupList ID="groupList" GroupType="ProjectPhase" EditPageUrl="~/Page/Project/ProjectPhaseCategoryAddNew.aspx" runat="server" />
</asp:Content>
