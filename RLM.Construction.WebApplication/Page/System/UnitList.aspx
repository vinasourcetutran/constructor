<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="UnitList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.SystemSetting.UnitList" %>
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
    <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/System/UnitAddNew.aspx" CssClass="AddItem"
        runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
    <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
        ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource" OnItemCommand="radItems_OnItemCommand" 
        ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
        <GroupingSettings CaseSensitive="false" />
        <ClientSettings>
            <Scrolling AllowScroll="True" EnableVirtualScrollPaging="false" UseStaticHeaders="True"
                SaveScrollPosition="True"></Scrolling>
        </ClientSettings>
        <MasterTableView  DataKeyNames="UnitId" AutoGenerateColumns="false" HierarchyLoadMode="ServerOnDemand" 
            AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto" runat="server"
            OnItemCommand="radItems_OnItemCommand">
            <Columns>
                <telerik:GridBoundColumn FilterControlWidth="105px" DataField="Name" meta:resourcekey="Name"
                    SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn GroupByExpression="Type Group By Type" UniqueName="UnitType" AllowFiltering=false HeaderStyle-Height="100px" meta:resourcekey="UnitType">
                    <ItemTemplate>
                        <asp:Literal ID='ltrTypeName' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="200px" DataField="Description" meta:resourcekey="Description"
                    UniqueName="Description" AutoPostBackOnFilter="true" AllowFiltering=false AllowSorting=false>
                </telerik:GridBoundColumn>
                <telerik:GridImageColumn GroupByExpression="IsBaseUnit Group By IsBaseUnit" FilterControlWidth="50px" meta:resourcekey="IsBaseUnit" SortExpression="IsBaseUnit"
                    DataImageUrlFields="IsBaseUnit" DataType="System.Boolean" UniqueName="IsBaseUnit"
                    AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                    ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="100px" />
                </telerik:GridImageColumn>
                <telerik:GridImageColumn  GroupByExpression="IsActive Group By IsActive" FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                    DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                    AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                    ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="100px" />
                </telerik:GridImageColumn>
                <telerik:GridDateTimeColumn FilterControlWidth="150px" DataField="LastModificationDate"
                    meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                    UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="160px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="30px"  UniqueName="TemplateColumn" AllowFiltering="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="editLinkBtn" runat="server" CommandName="EditItem" Text="Edit" ImageUrl="~/Resource/Image/edit.gif"
                            ToolTip="Edit" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
