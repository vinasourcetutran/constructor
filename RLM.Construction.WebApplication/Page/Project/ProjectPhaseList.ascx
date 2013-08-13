<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectPhaseList.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectPhaseList1" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Project/ItemInProjectList.ascx" TagName="ItemInProjectPhase" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="ProjectPhaseList" runat="server"></legend>
        <div class="ContentWrapper" style="display:table">
            <ul class="AttachFiles">
                <rlm:Repeater id="rptItems" runat="server" OnItemDataBound="rptItems_OnItemDataBound">
                
                <HeaderTemplate>
                    <table class="PreviewTableForm" cellpadding="0" cellspacing="0">
                    <thead>
                    <th>
                        <asp:Literal ID="Literal1"  runat="server" meta:resourcekey="Name"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal10"  runat="server" meta:resourcekey="Project"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal2"  runat="server" meta:resourcekey="DesignPrice"></asp:Literal>
                    </th>

                    <th>
                        <asp:Literal ID="Literal3"  runat="server" meta:resourcekey="ActualPrice"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal4"  runat="server" meta:resourcekey="CurrencyUnit"></asp:Literal>
                    </th>
                     <th>
                        <asp:Literal ID="Literal9"  runat="server" meta:resourcekey="ExchangeRate"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal8"  runat="server" meta:resourcekey="IsBillable"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal51"  runat="server" meta:resourcekey="Status"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal6"  runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal7"  runat="server" meta:resourcekey="IsApprove"></asp:Literal>
                    </th>
                     <th>
                        <asp:Literal ID="Literal5"  runat="server" meta:resourcekey="FromDate"></asp:Literal>
                    </th>
                    <th>&nbsp;</th>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a class='Underline' href='#' id='lnkName' runat="server"></a>
                            </td>
                            <td>
                                <asp:Literal ID="ltrProject"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrDesignedPrice"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrActualPrice"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrCurrencyUnit"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrExchangeRate"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <span id='spIsBillable' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                            <td>
                                <asp:Literal ID="ltrStatus"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <span id='spIsActive' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                            <td>
                                <span id='spIsApprove' runat="server" class="NotOK">&nbsp;</span>
                            </td>
                            <td>
                                <asp:Literal ID="ltrFromDate"  runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <asp:ImageButton ID='btnPreview' tabid='projectPhaseListClientViewDetail_' runat="server"  OnClientClick="InnerPageHelper.addPageFromDOM($(this));return false;" ImageUrl="~/Resource/Image/Icon/preview.png"/>
                            </td>
                        </tr>
                        <tr id='itemsWrapperId' runat="server" class="HideItem" style="display:none;">
                            <td colspan="10">
                                <rlm:ItemInProjectPhase ID='items' runat="server" Visible />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <NoneTemplate>
                        <tr>
                            <td colspan="11">
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
            <rlm:addnewlink id='lnkAddNew' ResourceId="0" ResourceType="ProjectPhase" runat='server' tabId='projectPhaseList'  meta:resourcekey="AddNew"/>
            </div>
        </div>
    </fieldset>
</div>
