
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Staff.aspx.cs" Inherits="Staff" Title="Staff List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Staff List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="StaffDataSource"
			DataKeyNames="StaffId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Staff.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:TemplateField HeaderText="UserId">
				<ItemTemplate>
						<asp:Repeater ID="UserId1" runat="server" DataSourceID="UserFilter1">
							<ItemTemplate>
								<%# Eval("Email") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UserFilter1" runat="server"
							DataSourceID="UserDataSource1"
							Filter='<%# String.Format("UserId = {0}", Eval("UserId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"  />
				<asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"  />
				<asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"  />
				<asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Staff Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnStaff" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/StaffEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:UserDataSource ID="UserDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:StaffDataSource ID="StaffDataSource" runat="server"
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
		</data:StaffDataSource>
	    		
</asp:Content>



