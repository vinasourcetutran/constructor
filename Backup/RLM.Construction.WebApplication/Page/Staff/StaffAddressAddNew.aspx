<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="StaffAddressAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffAddressAddNew" %>
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
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Country"></asp:Literal>
                    </label>
                    <rlm:GroupComboBox AutoPostBack="true" Type=Country IsShowAll="false" OnSelectedIndexChanged="drpCountry_OnSelectedIndexChanged" runat="server" ID='drpCountry'></rlm:GroupComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Province"></asp:Literal>
                        
                    </label>
                    <rlm:GroupComboBox Type="Province" ParentId=-1 IsShowAll="false" runat="server" ID='drpProvince'></rlm:GroupComboBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <div>
                        <rlm:AddressTypeComboBox id='drpType' runat='server' />
                    </div>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="Address"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtAddress' runat="server"></asp:TextBox>
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
                    <asp:Button ID='btnDelete' Visible="false" OnClick="btnDelete_OnClick" runat="server"
                        meta:resourcekey="Delete" />
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
