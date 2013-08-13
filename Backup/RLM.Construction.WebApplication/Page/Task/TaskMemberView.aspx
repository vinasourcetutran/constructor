<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="TaskMemberView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.TaskMemberView" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div>
    <div class="Row Bold">
        <asp:label id='lblResource' runat="server"></asp:label>
    </div>
    <fieldset>
            <legend id="legend" meta:resourcekey="TaskmemberView" runat="server"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row " id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Staff"></asp:Literal>
                    </label>
                    <rlm:AddNewRelatedItemLink ID='lnkStaff' CssClass="" runat="server" TabId="staffView" />
                </div>
                 <div class="Row " id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="Role"></asp:Literal>
                    </label>
                    <asp:Label ID='lblRole' runat="server"></asp:Label>
                </div>
                 <div class="Row " id='div2' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <asp:Label ID='lblStatus' runat="server"></asp:Label>
                </div>
                <div class="Row" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="EstimationFromDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblFromDate' runat="server"></asp:Label>
                </div>
                <div class="Row" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="EstimationToDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblToDate' runat="server"></asp:Label>
                </div>
                <div class="Row" id='div10' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal19' runat="server" meta:resourcekey="RealFromDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblRealFromDate' runat="server"></asp:Label>
                </div>
                <div class="Row" id='div11' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="RealToDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblRealToDate' runat="server"></asp:Label>
                </div>
                
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <div>
                        <Comment>
                            <asp:Literal ID='ltrComment' runat="server"></asp:Literal>
                        </Comment>
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblLastModificationDate' runat="server" Text="(None)"></asp:Label>
                </div>
                <div class="BottonRow Row PaddingTop20">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        meta:resourcekey="Back" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>