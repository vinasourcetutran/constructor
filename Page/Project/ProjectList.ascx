<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectList1" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="ProjectList" runat="server"></legend>
        <div class="ContentWrapper" style="display:table">
            <ul class="AttachFiles">
            <rlm:Repeater id="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                
                <HeaderTemplate>
                    <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                    <thead>
                    <th>
                        <asp:Literal ID="Literal1"  runat="server" meta:resourcekey="Name"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal9"  runat="server" meta:resourcekey="GroupName"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal2"  runat="server" meta:resourcekey="DesignPrice"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal3"  runat="server" meta:resourcekey="ActualPrice"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal4"  runat="server" meta:resourcekey="CurrencyUnit"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="ltrExchangeRate"  runat="server" meta:resourcekey="ExcahngeRate"></asp:Literal>
                    </th>
                    <th class="None">
                        <asp:Literal ID="Literal8"  runat="server" meta:resourcekey="CurrentPhase"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal6"  runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </th>
                     <th>
                        <asp:Literal ID="Literal5"  runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </th>
                    <th>&nbsp;</th>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrName"  runat="server" ></asp:Literal>
                            </td>
                             <td>
                                <asp:Literal ID="ltrGroupName"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrDesignedPrice"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrActualPrice"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrCurrencyUnit"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrExchangeRate"  runat="server" ></asp:Literal>
                            </td>
                            <td class="None">
                               <rlm:AddNewLink ID='lnkProjectPhase' CssClass="" rabid='projectPhaseList' runat="server" />
                            </td>
                            <td>
                                <span id='spIsActive' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                            <td>
                                <asp:Literal ID="ltrLastModificationDate"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:ImageButton ID='btnPreview' tabid='projectList' runat="server"  OnClientClick="InnerPageHelper.addPageFromDOM($(this));return false;" ImageUrl="~/Resource/Image/Icon/preview.png"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <NoneTemplate>
                        <tr>
                            <td colspan="10">
                                <asp:Literal ID='ltrNoDate' runat="server" meta:resourcekey="DataNotFound"></asp:Literal>
                            </td>
                        </tr>
                        
                    </NoneTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>    
                    </FooterTemplate>
                </rlm:Repeater>
            </ul>
            <div>
        </div>
    </fieldset>
</div>
