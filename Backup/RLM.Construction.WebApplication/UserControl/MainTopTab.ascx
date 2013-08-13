<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainTopTab.ascx.cs"
    Inherits="RLM.Construction.WebApplication.UserControl.MainTopTab" %>
<telerik:RadTabStrip ID="mainTab" runat="server" MultiPageID="multiContentPage" SelectedIndex="0" Align="Left" 
ReorderTabsOnSelect="true">
    <Tabs>
        <telerik:RadTab meta:resourcekey="StartPage">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<div class="Box3DLeft">
    <div class="Box3DRight">
        <div class="Box3DBottom">
            <div class="Box3DContent">
                    <telerik:RadMultiPage ID="multiContentPage" runat="server" SelectedIndex="0" CssClass="MainContentPageView">
                        <telerik:RadPageView ID="startPage" runat="server" CssClass="StartPageContentWrapper" ContentUrl="~/Page/Default.aspx"></telerik:RadPageView>
                    </telerik:RadMultiPage>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function() {
        RLMConfig.MainTabScriptId = "<%= mainTab.ClientID %>";
        RLMConfig.MainMultiPageViewId = "<%= multiContentPage.ClientID %>";
    });
</script>

