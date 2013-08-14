<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubItemList.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.SubItemList" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="ItemInItem" runat="server"></legend>
        <div class="ContentWrapper" style="display: table">
            <ul class="AttachFiles">
                <rlm:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound" OnItemCommand="rptItems_OnItemCommand">
                    <HeaderTemplate>
                        <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                            <thead>
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
                                    <asp:Literal ID="Literal3" runat="server" meta:resourcekey="Unit"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal5" runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                                </th>
                                <th>
                                </th>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                               <a href='#' id='lnkName'  runat=server></a>
                            </td>
                            <td>
                                <asp:Literal ID="ltrGroup" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrQuantity" runat="server"></asp:Literal>
                            </td>
                           <td>
                                <asp:Literal ID="lblUnit" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrLastModificationDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <rlm:AddNewRelatedItemLink ID='lnkPreview' IsShowText="false" runat="server" CssClass="Preview" TabId="Item_View" />
                            </td>
                        </tr>
                        <tr class="HideItem" id='trChild' runat="server">
                            <td colspan="8" width="98%" >
                                <asp:PlaceHolder ID='childItem' runat="server"></asp:PlaceHolder>
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
                        </tbody> </table>
                    </FooterTemplate>
                </rlm:Repeater>
            </ul>
        </div>
    </fieldset>
</div>
