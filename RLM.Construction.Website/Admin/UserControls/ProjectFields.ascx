<%@ Control Language="C#" ClassName="ProjectFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">ProjectId:</td>
				<td>
					<asp:TextBox runat="server" ID="dataProjectId" Text='<%# Bind("ProjectId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProjectId" runat="server" Display="Dynamic" ControlToValidate="dataProjectId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataProjectId" runat="server" Display="Dynamic" ControlToValidate="dataProjectId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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
				<td class="literal">Code:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCode" Text='<%# Bind("Code") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Name:</td>
				<td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">DesignedPrice:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDesignedPrice" Text='<%# Bind("DesignedPrice") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDesignedPrice" runat="server" Display="Dynamic" ControlToValidate="dataDesignedPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">FinalPrice:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFinalPrice" Text='<%# Bind("FinalPrice") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFinalPrice" runat="server" Display="Dynamic" ControlToValidate="dataFinalPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
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
					<asp:TextBox runat="server" ID="dataIsApprove" Text='<%# Bind("IsApprove") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIsApprove" runat="server" Display="Dynamic" ControlToValidate="dataIsApprove" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Status:</td>
				<td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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


