<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ItemAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Partner.ItemAddNew" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row None" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:GroupComboBox Type="Partner" CssClass="Item AutoWidth" DataValueField="GroupId"
                        DataTextField="Name" ID="drpGroup" runat="server">
                    </rlm:GroupComboBox>
                </div>
                <div class="Row None" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Contactor"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:ContactorComboBox CssClass="Item AutoWidth" DataValueField="ContactorId"
                        DataTextField="Name" ID="drpContactor" runat="server">
                    </rlm:ContactorComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" meta:resourcekey="TaxCode"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtTaxCode' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtName' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="NameInEnglish"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtNameInEnglish' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="Address"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtAddress' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal15' runat="server" meta:resourcekey="Phone"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtPhone' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal16' runat="server" meta:resourcekey="Fax"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtFax' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal17' runat="server" meta:resourcekey="Email"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtEmail' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Website"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtWebsite' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" Text="Người đại diện"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtRepresentative' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" Text="Người liên hệ"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtContactor' CssClass='width300'  runat="server"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtComment' TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
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
                    <input type="reset" id='btnReset' runat="server" value="Nhập lại" />
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
