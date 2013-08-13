<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.TaskList1" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/Task/GrantChart.ascx" TagName="GrantChart" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<rlm:AddNewRelatedItemLink CssClass="Bold" ID="lnkResource" runat="server" /><br />
 <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="radItems">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="radItems" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <asp:HyperLink ID='lnkAddNew' NavigateUrl="~/Page/Task/TaskAddNew.aspx" CssClass="AddItem Width100Percent" runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
        <telerik:RadGrid AutoGenerateColumns="false" ID="radItems" Width="100%" AllowFilteringByColumn="True"
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
            <MasterTableView  DataKeyNames="TaskId" AutoGenerateColumns="false" AllowFilteringByColumn="True"
                ShowFooter="True" TableLayout="Auto" runat="server" OnItemCommand="radItems_OnItemCommand">
                <Columns>
                    <telerik:GridBoundColumn FilterControlWidth="150px" DataField="Name" meta:resourcekey="Name"
                        SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                        ShowFilterIcon="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn  GroupByExpression="Status Group By Status"  UniqueName="Status" SortExpression="Status" DataField="Status"
                        meta:resourcekey="Status" HeaderStyle-Width="150px" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:Literal ID='ltrStatus' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  GroupByExpression="PercentComplete Group By PercentComplete"  UniqueName="PercentComplete" SortExpression="PercentComplete" DataField="PercentComplete"
                        meta:resourcekey="PercentComplete" HeaderStyle-Width="150px" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:Literal ID='ltrPercentComplete' runat="server"></asp:Literal>  (%)
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  GroupByExpression="CreationUserId Group By CreationUserId"  UniqueName="CreationUserId" SortExpression="CreationUserId" DataField="CreationUserId"
                        meta:resourcekey="CreationUserId" HeaderStyle-Width="150px" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:Literal ID='ltrCreationUserId' runat="server"></asp:Literal>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridImageColumn   GroupByExpression="IsActive Group By IsActive"  FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                        DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                        AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                        ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="70px" />
                    </telerik:GridImageColumn>
                    <telerik:GridDateTimeColumn AllowFiltering="false" DataField="LastModificationDate"
                        meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                        UniqueName="LastModificationDate" PickerType="DatePicker" DataType="System.DateTime" CurrentFilterFunction="LessThan" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
                        <HeaderStyle Width="80px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="70" UniqueName="TemplateColumn" AllowFiltering="false">
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
        <br />
        <div class="Row">
            <rlm:GrantChart id='grantChart' runat='server' />
        </div>
</asp:Content>