
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="UnitConvertorEdit.aspx.cs" Inherits="UnitConvertorEdit" Title="UnitConvertor Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">UnitConvertor - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="FromUnitId, ToUnitId" runat="server" DataSourceID="UnitConvertorDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UnitConvertorFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UnitConvertorFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>UnitConvertor not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:UnitConvertorDataSource ID="UnitConvertorDataSource" runat="server"
			SelectMethod="GetByFromUnitIdToUnitId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="FromUnitId" QueryStringField="FromUnitId" Type="String" />
<asp:QueryStringParameter Name="ToUnitId" QueryStringField="ToUnitId" Type="String" />

			</Parameters>
		</data:UnitConvertorDataSource>
		
		<br />


</asp:Content>

