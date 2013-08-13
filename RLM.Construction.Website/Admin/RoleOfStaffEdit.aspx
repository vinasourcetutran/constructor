
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="RoleOfStaffEdit.aspx.cs" Inherits="RoleOfStaffEdit" Title="RoleOfStaff Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">RoleOfStaff - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="RoleOfStaffId" runat="server" DataSourceID="RoleOfStaffDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RoleOfStaffFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RoleOfStaffFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>RoleOfStaff not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:RoleOfStaffDataSource ID="RoleOfStaffDataSource" runat="server"
			SelectMethod="GetByRoleOfStaffId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="RoleOfStaffId" QueryStringField="RoleOfStaffId" Type="String" />

			</Parameters>
		</data:RoleOfStaffDataSource>
		
		<br />

		

</asp:Content>

