<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffCommonInfo.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Staff.StaffCommonInfo" %>
<div>
        <fieldset>
            <legend id="legend" meta:resourcekey="ViewDetail" runat="server"></legend>
            <div class="EditFormWrapper">
            <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="StaffCode"></asp:Literal>
                    </label>
                    <asp:Label ID='lblStaffCode' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="FullName"></asp:Literal>
                    </label>
                    <asp:Label ID='lblFullName' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="Magnetic"></asp:Literal>
                    </label>
                    <asp:Label ID='lblMagnetic' runat="server" />
                </div>
                
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal112121" runat="server" meta:resourcekey="Sex"></asp:Literal>
                    </label>
                    <asp:Label ID='lblSex' runat="server" />
               </div>
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal9" runat="server" meta:resourcekey="Birthday"></asp:Literal>
                    </label>
                     <asp:Label ID='lblBirthday' runat="server" />
                </div>
                <div class="Row MarginRight5">
                    <label class="Label">
                        <asp:Literal ID="Literal10" runat="server" meta:resourcekey="BirthPlace"></asp:Literal>
                    </label>
                     <asp:Label ID='lblBirthPlace' runat="server" />
                </div>
                <div class="Row MarginRight5" style="display:none;">
                    <label class="Label">
                        <asp:Literal ID="Literal18" runat="server" meta:resourcekey="PermanentAddress"></asp:Literal>
                    </label>
                     <asp:Label ID='lblPerAddress' runat="server" />
                </div>
                <div class="Row MarginRight5" style="display:none;">
                    <label class="Label">
                        <asp:Literal ID="Literal19" runat="server" meta:resourcekey="TempAddress"></asp:Literal>
                    </label>
                     <asp:Label ID='lblTempAddress' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal12" runat="server" meta:resourcekey="Religous"></asp:Literal>
                    </label>
                     <asp:Label ID='lblReligious' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal13" runat="server" meta:resourcekey="People"></asp:Literal>
                    </label>
                     <asp:Label ID='lblPeople' runat="server" />
                </div>
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal14" runat="server" meta:resourcekey="StartWorkingDate"></asp:Literal>
                    </label>
                     <asp:Label ID='lblStartWorkingDay' runat="server" />
                </div>
                <div class="Row" >
                    <label class="Label">
                        <asp:Literal ID="Literal15" runat="server" meta:resourcekey="WorkingDate"></asp:Literal>
                    </label>
                     <asp:Label ID='lblWorkingDay' runat="server" />
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal16" runat="server" meta:resourcekey="Department"></asp:Literal>
                    </label>
                     <asp:Label ID='lblDept' runat="server" />
                </div>
                 <div class="Row">
                    <label class="Label">
                        <asp:Literal ID="Literal17" runat="server" meta:resourcekey="JobTitle"></asp:Literal>
                    </label>
                     <asp:Label ID='lblJobTitle' runat="server" />
                </div>
                
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <span id='spIsActive' runat="server" class="OK">&nbsp;</span>
                </div>
                <div class="Row">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow">
                    <asp:Button ID='btnBack' OnClick="btnBack_OnClick" runat="server"
                        meta:resourcekey="Back" />
                </div>
            </div>
        </fieldset>
    </div>