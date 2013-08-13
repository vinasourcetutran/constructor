<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="AppConfigList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.SystemSetting.AppConfigList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radItems" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/System/AppConfigAddNew.aspx" CssClass="AddItem"
        runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
    <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
        ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
        OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound">
        <MasterTableView DataKeyNames="AppConfigId" AutoGenerateColumns="false" 
            AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto" runat="server"
            OnItemCommand="radItems_OnItemCommand">
            <Columns>
                <telerik:GridBoundColumn FilterControlWidth="105px" DataField="AppConfigName" meta:resourcekey="AppConfigName"
                    SortExpression="AppConfigName" UniqueName="AppConfigName" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="105px" DataField="AppConfigValue" meta:resourcekey="AppConfigValue"
                    SortExpression="AppConfigValue" UniqueName="AppConfigValue" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn ReadOnly="true" FilterControlWidth="150px" DataField="LastModificationDate"
                    meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                    UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="160px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" HeaderStyle-Width="30px"
                    UniqueName="EditColumn">
                </telerik:GridEditCommandColumn>
            </Columns>
        </MasterTableView>
        
    </telerik:RadGrid>
</asp:Content>