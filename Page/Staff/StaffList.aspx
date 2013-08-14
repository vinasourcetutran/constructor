<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffList" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm"  %>
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
        <rlm:AddNewRelatedItemLink CssClass="AddItem" meta:resourceKey="AddNewItem" runat="server" ResourceType="Staff" ResourceId="0" Action="ClientAddNew" />
        <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" AllowFilteringByColumn="True"
            AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="false" runat="server"
            ShowHeader="true" GridLines="None" OnNeedDataSource="radItems_OnNeedDataSource"
            ShowStatusBar="true" OnItemDataBound="radItems_OnItemDataBound">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
            <GroupingSettings CaseSensitive="false" />
            <ClientSettings>
                <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
                    SaveScrollPosition="True"></Scrolling>
            </ClientSettings>
            <MasterTableView  DataKeyNames="StaffId" AutoGenerateColumns="false" AllowFilteringByColumn="True"
                ShowFooter="True" TableLayout="Auto" runat="server" OnItemCommand="radItems_OnItemCommand">
                <Columns>
                <telerik:GridTemplateColumn  UniqueName="Photo" meta:resourcekey="Photo" AllowFiltering="false">
                        <ItemTemplate>
                           <asp:Image ID='imgPhoto' runat="server" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn FilterControlWidth="150px" DataField="FullName" meta:resourcekey="FullName"
                        SortExpression="FullName" UniqueName="FullName" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn GroupByExpression="DeptId Group By DeptId" UniqueName="DeptId" SortExpression="DeptId" DataField="DeptId"
                        meta:resourcekey="DeptName" HeaderStyle-Width="150px" ShowSortIcon="true">
                        <FilterTemplate>
                            <rlm:GroupComboBox Type="Department" IsShowAll="true" meta:resourcekey="FilterCombobox"  id='rlmDept'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("DeptId").CurrentFilterValue %>' OnClientSelectedIndexChanged="DeptIdIndexChanged"
                             runat='server'/>
                            <telerik:RadScriptBlock ID="DeptIdRadScriptBlock1" runat="server">

                                <script type="text/javascript">
                                    function DeptIdIndexChanged(sender, args) {
                                        RadGridHelper.filter("<%= radItems.ClientID %>", "DeptId", args, "EqualTo");
                                    }
                                </script>
                            </telerik:RadScriptBlock>
                        </FilterTemplate>
                        <ItemTemplate>
                            <asp:Literal ID='ltrDeptName' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn GroupByExpression="JobTitleId Group By JobTitleId" UniqueName="JobTitleId" SortExpression="JobTitleId" DataField="JobTitleId"
                        meta:resourcekey="JobTitleName" HeaderStyle-Width="150px" ShowSortIcon="true">
                        <FilterTemplate>
                            <rlm:RoleComboBox RoleType=JobTitle IsShowAll="true" meta:resourcekey="FilterCombobox"  id='rlmJobTitle'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("JobTitleId").CurrentFilterValue %>' OnClientSelectedIndexChanged="JobTitleIdIndexChanged"
                             runat='server'/>
                            <telerik:RadScriptBlock ID="JobTitleIdRadScriptBlock1" runat="server">

                                <script type="text/javascript">
                                    function JobTitleIdIndexChanged(sender, args) {
                                        RadGridHelper.filter("<%= radItems.ClientID %>", "JobTitleId", args, "EqualTo");
                                    }
                                </script>
                            </telerik:RadScriptBlock>
                        </FilterTemplate>
                        <ItemTemplate>
                            <asp:Literal ID='ltrJobTitleName' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn GroupByExpression="Sex Group By Sex" UniqueName="Sex" SortExpression="Sex" DataField="Sex"
                        meta:resourcekey="Sex" HeaderStyle-Width="150px" ShowSortIcon="true">
                        <FilterTemplate>
                            <rlm:SexTypeComboBox IsShowAll="true" meta:resourcekey="FilterCombobox"  id='rlmSex'
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Sex").CurrentFilterValue %>' OnClientSelectedIndexChanged="SexIndexChanged"
                             runat='server'/>
                            <telerik:RadScriptBlock ID="SexRadScriptBlock1" runat="server">

                                <script type="text/javascript">
                                    function SexIndexChanged(sender, args) {
                                        RadGridHelper.filter("<%= radItems.ClientID %>", "Sex", args, "EqualTo");
                                    }
                                </script>
                            </telerik:RadScriptBlock>
                        </FilterTemplate>
                        <ItemTemplate>
                            <asp:Literal ID='ltrSex' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  GroupByExpression="StartWorkingDate Group By StartWorkingDate"  UniqueName="StartWorkingDate" SortExpression="StartWorkingDate" DataField="StartWorkingDate"
                        meta:resourcekey="StartWorkingDate" HeaderStyle-Width="150px" AllowFiltering="false">
                        <ItemTemplate>
                           <asp:Literal ID='ltrStartWorkingDate' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridImageColumn   GroupByExpression="IsActive Group By IsActive"  FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                        DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                        AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                        ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="70px" />
                    </telerik:GridImageColumn>
                    <telerik:GridDateTimeColumn  FilterControlWidth="150px" DataField="LastModificationDate"
                        meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                        UniqueName="LastModificationDate" PickerType="DatePicker" DataType="System.DateTime" CurrentFilterFunction="LessThan" DataFormatString="{0:D}">
                        <HeaderStyle Width="150px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridTemplateColumn HeaderText="" UniqueName="TemplateColumn" AllowFiltering="false">
                        <ItemTemplate>
                        <rlm:AddNewRelatedItemLink ID='lnkPreview' IsShowText=false ResourceType="Staff" Action="ClientView" runat="server" CssClass="Preview" />
                        <rlm:AddNewRelatedItemLink ID='lnkEdit'  IsShowText=false ResourceType="Staff" runat="server" Action="ClientEdit" CssClass="Edit" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="false" />
            </ClientSettings>
        </telerik:RadGrid>
</asp:Content>
