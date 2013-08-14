<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupList.ascx.cs" Inherits="RLM.Construction.WebApplication.UserControl.GroupList" %>
<asp:HyperLink ID='lnkAddNew' CssClass="AddItem Width100Percent" runat="server" meta:resourcekey="AddNew"></asp:HyperLink>
<telerik:RadGrid AutoGenerateColumns="false" ID="radGroupList" AllowFilteringByColumn="True"
    AllowSorting="True" AllowPaging="true" PageSize="10" ShowFooter="True" runat="server"
    ShowHeader="true" GridLines="None" OnNeedDataSource="radGroupList_OnNeedDataSource"
    OnItemCommand="radGroupList_OnItemCommand" ShowStatusBar="true">
    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Visible="true" />
    <GroupingSettings CaseSensitive="false" />
    <MasterTableView TableLayout="Auto">
    </MasterTableView>
    <ClientSettings>
        <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" UseStaticHeaders="True"
            SaveScrollPosition="True"></Scrolling>
    </ClientSettings>
    <MasterTableView DataKeyNames="GroupId" AutoGenerateColumns="false" EditMode="InPlace"
        AllowFilteringByColumn="True" ShowFooter="True" TableLayout="Auto" runat="server"
        OnItemCommand="radGroupList_OnItemCommand">
        <Columns>
            <telerik:GridBoundColumn DataField="Code" meta:resourcekey="Code" SortExpression="Code"
                UniqueName="Code" FilterControlWidth="90px" AutoPostBackOnFilter="false" CurrentFilterFunction="Contains"
                ShowFilterIcon="true">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn FilterControlWidth="105px" DataField="Name" meta:resourcekey="Name"
                SortExpression="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                ShowFilterIcon="true">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn FilterControlWidth="200px" DataField="Description" meta:resourcekey="Description"
                SortExpression="Description" ShowFilterIcon="true" AllowFiltering="true" CurrentFilterFunction='contains'
                AutoPostBackOnFilter='true' UniqueName="Description">
            </telerik:GridBoundColumn>
            <telerik:GridImageColumn GroupByExpression="IsActive Group By IsActive" FilterControlWidth="50px" meta:resourcekey="IsActive" SortExpression="IsActive"
                DataImageUrlFields="IsActive" DataType="System.Boolean" UniqueName="IsActive"
                AllowFiltering="false" DataImageUrlFormatString="~/Resource/Image/Icon/{0}.png"
                ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                <HeaderStyle Width="100px" />
            </telerik:GridImageColumn>
            <telerik:GridDateTimeColumn FilterControlWidth="150px" DataField="LastModificationDate"
                meta:resourcekey="LastModificationDate" SortExpression="LastModificationDate"
                UniqueName="LastModificationDate" PickerType="DatePicker" DataFormatString="{0:D}">
                <HeaderStyle Width="160px" />
            </telerik:GridDateTimeColumn>
            <telerik:GridTemplateColumn HeaderText="" UniqueName="TemplateColumn" AllowFiltering="false">
                <ItemTemplate>
                    <asp:ImageButton ID="editLinkBtn" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/Resource/Image/edit.gif"
                        ToolTip="Edit" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="deleteBtn" runat="server" OnClientClick="return confirm('Are you sure you want to delete the selected product?')"
                        CommandName="Delete" Text="Delete" ImageUrl="~/Resource/Image/delete.gif" ToolTip="Delete" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings>
        <Scrolling AllowScroll="false" />
    </ClientSettings>
</telerik:RadGrid>

<script type="text/javascript">
    //var groupGridId = "<%= radGroupList.ClientID %>";
    //    function groupRowItemClicked(sender, e) {
    //        RadGridHelper.groupRowItemClicked($find(groupGridId),sender,e);
    //    }
</script>

