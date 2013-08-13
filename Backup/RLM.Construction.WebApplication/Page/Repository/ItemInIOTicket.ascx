<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemInIOTicket.ascx.cs"
    Inherits="RLM.Construction.WebApplication.Page.Repository.ItemInIOTicket" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink"
    TagPrefix="rlm" %>
<div>
    <fieldset>
        <a href='#'><legend id="legend" meta:resourcekey="ItemInIOTicket" runat="server">
        </legend></a>
        <div class="ContentWrapper" style="display: table">
            <div class="Row">
            <rlm:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                <HeaderTemplate>
                    <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                        <thead>
                            <th>
                                <asp:Literal ID="Literal8" runat="server" meta:resourcekey="Photo"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal1" runat="server" meta:resourcekey="Name"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal9" runat="server" meta:resourcekey="GroupName"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Quantity"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal3" runat="server" meta:resourcekey="UnitPrice"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal4" runat="server" meta:resourcekey="TotalPrice"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal7" runat="server" meta:resourcekey="TotalPriceVND"></asp:Literal>
                            </th>
                             <th>
                                <asp:Literal ID="ltrRepositoryHeader" runat="server" meta:resourcekey="OutputFromRepository"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal5" runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                            </th>
                            <th>
                                &nbsp;
                            </th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='#' runat="server" target="_blank" id='lnkPhoto'>
                                <img id='imgPhoto' runat="server" />
                            </a>
                        </td>
                        <td>
                            <asp:Literal ID='ltrName' runat="server" />
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
                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltrTotalVND" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID='ltrRepository' runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="ltrLastModificationDate" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <rlm:AddNewRelatedItemLink ID='lnkPreview' isshowtext="false" Action="ClientView" ResourceType="Item" runat="server" CssClass="Preview" />
                             <a href='#' class="Edit" tabid='ItemInIOTicket_AddNew' runat="server" id='lnkEdit'>&nbsp;</a>
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
                    <tr class="TopLine Footer" id='trFooter' runat="server">
                        <td colspan="3">
                            <asp:Literal ID='ltrTotalFooter' runat="server" meta:resourcekey="FooterTotal"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltrQuantity" runat="server"></asp:Literal>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltrTotalVND" runat="server"></asp:Literal>
                        </td>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    </tbody> </table>
                </FooterTemplate>
            </rlm:Repeater>
            </div>
            <div class="Row">
                <a href='#' class="AddItem" tabid='ItemInIOTicket_AddNew' runat="server" id='lnkAddNew' meta:resourcekey="AddNewItemInIOTicket" />
            </div>
        </div>
    </fieldset>
</div>
