<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupAddNew.ascx.cs"
    Inherits="RLM.Construction.WebApplication.UserControl.GroupAddNew" %>
<div>
    <fieldset>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <legend id="legend" runat="server">Add Product For Company</legend>
        <div class="EditFormWrapper">
            <div class="Row" id='divParentId' runat="server">
                <label class="Label">
                    <asp:Literal ID='ltrParentGroup' runat="server" meta:resourcekey="ParentGroup"></asp:Literal>
                </label>
                <rlm:GroupComboBox ID='drpParent' IsShowAll="false" IsActiveOnly="False" runat="server" />
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                </label>
                <asp:TextBox ID='txtCode' CssClass="width300" runat="server"></asp:TextBox>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                    <span class="Required">*</span>
                </label>
                <asp:TextBox ID='txtName' CssClass="width300"  runat="server"></asp:TextBox>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                </label>
                <asp:TextBox ID='txtDescription' TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                </label>
                <asp:CheckBox ID='chkIsActive' Checked="true" runat="server" />
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal4' runat="server" meta:resourcekey="IsDeletable"></asp:Literal>
                </label>
                <span id="spIsDeletable" runat="server" class="OK">&nbsp;</span>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                </label>
                <span id="spLastModificationDate" runat="server">(None)</span>
            </div>
            <div class="BottonRow">
                <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                <asp:Button ID='btnDelete' OnClick="btnDelete_OnClick" runat="server" meta:resourcekey="Delete" />
                <input type="reset" id='btnReset' runat="server" value="Nhập lại" />
                <asp:Button ID='btnCancel' Visible="false" OnClick="btnCancel_OnClick" runat="server" meta:resourcekey="Cancel" />
            </div>
        </div>
    </fieldset>
</div>
<rlm:validationmanager id="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation" formtovalidate="aspnetForm">
</rlm:validationmanager>
