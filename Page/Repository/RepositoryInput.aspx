<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="RepositoryInput.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Repository.RepositoryInput" %>

<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink"
    TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radItems" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <rlm:AddNewRelatedItemLink ID="AddNewRelatedItemLink1" CssClass="AddItem" meta:resourceKey="AddNewItem" IsShowText="true" runat="server" ResourceType="ItemIOTicket" ResourceId="0" Action="ClientAddNew" />
    <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
        ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
        ShowStatusBar="true" 
        OnItemDataBound="radItems_OnItemDataBound">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
        <GroupingSettings CaseSensitive="false" />
        <MasterTableView CommandItemDisplay="Bottom" HierarchyLoadMode="ServerOnDemand" DataKeyNames="IOTicketId"
            AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto"
            runat="server">
            <Columns>
                <telerik:GridNumericColumn DataField="IOTicketId" Visible="false">
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn DataField="Name" meta:resourcekey="Name"
                    SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                
                <telerik:GridTemplateColumn GroupByExpression="StaffId Group By StaffId" UniqueName="StaffId"
                    SortExpression="StaffId" DataField="StaffId" meta:resourcekey="StaffId" HeaderStyle-Width="105px">
                    <FilterTemplate>
                        <rlm:StaffComboBox IsShowAll="true" meta:resourcekey="FilterCombobox"
                            ID='rlmStaff' SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("StaffId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="StaffIdIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="StaffIdRadScriptBlock1" runat="server">
                            <script type="text/javascript">
                                function StaffIdIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "StaffId", args, "EqualTo");
                                }
                            </script>
                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <rlm:AddNewRelatedItemLink id='lnkStaff' runat='server'  CssClass="" resourcetype="Staff" action="ClientView"></rlm:AddNewRelatedItemLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn FilterControlWidth="105px" HeaderStyle-Width="120px" DataField="Sender" meta:resourcekey="Sender"
                    SortExpression="Sender" UniqueName="Sender" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="105px" HeaderStyle-Width="120px" DataField="Receiver" meta:resourcekey="Receiver"
                    SortExpression="Receiver" UniqueName="Receiver" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn GroupByExpression="IOType Group By IOType" UniqueName="IOType"
                    SortExpression="IOType" DataField="IOType" meta:resourcekey="IOType" HeaderStyle-Width="100px" FilterControlWidth="100px">
                    <FilterTemplate>
                        <rlm:ItemIOTicketTypeCombobox IsShowAll="true" meta:resourcekey="FilterCombobox"
                            ID='rlmType' SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("IOType").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="IOTypeIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="IOTypeRadScriptBlock1" runat="server">
                            <script type="text/javascript">
                                function IOTypeIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "IOType", args, "EqualTo");
                                }
                            </script>
                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrType' runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn AllowFiltering="false" GroupByExpression="IODate Group By IODate" UniqueName="IODate"
                    SortExpression="IODate" DataField="IODate" meta:resourcekey="IODate" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Literal ID='ltrIODate' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn AllowFiltering="false" GroupByExpression="TaxPercent Group By TaxPercent" UniqueName="TaxPercent"
                    SortExpression="TaxPercent" DataField="TaxPercent" meta:resourcekey="TaxPercent" HeaderStyle-Width="70px">
                    <ItemTemplate>
                        <asp:Literal ID='ltrTax' runat="server"></asp:Literal> (%)
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn AllowFiltering="false" GroupByExpression="UnitId Group By UnitId" UniqueName="UnitId"
                    SortExpression="UnitId" DataField="UnitId" meta:resourcekey="UnitId" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Literal ID='ltrUnitId' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn GroupByExpression="Status Group By Status" FilterControlWidth="60" UniqueName="Status"
                    SortExpression="Status" DataField="Status" meta:resourcekey="Status" HeaderStyle-Width="60">
                    <FilterTemplate>
                        <rlm:ItemIOTicketStatusComboBox CssClass="AutoWidth" IsShowAll="true" meta:resourcekey="FilterCombobox"
                            ID='rlmStatus' SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Status").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="StatusIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="StatusRadScriptBlock1" runat="server">
                            <script type="text/javascript">
                                function StatusIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "Status", args, "EqualTo");
                                }
                            </script>
                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrStatus' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                
                <telerik:GridImageColumn GroupByExpression="IsActive Group By IsActive" 
                    meta:resourcekey="IsActive" SortExpression="IsActive" DataImageUrlFields="IsActive"
                    DataType="System.Boolean" UniqueName="IsActive" AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                    ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="50px" />
                </telerik:GridImageColumn>
                <telerik:GridDateTimeColumn AllowFiltering="false" DataField="LastModificationDate"
                    meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                    UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="170px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridTemplateColumn HeaderText="" UniqueName="TemplateColumn" HeaderStyle-Width="50"
                    AllowFiltering="false">
                    <ItemTemplate>
                        <rlm:AddNewRelatedItemLink IsShowText=false ID='lnkPreView' Action=ClientView ResourceType="ItemIOTicket" CssClass="Preview" runat="server" TabId="Item_View" />
                        <rlm:AddNewRelatedItemLink IsShowText=false ID='lnkEdit' Action=ClientEdit ResourceType="ItemIOTicket" CssClass="Edit" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Scrolling AllowScroll="false" />
        </ClientSettings>
    </telerik:RadGrid>
</asp:Content>
