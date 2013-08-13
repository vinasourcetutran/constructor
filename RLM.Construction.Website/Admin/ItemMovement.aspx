
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ItemMovement.aspx.cs" Inherits="ItemMovement" Title="ItemMovement List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">ItemMovement List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="ItemMovementDataSource"
			DataKeyNames="RepositoryMovementId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ItemMovement.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:TemplateField HeaderText="ItemId">
				<ItemTemplate>
						<asp:Repeater ID="ItemId1" runat="server" DataSourceID="ItemFilter1">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="ItemFilter1" runat="server"
							DataSourceID="ItemDataSource1"
							Filter='<%# String.Format("ItemId = {0}", Eval("ItemId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="FromRepositoryId">
				<ItemTemplate>
						<asp:Repeater ID="RepositoryId2" runat="server" DataSourceID="RepositoryFilter2">
							<ItemTemplate>
								<%# Eval("RepositoryManagerStaffId") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="RepositoryFilter2" runat="server"
							DataSourceID="RepositoryDataSource2"
							Filter='<%# String.Format("RepositoryId = {0}", Eval("FromRepositoryId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="ToRepositoryId">
				<ItemTemplate>
						<asp:Repeater ID="RepositoryId3" runat="server" DataSourceID="RepositoryFilter3">
							<ItemTemplate>
								<%# Eval("RepositoryManagerStaffId") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="RepositoryFilter3" runat="server"
							DataSourceID="RepositoryDataSource3"
							Filter='<%# String.Format("RepositoryId = {0}", Eval("ToRepositoryId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="FromRepositoryManagerId" HeaderText="FromRepositoryManagerId" SortExpression="FromRepositoryManagerId"  />
				<asp:BoundField DataField="ToRepositoryManagerId" HeaderText="ToRepositoryManagerId" SortExpression="ToRepositoryManagerId"  />
				<asp:BoundField DataField="StranferUserId" HeaderText="StranferUserId" SortExpression="StranferUserId"  />
				<asp:BoundField DataField="ReceiverUserId" HeaderText="ReceiverUserId" SortExpression="ReceiverUserId"  />
				<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"  />
				<asp:BoundField DataField="TotalQuantity" HeaderText="TotalQuantity" SortExpression="TotalQuantity"  />
				<asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" SortExpression="TotalAmount"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove"  />
				<asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" SortExpression="DeliveryDate"  />
				<asp:BoundField DataField="ReceivedDate" HeaderText="ReceivedDate" SortExpression="ReceivedDate"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ItemMovement Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnItemMovement" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/ItemMovementEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:ItemDataSource ID="ItemDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:RepositoryDataSource ID="RepositoryDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:RepositoryDataSource ID="RepositoryDataSource3" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ItemMovementDataSource ID="ItemMovementDataSource" runat="server"
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
		</data:ItemMovementDataSource>
	    		
</asp:Content>



