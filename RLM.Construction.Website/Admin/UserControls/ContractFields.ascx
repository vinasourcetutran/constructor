<%@ Control Language="C#" ClassName="ContractFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">ConstructDeptId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataConstructDeptId" DataSourceID="ConstructDeptIdDepartmentDataSource" DataTextField="Code" DataValueField="DeptId" SelectedValue='<%# Bind("ConstructDeptId") %>'></asp:DropDownList>
					<data:DepartmentDataSource ID="ConstructDeptIdDepartmentDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:DepartmentDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">DesignDeptId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataDesignDeptId" DataSourceID="DesignDeptIdDepartmentDataSource" DataTextField="Code" DataValueField="DeptId" SelectedValue='<%# Bind("DesignDeptId") %>'></asp:DropDownList>
					<data:DepartmentDataSource ID="DesignDeptIdDepartmentDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:DepartmentDataSource>
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
				<td class="literal">Number:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNumber" Text='<%# Bind("Number") %>' MaxLength="200"></asp:TextBox>
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
				<td class="literal">InitPrice:</td>
				<td>
					<asp:TextBox runat="server" ID="dataInitPrice" Text='<%# Bind("InitPrice") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataInitPrice" runat="server" Display="Dynamic" ControlToValidate="dataInitPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">LastPrice:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLastPrice" Text='<%# Bind("LastPrice") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLastPrice" runat="server" Display="Dynamic" ControlToValidate="dataLastPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Currency"></asp:RangeValidator>
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
				<td class="literal">RealFromDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataRealFromDate" Text='<%# Bind("RealFromDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRealFromDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">RealToDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataRealToDate" Text='<%# Bind("RealToDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRealToDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Status:</td>
				<td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsApprove:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsApprove" SelectedValue='<%# Bind("IsApprove") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsActive:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataIsActive" SelectedValue='<%# Bind("IsActive") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">IsPrinted:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIsPrinted" Text='<%# Bind("IsPrinted") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIsPrinted" runat="server" Display="Dynamic" ControlToValidate="dataIsPrinted" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">CreationUserId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataCreationUserId" DataSourceID="CreationUserIdUserDataSource" DataTextField="Email" DataValueField="UserId" SelectedValue='<%# Bind("CreationUserId") %>'></asp:DropDownList>
					<data:UserDataSource ID="CreationUserIdUserDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UserDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">CreationDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCreationDate" Text='<%# Bind("CreationDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreationDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">LastModificationUserId:</td>
				<td>
					<asp:DropDownList runat="server" ID="dataLastModificationUserId" DataSourceID="LastModificationUserIdUserDataSource" DataTextField="Email" DataValueField="UserId" SelectedValue='<%# Bind("LastModificationUserId") %>'></asp:DropDownList>
					<data:UserDataSource ID="LastModificationUserIdUserDataSource" runat="server"
 						SelectMethod="GetAll"
 					>
					</data:UserDataSource>
				</td>
			</tr>				
			<tr>
				<td class="literal">LastModificationDate:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLastModificationDate" Text='<%# Bind("LastModificationDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModificationDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


