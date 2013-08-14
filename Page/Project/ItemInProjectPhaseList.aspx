<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ItemInProjectPhaseList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ItemInProjectPhaseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="ExportToolbar None">
    <asp:ImageButton ID='btnExportToPdf' OnClick="btnExportToPdf_ExportToPdf" runat="server" ImageUrl="~/Resource/Image/Icon/pdf.png" />
    <asp:ImageButton ID='btnExportToWord' OnClick="btnExportToWord_ExportToWord" runat="server" ImageUrl="~/Resource/Image/Icon/word.png" />
    <asp:ImageButton ID='btnExportToExcel' OnClick="btnExportToExcel_ExportToExcel" runat="server" ImageUrl="~/Resource/Image/Icon/excel.png" />
    </div>
     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radItems" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadGrid Width="100%"  AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowAutomaticInserts="false" AllowPaging="true" PageSize="10" ShowGroupPanel="true"
        ShowFooter="True" runat="server" ShowHeader="true" OnNeedDataSource="radItems_OnNeedDataSource"
        OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound"
        OnInsertCommand="radItems_OnItemInsert" OnUpdateCommand="radItems_OnItemUpdate" OnItemCreated="radItems_OnItemCreated">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
        <MasterTableView EditMode="InPlace" CommandItemDisplay="Bottom" DataKeyNames="ItemInProjectId"
            AllowFilteringByColumn="True"
            runat="server">
            <Columns>
                <telerik:GridTemplateColumn GroupByExpression="ProjectId GROUP BY ProjectId"  EditFormColumnIndex="0" UniqueName="ProjectId" ColumnEditorID="drpProjectEditor"
                    SortExpression="ProjectId" DataField="ProjectId" meta:resourcekey="ProjectName"
                    ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:ProjectComboBox IsShowAll="true" meta:resourcekey="FilterCombobox" ID='rlmProject'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("ProjectId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="ProjectIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

                            <script type="text/javascript">
                                function ProjectIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "ProjectId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrProjectName' runat="server"></asp:Literal>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <rlm:ProjectComboBox IsShowActiveOnly="true" ID='drpProjectEditor' runat="server">
                        </rlm:ProjectComboBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn  GroupByExpression="ProjectPhaseId GROUP BY ProjectPhaseId" EditFormColumnIndex="1" UniqueName="ProjectPhaseId" ColumnEditorID="drpProjectPhaseEditor"
                    SortExpression="ProjectPhaseId" DataField="ProjectPhaseId" meta:resourcekey="ProjectPhaseName"
                    HeaderStyle-Width="150px" ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:ProjectPhaseComboBox IsShowAll="true" IsShowActiveOnly="true" meta:resourcekey="FilterCombobox" ID='rlmProjectPhase'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("ProjectPhaseId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="ProjectPhaseIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="ProjectPhaseRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function ProjectPhaseIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "ProjectPhaseId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrProjectPhaseName' runat="server"></asp:Literal>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <rlm:ProjectPhaseComboBox ID='drpProjectPhaseEditor' runat="server" />
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn  GroupByExpression="ItemId GROUP BY itemId"  EditFormColumnIndex="0" UniqueName="ItemId" ColumnEditorID="drpItemEditor"
                    SortExpression="ItemId" DataField="ItemId" meta:resourcekey="ItemName" HeaderStyle-Width="200px"
                    ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:ItemComboBox IsShowAll="true" IsShowActiveOnly="true" meta:resourcekey="FilterCombobox" ID='rlmItem'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("ItemId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="ItemIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="ItemRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function ItemIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "ItemId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrItemName' runat="server"></asp:Literal>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <rlm:ItemComboBox ID='drpItemEditor' runat="server" />
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn EditFormColumnIndex="1" HeaderStyle-Width="120px" meta:resourcekey="Quantity"
                    SortExpression="Quantity" DataField="Quantity" UniqueName="Quantity" AllowFiltering="false"
                    DataType="System.Int32">
                    <ItemTemplate>
                        <asp:Literal ID='ltrQuantity' runat="server"></asp:Literal>
                    </ItemTemplate>
                    <EditItemTemplate>  
                        <asp:TextBox ID='txtQuantity' runat="server" Width="50"></asp:TextBox>
                        (<asp:Literal ID='ltrQuantityUnitName' runat="server"></asp:Literal>)
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridNumericColumn EditFormColumnIndex="0" HeaderStyle-Width="70px" meta:resourcekey="UnitPrice"
                    SortExpression="UnitPrice" DataField="UnitPrice" UniqueName="UnitPrice" AllowFiltering="false"
                    DataType="System.Decimal" DataFormatString="{0:C0}">
                </telerik:GridNumericColumn>
                <telerik:GridTemplateColumn  GroupByExpression="PriceUnitId GROUP BY PriceUnitId"  EditFormColumnIndex="0" UniqueName="PriceUnitId"
                    SortExpression="PriceUnitId" DataField="PriceUnitId" meta:resourcekey="PriceUnit" HeaderStyle-Width="50px"
                    ShowSortIcon="true">
                    <FilterTemplate>
                        <rlm:UnitComboBox Width="100" Type="Money" IsShowAll="true" meta:resourcekey="FilterCombobox" ID='rlmPriceUnit'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("PriceUnitId").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="PriceUnitIdIndexChanged" runat='server' />
                        <telerik:RadScriptBlock ID="PriceUnitIdRadScriptBlock" runat="server">

                            <script type="text/javascript">
                                function PriceUnitIdIndexChanged(sender, args) {
                                    RadGridHelper.filter("<%= radItems.ClientID %>", "PriceUnitId", args, "EqualTo");
                                }
                            </script>

                        </telerik:RadScriptBlock>
                    </FilterTemplate>
                    <ItemTemplate>
                        <asp:Literal ID='ltrPriceUnitName' runat="server"></asp:Literal>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <rlm:UnitComboBox ID='drpPriceUnitEditor' Width="50" Type="Money" IsShowAll=false runat="server" />
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridNumericColumn EditFormColumnIndex="0" HeaderStyle-Width="70px" meta:resourcekey="ExchangeRate"
                    SortExpression="ExchangeRate" DataField="ExchangeRate" UniqueName="ExchangeRate" AllowFiltering="false"
                    DataType="System.int32" DataFormatString="{0:C0}">
                </telerik:GridNumericColumn>

                <telerik:GridTemplateColumn  GroupByExpression="IsActive GROUP BY IsActive"  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                    AllowFiltering="false" EditFormColumnIndex="1" UniqueName="IsActive" SortExpression="IsActive"
                    DataField="IsActive" meta:resourcekey="IsActive" HeaderStyle-Width="70px">
                    <ItemTemplate>
                        <img src="../../Resource/Image/Icon/<%# Eval("IsActive") %>.png" alt="<%# Eval("IsActive") %>" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input id='chkIsActive' runat="server" type="checkbox" />
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridDateTimeColumn ReadOnly="true" DataField="LastModificationDate" AllowFiltering=false meta:resourcekey="LastModificationDate"
                    SortExpression="LastModificationDate" UniqueName="LastModificationDate" PickerType="DatePicker"
                    DataType="System.DateTime" CurrentFilterFunction="LessThan" >
                    <HeaderStyle Width="120px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" HeaderStyle-Width="10px"
                    UniqueName="EditColumn">
                </telerik:GridEditCommandColumn>
                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="10px" UniqueName="DeleteColumn"
                    AllowFiltering="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete"
                            ImageUrl="~/Resource/Image/delete.gif" ToolTip="Delete" OnClientClick="return confirm('Bạn có thật sự muốn xóa thông tin này không?');" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <CommandItemSettings ShowAddNewRecordButton="true" ShowExportToExcelButton="true" ShowExportToWordButton="true" ShowExportToPdfButton="false" ShowExportToCsvButton="false"/>
            
        </MasterTableView>
        <ClientSettings AllowGroupExpandCollapse="True" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                AllowColumnsReorder="True">
            <Scrolling AllowScroll="false" />
        </ClientSettings>
        <ExportSettings FileName="Vat_Tu_Cong_Trinh" ExportOnlyData="true" IgnorePaging="true" OpenInNewWindow="true">
            <Pdf AllowAdd="false" AllowCopy="true" AllowModify="false"  AllowPrinting="true"/>
            <Csv FileExtension="csv" />
            <Excel FileExtension="xls" />
        </ExportSettings>
        <GroupingSettings ShowUnGroupButton="true" />
    </telerik:RadGrid>
    <telerik:RadWindowManager ID="windowManager" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
