
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Role.aspx.cs" Inherits="Role" Title="Role List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Role List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="RoleDataSource"
			DataKeyNames="RoleId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Role.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"  />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable"  />
				<asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Role Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnRole" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/RoleEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:RoleDataSource ID="RoleDataSource" runat="server"
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
		</data:RoleDataSource>
	    		
</asp:Content>



