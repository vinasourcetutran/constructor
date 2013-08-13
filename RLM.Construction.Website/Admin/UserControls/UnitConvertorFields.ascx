<%@ Control Language="C#" ClassName="UnitConvertorFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">FromUnitId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataFromUnitId" DataSourceID="FromUnitIdUnitDataSource" DataTextField="Name" DataValueField="UnitId" SelectedValue='<%# Bind("FromUnitId") %>'></asp:DropDownList>
					<data:UnitDataSource ID="FromUnitIdUnitDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UnitDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">ToUnitId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataToUnitId" DataSourceID="ToUnitIdUnitDataSource" DataTextField="Name" DataValueField="UnitId" SelectedValue='<%# Bind("ToUnitId") %>'></asp:DropDownList>
					<data:UnitDataSource ID="ToUnitIdUnitDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UnitDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">Quantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataQuantity" Text='<%# Bind("Quantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
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


