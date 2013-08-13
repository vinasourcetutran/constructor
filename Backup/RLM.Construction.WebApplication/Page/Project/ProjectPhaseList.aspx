<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectPhaseList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectPhaseList" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
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
        <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Project/ProjectPhaseAddNew.aspx" CssClass="AddItem Width100Percent"
            runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
        <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
            AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server" ShowGroupPanel="true"
            ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
            OnItemCommand="radItems_OnItemCommand"  ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView TableLayout="Auto">
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
                    SaveScrollPosition="True"></Scrolling>
            </ClientSettings>
            <MasterTableView  DataKeyNames="ProjectPhaseId" AutoGenerateColumns="false" AllowFilteringByColumn="True"
                ShowFooter="True" TableLayout="Auto" runat="server" OnItemCommand="radItems_OnItemCommand">
                <Columns>
                    <telerik:GridBoundColumn FilterControlWidth="150px" DataField="Name" meta:resourcekey="Name"
                        SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn GroupByExpression="ProjectId Group By ProjectId"  UniqueName="ProjectId" SortExpression="ProjectId" DataField="ProjectId"
                        meta:resourcekey="Project" HeaderStyle-Width="300px">
                        <FilterTemplate>
                            <rlm:ProjectComboBox Type="Contract" IsShowAll="true" id='rlmProject' meta:resourcekey="FilterCombobox"
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("ProjectId").CurrentFilterValue %>' 
                            OnClientSelectedIndexChanged="ProjectIndexChanged"
                             runat='server'/>
                            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

                                <script type="text/javascript">
                                    function ProjectIndexChanged(sender, args) {
                                        RadGridHelper.filter("<%= radItems.ClientID %>", "ProjectId", args, "EqualTo");
                                    }
                                </script>

                            </telerik:RadScriptBlock>
                        </FilterTemplate>
                        <ItemTemplate>
                            <a href='#' id='lnkProject' tabid='projectList' runat="server"></a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    
                    <telerik:GridNumericColumn HeaderStyle-Width="100px" meta:resourcekey="InitPrice"
                        SortExpression="DesignPrice" DataField="DesignPrice" UniqueName="DesignPrice"
                        AllowFiltering="false" DataType="System.Decimal"  DataFormatString="{0:c0}">
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn HeaderStyle-Width="100px" meta:resourcekey="LastPrice"
                        SortExpression="AuctualPrice" DataField="AuctualPrice" UniqueName="AuctualPrice"
                        AllowFiltering="false" DataType="System.Decimal"  DataFormatString="{0:c0}">
                    </telerik:GridNumericColumn>

                    <telerik:GridTemplateColumn  GroupByExpression="CurrencyUnitId Group By CurrencyUnitId" UniqueName="CurrencyUnitId" SortExpression="CurrencyUnitId" DataField="CurrencyUnitId"
                        meta:resourcekey="CurrencyName" HeaderStyle-Width="80px" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:Literal ID='ltrCurrentcy' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridNumericColumn HeaderStyle-Width="80px" meta:resourcekey="ExchangeRate"
                        SortExpression="ExchangeRate" DataField="ExchangeRate" UniqueName="ExchangeRate"
                        AllowFiltering="false" DataType="System.Int32" DataFormatString="{0:c0}">
                    </telerik:GridNumericColumn>

                    <telerik:GridImageColumn  GroupByExpression="IsBillable Group By IsBillable" meta:resourcekey="IsBillable" SortExpression="IsBillable"
                        DataImageUrlFields="IsBillable" DataType="System.Boolean" UniqueName="IsBillable"
                        AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                        ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="80px" />
                    </telerik:GridImageColumn>
                    <telerik:GridImageColumn GroupByExpression="IsCurrentProjectPhase Group By IsCurrentProjectPhase"  meta:resourcekey="IsCurrentProjectPhase" SortExpression="IsCurrentProjectPhase"
                        DataImageUrlFields="IsCurrentProjectPhase" DataType="System.Boolean" UniqueName="IsCurrentProjectPhase"
                        AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                        ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="80px" />
                    </telerik:GridImageColumn>
                    <telerik:GridImageColumn  GroupByExpression="IsActive Group By IsActive" FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                        DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                        AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                        ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="70px" />
                    </telerik:GridImageColumn>
                    <telerik:GridTemplateColumn GroupByExpression="Type Group By Type"  UniqueName="Type" SortExpression="Type" DataField="Type"
                        meta:resourcekey="Type" HeaderStyle-Width="100px" FilterControlWidth="50px">
                        <FilterTemplate>
                            <rlm:ProjectPhaseTypeComboBox Width="100px" IsShowAll="true" id='rlmType' meta:resourcekey="FilterCombobox"
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Type").CurrentFilterValue %>' 
                            OnClientSelectedIndexChanged="TypeIndexChanged"
                             runat='server'/>
                            <telerik:RadScriptBlock ID="typeRadScriptBlock" runat="server">

                                <script type="text/javascript">
                                    function TypeIndexChanged(sender, args) {
                                        RadGridHelper.filter("<%= radItems.ClientID %>", "Type", args, "EqualTo");
                                    }
                                </script>
                            </telerik:RadScriptBlock>
                        </FilterTemplate>
                        <ItemTemplate>
                           <asp:Literal ID='ltrType' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridDateTimeColumn AllowFiltering="false" DataField="LastModificationDate"
                        meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                        UniqueName="LastModificationDate" PickerType="DatePicker" DataType="System.DateTime" CurrentFilterFunction="LessThan" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}">
                        <HeaderStyle Width="150px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridTemplateColumn HeaderText="" UniqueName="TemplateColumn" AllowFiltering="false">
                        <HeaderStyle Width="100px" />
                        <ItemTemplate>
                            <rlm:AddNewRelatedItemLink ResourceType = "ProjectPhase" IsShowText="false" Action="ClientView" CssClass="Preview" ID='lnkPreview' runat="server" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Compare" Text="Compare" ImageUrl="~/Resource/Image/Icon/Compare.png" ToolTip="Compare" />
                            <asp:ImageButton ID="editLinkBtn" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/Resource/Image/edit.gif" ToolTip="Edit" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings AllowGroupExpandCollapse="True" AllowDragToGroup="True" AllowColumnsReorder="True">
                <Scrolling AllowScroll="false" />
            </ClientSettings>
        </telerik:RadGrid>
</asp:Content>
