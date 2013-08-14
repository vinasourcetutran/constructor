<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffRewardInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffReward" %>
<%@ Register Src="~/Page/Staff/StaffRewardInfo.ascx" TagName="StaffRewardInfo" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div class="Row">
        <rlm:StaffRewardInfo ID='staffRewardInfo' ContentType="StaffReward" runat="server"/>
    </div>
</asp:Content>
