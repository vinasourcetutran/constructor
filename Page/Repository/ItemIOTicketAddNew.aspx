<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ItemIOTicketAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Repository.ItemIOTicketAddNew" %>

<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink"
    TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="IOType"></asp:Literal>
                    </label>
                    <rlm:ItemIOTicketTypeCombobox AutoPostBack="true" IsShowAll=true OnSelectedIndexChanged="drpType_OnSelectedIndexChanged" CssClass="AutoWidth" id='drpType' runat='server' />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrName' runat="server" meta:resourcekey="Name"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtName' ValidationGroup="Validate" runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Staff"></asp:Literal>
                    </label>
                    <rlm:StaffComboBox ID='drpStaff'  CssClass="AutoWidth" runat="server" IsShowAll="false" />
                </div>
                <div class="Row" id='rowReceiver' visible="false" runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Receiver"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtReceiver' runat="server"></asp:TextBox>
                </div>
                <div class="Row" id='rowSender' visible="false" runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="Sender"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtSender' runat="server"></asp:TextBox>
                </div>
                <div class="Row" id='rowFromRepository' visible="false" runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="FromRepository"></asp:Literal>
                    </label>
                    <rlm:GroupComboBox Type="Repository" IsShowAll="true" runat="server" ID='drpFromRepository' />
                </div>
                <div class="Row" id='rowToRepository' visible="false" runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="ToRepository"></asp:Literal>
                    </label>
                    <rlm:GroupComboBox Type="Repository" IsShowAll="true" runat="server" ID='drpToRepository' />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Project"></asp:Literal>
                    </label>
                    <rlm:ProjectComboBox ID='drpProject' runat="server" IsShowAll="true" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal8" runat="server" meta:resourcekey="IODate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radIODate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="TotalAmount"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtTotalAmount' Text="0" runat="server" Width="150px" />
                    <rlm:UnitComboBox ID='drpUnitId' runat="server" Type=Money CssClass="AutoWidth"></rlm:UnitComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="TaxPercent"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtTax' Text="0" runat="server" Width="100px" />
                    (%)
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtComment' TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal21' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <rlm:ItemIOTicketStatusComboBox ID='drpStatus' CssClass="AutoWidth" runat="server" IsShowAll="false">
                    </rlm:ItemIOTicketStatusComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' Checked="true" runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnSave' OnClick="btnSave_OnClick" ValidationGroup="Validate" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset' runat="server" meta:resourcekey="Reset" />
                    <asp:Button ID='btnCancel' OnClick="btnCancel_OnClick" runat="server" meta:resourcekey="Cancel" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
