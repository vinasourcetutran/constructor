<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ContactorList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Partner.ContactorList" %>
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
    <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Partner/ContactorAddNew.aspx" CssClass="AddItem Width100Percent"
        runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
    <telerik:RadGrid AutoGenerateColumns="false" Width="100%" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
        ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
        OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
        <GroupingSettings CaseSensitive="false" />
        <ClientSettings>
            <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
                SaveScrollPosition="True"></Scrolling>
        </ClientSettings>
        <MasterTableView DataKeyNames="ContactorId" AutoGenerateColumns="false" 
            AllowFilteringByColumn="True" ShowFooter="True" runat="server"
            OnItemCommand="radItems_OnItemCommand">
            <Columns>
                <telerik:GridBoundColumn DataField="Name" meta:resourcekey="Name"
                    SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridNumericColumn FilterControlWidth="100px" meta:resourcekey="JobTitle"
                    SortExpression="JobTitle" DataField="JobTitle" UniqueName="JobTitle"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn FilterControlWidth="100px" meta:resourcekey="Phone"
                    SortExpression="Phone" DataField="Phone" UniqueName="Phone"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn FilterControlWidth="100px" meta:resourcekey="Mobile"
                    SortExpression="Mobile" DataField="Mobile" UniqueName="Mobile"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn FilterControlWidth="100px" meta:resourcekey="Email"
                    SortExpression="Email" DataField="Email" UniqueName="Email"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridImageColumn  GroupByExpression="IsActive Group By IsActive" FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                    DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                    AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                    ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="100px" />
                </telerik:GridImageColumn>
                <telerik:GridDateTimeColumn FilterControlWidth="120px" DataField="LastModificationDate"
                    meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                    UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="160px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridTemplateColumn HeaderText=""  UniqueName="TemplateColumn" AllowFiltering="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Preview" CssClass="Padding5" Text="Preview" ImageUrl="~/Resource/Image/Icon/preview.png" ToolTip="Preview" />
                        <asp:ImageButton ID="editLinkBtn" runat="server" CommandName="Edit"  CssClass="Padding5" Text="Edit" ImageUrl="~/Resource/Image/edit.gif" ToolTip="Edit" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Scrolling AllowScroll="false" />
        </ClientSettings>
    </telerik:RadGrid>
</asp:Content>
