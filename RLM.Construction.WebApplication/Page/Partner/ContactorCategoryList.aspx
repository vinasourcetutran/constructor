<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ContactorCategoryList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Partner.ContactorCategoryList" %>

<%@ Register src="~/UserControl/GroupList.ascx" tagname="GroupList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:GroupList EditPageUrl="~/Page/Partner/ContactorCategoryAddNew.aspx" ID="groupList" GroupType="Contactor" runat="server" />
</asp:Content>
