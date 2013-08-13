<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemInProjectList.ascx.cs"
    Inherits="RLM.Construction.WebApplication.Page.Project.ItemInProjectList" %>
    <%@ Register Src="~/Page/Item/SubItemList.ascx" TagName="SubItemList" TagPrefix="rlm" %>
    <%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
    
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="ItemInProjectPhase" runat="server"></legend>
        <div class="ContentWrapper" style="display: table">
                <rlm:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                    <HeaderTemplate>
                        <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                            <thead>
                                <th>
                                    <asp:Literal ID="Literal1" runat="server" meta:resourcekey="Name"></asp:Literal>
                                </th>
                                <th  style='width:150px;'>
                                    <asp:Literal ID="Literal9" runat="server" meta:resourcekey="GroupName"></asp:Literal>
                                </th>
                                <th style='width:100px;'> 
                                    <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Quantity"></asp:Literal>
                                </th>
                                <th style='width:100px;'>
                                    <asp:Literal ID="Literal3" runat="server" meta:resourcekey="UnitPrice"></asp:Literal>
                                </th>
                                <th  style='width:65px;'>
                                    <asp:Literal ID="Literal8" runat="server" meta:resourcekey="ExchangeRate"></asp:Literal>
                                </th>
                                <th  style='width:150px;'>
                                    <asp:Literal ID="Literal4" runat="server" meta:resourcekey="TotalPrice"></asp:Literal>
                                </th>
                                
                                <th  style='width:100px;'>
                                    <asp:Literal ID="Literal7" runat="server" meta:resourcekey="TotalPriceVND"></asp:Literal>
                                </th>
                                
                                <th>
                                    <asp:Literal ID="Literal6" runat="server" meta:resourcekey="IsActive"></asp:Literal>
                                </th>
                                <th  style='width:130px;'>
                                    <asp:Literal ID="Literal5" runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                                </th>
                                <th>&nbsp;</th>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a class='Underline' href='#' runat="server" id='lnkName'></a>
                            </td>
                            <td>
                                <asp:Literal ID="ltrGroup" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrQuantity" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrUnitPrice" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrExchangeRate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrTotal" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrTotalVND" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <span id='spIsActive' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                            <td>
                                <asp:Literal ID="ltrLastModificationDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <rlm:AddNewRelatedItemLink ID='lnkPreview' isshowtext=false Action="ClientView" ResourceType="Item" runat="server" CssClass="Preview" TabId="Item_View" />
                            </td>
                        </tr>
                        <tr id='trChild' runat="server" class="HideItem" >
                            <td width="100%" colspan="10">
                                <rlm:SubItemList id='subItemList' runat='server' />
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
                        <tr class="TopLine" id='trFooter' runat="server">
                            <td colspan="2">
                                <asp:Literal ID='ltrTotalFooter' runat="server" meta:resourcekey="FooterTotal"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrQuantity" runat="server"></asp:Literal>
                            </td>
                            <td colspan="3">&nbsp;</td>
                            
                            <td>
                                <asp:Literal ID="ltrTotalVND" runat="server"></asp:Literal>
                            </td>
                            <td colspan="3">&nbsp;
                            </td>
                        </tr>
                        </tbody> </table>
                    </FooterTemplate>
                </rlm:Repeater>
        </div>
    </fieldset>
</div>
