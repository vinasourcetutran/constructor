
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ProjectEdit.aspx.cs" Inherits="ProjectEdit" Title="Project Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Project - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProjectId" runat="server" DataSourceID="ProjectDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProjectFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProjectFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Project not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProjectDataSource ID="ProjectDataSource" runat="server"
			SelectMethod="GetByProjectId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProjectId" QueryStringField="ProjectId" Type="String" />

			</Parameters>
		</data:ProjectDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewItemInProject" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewItemInProject_SelectedIndexChanged"			 			 
			DataSourceID="ItemInProjectDataSource"
			DataKeyNames="ItemInProjectId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ItemInProject.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />				
				<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />				
				<asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />				
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />				
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove" />				
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />				
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId" />				
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate" />				
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No ItemInProject Found! </b>
				<asp:HyperLink runat="server" ID="hypItemInProject" NavigateUrl="~/admin/ItemInProjectEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					

		<data:ItemInProjectDataSource ID="ItemInProjectDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<asp:ControlParameter Name="WhereClause" ControlID="__Page" PropertyName="WhereClause" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridViewItemInProject" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridViewItemInProject" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ItemInProjectDataSource>
		<br />
		

</asp:Content>

