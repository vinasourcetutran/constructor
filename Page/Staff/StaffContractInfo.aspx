<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffContractInfo.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffContractInfo" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div>
    <a href='#' id='lnkAddNewItem' runat="server" class="AddItem" meta:resourcekey="AddNewItem"></a>
    <fieldset>
        <legend id="legend" meta:resourcekey="ContractDetail" runat="server"></legend>
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
                                    <asp:Literal ID="Literal8" runat="server" meta:resourceKey="FromDate"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal2" runat="server" meta:resourceKey="ToDate"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal4" runat="server" meta:resourceKey="IsCurrentJob"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal5" runat="server" meta:resourceKey="ContractFile"></asp:Literal>
                                </th>
                                 <th>
                                    <asp:Literal ID="Literal10" runat="server" meta:resourceKey="JobDescriptionFile"></asp:Literal>
                                </th>
                                 <th >
                                    <asp:Literal ID="Literal7" runat="server" meta:resourceKey="Comment"></asp:Literal>
                                </th>
                                <th >
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
                                <asp:Literal ID="ltrFromDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrToDate" runat="server"></asp:Literal>
                            </td>
                           
                             <td>
                                <span id='spIsCurrentJob' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                            <td>
                                <a href='#' id='lnkContractFile' target="_blank" class="Attach" runat="server">&nbsp;</a>
                            </td>
                             <td>
                                <a href='#' id='lnkJobDescriptionFile' target="_blank" class="Attach" runat="server">&nbsp;</a>
                            </td>
                            <td  style="max-width:400px">
                                <contractcomment>
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </contractcomment>
                                
                            </td>
                            <td >
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
</asp:Content>
