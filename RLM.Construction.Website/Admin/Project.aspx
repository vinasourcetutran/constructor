
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Project.aspx.cs" Inherits="Project" Title="Project List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Project List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="ProjectDataSource"
			DataKeyNames="ProjectId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Project.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ProjectId" HeaderText="ProjectId" SortExpression="ProjectId" ReadOnly />
				<asp:TemplateField HeaderText="GroupId">
				<ItemTemplate>
						<asp:Repeater ID="GroupId1" runat="server" DataSourceID="GroupFilter1">
							<ItemTemplate>
								<%# Eval("ParentGroupId") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="GroupFilter1" runat="server"
							DataSourceID="GroupDataSource1"
							Filter='<%# String.Format("GroupId = {0}", Eval("GroupId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="ContractId">
				<ItemTemplate>
						<asp:Repeater ID="ContractId2" runat="server" DataSourceID="ContractFilter2">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="ContractFilter2" runat="server"
							DataSourceID="ContractDataSource2"
							Filter='<%# String.Format("ContractId = {0}", Eval("ContractId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"  />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
				<asp:BoundField DataField="DesignedPrice" HeaderText="DesignedPrice" SortExpression="DesignedPrice"  />
				<asp:BoundField DataField="FinalPrice" HeaderText="FinalPrice" SortExpression="FinalPrice"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Project Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProject" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/ProjectEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:GroupDataSource ID="GroupDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ContractDataSource ID="ContractDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ProjectDataSource ID="ProjectDataSource" runat="server"
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
		</data:ProjectDataSource>
	    		
</asp:Content>



