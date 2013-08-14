<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="PeopleAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.PeopleAddNew" %>
<%@ Register src="~/UserControl/GroupAddNew.ascx" tagname="GroupAddNew" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<uc1:GroupAddNew ID="addNewItem" GroupListUrl="~/Page/Staff/PeopleList.aspx" IsShowParentGroup=false GroupType="People" runat="server" />
</asp:Content>
