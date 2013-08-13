<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="StaffContactInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffContactInfo" %>
<%@ Register Src="~/Page/Staff/StaffEmail.ascx" TagName="StaffEmail" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Staff/StaffPhone.ascx" TagName="StaffPhone" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Staff/StafAddress.ascx" TagName="StafAddress" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="Row PaddingBottom20">
        <rlm:StafAddress ID='address' runat="server" ContentType="StaffAddress" />
    </div>
     <div class="Row  PaddingBottom20">
        <rlm:StaffEmail ID='staffEmail' runat="server" ContentType="StaffEmail" />
    </div>
    <div class="Row  PaddingBottom20">
        <rlm:StaffPhone ID='staffPhone' runat="server" ContentType="StaffPhone" />
    </div>
</asp:Content>
