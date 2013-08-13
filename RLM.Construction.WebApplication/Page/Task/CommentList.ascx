<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentList.ascx.cs"
    Inherits="RLM.Construction.WebApplication.Page.Task.CommentList" %>
     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="radItems">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="btnSend" LoadingPanelID="ajaxPanel" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="radItems">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="rptItems" LoadingPanelID="ajaxPanel" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="radItems">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="pager" LoadingPanelID="ajaxPanel" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="CommentList" runat="server"></legend>
        <div class="ContentWrapper">
            <div class="Row">
                <rlm:Repeater ID='rptItems' runat="server" OnItemDataBound="rptItems_OnItemDatabound">
                    <HeaderTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0" class="TableList">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id='trrow' runat="server">
                            <td width="200px" class="Padding5" valign="top">
                                <div class="StaffInfo">
                                    <a href='#' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" id='lnkStaffInfo' class="displayTable" tabid="staffCommentDetail" runat="server">
                                        <img id='imgStaffPhoto' runat="server" />
                                    </a><a href='#' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" id='lnkStaffName' tabid="staffCommentDetail" runat="server">(None)</a>
                                </div>
                            </td>
                            <td valign="top">
                                <div class="DisplayInlineTable CommentDate">
                                    <label>
                                        <asp:Literal ID='ltrDate' runat="server"></asp:Literal>
                                    </label>
                                </div>
                                <div class="Row CommentContent">
                                    <commentcotnent>
                                        <asp:Literal id='ltrCommentContent' runat="server"></asp:Literal>
                                    </commentcotnent>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </rlm:Repeater>
            </div>
            <div class="TextRight">
                <rlm:HyperLinkPager ID='pager' runat="server" Parameter="PageIndex" >
                </rlm:HyperLinkPager>
            </div>
        </div>
        <div class="EditFormWrapper DetailFormView" id='divCommentPostWrapper' runat="server">
            <div class="Row">
                <asp:Label ID='lbl' runat="server" meta:resourcekey="PostTitle"></asp:Label><br />
                <telerik:RadEditor ID='radComment' CssClass="displayTable" ToolsFile="~/Resource/Xml/RadEditor/Basic.xml" Height="300px" runat="server">
                </telerik:RadEditor>
            </div>
            <div class="BottonRow Row PaddingTop20 ">
                <asp:Button ID='btnSend' OnClick="btnSend_OnClick" runat="server"  meta:resourcekey="Send" />
            </div>
        </div>
    </fieldset>
</div>
<telerik:RadAjaxLoadingPanel ID="ajaxPanel" runat="server">
    </telerik:RadAjaxLoadingPanel>
