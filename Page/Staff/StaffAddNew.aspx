<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffAddNew" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewRelatedItemLink" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
            <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="StaffCode"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtStaffCode' runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="FullName"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtFullName' runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Photo"></asp:Literal>
                    </label>
                    <div>
                        <asp:Image ID='photo' runat="server" />
                        <input type=file id='fphoto' runat="server" />
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="Magnetic"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtMagnetic' runat="server"></asp:TextBox>
                </div>
                
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal112121" runat="server" meta:resourcekey="Sex"></asp:Literal>
                    </label>
                    <rlm:SexTypeComboBox IsShowAll=false CssClass="Item AutoWidth" ID="drpSex" runat="server"></rlm:SexTypeComboBox>
                </div>
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal9" runat="server" meta:resourcekey="Birthday"></asp:Literal>
                    </label>
                     <telerik:RadDatePicker ID="radBirthday" runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldToDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row MarginRight5">
                    <label class="Label">
                        <asp:Literal ID="Literal10" runat="server" meta:resourcekey="BirthPlace"></asp:Literal>
                    </label>
                     <asp:TextBox ID='txtBirhtPlace' runat="server"></asp:TextBox>
                     <rlm:GroupComboBox Type=Province isshowall='false' CssClass="Item AutoWidth"  id='drpProvince' runat='server' />
                </div>
                <div class="Row MarginRight5 None" style="display:none;">
                    <label class="Label">
                        <asp:Literal ID="Literal18" runat="server" meta:resourcekey="PermanentAddress"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                     <asp:TextBox ID='txtPerAdress' runat="server"></asp:TextBox>
                     <rlm:GroupComboBox Type=Province IsShowAll='false' CssClass="Item AutoWidth"  id='drpPerAddress' runat='server' />
                </div>
                <div class="Row MarginRight5  None" style="display:none;">
                    <label class="Label">
                        <asp:Literal ID="Literal19" runat="server" meta:resourcekey="TempAddress"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                     <asp:TextBox ID='txtTempAddress' runat="server"></asp:TextBox>
                     <rlm:GroupComboBox Type=Province IsShowAll='false' CssClass="Item AutoWidth"  id='drpTempAddress' runat='server' />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal12" runat="server" meta:resourcekey="Religous"></asp:Literal>
                    </label>
                     <rlm:GroupComboBox IsShowAll=false CssClass="Item AutoWidth" ID="drpReligous" runat="server" Type="Religious"></rlm:GroupComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal13" runat="server" meta:resourcekey="People"></asp:Literal>
                    </label>
                     <rlm:GroupComboBox IsShowAll=false CssClass="Item AutoWidth" ID="drpPeople" runat="server" Type="People"></rlm:GroupComboBox>
                </div>
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal14" runat="server" meta:resourcekey="StartWorkingDate"></asp:Literal>
                    </label>
                     <telerik:RadDatePicker ID="radStartWorkingDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal15" runat="server" meta:resourcekey="WorkingDate"></asp:Literal>
                    </label>
                     <telerik:RadDatePicker ID="radWorkingDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal16" runat="server" meta:resourcekey="Department"></asp:Literal>
                    </label>
                     <rlm:GroupComboBox IsShowAll=false CssClass="Item AutoWidth" ID="drpDept" runat="server" Type="Department"></rlm:GroupComboBox>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal17" runat="server" meta:resourcekey="JobTitle"></asp:Literal>
                    </label>
                     <rlm:RoleComboBox RoleType=JobTitle IsShowAll=false CssClass="Item AutoWidth" ID="drpJobTitle" runat="server"></rlm:RoleComboBox>
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
                    <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset'  runat="server" meta:resourcekey="Reset" />
                    <asp:Button ID='btnCancel' OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>