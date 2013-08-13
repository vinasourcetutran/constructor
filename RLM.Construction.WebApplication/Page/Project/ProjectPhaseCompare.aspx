<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ProjectPhaseCompare.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectPhaseCompare" %>

<%@ Register Src="~/Page/System/UnitConvertorList.ascx" TagName="UnitConvertorList"
    TagPrefix="rlm" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink"
    TagPrefix="rlm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" meta:resourcekey="ItemInProjectPhaseCompare" runat="server"></legend>
            <div class="ContentWrapper Width100Percent" style="display: table">
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <rlm:AddNewRelatedItemLink ID='lnkTopFromProject' runat="server" CssClass="" />
                                        &gt;&gt;
                                    </td>
                                    <td>
                                        <rlm:AddNewRelatedItemLink ID='lnkTopFromProjectPhase' runat="server" CssClass="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <rlm:ProjectComboBox AutoPostBack="true" OnSelectedIndexChanged="btnProject_OnChangeSelectedIndex" ID='drpProject'
                                            runat="server" />
                                        &gt;&gt;
                                    </td>
                                    <td>
                                        <rlm:ProjectPhaseComboBox ID='drpProjectPhase' runat="server">
                                        </rlm:ProjectPhaseComboBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID='btnCompare' runat="server" OnClick="btnCompare_OnClick" meta:resourcekey="CompageProjectPhase" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <rlm:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                                <HeaderTemplate>
                                    <table class="PreviewTableForm BorderHeader" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th rowspan="2">
                                                <asp:Literal ID="Literal1" runat="server" meta:resourcekey="ItemName"></asp:Literal>
                                            </th>
                                            <th colspan="4" class="Center">
                                                <rlm:AddNewRelatedItemLink ID='lnkFromProjectPhase' ResourceType="ProjectPhase" Action="ClientView"
                                                    runat="server" CssClass="" />
                                            </th>
                                            <th colspan="4" class="Center">
                                                <rlm:AddNewRelatedItemLink ID='lnkToProjectPhase' ResourceType="ProjectPhase" Action="ClientView"
                                                    runat="server" CssClass="" />
                                            </th>
                                            <th colspan="3" class="Center">
                                                <asp:Literal ID="Literal3" runat="server" meta:resourcekey="DifferenceValue"></asp:Literal>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Quantity"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal4" meta:resourcekey="UnitPrice" runat="server"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal5" meta:resourcekey="Total" runat="server"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal12" meta:resourcekey="TotalVND" runat="server"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal7" runat="server" meta:resourcekey="Quantity"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal8" meta:resourcekey="UnitPrice" runat="server"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal9" meta:resourcekey="Total" runat="server"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal13" meta:resourcekey="TotalVND" runat="server"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal6" runat="server" meta:resourcekey="Quantity"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal10" meta:resourcekey="UnitPrice" runat="server"></asp:Literal>
                                            </th>
                                            <th>
                                                <asp:Literal ID="Literal11" meta:resourcekey="TotalVND" runat="server"></asp:Literal>
                                            </th>
                                        </tr>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <rlm:AddNewRelatedItemLink ID='lnkItem' ResourceType="Item" Action="ClientView" runat="server"
                                                CssClass="" />
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrFromQuantity" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrFromUnitPrice" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrFromTotal" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrFromTotalVND" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrToQuantity" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrToUnitPrice" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrToTotal" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrToTotalVND" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrQuantity" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrUnitPrice" Text="0" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrTotal" Text="0" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <NoneTemplate>
                                    <tr>
                                        <td colspan="12">
                                            <asp:Literal ID='ltrNoDate' runat="server" meta:resourcekey="DataNotFound"></asp:Literal>
                                        </td>
                                    </tr>
                                    
                                </NoneTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </rlm:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <br />
</asp:Content>
