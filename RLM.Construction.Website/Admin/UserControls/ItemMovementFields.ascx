<%@ Control Language="C#" ClassName="ItemMovementFields" %>

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
				<td class="literal">FromRepositoryId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataFromRepositoryId" DataSourceID="FromRepositoryIdRepositoryDataSource" DataTextField="RepositoryManagerStaffId" DataValueField="RepositoryId" SelectedValue='<%# Bind("FromRepositoryId") %>'></asp:DropDownList>
					<data:RepositoryDataSource ID="FromRepositoryIdRepositoryDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:RepositoryDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">ToRepositoryId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataToRepositoryId" DataSourceID="ToRepositoryIdRepositoryDataSource" DataTextField="RepositoryManagerStaffId" DataValueField="RepositoryId" SelectedValue='<%# Bind("ToRepositoryId") %>'></asp:DropDownList>
					<data:RepositoryDataSource ID="ToRepositoryIdRepositoryDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:RepositoryDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">FromRepositoryManagerId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFromRepositoryManagerId" Text='<%# Bind("FromRepositoryManagerId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFromRepositoryManagerId" runat="server" Display="Dynamic" ControlToValidate="dataFromRepositoryManagerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">ToRepositoryManagerId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataToRepositoryManagerId" Text='<%# Bind("ToRepositoryManagerId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataToRepositoryManagerId" runat="server" Display="Dynamic" ControlToValidate="dataToRepositoryManagerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">StranferUserId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataStranferUserId" Text='<%# Bind("StranferUserId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStranferUserId" runat="server" Display="Dynamic" ControlToValidate="dataStranferUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">ReceiverUserId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataReceiverUserId" Text='<%# Bind("ReceiverUserId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataReceiverUserId" runat="server" Display="Dynamic" ControlToValidate="dataReceiverUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">UnitPrice:</td>
				<td>
					<asp:TextBox runat="server" ID="dataUnitPrice" Text='<%# Bind("UnitPrice") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUnitPrice" runat="server" Display="Dynamic" ControlToValidate="dataUnitPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">TotalQuantity:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTotalQuantity" Text='<%# Bind("TotalQuantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalQuantity" runat="server" Display="Dynamic" ControlToValidate="dataTotalQuantity" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">TotalAmount:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTotalAmount" Text='<%# Bind("TotalAmount") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalAmount" runat="server" Display="Dynamic" ControlToValidate="dataTotalAmount" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
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
					<asp:TextBox runat="server" ID="dataIsActive" Text='<%# Bind("IsActive") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIsActive" runat="server" Display="Dynamic" ControlToValidate="dataIsActive" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsApprove:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsApprove" SelectedValue='<%# Bind("IsApprove") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">DeliveryDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDeliveryDate" Text='<%# Bind("DeliveryDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDeliveryDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">ReceivedDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataReceivedDate" Text='<%# Bind("ReceivedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataReceivedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


