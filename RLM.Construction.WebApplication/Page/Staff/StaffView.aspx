<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="StaffView.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" meta:resourcekey="ViewDetail" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="Padding5">
                                <asp:Image ID='staffPhoto' runat="server" ImageUrl="~/Resource/Image/NoPhoto/noimage_Thumnail.gif" />
                            </td>
                            <td>
                                <div class="Row Width50">
                                    <label class="Label">
                                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="StaffCode"></asp:Literal>
                                    </label>
                                    <asp:Label ID='lblStaffCode' runat="server" />
                                </div>
                                <div class="Row  Width50">
                                    <label class="Label">
                                        <asp:Literal ID="Literal16" runat="server" meta:resourcekey="Department"></asp:Literal>
                                    </label>
                                    <asp:Label ID='lblDept' runat="server" />
                                </div>
                                <div class="Row  Width50">
                                    <label class="Label">
                                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="FullName"></asp:Literal>
                                    </label>
                                    <asp:Label ID='lblFullName' runat="server" />
                                </div>
                                <div class="Row  Width50">
                                    <label class="Label">
                                        <asp:Literal ID="Literal17" runat="server" meta:resourcekey="JobTitle"></asp:Literal>
                                    </label>
                                    <asp:Label ID='lblJobTitle' runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="Row">
                    <div id="tabs">
                        <ul>
                            <li>
                                <asp:HyperLink ID='lnkCommonInfo' NavigateUrl="#tabCommonInfo" runat="server" meta:resourcekey="CommonInfo"></asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID='lnkContact' NavigateUrl="#tabStaffContactInfo" runat="server"
                                    meta:resourcekey="ContactInfo"></asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID='lnkIdentification' NavigateUrl="#tabStaffIdentifycationInfo"
                                    runat="server" meta:resourcekey="IdentifycationInfo"></asp:HyperLink></li>
                           <li>
                                <asp:HyperLink ID='lnkFamily' NavigateUrl="#tabStaffFamily" runat="server"
                                    meta:resourcekey="Family"></asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID='lnkReward' NavigateUrl="#tabStaffReward" runat="server"
                                    meta:resourcekey="Reward"></asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID='lnkPunish' NavigateUrl="#tabStaffPunish" runat="server"
                                    meta:resourcekey="Punish"></asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID='lnkContract' NavigateUrl="#tabStaffContract" runat="server"
                                    meta:resourcekey="Contract"></asp:HyperLink></li>
                            <li class="None">
                                <asp:HyperLink ID='lnkJob' NavigateUrl="~/Page/Staff/StaffJob.aspx" runat="server"
                                    meta:resourcekey="Job"></asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID='lnkResponsibility' NavigateUrl="#tabStaffResponsibility"
                                    runat="server" meta:resourcekey="Responsibility"></asp:HyperLink></li>
                        </ul>
                        <div id='tabCommonInfo'>
                            <iframe id='iframeCommonInfo' runat="server" class="AutoHeight" scrolling="no" frameborder="0">
                            </iframe>
                        </div>
                        <div id='tabStaffContactInfo'>
                            <iframe id='tabStaffContactInfoFrame' runat="server" class="AutoHeight" scrolling="no"
                                frameborder="0"></iframe>
                        </div>
                        <div id='tabStaffIdentifycationInfo'>
                            <iframe id='tabStaffIdentifycationInfoIframe' runat="server" class="AutoHeight" scrolling="no"
                                frameborder="0"></iframe>
                        </div>
                        <div id='tabStaffFamily'>
                            <iframe id='tabStaffFamilyIframe' runat="server" class="AutoHeight" scrolling="no"
                                frameborder="0"></iframe>
                        </div>
                        
                        <div id='tabStaffReward'>
                            <iframe id='tabStaffRewardIframe' runat="server" class="AutoHeight" scrolling="no"
                                frameborder="0"></iframe>
                        </div>
                        <div id='tabStaffPunish'>
                            <iframe id='tabStaffPunishIframe' runat="server" class="AutoHeight" scrolling="no"
                                frameborder="0"></iframe>
                        </div>
                        <div id='tabStaffContract'>
                            <iframe id='tabStaffContractIframe' runat="server" class="AutoHeight" scrolling="no"
                                frameborder="0"></iframe>
                        </div>
                        <div id='tabStaffResponsibility'>
                            <iframe id='tabStaffResponsibilityIframe' runat="server" class="AutoHeight" scrolling="no"
                                frameborder="0"></iframe>
                        </div>
                    </div>
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

            </div>
        </fieldset>
    </div>
</asp:Content>
