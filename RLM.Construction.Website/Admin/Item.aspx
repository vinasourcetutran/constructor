
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Item.aspx.cs" Inherits="Item" Title="Item List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Item List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="ItemDataSource"
			DataKeyNames="ItemId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Item.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" ReadOnly />
				<asp:TemplateField HeaderText="GroupId">
				<ItemTemplate>
						<asp:Repeater ID="GroupId1" runat="server" DataSourceID="GroupFilter1">
							<ItemTemplate>
								<%# Eval("ParentGroupId") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="GroupFilter1" runat="server"
							DataSourceID="GroupDataSource1"
							Filter='<%# String.Format("GroupId = {0}", Eval("GroupId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"  />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression=""  />
				<asp:TemplateField HeaderText="BaseUnitId">
				<ItemTemplate>
						<asp:Repeater ID="UnitId2" runat="server" DataSourceID="UnitFilter2">
							<ItemTemplate>
								<%# Eval("Name") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UnitFilter2" runat="server"
							DataSourceID="UnitDataSource2"
							Filter='<%# String.Format("UnitId = {0}", Eval("BaseUnitId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="UsedUnitId">
				<ItemTemplate>
						<asp:Repeater ID="UnitId3" runat="server" DataSourceID="UnitFilter3">
							<ItemTemplate>
								<%# Eval("Name") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UnitFilter3" runat="server"
							DataSourceID="UnitDataSource3"
							Filter='<%# String.Format("UnitId = {0}", Eval("UsedUnitId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Density" HeaderText="Density" SortExpression="Density"  />
				<asp:BoundField DataField="TotalQuantity" HeaderText="TotalQuantity" SortExpression="TotalQuantity"  />
				<asp:BoundField DataField="AvailabelQuantity" HeaderText="AvailabelQuantity" SortExpression="AvailabelQuantity"  />
				<asp:BoundField DataField="ReserveQuantity" HeaderText="ReserveQuantity" SortExpression="ReserveQuantity"  />
				<asp:BoundField DataField="ReturnQuantity" HeaderText="ReturnQuantity" SortExpression="ReturnQuantity"  />
				<asp:BoundField DataField="AdjustQuantity" HeaderText="AdjustQuantity" SortExpression="AdjustQuantity"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable"  />
				<asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Item Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnItem" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/ItemEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:GroupDataSource ID="GroupDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:UnitDataSource ID="UnitDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:UnitDataSource ID="UnitDataSource3" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ItemDataSource ID="ItemDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ItemDataSource>
	    		
</asp:Content>



