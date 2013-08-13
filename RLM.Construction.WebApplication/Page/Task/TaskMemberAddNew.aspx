<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="TaskMemberAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.TaskMemberAddNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div>
    <div class="Row Bold">
        <asp:label id='lblResource' runat="server"></asp:label>
    </div>
    <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper DetailFormView">
                <div class="Row " id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Staff"></asp:Literal>
                    </label>
                    <rlm:StaffComboBox id='staff' runat='server'></rlm:StaffComboBox>
                </div>
                 <div class="Row " id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="Role"></asp:Literal>
                    </label>
                    <rlm:rolecombobox id='role' RoleType="Task" IsActiveOnly="true" runat='server'></rlm:rolecombobox>
                </div>
                 <div class="Row " id='div2' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <rlm:taskmemberstatuscombobox  id='status' runat='server'></rlm:taskmemberstatuscombobox>
                </div>
                <div class="Row" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="EstimationFromDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldFromDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="EstimationToDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row" id='div10' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal19' runat="server" meta:resourcekey="RealFromDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radRealFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row" id='div11' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal20' runat="server" meta:resourcekey="RealToDate"></asp:Literal>
                    </label>
                    <telerik:RadDatePicker ID="radRealToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="Comment"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtComment' runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <asp:Label ID='lblLastModificationDate' runat="server" Text="(None)"></asp:Label>
                </div>
                <div class="BottonRow Row PaddingTop20">
                     <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                     <asp:Button ID='btnDelete' Visible="false" OnClick="btnDelete_OnClick" runat="server" meta:resourcekey="Delete" />
                    <input type="reset" id='btnReset' runat="server" value="Nhập lại" />
                    <asp:Button ID='btnCancel' Visible="false" OnClick="btnCancel_OnClick" runat="server" Text="Hủy" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>