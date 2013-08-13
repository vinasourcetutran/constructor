<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectPhaseView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectPhaseView" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ItemInProjectList.ascx" TagName="ItemInProjectList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ProjectPhaseList.ascx" TagName="ProjectPhaseList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/TaskList.ascx" TagName="TaskList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/System/UnitConvertorList.ascx" TagName="UnitConvertorList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ItemInProjectGraph.ascx" TagName="ItemInProjectGraph" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/GrantChart.ascx" TagName="GrantChart" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div>
        <fieldset>
            <legend id="legend" runat="server" meta:resourcekey="ViewDetail"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row" id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Project"></asp:Literal>
                    </label>
                    <rlm:addnewlink id='lnkProject' ResourceType="Project" Action="ClientView" runat='server' CssClass="" tabId='projectList' runat="server"  />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                    </label>
                    <asp:Label ID='lblName' runat="server"></asp:Label>
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
                <div class="Row Width32" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="LastPrice"></asp:Literal>
                    </label>
                    <asp:Label ID='lblLastPrice' runat="server"></asp:Label>
                </div>
                 <div class="Row Width32" id='div8' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="ExchangeRate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblExchangeRate' runat="server"></asp:Label>
                </div>
                
                <div class="Row Width32" id='div5' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="FromDate"></asp:Literal>
                        
                    </label>
                    <asp:Label ID='lblFromDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div6' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="ToDate"></asp:Literal>
                        
                    </label>
                    <asp:Label ID='lblToDate' runat="server"></asp:Label>
                </div>
                
                <div class="Row Width32" id='div10' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal19' runat="server" meta:resourcekey="RealFromDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblRealFromDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div11' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="RealToDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblRealToDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="IsBillable"></asp:Literal>
                    </label>
                    <span id='spBillable' runat="server" class="NotOK">&nbsp;</span>
                </div>
                
                <div class="Row Width32" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <asp:Label ID='lblStatus' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <asp:Label ID='lblType' runat="server"></asp:Label>
                </div>
                 <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="IsCurrentProjectPhase"></asp:Literal>
                    </label>
                    <span id='spIsCurrentPhase' runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id='spIsActive' runat="server" class="NotOk">&nbsp;</span>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="Row"></div>
                <div class="Row">
                    <rlm:ItemInProjectList ID='itemInProjectList' runat="server" />
                </div>
                <div class="Row">
                    <rlm:ItemInProjectGraph ID='itemGraph' ResourceType="ProjectPhase" runat="server" />
                </div>
                
                <div class="Row">
                    <rlm:TaskList ID='taskList' isactiveonly="true" IsAllowEdit=true  isshowaddnewlink='true' visibile=false  ResourceType="ProjectPhase" runat="server" />
                </div>
                
                <div class="Row">
                    <rlm:GrantChart id='grantChart' runat='server' ResourceType="ProjectPhase" />
                </div>
                
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="false" ID='files' runat="server" ResourceType="ProjectPhase" />
                </div>
                
                <div class="Row">
                    <rlm:ProjectPhaseList Visible=false IsShowAddNewLink="true" ID='projectPhaseList' runat="server" TitleResourceKey="OtherProjectPhase" />
                </div>
                <div class="Row None">
                    <rlm:UnitConvertorList ID='unitConvertor' Type="Money" runat="server"  IsAllowEdit="false"></rlm:UnitConvertorList>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        meta:resourcekey="Back" />
                    <asp:Button ID='Button1' OnClick="btnCompare_OnClick" runat="server" meta:resourcekey="Compare" />
                </div>
                
            </div>
        </fieldset>
    </div>
</asp:Content>