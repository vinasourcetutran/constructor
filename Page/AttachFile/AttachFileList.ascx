<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttachFileList.ascx.cs"
    Inherits="RLM.Construction.WebApplication.Page.AttachFile.AttachFileList" %>
    <%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="AttachFileListTitle" runat="server"></legend>
        <div class="ContentWrapper" style="display:table">
            <ul class="AttachFiles">
                <rlm:Repeater id="rptFiles" runat="server" OnItemDataBound="rptFiles_OnItemDataBound" OnItemCommand="rptFiles_OnItemCommand">
                    <ItemTemplate>
                        <li>
                            
                            <div>
                                <asp:LinkButton  ID='lnkImage' runat="server">
                                    <asp:Image ID='img' runat="server" />
                                </asp:LinkButton>
                            </div>
                            <span>
                            <asp:ImageButton ID='btnDelete' ImageUrl="~/Resource/Image/delete.gif" runat="server" CommandName="Delete" />
                            <asp:Literal ID='ltrName' runat="server"></asp:Literal>
                            </span>
                        </li>
                    </ItemTemplate>
                    <NoneTemplate>
                        <asp:Literal ID='ltrNoDate' runat="server" meta:resourcekey="AttachFileNotFound"></asp:Literal>
                    </NoneTemplate>
                </rlm:Repeater>
            </ul>
            <div>
            <rlm:addnewlink id='lnkAddNewFile' runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='attachList' runat="server"  meta:resourcekey="AddNewFile"/>
            </div>
        </div>
    </fieldset>
</div>
