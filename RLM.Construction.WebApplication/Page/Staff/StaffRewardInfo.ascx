<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffRewardInfo.ascx.cs"
    Inherits="RLM.Construction.WebApplication.Page.Staff.StaffRewardInfo" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<div>
<a href='#' id='lnkAddNewItem' runat="server" class="AddItem" meta:resourcekey="AddNewItem"></a>
    <fieldset>
        <legend id="legend" meta:resourcekey="RewardDetail" runat="server"></legend>
        <div class="EditFormWrapper">
            <div class="Row">
                <rlm:Repeater ID='rptItems' runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                    <HeaderTemplate>
                        <table cellpadding="0" class="PreviewTableForm" cellspacing="0" border="0">
                            <tr>
                                <th>
                                    <asp:Literal ID="Literal1" runat="server" meta:resourceKey="InfoType"></asp:Literal>
                                </th>
                                 <th>
                                    <asp:Literal ID="Literal8" runat="server" meta:resourceKey="RewardForm"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal2" runat="server" meta:resourceKey="Money"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal4" runat="server" meta:resourceKey="Reason"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal5" runat="server" meta:resourceKey="IssuedLevel"></asp:Literal>
                                </th>
                                 <th>
                                    <asp:Literal ID="Literal10" runat="server" meta:resourceKey="IssuedPerson"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal6" runat="server" meta:resourceKey="AssigedDate"></asp:Literal>
                                </th>
                                 <th>
                                    <asp:Literal ID="Literal7" runat="server" meta:resourceKey="Comment"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal9" runat="server" meta:resourceKey="AttachFile"></asp:Literal>&nbsp;
                                </th>
                                <th  class="None">
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
                                <asp:Literal ID="ltrInfoType" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrRewardForm" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrMoney" runat="server"></asp:Literal>
                            </td>
                           
                             <td>
                                <asp:Literal ID="ltrReason" runat="server"></asp:Literal>
                            </td>
                             <td>
                                <asp:Literal ID="ltrIssuedLevel" runat="server"></asp:Literal>
                            </td>
                             <td>
                                    <asp:Literal ID="ltrIsuePerson" runat="server"></asp:Literal>
                                </td>
                             <td>
                                <asp:Literal ID="ltrAssigedDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                            </td>
                            
                             <td>
                                <a href='#' id='lnkAttachFile' target="_blank" class="Attach" runat="server">&nbsp;</a>
                            </td>
                            <td  class="None">
                                <asp:Literal ID="ltrLastUpdate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <a href='#' id='lnkEdit' runat="server" class="Edit"></a><a href='#' id='lnkDelete' visible="false"
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
