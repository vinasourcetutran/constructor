
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="RoleOfStaff.aspx.cs" Inherits="RoleOfStaff" Title="RoleOfStaff List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">RoleOfStaff List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="RoleOfStaffDataSource"
			DataKeyNames="RoleOfStaffId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_RoleOfStaff.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="RoleOfStaffId" HeaderText="RoleOfStaffId" SortExpression="RoleOfStaffId" ReadOnly />
				<asp:TemplateField HeaderText="StaffId">
				<ItemTemplate>
						<asp:Repeater ID="StaffId1" runat="server" DataSourceID="StaffFilter1">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="StaffFilter1" runat="server"
							DataSourceID="StaffDataSource1"
							Filter='<%# String.Format("StaffId = {0}", Eval("StaffId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="RoleId">
				<ItemTemplate>
						<asp:Repeater ID="RoleId2" runat="server" DataSourceID="RoleFilter2">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="RoleFilter2" runat="server"
							DataSourceID="RoleDataSource2"
							Filter='<%# String.Format("RoleId = {0}", Eval("RoleId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="ResourceId" HeaderText="ResourceId" SortExpression="ResourceId"  />
				<asp:BoundField DataField="ResourceType" HeaderText="ResourceType" SortExpression="ResourceType"  />
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  />
				<asp:BoundField DataField="FromDate" HeaderText="FromDate" SortExpression="FromDate"  />
				<asp:BoundField DataField="ToDate" HeaderText="ToDate" SortExpression="ToDate"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No RoleOfStaff Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnRoleOfStaff" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/RoleOfStaffEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:StaffDataSource ID="StaffDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:RoleDataSource ID="RoleDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:RoleOfStaffDataSource ID="RoleOfStaffDataSource" runat="server"
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
		</data:RoleOfStaffDataSource>
	    		
</asp:Content>



