<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ContractView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.ContractView" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Contract/AdvanceRequestList.ascx" TagName="AdvanceRequestList" TagPrefix="rlm" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ProjectPhaseList.ascx" TagName="ProjectPhaseList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ItemInProjectList.ascx" TagName="ItemInProjectList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/TaskList.ascx" TagName="TaskList" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ItemInProjectGraph.ascx" TagName="ItemInProjectGraph" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/GrantChart.ascx" TagName="GrantChart" TagPrefix="rlm" %>
<%@ Register Src="~/Page/System/UnitConvertorList.ascx" TagName="UnitConvertorList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" meta:resourcekey="ViewDetailTitle" runat="server"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row Width50" id='div15' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" Text="Số HD"></asp:Literal>
                    </label>
                    <asp:Label id='lblContractNumber' runat="server"></asp:Label>
                </div>
                <div class="Row Width50" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                    </label>
                    <asp:Label id='lblGroup' runat="server"></asp:Label>
                </div>
             
                <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                    </label>
                    <asp:Label id='lblCode' runat="server"></asp:Label>
                </div>
                <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='ltrName' runat="server" meta:resourcekey="Name"></asp:Literal>
                        
                    </label>
                    <asp:Label id='lblName' runat="server"></asp:Label>
                </div>
              




              <div class="Row Width50" id='div9' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal15' runat="server" meta:resourcekey="Project"></asp:Literal>
                    </label>
                    <asp:Label ID='lblProject' runat="server">(None)</asp:Label>
                    <rlm:AddNewRelatedItemLink Visible="false" ID='lnkProject' IsShowText="true" ResourceType="Project" TabId="projectList" runat="server" CssClass="" />
                </div>
                <div class="Row  Width50" id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Partner"></asp:Literal>
                    </label>
                    <rlm:AddNewRelatedItemLink ID='lnkParner' ResourceType="Partner" TabId="partnerList" runat="server" CssClass="" />
                </div>
                
                <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='Literal18' runat="server" meta:resourcekey="ToContractor"></asp:Literal>
                    </label>
                    <asp:Label ID='lblToContact' Visible="false" runat="server"></asp:Label>
                    <rlm:AddNewRelatedItemLink ID='lnkToContactor' ResourceType="Contactor" Action="ClientView" runat="server" CssClass="" />
                </div>
                 
                 <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='Literal17' runat="server" meta:resourcekey="FromContractor"></asp:Literal>
                    </label>
                    <asp:Label ID='lblFromContact' runat="server"></asp:Label>
                    <rlm:AddNewRelatedItemLink Visible="false" ResourceType="Contactor" ID='lnkFromContactor' TabId="partnerContactorList"  runat="server" CssClass="" />
                </div>

                
                <div class="Row Width50 None">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                    <description>
                        <div>
                            <asp:Literal ID='ltrDescription' runat="server"></asp:Literal>
                        </div>
                    </description>
                </div>
                
                 <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal16' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <asp:Label id='lblType' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div5' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="ConstructDept"></asp:Literal>
                    </label>
                   <asp:Label id='lblConstructDept' runat="server"></asp:Label>
                </div>
                <div class="Row  Width32" id='div6' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="DesignDept"></asp:Literal>
                    </label>
                     <asp:Label id='lblDesignDept' runat="server"></asp:Label>
                </div>
                
                <div class="Row  Width32" id='div2' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="FirstPrice"></asp:Literal>
                        </label>
                    <asp:Label id='lblFirstPrice' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="LastPrice"></asp:Literal>
                    </label>
                    <asp:Label id='lblLastPrice' runat="server"></asp:Label>
                </div>
                <div class="Row Width32 None" id='div8' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="Currency"></asp:Literal>
                    </label>
                    <asp:Label id='lblUnit' runat="server"></asp:Label>
                </div>

                <div class="Row Width32" id='div17' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal25' runat="server" meta:resourcekey="ExchangeRate"></asp:Literal>
                    </label>
                    <asp:Label id='lblExchangeRate' runat="server"></asp:Label>
                </div>

                 <div class="Row Width32" id='div18' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal26' runat="server" meta:resourcekey="TotalAmount"></asp:Literal>
                    </label>
                    <asp:Label id='lblTotalAmount' runat="server"></asp:Label>
                </div>

                
                <div class="Row  Width32" id='div12' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal21' runat="server" meta:resourcekey="VATTax"></asp:Literal>
                    </label>
                    <asp:Label id='lblVat' runat="server"></asp:Label>
                </div>
                <div class="Row  Width32" id='div13' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal22' runat="server" meta:resourcekey="PITTax"></asp:Literal>
                    </label>
                    <asp:Label id='lblPit' runat="server"></asp:Label>
                </div>
                <div class="Row  Width32" id='div14' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal23' runat="server" meta:resourcekey="CITTax"></asp:Literal>
                        
                    </label>
                    <asp:Label id='lblCit' runat="server"></asp:Label>
                </div>
                
                <div class="Row Width32" id='div16' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal24' runat="server" Text="Ngày ký"></asp:Literal>
                        
                    </label>
                    <asp:Label id='lblSignedDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="FromDate"></asp:Literal>
                        
                    </label>
                    <asp:Label id='lblFromDate' runat="server"></asp:Label>
                </div>
                <div class="Row Width32" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="ToDate"></asp:Literal>
                        
                    </label>
                    <asp:Label id='lblToDate' runat="server"></asp:Label>
                    /<asp:Label id='lblTotalDays' runat="server"></asp:Label>(Ngày)
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
                    /<asp:Label id='lblRealTotalDays' runat="server"></asp:Label>(Ngày)
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="IsApprove"></asp:Literal>
                    </label>
                    <span id="spIsApprove" runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <asp:Label id='lblStatus' runat="server"></asp:Label>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="Row">
                    <rlm:ProjectPhaseList IsShowAddNewLink="false" ID='projectPhaseList' runat="server"  />
                </div>
                <div class="Row">
                    <rlm:ItemInProjectList ID='itemInProjectList' runat="server"  />
                </div>
                <div class="Row">
                    <rlm:ItemInProjectGraph ID='itemGraph' ResourceType="Contract" runat="server" />
                </div>
                 <div class="Row">
                    <rlm:AdvanceRequestList IsShowAddNewLink="false" ID='advanceRequestList' runat="server"  ResourceType="Contract" />
                </div>
                <div class="Row">
                    <rlm:TaskList ID='taskList' isactiveonly="true" IsAllowEdit=false  isshowaddnewlink='false' ResourceType="Contract" runat="server" />
                </div>
                <div class="Row">
                    <rlm:GrantChart id='grantChart' runat='server' ResourceType="Contract" />
                </div>
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="false" ID='files' runat="server" ResourceType="Contract" />
                </div>
                <div class="BottonRow Row PaddingTop20">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        Text="Trở về" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
