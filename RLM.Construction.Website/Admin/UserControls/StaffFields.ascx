<%@ Control Language="C#" ClassName="StaffFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">UserId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataUserId" DataSourceID="UserIdUserDataSource" DataTextField="Email" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>'></asp:DropDownList>
					<data:UserDataSource ID="UserIdUserDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UserDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">Code:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCode" Text='<%# Bind("Code") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">FirstName:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFirstName" Text='<%# Bind("FirstName") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">LastName:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLastName" Text='<%# Bind("LastName") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">MiddleName:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMiddleName" Text='<%# Bind("MiddleName") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


