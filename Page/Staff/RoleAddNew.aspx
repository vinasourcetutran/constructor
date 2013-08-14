<%@ Page Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="RoleAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.RoleAddNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
            <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtCode' runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrName' runat="server" meta:resourcekey="Name"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtName' runat="server"></asp:TextBox>
                </div>
                 
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrType' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <rlm:RoleTypeComboBox ID='drpRoleType' runat="server" IsShowAll="false" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrIsActive' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' Checked="true" runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrLastModificationDate' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset' runat="server" meta:resourcekey="Reset" />
                    <asp:Button ID='btnCancel' Visible="false" OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>