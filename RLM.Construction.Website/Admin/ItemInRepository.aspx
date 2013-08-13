
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ItemInRepository.aspx.cs" Inherits="ItemInRepository" Title="ItemInRepository List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">ItemInRepository List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="ItemInRepositoryDataSource"
			DataKeyNames="RepositoryId, ItemId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ItemInRepository.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:TemplateField HeaderText="RepositoryId">
				<ItemTemplate>
						<asp:Repeater ID="RepositoryId1" runat="server" DataSourceID="RepositoryFilter1">
							<ItemTemplate>
								<%# Eval("RepositoryManagerStaffId") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="RepositoryFilter1" runat="server"
							DataSourceID="RepositoryDataSource1"
							Filter='<%# String.Format("RepositoryId = {0}", Eval("RepositoryId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="ItemId">
				<ItemTemplate>
						<asp:Repeater ID="ItemId2" runat="server" DataSourceID="ItemFilter2">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="ItemFilter2" runat="server"
							DataSourceID="ItemDataSource2"
							Filter='<%# String.Format("ItemId = {0}", Eval("ItemId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="TotalQuantity" HeaderText="TotalQuantity" SortExpression="TotalQuantity"  />
				<asp:BoundField DataField="AvailabelQuantity" HeaderText="AvailabelQuantity" SortExpression="AvailabelQuantity"  />
				<asp:BoundField DataField="ReserveQuantity" HeaderText="ReserveQuantity" SortExpression="ReserveQuantity"  />
				<asp:BoundField DataField="ReturnQuantity" HeaderText="ReturnQuantity" SortExpression="ReturnQuantity"  />
				<asp:BoundField DataField="AdjustQuantity" HeaderText="AdjustQuantity" SortExpression="AdjustQuantity"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  />
				<asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority"  />
				<asp:BoundField DataField="BaseUnitId" HeaderText="BaseUnitId" SortExpression="BaseUnitId"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ItemInRepository Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnItemInRepository" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/ItemInRepositoryEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:RepositoryDataSource ID="RepositoryDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ItemDataSource ID="ItemDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ItemInRepositoryDataSource ID="ItemInRepositoryDataSource" runat="server"
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
		</data:ItemInRepositoryDataSource>
	    		
</asp:Content>



