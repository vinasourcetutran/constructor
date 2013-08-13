<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffFamilyInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffFamily" %>
<%@ Register Src="~/Page/Staff/StaffFamilyInfo.ascx" TagName="StaffFamilyInfo" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div class="Row">
        <rlm:StaffFamilyInfo ID='familyInfo' ContentType="StaffFamily" runat="server"/>
    </div>
</asp:Content>
