using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Construction.Entities
{
    public enum ViewMode
    {
     Edit,
     View
    }
    public enum ItemIOTicketStatus{
        New=1,
        Approved,
        Rejected,
        Closed,
        Reopened,
        Cancelled
    }
    public enum ItemIOTicketType
    {
        Input=1,
        Output,
        Movement
    }
    public enum StaffContractType
    {
        Temporary=1,
        Permanence
    }
    public enum RewardFormType
    {
        Promotion = 1,
        Money,
        Holiday
    }
    public enum FamilySideType
    {
        Mine=1,
        Wife,
        Husban
    }
    public enum SexType
    {
        None=1,
        Female,
        Male
    }

    public enum PunishFormType
    {
        Money=1,
        StopWorking,
        TempStopWorking
    }
    public enum PersonalIdentityField
    {
        Type,
        ID,
        IssuedPlace,
        IssuedDate,
        ExpiredDate,
        Comment,
        Country,
        Province,
        IssuedPerson
    }
    public enum PunishField
    {
        PunishForm,
        Money,
        MoneyUnit,
        Reason,
        IssuedLevel,
        AssigedDate,
        FromDate,
        ToDate,
        Comment,
        AttachFileUrl,
        AttachFileName,
        IsActive,
        IssuePerson,
        IssueId,
    }

    public enum ResponsibilityField
    {
        Type,
        Title,
        FromDate,
        ToDate,
        IsCurrentJob,
        Comment
    }

    public enum ContractField
    {
        Type,
        ContractNumber,
        FromDate,
        ToDate,
        ContractFile,
        ContractFileName,
        JobDescriptionFile,
        JobDescriptionFileName,
        IsCurrentJob,
        Comment
    }


    public enum RewardField
    {
        IsActive,
        IssuePerson,
        IssueId,
        RewardForm,
        Money,
        MoneyUnit,
        Reason,
        IssuedLevel,
        AssigedDate,
        EffectFrom,
        Comment,
        AttachFileUrl,
        AttachFileName
    }

    public enum EmailField
    {
        Type,
        Email,
        IsCurrentUsed
    }
    public enum PhoneField
    {
        Type,
        Phone,
        IsCurrentUsed
    }

    public enum FamilyField
    {
        Type,
        Side,
        FullName,
        Sex,
        Birhday,
        PID,
        Comment
    }

    public enum AddressField
    {
        Country,
        Province,
        Type,
        Address
    }
    public enum FamilyType
    {
        Father=1,
        Mother,
        Child,
        Daughter,
        GrandSon
    }
    public enum IdentifycationType
    {
        PersonalIdentity,
        Visa,
        Passport,
        DriverLicensed,
        Other
    }

    public enum PhoneType
    {
        Mobile=1,
        Phone
    }

    public enum EmailType
    {
        Yahoo=1,
        Gmail,
        Internal,
        MSN,
        Other
    }
    public enum AddressType
    {
        Permanent=1,
        Temporary
    }
    public enum ResourceDataContentType
    {
        StaffEmail=1,
        StaffPhone,
        StaffAddress,
        StaffIdentifycation,
        StaffFamily,
        StaffReward,
        StaffPunish,
        StaffContract,
        StaffJob,
        StaffResponsibility
    }

    public enum GraphDataItemType
    {
        Quantity,
        Price
    }
    public enum GraphType
    {
        Pie = 1,
        Line,
        Grant
    }

    public enum RoleType
    {
        Project=1,
        JobTitle,
        Task
    }

    public enum ResourceType
    {
        Contract = 1,
        ProjectGroup,
        Project,
        ProjectPhase,
        AdvanceRequest,
        Task,
        TaskMember,
        Meeting,
        Traning,
        Item,
        Role,
        Partner,
        Staff,
        RepositoryInput,
        RepositoryOutput,
        ItemMovement,
        ItemIOTicket,
        Contactor,
        Unit,
        AttachFile
    }
    public enum TaskMemberStatus
    {
        Waiting = 1,
        Joined,
        Released,
        Denied
    }

    public enum TaskType
    {
        Project = 1,
        Contract,
        ProjectPhase,
        Traning,
        Metting
    }

    public enum TaskStatus
    {
        Open = 1,
        Discussing,
        Rejected,
        Deploying,
        Deployed,
        Fail,
        Success,
        Closed
    }

    public enum AdvanceRequestStatus
    {
        New = 1,
        Approved,
        Finished,
        Close,
        Cancel
    }

    public enum AdvanceRequestType
    {
        Contract = 1,
        Project,
        ProjectPhase,
        Other
    }


    public enum ContractType
    {
        Electromechanical = 1,// co dien
        Construction,// xay lap
        Other
    }

    public enum ContractStatus
    {
        QuotationOut = 1,//bao gia di
        QuotationIn,// bao gia ve
        Start,
        Confirmed,//Xac nhan hoan thanh
        Finished,
        Liquidation,// thanh ly
        Cancel
    }

    public enum ExportFileType
    {
        None = 1,
        Pdf,
        Csv,
        Word,
        Excel
    }

    public enum ProjectPhaseType
    {
        Quotation = 1,//bao gia
        Design,// thiet ke
        InProgress,//thi cong
        Auctual,//thuc te
        Verify,//hoan cong
        Finished,// ket thuc
        Other
    }

    public enum ProjectPhaseStatus
    {
        NotStarted = 1,
        Started,
        Finished,
        Closed
    }

    public enum NavigateAction
    {
        List=1 ,
        Detail,
        Edit,
        AddNew,
        View,
        ClientView,
        ClientEdit,
        ClientAddNew,
        Delete,
        Thumnail,
        Big,// image with the full size
        OriginalFile,
        ClientCompare,//used for projectphase only
        Compare//used for projectphase only
    }

    public enum FileViewType
    {
        None,
        Thumnail = 1,
        Big,
        Full
    }

    //public enum AttachFileResourceType
    //{
    //    Contract = 1,
    //    Project,
    //    ProjectPhase,
    //    AdvanceRequest,
    //    Task,
    //    TaskMember,
    //    Comment
    //}

    public enum UnitType
    {
        Length = 1,
        Temperature,
        Money,
        Volume,// Thể tích
        Weight,
        Quantity
    }

    public enum GroupType
    {
        Repository = 1,
        Partner,
        ProjectPhase,
        Department,
        Contract,
        Item,
        Project,
        Contactor,
        JobTitle,
        Province,
        People,
        Religious,
        Reward,
        Punish,
        Country
    }

    public enum ItemStatus
    {
        NotAvailabel = 1
    }

    public enum ErrorType
    {
        None = 1,
        Error,
        Wraning,
        Info,
        Announcement
    }

    public enum SessionVariableEnum
    {
        CurrentUser = 1
    }
}
