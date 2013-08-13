
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="UnitConvertor.aspx.cs" Inherits="UnitConvertor" Title="UnitConvertor List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">UnitConvertor List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="UnitConvertorDataSource"
			DataKeyNames="FromUnitId, ToUnitId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_UnitConvertor.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:TemplateField HeaderText="FromUnitId">
				<ItemTemplate>
						<asp:Repeater ID="UnitId1" runat="server" DataSourceID="UnitFilter1">
							<ItemTemplate>
								<%# Eval("Name") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UnitFilter1" runat="server"
							DataSourceID="UnitDataSource1"
							Filter='<%# String.Format("UnitId = {0}", Eval("FromUnitId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="ToUnitId">
				<ItemTemplate>
						<asp:Repeater ID="UnitId2" runat="server" DataSourceID="UnitFilter2">
							<ItemTemplate>
								<%# Eval("Name") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UnitFilter2" runat="server"
							DataSourceID="UnitDataSource2"
							Filter='<%# String.Format("UnitId = {0}", Eval("ToUnitId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"  />
				<asp:BoundField DataField="IsDeletable" HeaderText="IsDeletable" SortExpression="IsDeletable"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:BoundField DataField="CreationUserId" HeaderText="CreationUserId" SortExpression="CreationUserId"  />
				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
				<asp:BoundField DataField="LastModificationUserId" HeaderText="LastModificationUserId" SortExpression="LastModificationUserId"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No UnitConvertor Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnUnitConvertor" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/UnitConvertorEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:UnitDataSource ID="UnitDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:UnitDataSource ID="UnitDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:UnitConvertorDataSource ID="UnitConvertorDataSource" runat="server"
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
		</data:UnitConvertorDataSource>
	    		
</asp:Content>



