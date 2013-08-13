
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="GroupEdit.aspx.cs" Inherits="GroupEdit" Title="Group Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Group - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="GroupId" runat="server" DataSourceID="GroupDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/GroupFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/GroupFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Group not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:GroupDataSource ID="GroupDataSource" runat="server"
			SelectMethod="GetByGroupId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="GroupId" QueryStringField="GroupId" Type="String" />

			</Parameters>
		</data:GroupDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewContract" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewContract_SelectedIndexChanged"			 			 
			DataSourceID="ContractDataSource"
			DataKeyNames="ContractId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Contract.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />				
				<asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />				
				<asp:BoundField DataField="InitPrice" HeaderText="InitPrice" SortExpression="InitPrice" />				
				<asp:BoundField DataField="LastPrice" HeaderText="LastPrice" SortExpression="LastPrice" />				
				<asp:BoundField DataField="FromDate" HeaderText="FromDate" SortExpression="FromDate" />				
				<asp:BoundField DataField="ToDate" HeaderText="ToDate" SortExpression="ToDate" />				
				<asp:BoundField DataField="RealFromDate" HeaderText="RealFromDate" SortExpression="RealFromDate" />				
				<asp:BoundField DataField="RealToDate" HeaderText="RealToDate" SortExpression="RealToDate" />				
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />				
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove" />				
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />				
				<asp:BoundField DataField="IsPrinted" HeaderText="IsPrinted" SortExpression="IsPrinted" />				
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />				
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Contract Found! </b>
				<asp:HyperLink runat="server" ID="hypContract" NavigateUrl="~/admin/ContractEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					

		<data:ContractDataSource ID="ContractDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<asp:ControlParameter Name="WhereClause" ControlID="__Page" PropertyName="WhereClause" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridViewContract" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridViewContract" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ContractDataSource>
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
		<data:EntityGridView ID="GridViewItem" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewItem_SelectedIndexChanged"			 			 
			DataSourceID="ItemDataSource"
			DataKeyNames="ItemId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Item.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />				
				<asp:BoundField DataField="Density" HeaderText="Density" SortExpression="Density" />				
				<asp:BoundField DataField="TotalQuantity" HeaderText="TotalQuantity" SortExpression="TotalQuantity" />				
				<asp:BoundField DataField="AvailabelQuantity" HeaderText="AvailabelQuantity" SortExpression="AvailabelQuantity" />				
				<asp:BoundField DataField="ReserveQuantity" HeaderText="ReserveQuantity" SortExpression="ReserveQuantity" />				
				<asp:BoundField DataField="ReturnQuantity" HeaderText="ReturnQuantity" SortExpression="ReturnQuantity" />				
				<asp:BoundField DataField="AdjustQuantity" HeaderText="AdjustQuantity" SortExpression="AdjustQuantity" />				
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />				
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />				
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable" />				
				<asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />				
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />				
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId" />				
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate" />				
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Item Found! </b>
				<asp:HyperLink runat="server" ID="hypItem" NavigateUrl="~/admin/ItemEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					

		<data:ItemDataSource ID="ItemDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<asp:ControlParameter Name="WhereClause" ControlID="__Page" PropertyName="WhereClause" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridViewItem" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridViewItem" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ItemDataSource>
		<br />
		

</asp:Content>

