<%@ Control Language="C#" ClassName="RoleOfStaffFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">RoleOfStaffId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataRoleOfStaffId" Text='<%# Bind("RoleOfStaffId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRoleOfStaffId" runat="server" Display="Dynamic" ControlToValidate="dataRoleOfStaffId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataRoleOfStaffId" runat="server" Display="Dynamic" ControlToValidate="dataRoleOfStaffId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">StaffId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataStaffId" DataSourceID="StaffIdStaffDataSource" DataTextField="Code" DataValueField="StaffId" SelectedValue='<%# Bind("StaffId") %>'></asp:DropDownList>
					<data:StaffDataSource ID="StaffIdStaffDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:StaffDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">RoleId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataRoleId" DataSourceID="RoleIdRoleDataSource" DataTextField="Code" DataValueField="RoleId" SelectedValue='<%# Bind("RoleId") %>'></asp:DropDownList>
					<data:RoleDataSource ID="RoleIdRoleDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:RoleDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">ResourceId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataResourceId" Text='<%# Bind("ResourceId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataResourceId" runat="server" Display="Dynamic" ControlToValidate="dataResourceId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataResourceId" runat="server" Display="Dynamic" ControlToValidate="dataResourceId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">ResourceType:</td>
				<td>
					<asp:TextBox runat="server" ID="dataResourceType" Text='<%# Bind("ResourceType") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataResourceType" runat="server" Display="Dynamic" ControlToValidate="dataResourceType" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataResourceType" runat="server" Display="Dynamic" ControlToValidate="dataResourceType" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsApprove:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIsApprove" Text='<%# Bind("IsApprove") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIsApprove" runat="server" Display="Dynamic" ControlToValidate="dataIsApprove" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsActive:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsActive" SelectedValue='<%# Bind("IsActive") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">Status:</td>
				<td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">FromDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFromDate" Text='<%# Bind("FromDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataFromDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">ToDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataToDate" Text='<%# Bind("ToDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataToDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


