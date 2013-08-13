
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ItemInProjectEdit.aspx.cs" Inherits="ItemInProjectEdit" Title="ItemInProject Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">ItemInProject - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ItemInProjectId" runat="server" DataSourceID="ItemInProjectDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ItemInProjectFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ItemInProjectFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ItemInProject not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ItemInProjectDataSource ID="ItemInProjectDataSource" runat="server"
			SelectMethod="GetByItemInProjectId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ItemInProjectId" QueryStringField="ItemInProjectId" Type="String" />

			</Parameters>
		</data:ItemInProjectDataSource>
		
		<br />

		

</asp:Content>

