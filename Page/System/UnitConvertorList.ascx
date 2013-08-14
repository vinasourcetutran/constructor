<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnitConvertorList.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.SystemSetting.UnitConvertorList" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="UnitConvertor" runat="server"></legend>
        <div class="ContentWrapper" style="display: table">
                <rlm:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                    <HeaderTemplate>
                        <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                            <thead>
                                <th>
                                    <asp:Literal ID="Literal6" runat="server" meta:resourcekey="FromUnitName"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal1" runat="server" meta:resourcekey="ToUnitName"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Quantity"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal3" runat="server" meta:resourcekey="IsActive"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal4" runat="server" meta:resourcekey="EffectFrom"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal5" runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                                </th>
                                <th>&nbsp;</th>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td>
                                <asp:Literal ID="ltrFromUnitName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrToUnitName" runat="server"></asp:Literal>
                            </td>
                            
                            <td>
                                <asp:Literal ID="ltrQuantity" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <span id='spIsActive' runat="server">&nbsp;</span>
                            </td>
                            <td>
                                <asp:Literal ID="ltrEffectFrom" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrLastModificationDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <a href='#' id='lnkEdit' visible="false" runat="server" >
                                     <asp:ImageButton ID="editLinkBtn" runat="server" CommandName="EditItem" Text="Edit" ImageUrl="~/Resource/Image/edit.gif" ToolTip="Edit" />
                                </a>
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
        </div>
        <div>
            <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/System/UnitConvertor.aspx" CssClass="AddItem"
            runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
        </div>
    </fieldset>
</div>
