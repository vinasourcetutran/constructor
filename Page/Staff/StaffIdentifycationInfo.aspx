<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffIdentifycationInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffIdentifycationInfo" %>
<%@ Register Src="~/Page/Staff/StaffIdentificationInfo.ascx" TagName="StaffIdentificationInfo" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div class="Row">
        <rlm:StaffIdentificationInfo ID='identifycation' runat="server" ContentType="StaffIdentifycation" />
    </div>
</asp:Content>
