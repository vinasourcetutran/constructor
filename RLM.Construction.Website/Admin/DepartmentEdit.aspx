
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="DepartmentEdit.aspx.cs" Inherits="DepartmentEdit" Title="Department Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Department - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="DeptId" runat="server" DataSourceID="DepartmentDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DepartmentFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DepartmentFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Department not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DepartmentDataSource ID="DepartmentDataSource" runat="server"
			SelectMethod="GetByDeptId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="DeptId" QueryStringField="DeptId" Type="String" />

			</Parameters>
		</data:DepartmentDataSource>
		
		<br />

		

</asp:Content>

