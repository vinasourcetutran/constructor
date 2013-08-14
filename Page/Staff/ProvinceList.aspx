<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProvinceList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.ProvinceList" %>
<%@ Register src="~/UserControl/GroupList.ascx" tagname="GroupList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<uc1:GroupList ID="groupList" EditPageUrl="~/Page/Staff/ProvinceAddNew.aspx" GroupType="Province" runat="server" />
</asp:Content>
