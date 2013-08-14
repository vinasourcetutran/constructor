<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Partner.ItemList" %>
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
    <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Partner/ItemAddNew.aspx" CssClass="AddItem Width100Percent"
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
        <MasterTableView DataKeyNames="PartnerId" AutoGenerateColumns="false" 
            AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto" runat="server"
            OnItemCommand="radItems_OnItemCommand">
            <Columns>
             <telerik:GridTemplateColumn HeaderStyle-Width="20" meta:resourcekey="OrderIndex" UniqueName="STT" ShowFilterIcon="false" AllowFiltering="false" >
                <ItemTemplate>
                    <asp:Literal ID='ltrOrderIndex' runat="server"></asp:Literal>
                </ItemTemplate>
             </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn DataField="TaxCode" Visible="true" meta:resourcekey="Code" SortExpression="TaxCode"
                    UniqueName="TaxCode" FilterControlWidth="90px" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlWidth="105px" DataField="Name" meta:resourcekey="Name"
                    SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                    ShowFilterIcon="true">
                    <ItemTemplate>
                        <a href='#' id='lnkName' runat="server"></a>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn Visible="false" GroupByExpression="GroupId Group By GroupId"  UniqueName="GroupId" SortExpression="GroupId" DataField="GroupId" meta:resourcekey="GroupName"
                    HeaderStyle-Width="200px">
                    <FilterTemplate>
                        <rlm:GroupComboBox Type="Partner" ID="radGroup" AppendDataBoundItems="false" 
                        IsShowAll="true" meta:resourcekey="FilterCombobox" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("GroupId").CurrentFilterValue %>'
                            runat="server" OnClientSelectedIndexChanged="GroupIndexChanged">
                        </rlm:GroupComboBox>
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
                <telerik:GridNumericColumn FilterControlWidth="50px" meta:resourcekey="Phone"
                    SortExpression="Phone" DataField="Phone" UniqueName="Phone"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn FilterControlWidth="50px" meta:resourcekey="Fax"
                    SortExpression="Fax" DataField="Fax" UniqueName="Fax"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn FilterControlWidth="50px" meta:resourcekey="Email"
                    SortExpression="Email" DataField="Email" UniqueName="Email"
                    AllowFiltering="true">
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn meta:resourcekey="RepresentativeName"
                    SortExpression="RepresentativeName" DataField="RepresentativeName" UniqueName="RepresentativeName"
                    AllowFiltering="true">
                </telerik:GridBoundColumn>
                <telerik:GridImageColumn GroupByExpression="IsActive Group By IsActive"  FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                    DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                    AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                    ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle Width="100px" />
                </telerik:GridImageColumn>
                <telerik:GridDateTimeColumn Visible="false" FilterControlWidth="120px" DataField="LastModificationDate"
                    meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                    UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="160px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridTemplateColumn HeaderText=""  HeaderStyle-Width="70px"  UniqueName="TemplateColumn" AllowFiltering="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server"  CssClass="Padding5"  CommandName="Preview" Text="Preview" ImageUrl="~/Resource/Image/Icon/preview.png"
                            ToolTip="Preview" />
                        <asp:ImageButton ID="editLinkBtn" runat="server"  CssClass="Padding5"  CommandName="Edit" Text="Edit" ImageUrl="~/Resource/Image/edit.gif"
                            ToolTip="Edit" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Scrolling AllowScroll="false" />
        </ClientSettings>
    </telerik:RadGrid>
</asp:Content>
