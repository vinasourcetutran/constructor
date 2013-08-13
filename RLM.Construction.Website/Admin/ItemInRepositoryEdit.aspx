
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ItemInRepositoryEdit.aspx.cs" Inherits="ItemInRepositoryEdit" Title="ItemInRepository Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">ItemInRepository - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="RepositoryId, ItemId" runat="server" DataSourceID="ItemInRepositoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ItemInRepositoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ItemInRepositoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ItemInRepository not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ItemInRepositoryDataSource ID="ItemInRepositoryDataSource" runat="server"
			SelectMethod="GetByRepositoryIdItemId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="RepositoryId" QueryStringField="RepositoryId" Type="String" />
<asp:QueryStringParameter Name="ItemId" QueryStringField="ItemId" Type="String" />

			</Parameters>
		</data:ItemInRepositoryDataSource>
		
		<br />


</asp:Content>

