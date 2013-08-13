
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="ItemInProject.aspx.cs" Inherits="ItemInProject" Title="ItemInProject List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">ItemInProject List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="ItemInProjectDataSource"
			DataKeyNames="ItemInProjectId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ItemInProject.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:TemplateField HeaderText="ItemId">
				<ItemTemplate>
						<asp:Repeater ID="ItemId1" runat="server" DataSourceID="ItemFilter1">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="ItemFilter1" runat="server"
							DataSourceID="ItemDataSource1"
							Filter='<%# String.Format("ItemId = {0}", Eval("ItemId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="ProjectId">
				<ItemTemplate>
						<asp:Repeater ID="ProjectId2" runat="server" DataSourceID="ProjectFilter2">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="ProjectFilter2" runat="server"
							DataSourceID="ProjectDataSource2"
							Filter='<%# String.Format("ProjectId = {0}", Eval("ProjectId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="ContractId">
				<ItemTemplate>
						<asp:Repeater ID="ContractId3" runat="server" DataSourceID="ContractFilter3">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="ContractFilter3" runat="server"
							DataSourceID="ContractDataSource3"
							Filter='<%# String.Format("ContractId = {0}", Eval("ContractId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"  />
				<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"  />
				<asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ItemInProject Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnItemInProject" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/ItemInProjectEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:ItemDataSource ID="ItemDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ProjectDataSource ID="ProjectDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ContractDataSource ID="ContractDataSource3" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ItemInProjectDataSource ID="ItemInProjectDataSource" runat="server"
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
		</data:ItemInProjectDataSource>
	    		
</asp:Content>



