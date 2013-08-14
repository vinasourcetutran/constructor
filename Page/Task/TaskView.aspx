<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="TaskView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.TaskView" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/TaskMember.ascx" TagName="TaskMember" TagPrefix="rlm" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/CommentList.ascx" TagName="CommentList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<rlm:AddNewRelatedItemLink CssClass="Bold" ID="lnkResource" IsShowText="true" ResourceType="Contract" runat="server" /><br />
    <div>
        <fieldset>
            <legend id="legend" meta:resourcekey="ViewDetailTitle" runat="server"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row  " id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Name"></asp:Literal>
                    </label>
                    <asp:Label ID='lblName' runat="server"></asp:Label>
                </div>
                 <div class="Row ">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                    <description>
                        <div class='RowLongContent'>
                            <asp:Literal ID='ltrDescription' runat="server"></asp:Literal>
                        </div>
                    </description>
                </div>
                <div class="Row" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="PercentComplete"></asp:Literal> (%)
                    </label>
                    <asp:Label id='lblPercentComplete' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="EstimationFromDate"></asp:Literal>
                    </label>
                    <asp:Label id='lblFromDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="EstimationToDate"></asp:Literal>
                    </label>
                    <asp:Label id='lblToDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id="spIsActive" runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row Width32" id='div10' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal19' runat="server" meta:resourcekey="RealFromDate"></asp:Literal>
                    </label>
                    <asp:Label id='lblRealFromDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div11' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="RealToDate"></asp:Literal>
                    </label>
                    <asp:Label id='lblRealToDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width20">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="IsApprove"></asp:Literal>
                    </label>
                    <span id="spIsApprove" runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row">
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <asp:Label id='lblStatus' runat="server"></asp:Label>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="CreatorName"></asp:Literal>
                    </label>
                    <asp:label ID='lblCreator' runat="server" Text="(None)"></asp:label>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                </div>
               
                <div class="Row">
                    <rlm:TaskMember ID='members' runat="server" ResourceType="Task"/>
                </div>
                <div class="Row">
                    <rlm:AttachFileList ID='files' runat="server" ResourceType="Task"/>
                </div>
                <div class="Row">
                    <rlm:CommentList ID='comments'  runat="server" ResourceType="Task"/>
                </div>
                 <div class="BottonRow Row PaddingTop20">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        meta:resourcekey="Back" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
