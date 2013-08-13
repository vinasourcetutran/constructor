
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ContactorEdit.aspx.cs" Inherits="ContactorEdit" Title="Contactor Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Contactor - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ContractId" runat="server" DataSourceID="ContactorDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ContactorFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ContactorFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Contactor not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ContactorDataSource ID="ContactorDataSource" runat="server"
			SelectMethod="GetByContractId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ContractId" QueryStringField="ContractId" Type="String" />

			</Parameters>
		</data:ContactorDataSource>
		
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
		<data:EntityGridView ID="GridViewProject" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewProject_SelectedIndexChanged"			 			 
			DataSourceID="ProjectDataSource"
			DataKeyNames="ProjectId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Project.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />				
				<asp:BoundField DataField="DesignedPrice" HeaderText="DesignedPrice" SortExpression="DesignedPrice" />				
				<asp:BoundField DataField="FinalPrice" HeaderText="FinalPrice" SortExpression="FinalPrice" />				
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />				
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove" />				
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />				
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />				
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId" />				
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate" />				
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Project Found! </b>
				<asp:HyperLink runat="server" ID="hypProject" NavigateUrl="~/admin/ProjectEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					

		<data:ProjectDataSource ID="ProjectDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<asp:ControlParameter Name="WhereClause" ControlID="__Page" PropertyName="WhereClause" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridViewProject" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridViewProject" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProjectDataSource>
		<br />
		

</asp:Content>

