<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffPunishInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffPunish" %>
<%@ Register Src="~/Page/Staff/StaffPunishInfo.ascx" TagName="StaffPunishInfo" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div class="Row">
        <rlm:StaffPunishInfo ID='staffPunishInfo' ContentType="StaffPunish" runat="server"/>
    </div>
</asp:Content>
