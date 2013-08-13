<%@ Control Language="C#" ClassName="UserFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">UserGroupId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataUserGroupId" DataSourceID="UserGroupIdUserGroupDataSource" DataTextField="UserGroupName" DataValueField="UserGroupId" SelectedValue='<%# Bind("UserGroupId") %>'></asp:DropDownList>
					<data:UserGroupDataSource ID="UserGroupIdUserGroupDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UserGroupDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">Email:</td>
				<td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmail" runat="server" Display="Dynamic" ControlToValidate="dataEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Pwd:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPwd" Text='<%# Bind("Pwd") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPwd" runat="server" Display="Dynamic" ControlToValidate="dataPwd" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">PwdFormat:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPwdFormat" Text='<%# Bind("PwdFormat") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPwdFormat" runat="server" Display="Dynamic" ControlToValidate="dataPwdFormat" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">FullName:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFullName" Text='<%# Bind("FullName") %>' MaxLength="200"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFullName" runat="server" Display="Dynamic" ControlToValidate="dataFullName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Phone:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsDeletable:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsDeletable" SelectedValue='<%# Bind("IsDeletable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsActive:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsActive" SelectedValue='<%# Bind("IsActive") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsFirstLoggedIn:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsFirstLoggedIn" SelectedValue='<%# Bind("IsFirstLoggedIn") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsLocked:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsLocked" SelectedValue='<%# Bind("IsLocked") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">LogInFail:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLogInFail" Text='<%# Bind("LogInFail") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLogInFail" runat="server" Display="Dynamic" ControlToValidate="dataLogInFail" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">LastLoginDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLastLoginDate" Text='<%# Bind("LastLoginDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastLoginDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">CreationDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCreationDate" Text='<%# Bind("CreationDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreationDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">CreationUserId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCreationUserId" Text='<%# Bind("CreationUserId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCreationUserId" runat="server" Display="Dynamic" ControlToValidate="dataCreationUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">LastModificationDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLastModificationDate" Text='<%# Bind("LastModificationDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModificationDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">LastModificationUserId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLastModificationUserId" Text='<%# Bind("LastModificationUserId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLastModificationUserId" runat="server" Display="Dynamic" ControlToValidate="dataLastModificationUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


