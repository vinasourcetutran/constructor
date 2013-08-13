<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="AdvanceRequestList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.AdvanceRequestList" %>
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
    <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Contract/AdvanceRequestAddNew.aspx" CssClass="AddItem"
        runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
    <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
        ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
        OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound">
        <MasterTableView DataKeyNames="AdvanceRequestId" AutoGenerateColumns="false" 
            AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto" runat="server"
            OnItemCommand="radItems_OnItemCommand">
            <Columns>
                <telerik:GridTemplateColumn GroupByExpression="ContractId GROUP BY ContractId"  UniqueName="ContractId" 
                    SortExpression="ContractId" DataField="ContractId" meta:resourcekey="ContractName"
                    HeaderStyle-Width="200px" ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:ContractComboBox IsShowAll="true" meta:resourcekey="FilterCombobox" ID='rlmContract'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("ContractId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="ContractIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="ContractRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function ContractIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "ContractId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrContractName' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn GroupByExpression="RequestContactorId GROUP BY RequestContactorId"  UniqueName="RequestContactorId" 
                    SortExpression="RequestContactorId" DataField="RequestContactorId" meta:resourcekey="RequestContactorId"
                    HeaderStyle-Width="200px" ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:ContactorComboBox IsShowAll="true" meta:resourcekey="FilterCombobox" ID='rlmRequestContactor'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("RequestContactorId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="RequestContactorIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="RequestContactorRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function RequestContactorIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "RequestContactorId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrRequestContactorName' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridBoundColumn HeaderStyle-Width="110px" DataField="RequestAmount" meta:resourcekey="RequestAmount"
                    SortExpression="RequestAmount" UniqueName="RequestAmount" AutoPostBackOnFilter="true"  AllowFiltering="false">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn GroupByExpression="CurrencyUnitId GROUP BY CurrencyUnitId"  UniqueName="CurrencyUnitId" 
                    SortExpression="CurrencyUnitId" DataField="CurrencyUnitId" meta:resourcekey="CurrencyUnitId"
                    HeaderStyle-Width="200px" ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:UnitComboBox Type="Money" IsShowAll="true" meta:resourcekey="FilterCombobox" ID='rlmCurrencyUnit'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("CurrencyUnitId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="CurrencyUnitIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="CurrencyUnitRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function CurrencyUnitIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "CurrencyUnitId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrCurrencyUnitName' runat="server"></asp:Literal>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="RequestComment" meta:resourcekey="RequestComment"
                    SortExpression="RequestComment" UniqueName="RequestComment"  AllowFiltering="false">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn GroupByExpression="Status GROUP BY Status"  UniqueName="Status" 
                    SortExpression="Status" DataField="Status" meta:resourcekey="Status"
                    HeaderStyle-Width="200px" ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:AdvanveRequestStatusComboBox IsShowAll="true" meta:resourcekey="FilterCombobox" ID='rlmAdvanceRequest'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Status").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="StatusIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="StatusRadScriptBlock" runat="server">

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
                <telerik:GridDateTimeColumn ReadOnly="true" FilterControlWidth="150px" DataField="RequestDate"
                    meta:resourcekey="RequestDate" SortExpression="RequestDate"
                    UniqueName="RequestDate" PickerType="DatePicker" DataFormatString="{0:D}">
                    <HeaderStyle Width="160px" />
                </telerik:GridDateTimeColumn>
               <telerik:GridTemplateColumn HeaderText="" UniqueName="TemplateColumn" HeaderStyle-Width="70px" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="Padding5" CommandName="Preview" Text="Edit"
                                ImageUrl="~/Resource/Image/Icon/preview.png" ToolTip="Preview" />
                            <asp:ImageButton ID="editLinkBtn" runat="server" CssClass="Padding5" CommandName="Edit" Text="Edit"
                                ImageUrl="~/Resource/Image/edit.gif" ToolTip="Edit" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        
    </telerik:RadGrid>
</asp:Content>