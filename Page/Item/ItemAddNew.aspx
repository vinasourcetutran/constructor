<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ItemAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Item.ItemAddNew" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
<div>
    <fieldset>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <legend id="legend" runat="server"></legend>
        <div class="EditFormWrapper">
            <div class="Row" id='divParentId' runat="server">
                <label class="Label">
                    <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                    <span class="Required">*</span>
                </label>
                <rlm:GroupComboBox Type="Item" CssClass="Item AutoWidth" ID="drpParent" runat="server" 
                    DropDownWidth="200px" HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true">
                </rlm:GroupComboBox>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                    <span class="Required">*</span>
                </label>
                <asp:TextBox ID='txtCode' runat="server"></asp:TextBox>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                    <span class="Required">*</span>
                </label>
                <asp:TextBox ID='txtName' runat="server"></asp:TextBox>
            </div>
            <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" meta:resourcekey="ItemPhoto"></asp:Literal>
                    </label>
                    <div>
                        <input type=file id='fphoto' runat="server" /><br />
                        <a href='#' id='lnkAttachFile' target="_blank" runat="server" class="Padding5"></a>
                    </div>
                </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                </label>
                <asp:TextBox ID='txtDescription' TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
            </div>
            <div class="Row" id='div2' runat="server">
                <label class="Label">
                    <asp:Literal ID='Literal7' runat="server" meta:resourcekey="UsedUnit"></asp:Literal>
                    <span class="Required">*</span>
                </label>
                <rlm:UnitComboBox IsActiveOnly="true" IsLoadAll="true" CssClass="Item AutoWidth" ID="drpUsedUnit" runat="server" HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true">
                </rlm:UnitComboBox>
            </div>
            <div class="Row" id='div1' runat="server">
                <label class="Label">
                    <asp:Literal ID='Literal6' runat="server" meta:resourcekey="BasedUnit"></asp:Literal>
                    <span class="Required">*</span>
                </label>
                <rlm:UnitComboBox IsActiveOnly="true"  IsLoadAll="true" CssClass="Item AutoWidth" ID="drpBasedUnit" runat="server" HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true">
                </rlm:UnitComboBox>
            </div>
            <div class="Row">
                <label class="Label">
                    <asp:Literal ID='Literal8' runat="server" meta:resourcekey="Ratio"></asp:Literal>
                </label>
                <asp:TextBox ID='txtRatio' Text="1" Width="150px" CssClass="Width150" runat="server"></asp:TextBox>
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
                <asp:Button ID='btnDelete' Visible="false" OnClick="btnDelete_OnClick" runat="server" meta:resourcekey="Delete" />
                <input type="reset" id='btnReset' runat="server" meta:resourcekey="Reset" />
                <asp:Button ID='btnCancel' Visible="false" OnClick="btnCancel_OnClick" runat="server" meta:resourcekey="Cancel" />
            </div>
        </div>
    </fieldset>
</div>
<rlm:validationmanager id="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation" formtovalidate="aspnetForm">
</rlm:validationmanager>
</asp:Content>
