<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainLeftNav.ascx.cs"
    Inherits="RLM.Construction.WebApplication.UserControl.MainLeftNav" %>
<div>
    <telerik:RadMenu runat="server" ID="mainLeftNavPanel" ExpandMode="SingleExpandedItem"
        Width="100%" OnClientItemClicked="RadPanelBarHelper.radPanelItemClicked">
        <Items>
           <%-- <telerik:RadMenuItem Visible="false" meta:resourcekey="CategoryPanelItem">
                <Items>
                </Items>
            </telerik:RadMenuItem>--%>
            <telerik:RadMenuItem meta:resourcekey="ContractPanelItem">
                <Items>
                    <telerik:RadMenuItem id='categoryContractList' meta:resourcekey="ContractCategoryList" url="Page/Contract/CategoryList.aspx" />
                    <telerik:RadMenuItem id='categoryContractAddNew' meta:resourcekey="ContractCategoryAddNew" url="Page/Contract/CategoryAddNew.aspx" />
                    <telerik:RadMenuItem id='contractList' meta:resourcekey="ContractList" url="Page/Contract/ContractList.aspx" />
                    <telerik:RadMenuItem id='contractAddNew'  meta:resourcekey="ContractAddNew" url="Page/Contract/ContractAddNew.aspx" />
                    <telerik:RadMenuItem id='contractAdvanceRequest' Visible="true" meta:resourcekey="ContractAdvanceRequest"
                        url="Page/Contract/AdvanceRequestList.aspx" />
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem meta:resourcekey="ProjectPanelItem">
                <Items>
                    <telerik:RadMenuItem id='projectCategoryList' meta:resourcekey="ProjectCategoryList" url="Page/Project/CategoryList.aspx" />
                    <telerik:RadMenuItem id='projectCategoryAddNew' meta:resourcekey="ProjectCategoryAddNew"
                        url="Page/Project/CategoryAddNew.aspx" />
                    <telerik:RadMenuItem id='projectPhaseList' meta:resourcekey="ProjectProjectPhase" url="Page/Project/ProjectPhaseList.aspx" />
                    <telerik:RadMenuItem id='categoryProjectPhaseAddNew' meta:resourcekey="ProjectProjectPhaseAddNew"
                        url="Page/Project/ProjectPhaseAddNew.aspx" />
                    <telerik:RadMenuItem id='projectList' meta:resourcekey="ProjectList" url="Page/Project/ProjectList.aspx" />
                    <telerik:RadMenuItem id='projectAddNew' meta:resourcekey="ProjectAddNew"
                        url="Page/Project/ProjectAddNew.aspx" />
                    <telerik:RadMenuItem id='itemInProjectList' meta:resourcekey="ProjectItemInProject"
                        url="Page/Project/ItemInProjectPhaseList.aspx" />
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem meta:resourcekey="ItemPanelItem">
                <Items>
                    <telerik:RadMenuItem id='itemCategory' meta:resourcekey="ItemCategory" url="Page/Item/CategoryList.aspx"> </telerik:RadMenuItem>
                    <telerik:RadMenuItem id='itemCategoryAddNew' meta:resourcekey="ItemCategoryAddNew" url="Page/Item/CategoryAddNew.aspx"/>
                    <telerik:RadMenuItem id='itemList' meta:resourcekey="ItemList" url="Page/Item/ItemList.aspx" />
                    <telerik:RadMenuItem id='itemAddNew' meta:resourcekey="ItemAddNew"
                        url="Page/Item/ItemAddNew.aspx" />
                </Items>
            </telerik:RadMenuItem>
             <telerik:RadMenuItem  meta:resourcekey="RepositoryPanelItem">
                <Items>
                    <telerik:RadMenuItem id='categoryRepository'  meta:resourcekey="CategoryRepository" url="Page/Repository/CategoryList.aspx"> </telerik:RadMenuItem>
                    <telerik:RadMenuItem id='categoryRepositoryAddNew'  meta:resourcekey="CategoryRepositoryAddNew" url="Page/Repository/CategoryAddNew.aspx"/>
                    <telerik:RadMenuItem id='repositoryInput'  Visible="true"  meta:resourcekey="RepositoryInput" url="Page/Repository/RepositoryInput.aspx" />
                    <telerik:RadMenuItem id='repositoryOutput' Visible=true meta:resourcekey="RepositoryOutput" url="Page/Repository/RepositoryOutput.aspx" />
                    <telerik:RadMenuItem id='repositoryMovement' Visible="true"  meta:resourcekey="RepositoryMovement" url="Page/Repository/RepositoryMovement.aspx" />
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem  meta:resourcekey="ReportPanelItem">
                <Items>
                        <telerik:RadMenuItem id='reportInProject' meta:resourcekey="ReportItemInProject" url="Page/Report/ReportItemInProject.aspx" />
                        <telerik:RadMenuItem id='reportByPartner' meta:resourcekey="ReportByPartner" url="Page/Report/ReportByPartner.aspx" />
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem meta:resourcekey="PartnerPanelItem">
                <Items>
                    <%--<telerik:RadMenuItem id='partnerContactorCategoryList' Visible="false" meta:resourcekey="PartnerContactorCategoryList"
                        url="Page/Partner/ContactorCategoryList.aspx" />--%>
                    
                    <telerik:RadMenuItem id='partnerContactorList' meta:resourcekey="PartnerContactorList" url="Page/Partner/ContactorList.aspx" />
                    <telerik:RadMenuItem id='partnerContactorAdNew' meta:resourcekey="PartnerContactorAddNew" url="Page/Partner/ContactorAddNew.aspx" />
                    
                    <%--<telerik:RadMenuItem id='partnerCategoryList'  Visible="false" meta:resourcekey="PartnerCategoryList" url="Page/Partner/CategoryList.aspx" />--%>
                    
                    <telerik:RadMenuItem id='partnerList' meta:resourcekey="PartnerList" url="Page/Partner/ItemList.aspx" />
                    <telerik:RadMenuItem id='partnerAddNew' meta:resourcekey="PartnerAddNew" url="Page/Partner/ItemAddNew.aspx" />
                    
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem meta:resourcekey="StaffPanelItem">
                <Items>
                    <telerik:RadMenuItem id='staffList' meta:resourcekey="StaffList" url="Page/Staff/StaffList.aspx" />
                    <telerik:RadMenuItem id='departmentCategoryList' meta:resourcekey="CategoryDepartment" url="Page/Department/CategoryList.aspx" />
                    <telerik:RadMenuItem id='staffCountry' meta:resourcekey="StaffCountryList" url="Page/Staff/CountryList.aspx" />
                    <telerik:RadMenuItem id='staffProvince' meta:resourcekey="StaffProvinceList" url="Page/Staff/ProvinceList.aspx" />
                    <telerik:RadMenuItem id='staffPeople' meta:resourcekey="StaffPeopleList" url="Page/Staff/PeopleList.aspx" />
                    <telerik:RadMenuItem id='staffReligious' meta:resourcekey="StaffReligiousList" url="Page/Staff/ReligiousList.aspx" />
                    <telerik:RadMenuItem id='staffRewardList' meta:resourcekey="StaffRewardList" url="Page/Staff/RewardList.aspx" />
                    <telerik:RadMenuItem id='staffPunishList' meta:resourcekey="StaffPunishList" url="Page/Staff/PunishList.aspx" />
                    <telerik:RadMenuItem id='staffRoleList' meta:resourcekey="StaffRoleList" url="Page/Staff/RoleList.aspx" />
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem  meta:resourcekey="SystemPanelItem">
                <Items>
                    <telerik:RadMenuItem id='systemUnitList' meta:resourcekey="SystemUnitList" url="Page/System/UnitList.aspx" />
                    <telerik:RadMenuItem id='systemAppConfig' meta:resourcekey="SystemAppConfig" url="Page/System/AppConfigList.aspx" />
                </Items>
            </telerik:RadMenuItem>
        </Items>
    </telerik:RadMenu>
</div>
