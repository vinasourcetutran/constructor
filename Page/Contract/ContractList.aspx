<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ContractList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.ContractList" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
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
        <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Contract/ContractAddNew.aspx" CssClass="AddItem Width100Percent" runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
        <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
            AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
            ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
            OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
            <GroupingSettings CaseSensitive="false" />
            <ClientSettings>
                <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
                    SaveScrollPosition="True"></Scrolling>
            </ClientSettings>
            <MasterTableView ShowGroupFooter="true"  DataKeyNames="ContractId" AutoGenerateColumns="false" AllowFilteringByColumn="True"
                ShowFooter="true" TableLayout="Auto" runat="server" OnItemCommand="radItems_OnItemCommand">
                <Columns>
                <telerik:GridTemplateColumn HeaderStyle-Width="20" meta:resourcekey="OrderIndex" UniqueName="STT" ShowFilterIcon="false" AllowFiltering="false" >
                <ItemTemplate>
                    <asp:Literal ID='ltrOrderIndex' runat="server"></asp:Literal>
                </ItemTemplate>
             </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="150px" DataField="Number" meta:resourcekey="Number"
                        SortExpression="Number" UniqueName="Number" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn Aggregate="Count"  DataField="Name" meta:resourcekey="Name"
                        SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn Visible="false" GroupByExpression="PartnerId Group By PartnerId" UniqueName="PartnerId" SortExpression="PartnerId" DataField="PartnerId"
                        meta:resourcekey="PartnerName">
                        <FilterTemplate>
                            <rlm:PartnerComboBox IsShowAll="true" meta:resourcekey="FilterCombobox"  id='rlmPartner'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("PartnerId").CurrentFilterValue %>' OnClientSelectedIndexChanged="PartnerIdIndexChanged"
                             runat='server'/>
                            <telerik:RadScriptBlock ID="PartnerIdRadScriptBlock1" runat="server">

                                <script type="text/javascript">
                                    function PartnerIdIndexChanged(sender, args) {
                                        RadGridHelper.filter("<%= radItems.ClientID %>", "PartnerId", args, "EqualTo");
                                    }
                                </script>

                            </telerik:RadScriptBlock>
                        </FilterTemplate>
                        <ItemTemplate>
                            <rlm:AddNewRelatedItemLink ID='lnkPartner' runat="server" CssClass="" ResourceType="Partner" Action="ClientView" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn Visible="false" GroupByExpression="GroupId Group By GroupId" UniqueName="GroupId" SortExpression="GroupId" DataField="GroupId"
                        meta:resourcekey="GroupName" HeaderStyle-Width="100px">
                        <FilterTemplate>
                            <rlm:GroupComboBox Type="Contract" Width="80" IsShowAll="true" meta:resourcekey="FilterCombobox"  id='rlmGroup'
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
                    <telerik:GridTemplateColumn GroupByExpression="Status Group By Status" AutoPostBackOnFilter="true" HeaderStyle-Width="100"  SortExpression="Status" UniqueName="Status" DataField="Status"
                    meta:resourcekey="Status">
                    <FilterTemplate>
                        <rlm:ContractStatusCombobox ID="radStatus"  Width="80" IsShowAll="true" meta:resourcekey="FilterCombobox" DataTextField="Name" DataValueField="Value"
                            AppendDataBoundItems="false" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Status").CurrentFilterValue %>'
                            runat="server" OnClientSelectedIndexChanged="StatusIndexChanged">
                        </rlm:ContractStatusCombobox>
                        <telerik:RadScriptBlock ID="unitRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function StatusIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "Status", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrStatusName' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn Visible="false" UniqueName="UnitPrice" meta:resourcekey="InitPrice" AllowFiltering="false">
                    <ItemTemplate>
                        <asp:Label ID='lblInitPrice' runat="server"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  Visible="false" UniqueName="LastPrice" meta:resourcekey="LastPrice" AllowFiltering="false">
                    <ItemTemplate>
                        <asp:Label ID='lblLastPrice' runat="server"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                    <telerik:GridImageColumn  Visible="false" GroupByExpression="IsActive Group By IsActive" FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                        DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                        AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                        ItemStyle-VerticalAlign="Middle"    ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="70px" />
                    </telerik:GridImageColumn>
                    <telerik:GridDateTimeColumn FilterControlWidth="120px" DataField="FromDate"
                        meta:resourcekey="FromDate" SortExpression="FromDate"
                        UniqueName="FromDate" PickerType="DatePicker" DataType="System.DateTime" AllowFiltering=false CurrentFilterFunction="GreaterThan" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="100px" />
                    </telerik:GridDateTimeColumn>
                     <telerik:GridDateTimeColumn FilterControlWidth="120px" DataField="ToDate"
                        meta:resourcekey="ToDate" SortExpression="ToDate"
                        UniqueName="ToDate" PickerType="DatePicker" DataType="System.DateTime" AllowFiltering="false" CurrentFilterFunction="LessThan" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="100px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="70"  UniqueName="TemplateColumn" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="Padding5" CommandName="Preview" Text="Edit"
                                ImageUrl="~/Resource/Image/Icon/preview.png" ToolTip="Preview" />
                            <asp:ImageButton ID="editLinkBtn" runat="server" CssClass="Padding5" CommandName="Edit" Text="Edit"
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
