<%@ Control Language="C#" ClassName="PartnerFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
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
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">NameInEng:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNameInEng" Text='<%# Bind("NameInEng") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">TaxCode:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTaxCode" Text='<%# Bind("TaxCode") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Priority:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPriority" Text='<%# Bind("Priority") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPriority" runat="server" Display="Dynamic" ControlToValidate="dataPriority" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Address:</td>
				<td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Phone:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Fax:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFax" Text='<%# Bind("Fax") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Email:</td>
				<td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="200"></asp:TextBox>
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

