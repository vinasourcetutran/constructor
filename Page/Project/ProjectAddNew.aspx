<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectAddNew" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row" id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Contract"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:ContractComboBox CssClass="Item AutoWidth"  DataValueField="ContractId" DataTextField="Name"
                        ID="drpContract" runat="server">
                    </rlm:ContractComboBox>
                    <a href='#' id='lnkContract' runat="server"></a>
                    <rlm:addnewlink id='addNewContractLink' runat='server' runat="server" ResourceType="Contract" ResourceId="0" IsShowText="false"  meta:resourcekey="AddNewContract" />
                </div>
                <div class="Row" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:GroupComboBox Type="Project" CssClass="Item AutoWidth" DataValueField="GroupId"
                        DataTextField="Name" ID="drpGroup" runat="server">
                    </rlm:GroupComboBox>
                    <rlm:addnewlink id='addNewGroupLink' runat='server' runat="server" IsShowText="false"  meta:resourcekey="AddNewGroup" ResourceType="ProjectGroup" ResourceId="0" />
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
                <div class="Row None">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="ProjectPhase"></asp:Literal>
                    </label>
                    <a id='lnkProjectPhase' href='#' runat="server">(Chưa có dữ liệu)</a>
                    <rlm:addnewlink id='lnkAddNewProjectPhase' runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" IsShowText="false" ResourceType="ProjectPhase" tabId='projectPhaseList' runat="server"  meta:resourcekey="AddNewProjectPhase" url="Page/Project/ProjectPhaseAddNew.aspx" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtDescription' TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
                </div>
                <div class="Row" id='div2' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="FirstPrice"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtFirstPrice' Width="100" Text="0" runat="server"></asp:TextBox>
                </div>
                <div class="Row" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="LastPrice"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtLastPrice' Width="100" Text="0" runat="server"></asp:TextBox>
                </div>
                 <div class="Row" id='div8' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="Currency"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:UnitComboBox type="Money" CssClass="Item AutoWidth" DataValueField="UnitId" DataTextField="Name" ID="drpUnit" runat="server" >
                    </rlm:UnitComboBox>
                    <rlm:addnewlink id='Addnewlink3' runat='server' IsShowText="false" ResourceType="Unit" onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='systemUnitList' runat="server"  meta:resourcekey="AddNewUnit" url="Page/System/UnitAddNew.aspx" />
                </div>

                <div class="Row" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="ExchangeRate"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtExchangeRate' Width="100" Text="1" runat="server"></asp:TextBox>
                    <span>&nbsp;&nbsp;VND</span>
                </div>

                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' Checked="true" runat="server" />
                </div>
                <div class="Row None">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="IsApprove"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsApprove' Visible="false" Checked="true" runat="server" />
                    <span id="spIsApprove" runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset' runat="server" meta:resourcekey="Reset" />
                    <asp:Button ID='btnCancel' Visible="false" OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="true" ID='files' Visible="false" runat="server" ResourceType="Project" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
