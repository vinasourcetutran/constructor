<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemIO.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.ItemIO" %>
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
                                <asp:Literal ID="Literal8" runat="server" meta:resourcekey="TicketName"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal1" runat="server" meta:resourcekey="Receiver"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal9" runat="server" meta:resourcekey="Sender"></asp:Literal>
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
                             <th  id='thToRepositoryId' runat="server">
                                <asp:Literal ID="ltrRepositoryHeader" runat="server" meta:resourcekey="InputToRepository"></asp:Literal>
                            </th>
                            <th id='thFromRepositoryId' runat="server">
                                <asp:Literal ID="Literal10" runat="server" meta:resourcekey="OutputFromRepository"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal6" runat="server" meta:resourcekey="Status"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="Literal5" runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                            </th>
                            </th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <rlm:AddNewRelatedItemLink ID='lnkTicket' ResourceType="ItemIOTicket" Action="ClientView" CssClass="" runat="server" IsShowText=true />
                        </td>
                        <td>
                            <rlm:AddNewRelatedItemLink ID='lnkReceiver' ResourceType="Staff" Action="ClientView" CssClass="" runat="server" IsShowText=true />
                            <asp:Literal ID="ltrReceiver" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltrSender" runat="server"></asp:Literal>
                            <rlm:AddNewRelatedItemLink ID='lnkSender' ResourceType="Staff" Action="ClientView" CssClass="" runat="server" IsShowText=true />
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
                        <td id='tdFromRepository' runat="server" visible="false">
                            <asp:Literal ID='ltrFromRepository' runat="server" />
                        </td>
                        <td id='tdToRepository' runat="server" visible="false">
                            <asp:Literal ID='ltrToRepository' runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID='ltrStatus' runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="ltrLastModificationDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </ItemTemplate>
                <NoneTemplate>
                    <tr>
                        <td colspan="15">
                            <asp:Literal ID='ltrNoDate' runat="server" meta:resourcekey="DataNotFound"></asp:Literal>
                        </td>
                    </tr>
                </NoneTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </rlm:Repeater>
            </div>
        </div>
    </fieldset>
</div>

