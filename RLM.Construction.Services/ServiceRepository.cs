using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Construction.Services
{
    public class ServiceRepository
    {
        #region Group
        static GroupService groupService;
        public static GroupService GroupService
        {
            get
            {
                if (groupService == null)
                {
                    groupService = new GroupService();
                }
                return groupService;
            }
        }
        #endregion

        #region Item
        static ItemService itemService;
        public static ItemService ItemService
        {
            get
            {
                if (itemService == null)
                {
                    itemService = new ItemService();
                }
                return itemService;
            }
        }
        #endregion

        #region Unit
        static UnitService unitService;
        public static UnitService UnitService
        {
            get
            {
                if (unitService == null)
                {
                    unitService = new UnitService();
                }
                return unitService;
            }
        }
        #endregion

        #region ContractService
        static ContractService contractService;
        public static ContractService ContractService
        {
            get
            {
                if (contractService == null)
                {
                    contractService = new ContractService();
                }
                return contractService;
            }
        }
        #endregion

        #region PartnerService
        static PartnerService partnerService;
        public static PartnerService PartnerService
        {
            get
            {
                if (partnerService == null)
                {
                    partnerService = new PartnerService();
                }
                return partnerService;
            }
        }
        #endregion

        #region DepartmentService
        static DepartmentService departmentService;
        public static DepartmentService DepartmentService
        {
            get
            {
                if (departmentService == null)
                {
                    departmentService = new DepartmentService();
                }
                return departmentService;
            }
        }
        #endregion

        #region ContactorService
        static ContactorService contactorService;
        public static ContactorService ContactorService
        {
            get
            {
                if (contactorService == null)
                {
                    contactorService = new ContactorService();
                }
                return contactorService;
            }
        }
        #endregion

        #region AttachFileService
        static AttachFileService attachFileService;
        public static AttachFileService AttachFileService
        {
            get
            {
                if (attachFileService == null)
                {
                    attachFileService = new AttachFileService();
                }
                return attachFileService;
            }
        }
        #endregion

        #region AttachFileService
        static ProjectService projectService;
        public static ProjectService ProjectService
        {
            get
            {
                if (projectService == null)
                {
                    projectService = new ProjectService();
                }
                return projectService;
            }
        }
        #endregion

        #region ProjectPhaseService
        static ProjectPhaseService projectPhaseService;
        public static ProjectPhaseService ProjectPhaseService
        {
            get
            {
                if (projectPhaseService == null)
                {
                    projectPhaseService = new ProjectPhaseService();
                }
                return projectPhaseService;
            }
        }
        #endregion

        #region ProjectPhaseService
        static ItemInProjectService itemInProjectService;
        public static ItemInProjectService ItemInProjectService
        {
            get
            {
                if (itemInProjectService == null)
                {
                    itemInProjectService = new ItemInProjectService();
                }
                return itemInProjectService;
            }
        }
        #endregion

        #region ItemInItemService
        static ItemInItemService itemInItemService;
        public static ItemInItemService ItemInItemService
        {
            get
            {
                if (itemInItemService == null)
                {
                    itemInItemService = new ItemInItemService();
                }
                return itemInItemService;
            }
        }
        #endregion

        #region AppConfigService
        static AppConfigService appConfigService;
        public static AppConfigService AppConfigService
        {
            get
            {
                if (appConfigService == null)
                {
                    appConfigService = new AppConfigService();
                }
                return appConfigService;
            }
        }
        #endregion
        
        #region AppConfigService
        static AdvanceRequestService advanceRequestService;
        public static AdvanceRequestService AdvanceRequestService
        {
            get
            {
                if (advanceRequestService == null)
                {
                    advanceRequestService = new AdvanceRequestService();
                }
                return advanceRequestService;
            }
        }
        #endregion

        #region AppConfigService
        static UnitConvertorService unitConvertorService;
        public static UnitConvertorService UnitConvertorService
        {
            get
            {
                if (unitConvertorService == null)
                {
                    unitConvertorService = new UnitConvertorService();
                }
                return unitConvertorService;
            }
        }
        #endregion
        
        #region AppConfigService
        static TaskService taskService;
        public static TaskService TaskService
        {
            get
            {
                if (taskService == null)
                {
                    taskService = new TaskService();
                }
                return taskService;
            }
        }
        #endregion

        #region AppConfigService
        static UserService userService;
        public static UserService UserService
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService();
                }
                return userService;
            }
        }
        #endregion

        #region StaffService
        static StaffService staffService;
        public static StaffService StaffService
        {
            get
            {
                if (staffService == null)
                {
                    staffService = new StaffService();
                }
                return staffService;
            }
        }
        #endregion

        #region RoleService
        static RoleService roleService;
        public static RoleService RoleService
        {
            get
            {
                if (roleService == null)
                {
                    roleService = new RoleService();
                }
                return roleService;
            }
        }
        #endregion
        
        #region RoleService
        static TaskMemberService taskMemberService;
        public static TaskMemberService TaskMemberService
        {
            get
            {
                if (taskMemberService == null)
                {
                    taskMemberService = new TaskMemberService();
                }
                return taskMemberService;
            }
        }
        #endregion

        #region CommentService
        static CommentService commentService;
        public static CommentService CommentService
        {
            get
            {
                if (commentService == null)
                {
                    commentService = new CommentService();
                }
                return commentService;
            }
        }
        #endregion

        #region GraphService
        static GraphService graphService;
        public static GraphService GraphService
        {
            get
            {
                if (graphService == null)
                {
                    graphService = new GraphService();
                }
                return graphService;
            }
        }
        #endregion

        #region ResourceDataService
        static ResourceDataService resourceDataService;
        public static ResourceDataService ResourceDataService
        {
            get
            {
                if (resourceDataService == null)
                {
                    resourceDataService = new ResourceDataService();
                }
                return resourceDataService;
            }
        }
        #endregion

        #region ItemIOTicketService
        static ItemIOTicketService itemIOTicketService;
        public static ItemIOTicketService ItemIOTicketService
        {
            get
            {
                if (itemIOTicketService == null)
                {
                    itemIOTicketService = new ItemIOTicketService();
                }
                return itemIOTicketService;
            }
        }
        #endregion

        #region ItemIOItemService
        static ItemIOItemService itemIOItemService;
        public static ItemIOItemService ItemIOItemService
        {
            get
            {
                if (itemIOItemService == null)
                {
                    itemIOItemService = new ItemIOItemService();
                }
                return itemIOItemService;
            }
        }
        #endregion
        
    }
}
