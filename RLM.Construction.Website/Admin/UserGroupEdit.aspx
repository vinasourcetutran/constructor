
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="UserGroupEdit.aspx.cs" Inherits="UserGroupEdit" Title="UserGroup Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">UserGroup - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="UserGroupId" runat="server" DataSourceID="UserGroupDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserGroupFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserGroupFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>UserGroup not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:UserGroupDataSource ID="UserGroupDataSource" runat="server"
			SelectMethod="GetByUserGroupId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="UserGroupId" QueryStringField="UserGroupId" Type="String" />

			</Parameters>
		</data:UserGroupDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewUser" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewUser_SelectedIndexChanged"			 			 
			DataSourceID="UserDataSource"
			DataKeyNames="UserId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_User.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />				
				<asp:BoundField DataField="Pwd" HeaderText="Pwd" SortExpression="Pwd" />				
				<asp:BoundField DataField="PwdFormat" HeaderText="PwdFormat" SortExpression="PwdFormat" />				
				<asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />				
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />				
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable" />				
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />				
				<asp:BoundField DataField="IsFirstLoggedIn" HeaderText="IsFirstLoggedIn" SortExpression="IsFirstLoggedIn" />				
				<asp:BoundField DataField="IsLocked" HeaderText="IsLocked" SortExpression="IsLocked" />				
				<asp:BoundField DataField="LogInFail" HeaderText="LogInFail" SortExpression="LogInFail" />				
				<asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" SortExpression="LastLoginDate" />				
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />				
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId" />				
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate" />				
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No User Found! </b>
				<asp:HyperLink runat="server" ID="hypUser" NavigateUrl="~/admin/UserEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					

		<data:UserDataSource ID="UserDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<asp:ControlParameter Name="WhereClause" ControlID="__Page" PropertyName="WhereClause" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridViewUser" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridViewUser" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:UserDataSource>
		<br />
		

</asp:Content>

