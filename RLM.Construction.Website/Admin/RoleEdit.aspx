
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="RoleEdit.aspx.cs" Inherits="RoleEdit" Title="Role Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Role - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="RoleId" runat="server" DataSourceID="RoleDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RoleFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RoleFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Role not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:RoleDataSource ID="RoleDataSource" runat="server"
			SelectMethod="GetByRoleId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="RoleId" QueryStringField="RoleId" Type="String" />

			</Parameters>
		</data:RoleDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewRoleOfStaff" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewRoleOfStaff_SelectedIndexChanged"			 			 
			DataSourceID="RoleOfStaffDataSource"
			DataKeyNames="RoleOfStaffId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_RoleOfStaff.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="ResourceId" HeaderText="ResourceId" SortExpression="ResourceId" />				
				<asp:BoundField DataField="ResourceType" HeaderText="ResourceType" SortExpression="ResourceType" />				
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove" />				
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />				
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />				
				<asp:BoundField DataField="FromDate" HeaderText="FromDate" SortExpression="FromDate" />				
				<asp:BoundField DataField="ToDate" HeaderText="ToDate" SortExpression="ToDate" />				
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />				
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId" />				
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate" />				
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No RoleOfStaff Found! </b>
				<asp:HyperLink runat="server" ID="hypRoleOfStaff" NavigateUrl="~/admin/RoleOfStaffEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					

		<data:RoleOfStaffDataSource ID="RoleOfStaffDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<asp:ControlParameter Name="WhereClause" ControlID="__Page" PropertyName="WhereClause" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridViewRoleOfStaff" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridViewRoleOfStaff" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:RoleOfStaffDataSource>
		<br />
		

</asp:Content>

