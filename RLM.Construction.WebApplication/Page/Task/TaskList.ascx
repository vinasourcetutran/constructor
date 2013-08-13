<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskList.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.TaskList" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="TaskList" runat="server"></legend>
        <div class="ContentWrapper" style="display: table">
                <rlm:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                    <HeaderTemplate>
                        <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                            <thead>
                                <th>
                                    <asp:Literal ID="Literal1" runat="server" meta:resourcekey="Name"></asp:Literal>
                                </th>
                                 <th>
                                    <asp:Literal ID="Literal3" runat="server" meta:resourcekey="PercentComplete"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal6" runat="server" meta:resourcekey="IsActive"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal9" runat="server" meta:resourcekey="Status"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal2" runat="server" meta:resourcekey="CreationUserId"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal4" runat="server" meta:resourcekey="FromDate"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal5" runat="server" meta:resourcekey="CreationDate"></asp:Literal>
                                </th>
                                <th>&nbsp;</th>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID='lblName' runat="server"></asp:Label>
                            </td>
                             <td>
                                    <asp:Literal ID="ltrPercentComplete" runat="server"></asp:Literal>
                                </td>
                            <td>
                                <span id='spIsActive' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                            <td>
                                <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrCreatorUserId" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrFromDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrCreationDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:ImageButton ID='btnEdit' tabid='taskAddNew' runat="server"  OnClientClick="InnerPageHelper.addPageFromDOM($(this));return false;" ImageUrl="~/Resource/Image/Edit.gif"/>
                                <asp:ImageButton ID='btnPreview' tabid='taskList' runat="server"  OnClientClick="InnerPageHelper.addPageFromDOM($(this));return false;" ImageUrl="~/Resource/Image/Icon/preview.png"/>
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
            <rlm:AddNewLink ID='lnkAddNewTask' ResourceType="Task" ResourceId="0" Visible="false" meta:resourcekey="AddNew" CssClass="AddItem Width100Percent" runat="server" />
        </div>
    </fieldset>
</div>