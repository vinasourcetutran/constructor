<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectView" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ProjectPhaseList.ascx" TagName="ProjectPhaseList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ItemInProjectList.ascx" TagName="ItemInProjectList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/TaskList.ascx" TagName="TaskList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ItemInProjectGraph.ascx" TagName="ItemInProjectGraph" TagPrefix="rlm" %>
<%@ Register Src="~/Page/System/UnitConvertorList.ascx" TagName="UnitConvertorList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/GrantChart.ascx" TagName="GrantChart" TagPrefix="rlm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server" meta:resourceKey="DetailView"></legend>
            <div class="EditFormWrapper DetailFormView">
            <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                    </label>
                    <asp:Label ID='lblCode' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                        
                    </label>
                    <asp:Label ID='lblName' runat="server"></asp:Label>
                </div>
                <div class="Row" id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Contract"></asp:Literal>
                    </label>
                    <rlm:AddNewLink ID='lnkContract' ResourceType="Contract" Action=ClientView runat="server" CssClass="" TabId="contractList" />
                </div>
                <div class="Row" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                                            </label>
                    <asp:Label ID='lblGroup' runat="server"></asp:Label>
                </div>
                
                <div class="Row None">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="ProjectPhase"></asp:Literal>
                    </label>
                    <rlm:addnewlink id='lnkProjectPhase' Action="ClientView" ResourceType="ProjectPhase" CssClass="" runat='server' tabId='projectPhaseList' runat="server"  meta:resourcekey="AddNewProjectPhase" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                    <description>
                        <div>
                            <asp:literal ID='ltrDescription' runat="server"></asp:literal>
                        </div>
                    </description>
                </div>
                <div class="Row Width32" id='div2' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="FirstPrice"></asp:Literal>
                    </label>
                    <asp:Label ID='lblFirstPrice' runat="server"></asp:Label>
                </div>
                <div class="Row  Width32" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="LastPrice"></asp:Literal>
                    </label>
                    <asp:Label ID='lblLastPrice' runat="server"></asp:Label>
                </div>
                 <div class="Row  Width32" id='div8' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="ExchangeRate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblExchangeRate' runat="server"></asp:Label>
                </div>
                <div class="Row  Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id='spIsActive' runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row None">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="IsApprove"></asp:Literal>
                    </label>
                    <span id="spIsApprove" runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row  Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="Row">
                    <rlm:ProjectPhaseList IsShowAddNewLink="true" ID='projectPhases' runat="server"  />
                </div>
                <div class="Row">
                    <rlm:ItemInProjectList ID='itemInProject' runat="server"  />
                </div>
                <div class="Row">
                    <rlm:ItemInProjectGraph ID='itemGraph' ResourceType="Project" runat="server" />
                </div>
                <div class="Row">
                    <rlm:TaskList ID='taskList' isactiveonly="true" IsAllowEdit=true  isshowaddnewlink='true' ResourceType="Project" runat="server" />
                </div>
                <div class="Row">
                    <rlm:GrantChart id='grantChart' runat='server' ResourceType="Project" />
                </div>
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="true" ID='files' ViewMode="Edit" runat="server" ResourceType="Project" />
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        meta:resourcekey="Back" />
                </div>
                
            </div>
        </fieldset>
    </div>
</asp:Content>
