<%@ Control Language="C#" ClassName="ItemFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">ItemId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataItemId" Text='<%# Bind("ItemId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataItemId" runat="server" Display="Dynamic" ControlToValidate="dataItemId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataItemId" runat="server" Display="Dynamic" ControlToValidate="dataItemId" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">GroupId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataGroupId" DataSourceID="GroupIdGroupDataSource" DataTextField="ParentGroupId" DataValueField="GroupId" SelectedValue='<%# Bind("GroupId") %>'></asp:DropDownList>
					<data:GroupDataSource ID="GroupIdGroupDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:GroupDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">Code:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCode" Text='<%# Bind("Code") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Name:</td>
				<td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Description:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="16"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">BaseUnitId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataBaseUnitId" DataSourceID="BaseUnitIdUnitDataSource" DataTextField="Name" DataValueField="UnitId" SelectedValue='<%# Bind("BaseUnitId") %>'></asp:DropDownList>
					<data:UnitDataSource ID="BaseUnitIdUnitDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UnitDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">UsedUnitId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataUsedUnitId" DataSourceID="UsedUnitIdUnitDataSource" DataTextField="Name" DataValueField="UnitId" SelectedValue='<%# Bind("UsedUnitId") %>'></asp:DropDownList>
					<data:UnitDataSource ID="UsedUnitIdUnitDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UnitDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">Density:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDensity" Text='<%# Bind("Density") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDensity" runat="server" Display="Dynamic" ControlToValidate="dataDensity" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">TotalQuantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTotalQuantity" Text='<%# Bind("TotalQuantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalQuantity" runat="server" Display="Dynamic" ControlToValidate="dataTotalQuantity" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">AvailabelQuantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataAvailabelQuantity" Text='<%# Bind("AvailabelQuantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAvailabelQuantity" runat="server" Display="Dynamic" ControlToValidate="dataAvailabelQuantity" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">ReserveQuantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataReserveQuantity" Text='<%# Bind("ReserveQuantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataReserveQuantity" runat="server" Display="Dynamic" ControlToValidate="dataReserveQuantity" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">ReturnQuantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataReturnQuantity" Text='<%# Bind("ReturnQuantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataReturnQuantity" runat="server" Display="Dynamic" ControlToValidate="dataReturnQuantity" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">AdjustQuantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataAdjustQuantity" Text='<%# Bind("AdjustQuantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAdjustQuantity" runat="server" Display="Dynamic" ControlToValidate="dataAdjustQuantity" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Status:</td>
				<td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsActive:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsActive" SelectedValue='<%# Bind("IsActive") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsDeletable:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsDeletable" SelectedValue='<%# Bind("IsDeletable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">Priority:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPriority" Text='<%# Bind("Priority") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPriority" runat="server" Display="Dynamic" ControlToValidate="dataPriority" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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


