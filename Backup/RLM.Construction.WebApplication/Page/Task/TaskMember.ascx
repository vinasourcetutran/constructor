<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskMember.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.TaskMember" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="TaskMemberList" runat="server"></legend>
        <div class="ContentWrapper" style="display: table">
            <ul class="AttachFiles">
                <rlm:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                    <HeaderTemplate>
                        <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                            <thead>
                                <th>
                                    <asp:Literal ID="Literal1" runat="server" meta:resourcekey="FullName"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal6" runat="server" meta:resourcekey="RoleName"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal9" runat="server" meta:resourcekey="Status"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal2" runat="server" meta:resourcekey="FromDate"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="Literal3" runat="server" meta:resourcekey="ToDate"></asp:Literal>
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
                                <asp:Literal ID="ltrFullName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrRoleName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrFromDate" runat="server"></asp:Literal>
                            </td>
                             <td>
                                <asp:Literal ID="ltrToDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrLastModificationDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:ImageButton ID='btnEdit' tabid='taskmemberEdit' runat="server"  OnClientClick="InnerPageHelper.addPageFromDOM($(this));return false;" ImageUrl="~/Resource/Image/edit.gif"/>
                                <asp:ImageButton ID='btnPreview' tabid='taskMemberView' runat="server"  OnClientClick="InnerPageHelper.addPageFromDOM($(this));return false;" ImageUrl="~/Resource/Image/Icon/preview.png"/>
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
        <div>
            <rlm:AddNewLink ID='lnkAddMember'  ResourceType="Staff"  Visible="false" meta:resourcekey="AddNew" CssClass="AddItem Width100Percent" runat="server" />
        </div>
    </fieldset>
</div>