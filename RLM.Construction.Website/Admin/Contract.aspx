
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Contract.aspx.cs" Inherits="Contract" Title="Contract List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Contract List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		
		<data:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="ContractDataSource"
			DataKeyNames="ContractId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Contract.xls"  
			AllowSorting="true"
			AllowPaging="true"			
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:TemplateField HeaderText="ConstructDeptId">
				<ItemTemplate>
						<asp:Repeater ID="DeptId1" runat="server" DataSourceID="DepartmentFilter1">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="DepartmentFilter1" runat="server"
							DataSourceID="DepartmentDataSource1"
							Filter='<%# String.Format("DeptId = {0}", Eval("ConstructDeptId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="DesignDeptId">
				<ItemTemplate>
						<asp:Repeater ID="DeptId2" runat="server" DataSourceID="DepartmentFilter2">
							<ItemTemplate>
								<%# Eval("Code") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="DepartmentFilter2" runat="server"
							DataSourceID="DepartmentDataSource2"
							Filter='<%# String.Format("DeptId = {0}", Eval("DesignDeptId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="GroupId">
				<ItemTemplate>
						<asp:Repeater ID="GroupId3" runat="server" DataSourceID="GroupFilter3">
							<ItemTemplate>
								<%# Eval("ParentGroupId") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="GroupFilter3" runat="server"
							DataSourceID="GroupDataSource3"
							Filter='<%# String.Format("GroupId = {0}", Eval("GroupId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"  />
				<asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number"  />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression=""  />
				<asp:BoundField DataField="InitPrice" HeaderText="InitPrice" SortExpression="InitPrice"  />
				<asp:BoundField DataField="LastPrice" HeaderText="LastPrice" SortExpression="LastPrice"  />
				<asp:BoundField DataField="FromDate" HeaderText="FromDate" SortExpression="FromDate"  />
				<asp:BoundField DataField="ToDate" HeaderText="ToDate" SortExpression="ToDate"  />
				<asp:BoundField DataField="RealFromDate" HeaderText="RealFromDate" SortExpression="RealFromDate"  />
				<asp:BoundField DataField="RealToDate" HeaderText="RealToDate" SortExpression="RealToDate"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  />
				<asp:BoundField DataField="IsApprove" HeaderText="IsApprove" SortExpression="IsApprove"  />
				<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"  />
				<asp:BoundField DataField="IsPrinted" HeaderText="IsPrinted" SortExpression="IsPrinted"  />
				<asp:TemplateField HeaderText="CreationUserId">
				<ItemTemplate>
						<asp:Repeater ID="UserId4" runat="server" DataSourceID="UserFilter4">
							<ItemTemplate>
								<%# Eval("Email") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UserFilter4" runat="server"
							DataSourceID="UserDataSource4"
							Filter='<%# String.Format("UserId = {0}", Eval("CreationUserId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"  />
				<asp:TemplateField HeaderText="LastModificationUserId">
				<ItemTemplate>
						<asp:Repeater ID="UserId5" runat="server" DataSourceID="UserFilter5">
							<ItemTemplate>
								<%# Eval("Email") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="UserFilter5" runat="server"
							DataSourceID="UserDataSource5"
							Filter='<%# String.Format("UserId = {0}", Eval("LastModificationUserId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:BoundField DataField="LastModificationDate" HeaderText="LastModificationDate" SortExpression="LastModificationDate"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Contract Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnContract" OnClientClick="javascript:location.href='/RLM.Construction.website/admin/ContractEdit.aspx'; return false;" Text="Add New"></asp:Button>
			
		<data:DepartmentDataSource ID="DepartmentDataSource1" runat="server"
			SelectMethod="GetAll"
		/>

		<data:DepartmentDataSource ID="DepartmentDataSource2" runat="server"
			SelectMethod="GetAll"
		/>

		<data:GroupDataSource ID="GroupDataSource3" runat="server"
			SelectMethod="GetAll"
		/>

		<data:UserDataSource ID="UserDataSource4" runat="server"
			SelectMethod="GetAll"
		/>

		<data:UserDataSource ID="UserDataSource5" runat="server"
			SelectMethod="GetAll"
		/>

		<data:ContractDataSource ID="ContractDataSource" runat="server"
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
		</data:ContractDataSource>
	    		
</asp:Content>



