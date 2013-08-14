<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="TaskAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.TaskAddNew" %>
<%@ Register Src="~/Page/Task/TaskMember.ascx" TagName="TaskMember" TagPrefix="rlm" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div>
<div class="Row Bold">
    <label id='lblResource' runat="server"></label>
</div>
        <fieldset>
            <legend id="legend" meta:resourcekey="ViewDetailTitle" runat="server"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row " id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Name"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtName' Width="680" runat="server"></asp:TextBox>
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                        <div>
                            <telerik:RadEditor CssClass="radEditor" ID='radDescription' runat="server"></telerik:RadEditor>
                        </div>
                </div>
                <div class="Row" id='divParentId' runat="server">
                    <label class="Label MarginTop20">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="PercentComplete"></asp:Literal> (%)
                    </label>
                    <telerik:RadSlider ThumbsInteractionMode="Push" CssClass="displayTable" ID="radPercentComplete" runat="server" MinimumValue="0" MaximumValue="100"
                            SmallChange="5" LargeChange="10" ItemType="tick" Height="70px" Width="350px"
                            AnimationDuration="400" >
                        </telerik:RadSlider>
                </div>
                <div class="Row Width32" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="EstimationFromDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldFromDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="EstimationToDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' runat="server" />
                </div>
                <div class="Row Width32" id='div10' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal19' runat="server" meta:resourcekey="RealFromDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radRealFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32" id='div11' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="RealToDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radRealToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width20">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="IsApprove"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsApprove' runat="server" />
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <rlm:TaskStatusComboBox Width="50" id='drpStatus' runat='server'></rlm:TaskStatusComboBox>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="CreatorName"></asp:Literal>
                    </label>
                    <span id="spCreatorName" runat="server">(None)</span>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow Row PaddingTop20">
                     <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset' runat="server" value="Nhập lại"/>
                    <asp:Button ID='btnCancel' Visible="false" OnClick="btnCancel_OnClick" runat="server"
                        meta:resourcekey="Cancel" />
                </div>
                <div class="Row">
                    <rlm:TaskMember ID='members' IsAllowEdit="true" IsShowAddNewLink="true" runat="server" Visible="false" ResourceType="Task"/>
                </div>
                <div class="Row">
                    <rlm:AttachFileList ID='files' runat="server" Visible="true" IsShowAddNewFileLink="true" IsShowDeleteButton="true" ResourceType="Task"/>
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
