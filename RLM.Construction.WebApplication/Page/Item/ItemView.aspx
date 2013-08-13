<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ItemView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.ItemView" %>

<%@ Register Src="~/Page/Item/SubItemList.ascx" TagName="SubItemList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server" meta:resourcekey="ItemDetail"></legend>
            <div class="EditFormWrapper">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="Width150">
                            <a href="#" id='lnkItemFullPhoto' target="_blank" runat="server">
                                <asp:Image ID='itemPhoto' runat="server" />
                            </a>
                        </td>
                        <td>
                            <div class="Row Width50">
                                <label class="Label">
                                    <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                                </label>
                                <asp:Label ID='lblName' runat="server"></asp:Label>
                            </div>
                            <div class="Row Width50">
                                <label class="Label">
                                    <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Group"></asp:Literal>
                                </label>
                                <asp:Label ID='lblGroup' runat="server"></asp:Label>
                            </div>
                            <div class="Row Width50" id='div2' runat="server">
                                <label class="Label">
                                    <asp:Literal ID='Literal7' runat="server" meta:resourcekey="UsedUnit"></asp:Literal>
                                </label>
                                <asp:Label ID='lblUsedUnit' runat="server"></asp:Label>
                            </div>
                            <div class="Row  Width50" id='div1' runat="server">
                                <label class="Label">
                                    <asp:Literal ID='Literal6' runat="server" meta:resourcekey="BasedUnit"></asp:Literal>
                                </label>
                                <asp:Label ID='lblBaseUnit' runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="Row">
                                <div id="tabs">
                                    <ul>
                                        <li>
                                            <asp:HyperLink ID='lnkCommonInfo' NavigateUrl="#tabCommonInfo" runat="server" meta:resourcekey="CommonInfo"></asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID='lnkSubItem' NavigateUrl="#tabSubItemInfo" runat="server" meta:resourcekey="SubItem"></asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID='lnkInput' NavigateUrl="#tabInputInfo" runat="server" meta:resourcekey="Input"></asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID='lnkOutput' NavigateUrl="#tabOutputInfo" runat="server" meta:resourcekey="Output"></asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID='lnkMovement' NavigateUrl="#tabMovementInfo" runat="server" meta:resourcekey="Movement"></asp:HyperLink></li>
                                    </ul>
                                    <div id='tabCommonInfo'>
                                        <iframe id='tabCommonInfoIFrame' runat="server" class="AutoHeight" scrolling="no"
                                            frameborder="0"></iframe>
                                    </div>
                                    <div id='tabSubItemInfo'>
                                        <iframe id='tabSubItemInfoIFrame' runat="server" class="AutoHeight" scrolling="no"
                                            frameborder="0"></iframe>
                                    </div>
                                    <div id='tabInputInfo'>
                                        <iframe id='tabInputInfoIframe' runat="server" class="AutoHeight" scrolling="no"
                                            frameborder="0"></iframe>
                                    </div>
                                    <div id='tabOutputInfo'>
                                        <iframe id='tabOutputInfoIframe' runat="server" class="AutoHeight" scrolling="no"
                                            frameborder="0"></iframe>
                                    </div>
                                    <div id='tabMovementInfo'>
                                        <iframe id='tabMovementInfoIframe' runat="server" class="AutoHeight" scrolling="no"
                                            frameborder="0"></iframe>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>

    <script type="text/javascript">
        //$("#tabs").tabs({ panelTemplate: '<iframe></iframe>' });
        $(document).ready(function() {
            $("#tabs").tabs({
                show: function(event, ui) {
                    var url = $(ui.tab).attr("frameContent");
                    if (url) {
                        var item = $('#' + url)[0];
                        item.style.height = item.contentWindow.document.body.offsetHeight + 'px'
                    }
                    return true;
                }
            });
            $('iframe.AutoHeight').iframeAutoHeight();
        });
                    
    </script>

</asp:Content>
