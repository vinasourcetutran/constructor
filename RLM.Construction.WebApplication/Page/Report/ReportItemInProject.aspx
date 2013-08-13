<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ReportItemInProject.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Report.ReportItemInProject" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/System/UnitConvertorList.ascx" TagName="UnitConvertorList" TagPrefix="rlm" %>
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
    <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
        AllowSorting="True" AllowAutomaticInserts="false" AllowPaging="true" PageSize="10" ShowGroupPanel="true"
        ShowFooter="false" runat="server" ShowHeader="true" OnNeedDataSource="radItems_OnNeedDataSource"
        OnItemCommand="radItems_OnItemCommand" ShowStatusBar="true" OnItemDataBound="radItems_OnOtemDataBound"
        OnInsertCommand="radItems_OnItemInsert" OnUpdateCommand="radItems_OnItemUpdate" OnItemCreated="radItems_OnItemCreated">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
        <MasterTableView ShowGroupFooter="true" EditMode="InPlace" CommandItemDisplay="Bottom" DataKeyNames="ItemInProjectId"
            AllowFilteringByColumn="True"
            runat="server">
            <GroupByExpressions>
                    <telerik:GridGroupByExpression>
                        <SelectFields>
                            <telerik:GridGroupByField FieldAlias="ProjectId" meta:resourcekey="ProjectName" FieldName="ProjectId"></telerik:GridGroupByField>
                        </SelectFields>
                        <GroupByFields>
                            <telerik:GridGroupByField SortOrder="Ascending" FieldName="ProjectId"></telerik:GridGroupByField>
                        </GroupByFields>
                    </telerik:GridGroupByExpression>
                </GroupByExpressions>
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
                        <rlm:AddNewRelatedItemLink ID='lnkProject' CssClass="" runat="server" />
                    </ItemTemplate>
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
                        <rlm:AddNewRelatedItemLink ID='lnkProjectPhase' CssClass=""  runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn Aggregate="Count" GroupByExpression="ItemId GROUP BY itemId"  EditFormColumnIndex="0" UniqueName="ItemId" ColumnEditorID="drpItemEditor"
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
                        <rlm:AddNewRelatedItemLink  CssClass="" ID='lnkItem' runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn Aggregate="Sum" DataField="Quantity"  AllowFiltering="false" UniqueName="Quantity" meta:resourcekey="Quantity" HeaderStyle-Width="140px">
                    <ItemTemplate>
                        <asp:Label ID='lblQuantity' runat="server"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn  GroupByExpression="UnitPrice GROUP BY UnitPrice"  EditFormColumnIndex="0" UniqueName="UnitPrice"
                    SortExpression="UnitPrice" AllowFiltering="false" DataField="UnitPrice" meta:resourcekey="UnitPrice" HeaderStyle-Width="120px"
                    ShowSortIcon="true">
                    <ItemTemplate>
                        <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataType=System.Decimal DataField="Total"  UniqueName="TotalPrice"
                    SortExpression="TotalPrice" AllowFiltering="false" meta:resourcekey="TotalPrice" HeaderStyle-Width="120px"
                    ShowSortIcon="true">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn  GroupByExpression="IsActive GROUP BY IsActive"  ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                    AllowFiltering="false" EditFormColumnIndex="1" UniqueName="IsActive" SortExpression="IsActive"
                    DataField="IsActive" meta:resourcekey="IsActive" HeaderStyle-Width="70px">
                    <ItemTemplate>
                        <img src="../../Resource/Image/Icon/<%# Eval("IsActive") %>.png" alt="<%# Eval("IsActive") %>" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridDateTimeColumn ReadOnly="true" DataField="LastModificationDate" meta:resourcekey="LastModificationDate"
                    SortExpression="LastModificationDate" UniqueName="LastModificationDate" PickerType="DatePicker"
                    DataType="System.DateTime" CurrentFilterFunction="LessThan" DataFormatString="{0:D}">
                    <HeaderStyle Width="180px" />
                </telerik:GridDateTimeColumn>
            </Columns>
            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToExcelButton="true" ShowExportToWordButton="true" ShowExportToPdfButton="false" ShowExportToCsvButton="false"/>
        </MasterTableView>
        <ClientSettings AllowGroupExpandCollapse="True" ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
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
    <div class="Row">
        <rlm:UnitConvertorList ID='unitConvertor' IsAllowEdit="false" runat="server" />
    </div>
</asp:Content>