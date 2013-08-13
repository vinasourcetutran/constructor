<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffEmail.ascx.cs"
    Inherits="RLM.Construction.WebApplication.Page.Staff.StaffEmail" %>
<div>
<a href='#' id='lnkAddNewItem' runat="server" class="AddItem" meta:resourcekey="AddNewItem"></a>
    <fieldset>
        <legend id="legend" meta:resourcekey="EmailDetail" runat="server"></legend>
        <div class="EditFormWrapper  NoPaddingBottom">
            <div class="Row">
                <rlm:Repeater ID='rptItems' runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                    <HeaderTemplate>
                        <table cellpadding="0" class="PreviewTableForm" cellspacing="0" border="0">
                            <tr>
                                <th>
                                    <asp:Literal runat="server" meta:resourceKey="Order"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal1" runat="server" meta:resourceKey="InfoType"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal2" runat="server" meta:resourceKey="Content"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal4" runat="server" meta:resourceKey="UsedEmail"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal3" runat="server" meta:resourceKey="LastUpdate"></asp:Literal>
                                </th>
                                <th>
                                    &nbsp;
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrOrder" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrInfoType" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <span id='spanIsUsed' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                             <td>
                                <asp:Literal ID="ltrLastUpdate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <a href='#' id='lnkEdit' runat="server" class="Edit"></a><a href='#' id='lnkDelete' visible=false
                                    runat="server" class="Delete"></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <NoneTemplate>
                        <tr>
                            <td colspan="10">
                                <asp:Literal ID="Literal1" runat="server" meta:resourceKey="NoData"></asp:Literal>
                            </td>
                        </tr>
                    </NoneTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </rlm:Repeater>
            </div>
        </div>
    </fieldset>
</div>
