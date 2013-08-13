<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="ProjectPhaseAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ProjectPhaseAddNew" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                <div class="Row " id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Project"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:ProjectComboBox CssClass="Item AutoWidth"  DataValueField="ProjectId" DataTextField="Name"
                        ID="drpProject" runat="server">
                    </rlm:ProjectComboBox>
                    <a href='#' id='lnkProject' runat="server"></a>
                    <rlm:addnewlink id='addNewProjectLink' CssClass="" ResourceId='0' ResourceType="Project" IsShowText="false" runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='projectList' runat="server"  meta:resourcekey="AddNewProject" url="Page/Project/ProjectAddNew.aspx" />
                </div>
                <div class="Row  ">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtName' CssClass="width300" runat="server"></asp:TextBox>
                </div>
                <div class="Row  ">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtDescription' TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
                </div>
                <div class="Row"></div>
                <div class="Row Width32" id='div2' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="FirstPrice"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtFirstPrice' Width="150" Text="0" runat="server"></asp:TextBox>
                </div> 
                <div class="Row  Width32" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="LastPrice"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtLastPrice' Width="150" Text="0" runat="server"></asp:TextBox>
                </div>
                 <div class="Row  Width32" id='div8' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="Currency"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:UnitComboBox type="Money" CssClass="Item AutoWidth" Width="150px" ID="drpUnit" runat="server">
                    </rlm:UnitComboBox>
                    <rlm:addnewlink id='Addnewlink3' CssClass="None" ResourceType="Unit" ResourceId="0" IsShowText="false" runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='systemUnitList' runat="server"  meta:resourcekey="AddNewUnit" url="Page/System/UnitList.aspx" />
                </div>

                <div class="Row Width32" id='div9' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" meta:resourcekey="ExchangRate"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtExchangRate' Width="100" Text="1" runat="server"></asp:TextBox>
                    <span>&nbsp;&nbsp;(VND)</span>
                </div> 


                <div class="Row Width32" id='div5' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="FromDate"></asp:Literal>
                        
                    </label>
                    <telerik:RadDatePicker ID="radFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldFromDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32" id='div6' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="ToDate"></asp:Literal>
                        
                    </label>
                    <telerik:RadDatePicker ID="radToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldToDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                
                <div class="Row Width32" id='div10' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal19' runat="server" meta:resourcekey="RealFromDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radRealFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32" id='div11' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="RealToDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radRealToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="IsBillable"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsBillable' Checked="true" runat="server" />
                </div>
                <div class="Row Width32" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <rlm:ProjectPhaseStatusComboBox CssClass="Item AutoWidth" ID="drpProjectPhaseStatus" runat="server">
                    </rlm:ProjectPhaseStatusComboBox>
                </div>
                <div class="Row Width32" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <rlm:ProjectPhaseTypeComboBox CssClass="Item AutoWidth" ID="drpProjectPhaseType" runat="server">
                    </rlm:ProjectPhaseTypeComboBox>
                </div>
                 <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="IsCurrentProjectPhase"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsCurrentProjectPhase' Checked="false" runat="server" />
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' Checked="true" runat="server" />
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow Row PaddingTop20">
                    <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset' runat="server" value="Nhập lại" />
                    <asp:Button ID='btnCancel' OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="true" ID='files' Visible="false" runat="server" ResourceType="ProjectPhase" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
