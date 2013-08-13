<%@ Control Language="C#" ClassName="ItemInProjectFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">ItemId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataItemId" DataSourceID="ItemIdItemDataSource" DataTextField="Code" DataValueField="ItemId" SelectedValue='<%# Bind("ItemId") %>'></asp:DropDownList>
					<data:ItemDataSource ID="ItemIdItemDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:ItemDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">ProjectId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataProjectId" DataSourceID="ProjectIdProjectDataSource" DataTextField="Code" DataValueField="ProjectId" SelectedValue='<%# Bind("ProjectId") %>'></asp:DropDownList>
					<data:ProjectDataSource ID="ProjectIdProjectDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:ProjectDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">ContractId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataContractId" DataSourceID="ContractIdContractDataSource" DataTextField="Code" DataValueField="ContractId" SelectedValue='<%# Bind("ContractId") %>'></asp:DropDownList>
					<data:ContractDataSource ID="ContractIdContractDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:ContractDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">Quantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataQuantity" Text='<%# Bind("Quantity") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">UnitPrice:</td>
				<td>
					<asp:TextBox runat="server" ID="dataUnitPrice" Text='<%# Bind("UnitPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUnitPrice" runat="server" Display="Dynamic" ControlToValidate="dataUnitPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataUnitPrice" runat="server" Display="Dynamic" ControlToValidate="dataUnitPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Total:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTotal" Text='<%# Bind("Total") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTotal" runat="server" Display="Dynamic" ControlToValidate="dataTotal" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTotal" runat="server" Display="Dynamic" ControlToValidate="dataTotal" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsActive:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsActive" SelectedValue='<%# Bind("IsActive") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsApprove:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsApprove" SelectedValue='<%# Bind("IsApprove") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
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


