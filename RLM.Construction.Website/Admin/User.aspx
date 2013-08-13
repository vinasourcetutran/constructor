
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="User.aspx.cs" Inherits="User" Title="User List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">User List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="UserDataSource"
			DataKeyNames="UserId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_User.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:TemplateField HeaderText="UserGroupId">
				<ItemTemplate>
						<asp:Repeater ID="UserGroupId1" runat="server" DataSourceID="UserGroupFilter1">
							<ItemTemplate>
								<%# Eval("UserGroupName") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UserGroupFilter1" runat="server"
							DataSourceID="UserGroupDataSource1"
							Filter='<%# String.Format("UserGroupId = {0}", Eval("UserGroupId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"  />
				<asp:BoundField DataField="Pwd" HeaderText="Pwd" SortExpression="Pwd"  />
				<asp:BoundField DataField="PwdFormat" HeaderText="PwdFormat" SortExpression="PwdFormat"  />
				<asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName"  />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone"  />
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsFirstLoggedIn" HeaderText="IsFirstLoggedIn" SortExpression="IsFirstLoggedIn"  />
				<asp:BoundField DataField="IsLocked" HeaderText="IsLocked" SortExpression="IsLocked"  />
				<asp:BoundField DataField="LogInFail" HeaderText="LogInFail" SortExpression="LogInFail"  />
				<asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" SortExpression="LastLoginDate"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No User Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnUser" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/UserEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:UserGroupDataSource ID="UserGroupDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:UserDataSource ID="UserDataSource" runat="server"
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
		</data:UserDataSource>
	    		
</asp:Content>



