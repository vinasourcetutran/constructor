<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true"
    CodeBehind="ContractAddNew.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.Contract.ContractAddNew" %>
<%@ Register Src="~/UserControl/AddNewRelatedItemLink.ascx" TagName="AddNewLink" TagPrefix="rlm" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript">
    function onPartnerSelected(id, name, representative) {
        $('.PartnerId').val(id);
        $('.PartnerName').html(name);
        if (representative != '') {
            $('.PartnerRepresentative').val(representative);
        }
//        var items = $('.PartnerRepresentative');
//        if (items && items.length > 0) {
////            var item = $('#' + items[0].id);
//            if (item.val() != '') { return; }
//            item.val(representative);
//        }
        
    }
</script>
    <div>
        <fieldset>
            <legend id="legend" runat="server"></legend>
            <div class="EditFormWrapper">
                
                <div class="Row Width50" id='divParentId' runat="server">
                    <label class="Label">
                        <asp:Literal ID='ltrGroup' runat="server" meta:resourcekey="Group"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:GroupComboBox Type="Contract" CssClass="Item AutoWidth" DataValueField="GroupId"
                        DataTextField="Name" ID="drpGroup" runat="server">
                    </rlm:GroupComboBox>
                    <rlm:addnewlink id='addNewGroupLink'  CssClass="" ResourceType="ProjectGroup" ResourceId=0 IsShowText=false runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='itemCategoryList' runat="server"  meta:resourcekey="AddNewGroup" url="Page/Contract/CategoryAddNew.aspx" />
                </div>
             
                <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='ltrCode' runat="server" meta:resourcekey="Code"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtCode' runat="server" Width="150" ></asp:TextBox>
                 </div>
                 <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='Literal24' runat="server" Text="Số HD"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtContractNumber' runat="server" Width="150" ></asp:TextBox>
                 </div>
                <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='ltrname' runat="server" meta:resourcekey="Name"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtName' CssClass="width300" runat="server"></asp:TextBox>
                </div>
                
                
                <div class="Row Width50" id='div9' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal15' runat="server" meta:resourcekey="Project"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <a href='#' id='lnkProject' runat="server" title="Thêm dự án">(Hiện tại chưa có dự án)</a>
                    <rlm:addnewlink id='lnkAddNewProject' CssClass="" ResourceId='0' ResourceType="Project" IsShowText="false" runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='projectList' runat="server"  meta:resourcekey="AddNewProject" url="Page/Project/ProjectAddNew.aspx" />
                </div>
                
                <div class="Row  Width50" id='div7' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal12' runat="server" meta:resourcekey="Partner"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:PartnerComboBox Visible="false" CssClass="Item AutoWidth" DataValueField="PartnerId" DataTextField="Name"
                        ID="drpPartner" runat="server">
                    </rlm:PartnerComboBox>
                    <input type="hidden" id='hddContractPartnerId' class='PartnerId' runat="server" />
                    <label class='PartnerName' runat="server" id='lblPartnerName'>(Vui lòng chọn)</label>
                    <rlm:addnewlink Visible="false" id='addNewPartnerLink' ResourceId="0" ResourceType=Partner IsShowText="false" runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='partnerList' runat="server"  meta:resourcekey="AddNewPartner" url="Page/Partner/ItemAddNew.aspx" />
                    <a class='SelectItemPopup thickbox' id='lnkSelectPartner' runat="server" href='#' title='Chọn đối tác'>&nbsp;</a>
                </div>
                
                <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='Literal18' runat="server" meta:resourcekey="ToContractor"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:ContactorComboBox ID="drpToContactor" CssClass="Item AutoWidth" runat="server">
                    </rlm:ContactorComboBox>
                    <asp:TextBox Visible="false" CssClass=' width300'  ID='txtContractRepresentative' runat="server"></asp:TextBox>
                </div>
                
                <div class="Row Width50">
                    <label class="Label">
                        <asp:Literal ID='Literal17' runat="server" meta:resourcekey="FromContractor"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <rlm:ContactorComboBox Visible="false" ID="drpFromContactor" CssClass="Item AutoWidth" runat="server">
                    </rlm:ContactorComboBox>
                    <asp:TextBox ID='txtFromRepresentative'  CssClass="width300 PartnerRepresentative" runat="server"></asp:TextBox>
                </div>
                
                
                
                
               
                <div class="Row None Width50">
                    <label class="Label">
                        <asp:Literal ID='Literal2' runat="server" meta:resourcekey="Description"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtDescription' TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
                </div>
                
                 <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal16' runat="server" meta:resourcekey="Type"></asp:Literal>
                    </label>
                    <rlm:ContractTypeCombobox ID="drpType" CssClass="Item AutoWidth" DataTextField="Name"
                        DataValueField="Value" runat="server">
                    </rlm:ContractTypeCombobox>
                </div>
                 <div class="Row None" style="display:none;">
                    <label class="Label">
                        <asp:Literal ID='Literal14' runat="server" meta:resourcekey="ContractFile"></asp:Literal>
                    </label>
                    <asp:FileUpload ID='contractFile' runat="server" />
                    <a  href='#' id='lnkContractFile' runat="server" target="_blank"></a>
                </div>
                <div class="None" id='div5' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal4' runat="server" meta:resourcekey="ConstructDept"></asp:Literal>
                    </label>
                    <rlm:GroupComboBox Type="Department" CssClass="Item AutoWidth" DataValueField="DeptId"
                        DataTextField="Name" ID="drpConstruct" runat="server">
                    </rlm:GroupComboBox>
                    <rlm:addnewlink id='Addnewlink1' runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='departmentCategoryList' runat="server"  meta:resourcekey="AddNewDepartment" url="Page/Department/CategoryAddNew.aspx" />
                </div>
                <div class="None" id='div6' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal11' runat="server" meta:resourcekey="DesignDept"></asp:Literal>
                    </label>
                     <rlm:GroupComboBox Type="Department" CssClass="Item AutoWidth" DataValueField="DeptId"
                        DataTextField="Name" ID="drpDesign" runat="server">
                    </rlm:GroupComboBox>
                    <rlm:addnewlink id='Addnewlink2'  runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='departmentCategoryList' runat="server"  meta:resourcekey="AddNewDepartment" url="Page/Department/CategoryAddNew.aspx" />
                </div>
                
                <div class="Row  Width32" id='div2' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal7' runat="server" meta:resourcekey="FirstPrice"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtFirstPrice' Width="150" Text="0" runat="server" CssClass='CustomFormat'></asp:TextBox>
                </div>
                <div class="Row Width32" id='div1' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal1' runat="server" meta:resourcekey="LastPrice"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtLastPrice' Width="150" Text="0" runat="server" CssClass='CustomFormat'></asp:TextBox>
                </div>

                <div class="Row Width32" id='div8' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal13' runat="server" meta:resourcekey="Currency"></asp:Literal>
                    </label>
                    <rlm:UnitComboBox type="Money" CssClass="Item AutoWidth" DataValueField="UnitId" DataTextField="Name"
                        ID="drpUnit" runat="server">
                    </rlm:UnitComboBox>
                    <rlm:addnewlink id='Addnewlink3' Visible="false"  CssClass="" ResourceId='0' ResourceType="Unit" IsShowText="false" runat='server' onclick="InnerPageHelper.addPageFromDOM($(this));return false;" tabId='systemUnitList' runat="server"  meta:resourcekey="AddNewUnit" url="Page/System/UnitList.aspx" />
                </div>

                <div class="Row Width32" id='div16' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal26' runat="server" meta:resourcekey="ExchangRate"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtExchangRate' Width="100" Text="1" runat="server" CssClass="CustomFormat"></asp:TextBox>
                    <span>&nbsp;&nbsp;(VND)</span>
                </div> 
                
                <div class="Row  Width32" id='div12' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal21' runat="server" meta:resourcekey="VATTax"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtVAT' Width="150" Text="0" runat="server"></asp:TextBox>
                </div>
                <div class="Row  Width32" id='div13' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal22' runat="server" meta:resourcekey="PITTax"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtPITTax' Width="150" Text="0" runat="server"></asp:TextBox>
                </div>
                <div class="Row  Width32" id='div14' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal23' runat="server" meta:resourcekey="CITTax"></asp:Literal>
                        <span class="Required">*</span>
                    </label>
                    <asp:TextBox ID='txtCITTax' Width="150" Text="0" runat="server"></asp:TextBox>
                </div>
                
                <div class="Row Width32" id='div15' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal25' runat="server" Text="Ngày ký"></asp:Literal>
                        
                    </label>
                    <telerik:RadDatePicker ID="radSignedDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32" id='div3' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal6' runat="server" meta:resourcekey="FromDate"></asp:Literal>
                        
                    </label>
                    <telerik:RadDatePicker ID="radFromDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="cldFromDate" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32" id='div4' runat="server">
                    <label class="Label">
                        <asp:Literal ID='Literal8' runat="server" meta:resourcekey="ToDate"></asp:Literal>
                    </label>
                    <asp:TextBox ID='txtTotalDays' Width="50" Text="0" runat="server" CssClass='CustomFormat'></asp:TextBox>
                    (ngày)&nbsp;
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
                    <asp:TextBox ID='txtRealTotalDays' Width="50" Text="0" runat="server" CssClass='CustomFormat'></asp:TextBox>
                    (ngày)&nbsp;
                    <telerik:RadDatePicker ID="radRealToDate" runat="server" MinDate="1900-01-01">
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal3' runat="server" meta:resourcekey="IsActive"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsActive' Checked="true" runat="server" />
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal10' runat="server" meta:resourcekey="IsApprove"></asp:Literal>
                    </label>
                    <asp:CheckBox ID='chkIsApprove' Visible="false" Checked="true" runat="server" />
                    <span id="spIsApprove" runat="server" class="NotOK">&nbsp;</span>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal9' runat="server" meta:resourcekey="Status"></asp:Literal>
                    </label>
                    <rlm:ContractStatusCombobox ID="drpStatus" CssClass="Item AutoWidth" DataTextField="Name"
                        DataValueField="Value" runat="server">
                    </rlm:ContractStatusCombobox>
                </div>
                <div class="Row Width32">
                    <label class="Label">
                        <asp:Literal ID='Literal5' runat="server" meta:resourcekey="LastModificationDate"></asp:Literal>
                    </label>
                    <span id="spLastModificationDate" runat="server">(None)</span>
                </div>
                <div class="BottonRow Row PaddingTop20 Width100Percent">
                    <asp:Button ID='btnSave' OnClick="btnSave_OnClick" runat="server" meta:resourcekey="Save" />
                    <input type="reset" id='btnReset' runat="server" value="Nhập lại" />
                    <asp:Button ID='btnCancel' Visible="false" OnClick="btnCancel_OnClick" runat="server" Text="Hủy"/>
                </div>
                <div class="Row">
                    <rlm:AttachFileList IsShowAddNewFileLink="true" ID='files' ViewMode="Edit" Visible="false" runat="server" ResourceType="Contract" />
                </div>
            </div>
        </fieldset>
    </div>
    <rlm:ValidationManager ID="validationManager" runat="server" SupportFolder="~/Resource/js/XValidation"
        FormToValidate="aspnetForm">
    </rlm:ValidationManager>
</asp:Content>
