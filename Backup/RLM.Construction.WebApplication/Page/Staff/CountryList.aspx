<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.CountryList" %>
<%@ Register src="~/UserControl/GroupList.ascx" tagname="GroupList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<uc1:GroupList ID="groupList" EditPageUrl="~/Page/Staff/CountryAddNew.aspx" GroupType="Country" runat="server" />
</asp:Content>
