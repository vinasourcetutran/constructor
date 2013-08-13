<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="PartnerView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Partner.PartnerView" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ProjectList.ascx" TagName="ProjectList" TagPrefix="rlm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server" meta:resourcekey="ViewDetail"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row None" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                    </label>
                    <asp:Label ID='lblGroup' runat="server"></asp:Label>
                </div>
                <div class="Row" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Contactor"></asp:Literal>
                    </label>
                   <rlm:AddNewRelatedItemLink ID='lnkContactor' TabId="partnerContactorList" ResourceType="Contactor" runat="server" CssClass="" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" meta:resourcekey="TaxCode"></asp:Literal>
                        
                    </label>
                   <asp:Label ID='lblTaxCode' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                        
                    </label>
                    <asp:Label ID='lblName' runat="server"></asp:Label>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="NameInEnglish"></asp:Literal>
                    </label>
                    <asp:Label ID='lblShortName' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="Address"></asp:Literal>
                    </label>
                    <asp:Label ID='lblAddress' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal15' runat="server" meta:resourcekey="Phone"></asp:Literal>
                    </label>
                    <asp:Label ID='lblPhone' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal16' runat="server" meta:resourcekey="Fax"></asp:Literal>
                    </label>
                    <asp:Label ID='lblFax' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal17' runat="server" meta:resourcekey="Email"></asp:Literal>
                    </label>
                    <asp:Label ID='lblEmail' runat="server"></asp:Label>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Website"></asp:Literal>
                    </label>
                    <a href='#' target="_blank" id='lnkWebsite' runat="server"></a>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <comment>
                        <div>
                            <asp:Literal ID='ltrComment' runat="server"></asp:Literal>
                        </div>
                    </comment>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id='spIsActive' runat="server" class='NotOK'>&nbsp;&nbsp;</span>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                
                <div class="Row">
                    <rlm:projectlist id='projectList' runat='server'></rlm:projectlist>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        meta:resourcekey="Back" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
