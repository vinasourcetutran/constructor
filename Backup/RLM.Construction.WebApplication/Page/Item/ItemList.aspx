<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ItemList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.ItemList" %>

<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink"
    TagPrefix="rlm" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radItems" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Item/ItemAddNew.aspx" CssClass="AddItem Width100Percent"
        runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
    <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
        ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
        OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnDetailTableDataBind="radItems_OnDetailTableBinding"
        OnItemCreated="radItems_OnItemCreated" OnItemDataBound="radItems_OnItemDataBound"
        OnInsertCommand="radItems_OnInsertCommand" OnUpdateCommand="radItems_OnUpdateCommand" >
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
        <GroupingSettings CaseSensitive="false" />
        <ClientSettings>
            <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
                SaveScrollPosition="True"></Scrolling>
        </ClientSettings>
        <MasterTableView CommandItemDisplay="Bottom" HierarchyLoadMode="ServerOnDemand" DataKeyNames="ItemId"
            AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto"
            runat="server" OnItemCommand="radItems_OnItemCommand" >
            <DetailTables>
                <telerik:GridTableView EditMode="InPlace" DataKeyNames="ItemInItemId" CommandItemDisplay="Bottom"
                    Name="SubItem" AutoGenerateColumns="false" AllowFilteringByColumn="false" ShowFooter="True"
                    runat="server" OnItemCommand="radItems_OnSubItemCommand">
                    <CommandItemSettings ShowAddNewRecordButton="true" ShowRefreshButton="true" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GroupId" meta:resourcekey="GroupName" HeaderStyle-Width="200px">
                            <EditItemTemplate>
                                <rlm:GroupComboBox Type="Item" IsShowAll="false" ID='rlmGroup' runat='server' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Literal ID='ltrSubGroupName' runat="server"></asp:Literal>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ItemPhoto" AllowFiltering="false" HeaderStyle-Width="100px" meta:resourcekey="ItemPhoto">
                            <ItemTemplate>
                                <asp:Image ID='itemPhoto' runat="server" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="Name" SortExpression="Name" DataField="Name"
                            meta:resourcekey="Name">
                            <EditItemTemplate>
                                <rlm:ItemComboBox IsShowAll="false" ID='rlmItems' runat='server' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Literal ID='ltrSubName' runat="server"></asp:Literal>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn SortExpression="UnitId" UniqueName="UnitId" DataField="UnitId"
                            meta:resourcekey="UnitId" HeaderStyle-Width="100px">
                            <EditItemTemplate>
                                <rlm:UnitComboBox IsLoadAll="true" IsActiveOnly="true" IsShowAll="false" ID='rlmUnit'
                                    runat='server' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Literal ID='ltrSubUnitName' runat="server"></asp:Literal>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridNumericColumn DataType="System.Double" SortExpression="Quantity" UniqueName="Quantity"
                            DataField="Quantity" meta:resourcekey="Quantity" HeaderStyle-Width="100px">
                        </telerik:GridNumericColumn>
                        <telerik:GridEditCommandColumn ButtonType="ImageButton" HeaderStyle-Width="10px"
                            UniqueName="EditColumn">
                        </telerik:GridEditCommandColumn>
                        <telerik:GridTemplateColumn HeaderText="" ReadOnly="true" HeaderStyle-Width="10px"
                            UniqueName="DeleteColumn" AllowFiltering="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete"
                                    ImageUrl="~/Resource/Image/delete.gif" ToolTip="Delete" OnClientClick="return confirm('Bạn có thật sự muốn xóa thông tin này không?');" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <NoRecordsTemplate>
                        <asp:Literal ID='ltrNoRecord' runat="server" meta:resourceKey="NoRecordText"></asp:Literal>
                    </NoRecordsTemplate>
                </telerik:GridTableView>
            </DetailTables>
            <Columns>
                <telerik:GridNumericColumn DataField="ItemId" Visible="false">
                </telerik:GridNumericColumn>
                <telerik:GridTemplateColumn UniqueName="ItemPhoto" AllowFiltering="false"
                    meta:resourcekey="ItemPhoto">
                    <ItemTemplate>
                        <asp:Image ID='itemPhoto' runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn FilterControlWidth="105px" DataField="Name" meta:resourcekey="Name"
                    SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn GroupByExpression="GroupId Group By GroupId" UniqueName="GroupId"
                    SortExpression="GroupId" DataField="GroupId" meta:resourcekey="GroupName" HeaderStyle-Width="200px">
                    <FilterTemplate>
                        <rlm:GroupComboBox Type="Item" IsShowAll="true" meta:resourcekey="FilterCombobox"
                            ID='rlmGroup' SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("GroupId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="GroupIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

                            <script type="text/javascript">
                                function GroupIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "GroupId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrGroupName' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn SortExpression="BaseUnitId" UniqueName="BaseUnitId" DataField="BaseUnitId"
                    meta:resourcekey="BasedUnitId" HeaderStyle-Width="200px">
                    <FilterTemplate>
                        <rlm:UnitComboBox IsLoadAll="true" IsShowAll="true" meta:resourcekey="FilterCombobox"
                            ID='rlmUnit' SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("BaseUnitId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="UnitIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">

                            <script type="text/javascript">
                                function UnitIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "BaseUnitId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrUnitName' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridNumericColumn FilterControlWidth="105px" meta:resourcekey="AvailabelQuantity"
                    SortExpression="AvailabelQuantity" DataField="AvailabelQuantity" UniqueName="AvailabelQuantity"
                    AllowFiltering="false">
                </telerik:GridNumericColumn>
                <telerik:GridImageColumn GroupByExpression="IsActive Group By IsActive" FilterControlWidth="50px"
                    meta:resourcekey="IsActive" SortExpression="IsActive" DataImageUrlFields="IsActive"
                    DataType="System.Boolean" UniqueName="IsActive" AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                    ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="100px" />
                </telerik:GridImageColumn>
                <telerik:GridDateTimeColumn FilterControlWidth="120px" DataField="LastModificationDate"
                    meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                    UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="160px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridTemplateColumn HeaderText="" UniqueName="TemplateColumn" HeaderStyle-Width="70"
                    AllowFiltering="false">
                    <ItemTemplate>
                        <rlm:AddNewRelatedItemLink IsShowText=false ID='lnkPreView' CssClass="Preview" runat="server" TabId="Item_View" />
                        <asp:ImageButton ID="editLinkBtn" runat="server" CommandName="EditItem" Text="Edit"
                            ImageUrl="~/Resource/Image/edit.gif" ToolTip="Edit" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Scrolling AllowScroll="false" />
        </ClientSettings>
    </telerik:RadGrid>
</asp:Content>
