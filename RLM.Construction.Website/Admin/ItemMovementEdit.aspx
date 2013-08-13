
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ItemMovementEdit.aspx.cs" Inherits="ItemMovementEdit" Title="ItemMovement Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">ItemMovement - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="RepositoryMovementId" runat="server" DataSourceID="ItemMovementDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ItemMovementFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ItemMovementFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ItemMovement not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ItemMovementDataSource ID="ItemMovementDataSource" runat="server"
			SelectMethod="GetByRepositoryMovementId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="RepositoryMovementId" QueryStringField="RepositoryMovementId" Type="String" />

			</Parameters>
		</data:ItemMovementDataSource>
		
		<br />

		

</asp:Content>

