<%@ Page Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.RoleList" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<asp:content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:content>
<asp:content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <telerik:radajaxmanager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radItems" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanager>
        <rlm:AddNewRelatedItemLink ID='lnkAddnew' runat="server" ResourceType=Role ResourceId=0 Action="ClientAddNew" meta:resourcekey="AddNewItem" CssClass="AddItem" />
    <telerik:radgrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
        ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
         ShowStatusBar="true" OnItemDataBound="radItems_OnItemDataBound" >
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
        <GroupingSettings CaseSensitive="false" />
        <MasterTableView TableLayout="Auto">
        </MasterTableView>
        <ClientSettings>
            <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
                SaveScrollPosition="True"></Scrolling>
        </ClientSettings>
        <MasterTableView DataKeyNames="RoleId" AutoGenerateColumns="false" 
            AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto" runat="server"
            OnItemCommand="radItems_OnItemCommand">
            <Columns>
             <telerik:GridNumericColumn FilterControlWidth="50px" meta:resourcekey="Code"
                    SortExpression="Code" DataField="Code" HeaderStyle-Width="70px" UniqueName="Code"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn FilterControlWidth="105px" DataField="Name" meta:resourcekey="Name"
                    SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
               
               <telerik:GridTemplateColumn GroupByExpression="Type Group By Type" UniqueName="Type"
                    SortExpression="Type" DataField="Type" meta:resourcekey="RoleType" HeaderStyle-Width="200px">
                    <FilterTemplate>
                        <rlm:RoleTypeComboBox IsShowAll="true" meta:resourcekey="FilterCombobox"
                            ID='rlmType' SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Type").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="RoleTypeIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="RoleTypeRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function RoleTypeIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "Type", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrRoleType' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridImageColumn  GroupByExpression="IsActive Group By IsActive" FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                    DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                    AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                    ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="100px" />
                </telerik:GridImageColumn>
                <telerik:GridDateTimeColumn FilterControlWidth="120px" DataField="LastModificationDate"
                    meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                    UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="260px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="70"  UniqueName="TemplateColumn" AllowFiltering="false">
                    <ItemTemplate>
                        <rlm:AddNewRelatedItemLink ID='lnkPreview' Action="ClientView" IsShowText="false" runat="server" CssClass="Preview" />
                        <rlm:AddNewRelatedItemLink ID='lnkEdit'  Action="ClientView" runat="server" IsShowText="false" CssClass="Edit" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Scrolling AllowScroll="false" />
        </ClientSettings>
    </telerik:radgrid>
</asp:content>