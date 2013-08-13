<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="AdvanceRequestView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.AdvanceRequestView" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server" meta:resourcekey="ViewDetail"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Contract"></asp:Literal>
                    </label>
                    <asp:Literal ID='lblContract' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="RequestContactor"></asp:Literal>
                    </label>
                    <asp:Literal ID='lblRequestContactor' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="RequestAmount"></asp:Literal>
                        
                    </label>
                   <asp:Literal ID='lblAmount' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="CurrentcyUnit"></asp:Literal>
                    </label>
                    <asp:Literal ID='lblUnit' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="RequestComment"></asp:Literal>
                    </label>
                    <RequestComment>
                        <div>
                            <asp:Literal ID='ltrRequestComment' runat="server"></asp:Literal>
                        </div>
                    </RequestComment>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <asp:Literal ID='lblStatus' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="RequestDate"></asp:Literal>
                    </label>
                    <asp:Literal ID='lblRequestDate' runat="server"></asp:Literal>
                </div>
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="false" ID='files' runat="server" ResourceType="AdvanceRequest" />
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        meta:resourcekey="Back" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>

