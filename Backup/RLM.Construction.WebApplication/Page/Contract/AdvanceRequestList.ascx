<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvanceRequestList.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.AdvanceRequestList1" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="AdvanceRequestListTitle" runat="server"></legend>
        <div class="ContentWrapper" style="display:table">
            <ul class="AttachFiles">
                <rlm:Repeater id="rptFiles" runat="server" OnItemDataBound="rptFiles_OnItemDataBound">
                
                <HeaderTemplate>
                    <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                    <thead>
                    <th>
                        <asp:Literal  runat="server" meta:resourcekey="RequestContactor"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal1"  runat="server" meta:resourcekey="RequestContent"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal2"  runat="server" meta:resourcekey="RequestAmount"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal3"  runat="server" meta:resourcekey="CurrencyUnit"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal5"  runat="server" meta:resourcekey="Status"></asp:Literal>
                    </th>
                     <th>
                        <asp:Literal ID="Literal4"  runat="server" meta:resourcekey="RequestDate"></asp:Literal>
                    </th>
                    <th>&nbsp;</th>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrRequestContactor"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrRequestContent"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrRequestAmount"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrCurrencyUnit"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrStatus"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrRequestDate"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:ImageButton ID='btnPreview' tabid='contractAdvanceRequest' runat="server" ImageUrl="~/Resource/Image/Icon/preview.png" OnClientClick="InnerPageHelper.addPageFromDOM($(this));return false;"/>
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
                        </tbody>
                        </table>    
                    </FooterTemplate>
                </rlm:Repeater>
            </ul>
            <div>
            <rlm:addnewlink id='lnkAddNewFile'  ResourceType="AdvanceRequest" ResourceId='0' runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='attachList' runat="server"  meta:resourcekey="AddNewFile"/>
            </div>
        </div>
    </fieldset>
</div>
