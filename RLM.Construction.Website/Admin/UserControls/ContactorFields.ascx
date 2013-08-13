<%@ Control Language="C#" ClassName="ContactorFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">PartnerId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPartnerId" Text='<%# Bind("PartnerId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPartnerId" runat="server" Display="Dynamic" ControlToValidate="dataPartnerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">GroupId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataGroupId" Text='<%# Bind("GroupId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataGroupId" runat="server" Display="Dynamic" ControlToValidate="dataGroupId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Code:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCode" Text='<%# Bind("Code") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Name:</td>
				<td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">JobTitle:</td>
				<td>
					<asp:TextBox runat="server" ID="dataJobTitle" Text='<%# Bind("JobTitle") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Email:</td>
				<td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mobile:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMobile" Text='<%# Bind("Mobile") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Phone:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ext:</td>
				<td>
					<asp:TextBox runat="server" ID="dataExt" Text='<%# Bind("Ext") %>' MaxLength="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsActive:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsActive" SelectedValue='<%# Bind("IsActive") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">Priority:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPriority" Text='<%# Bind("Priority") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPriority" runat="server" Display="Dynamic" ControlToValidate="dataPriority" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Comment:</td>
				<td>
					<asp:TextBox runat="server" ID="dataComment" Text='<%# Bind("Comment") %>' MaxLength="16"></asp:TextBox>
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
				<td class="literal">LastModifitionDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLastModifitionDate" Text='<%# Bind("LastModifitionDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModifitionDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


