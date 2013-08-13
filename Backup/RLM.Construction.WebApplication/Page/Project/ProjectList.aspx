<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectList" %>
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
        <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Project/ProjectAddNew.aspx" CssClass="AddItem Width100Percent"
            runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
        <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
            AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
            ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
            OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView TableLayout="Auto">
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
                    SaveScrollPosition="True"></Scrolling>
            </ClientSettings>
            <MasterTableView  DataKeyNames="ProjectId" AutoGenerateColumns="false" AllowFilteringByColumn="True"
                ShowFooter="True" TableLayout="Auto" runat="server" OnItemCommand="radItems_OnItemCommand">
                <Columns>
                    <telerik:GridTemplateColumn HeaderStyle-Width="20" meta:resourcekey="OrderIndex" UniqueName="STT" ShowFilterIcon="false" AllowFiltering="false" >
                <ItemTemplate>
                    <asp:Literal ID='ltrOrderIndex' runat="server"></asp:Literal>
                </ItemTemplate>
             </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="Code" meta:resourcekey="Code" SortExpression="Code"
                        UniqueName="Code" FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains"
                        ShowFilterIcon="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn FilterControlWidth="150px" DataField="Name" meta:resourcekey="Name"
                        SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn GroupByExpression="GroupId Group By GroupId" UniqueName="GroupId" SortExpression="GroupId" DataField="GroupId"
                        meta:resourcekey="GroupName" HeaderStyle-Width="150px" ShowSortIcon="true">
                        <FilterTemplate>
                            <rlm:GroupComboBox Type="Project" IsShowAll="true" meta:resourcekey="FilterCombobox"  id='rlmGroup'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("GroupId").CurrentFilterValue %>' OnClientSelectedIndexChanged="GroupIndexChanged"
                             runat='server'/>
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
                    <telerik:GridTemplateColumn  GroupByExpression="ContractId Group By ContractId"  UniqueName="ContractId" SortExpression="ContractId" DataField="ContractId"
                        meta:resourcekey="CotractName" HeaderStyle-Width="250px" AllowFiltering="false">
                        <ItemTemplate>
                            <a href='#' id='lnkContract' runat="server"></a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridNumericColumn FilterControlWidth="120px" meta:resourcekey="InitPrice"
                        SortExpression="DesignedPrice" DataField="DesignedPrice" UniqueName="DesignedPrice"
                        AllowFiltering="false" DataType="System.Decimal" DataFormatString="{0:c0}">
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn FilterControlWidth="120px" meta:resourcekey="LastPrice"
                        SortExpression="AuctualPrice" DataField="AuctualPrice" UniqueName="AuctualPrice"
                        AllowFiltering="false" DataType="System.Decimal" DataFormatString="{0:c0}" >
                    </telerik:GridNumericColumn>
                   <telerik:GridTemplateColumn  GroupByExpression="CurrencyUnitId Group By CurrencyUnitId" UniqueName="CurrencyUnitId" SortExpression="CurrencyUnitId" DataField="CurrencyUnitId"
                        meta:resourcekey="CurrencyName" HeaderStyle-Width="80px" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:Literal ID='ltrCurrentcy' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridNumericColumn FilterControlWidth="120px" meta:resourcekey="ExchangeRate"
                        SortExpression="ExchangeRate" DataField="ExchangeRate" UniqueName="ExchangeRate"
                        AllowFiltering="false" DataType="System.Int32" DataFormatString="{0:c0}">
                    </telerik:GridNumericColumn>
                    <telerik:GridImageColumn   GroupByExpression="IsActive Group By IsActive"  FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                        DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                        AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                        ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="70px" />
                    </telerik:GridImageColumn>
                    <telerik:GridDateTimeColumn AllowFiltering="false" FilterControlWidth="100px" DataField="LastModificationDate"
                        meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                        UniqueName="LastModificationDate" PickerType="DatePicker" DataType="System.DateTime" CurrentFilterFunction="LessThan" DataFormatString="{0:dd/MM/yyyy hh:mm:ms}">
                        <HeaderStyle Width="150px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridTemplateColumn HeaderStyle-Width="80px" HeaderText="" UniqueName="TemplateColumn" AllowFiltering="false">
                        <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="Padding5" CommandName="Preview" Text="Preview" ImageUrl="~/Resource/Image/Icon/preview.png" AlternateText="Preview" ToolTip="Preview" />
                            <asp:ImageButton ID="editLinkBtn" runat="server"  CssClass="Padding5" CommandName="Edit" Text="Edit" ImageUrl="~/Resource/Image/edit.gif" AlternateText="Edit" ToolTip="Edit" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="false" />
            </ClientSettings>
        </telerik:RadGrid>
</asp:Content>
