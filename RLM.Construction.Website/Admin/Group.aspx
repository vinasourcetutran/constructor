
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Group.aspx.cs" Inherits="Group" Title="Group List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Group List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="GroupDataSource"
			DataKeyNames="GroupId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Group.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ParentGroupId" HeaderText="ParentGroupId" SortExpression="ParentGroupId"  />
				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"  />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"  />
				<asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable"  />
				<asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Group Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnGroup" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/GroupEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:GroupDataSource ID="GroupDataSource" runat="server"
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
		</data:GroupDataSource>
	    		
</asp:Content>



