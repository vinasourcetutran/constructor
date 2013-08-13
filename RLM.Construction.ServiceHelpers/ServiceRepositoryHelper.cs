using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLM.Construction.ServiceHelpers
{
    public class ServiceRepositoryHelper
    {
        #region item
        static ItemServiceHelper itemServiceHelper;
        public static ItemServiceHelper ItemServiceHelper {
            get
            {
                if (itemServiceHelper == null)
                {
                    itemServiceHelper = new ItemServiceHelper();
                }
                return itemServiceHelper;
            }
        }
        #endregion

        #region GroupServiceHelper
        static GroupServiceHelper droupServiceHelper;
        public static GroupServiceHelper GroupServiceHelper
        {
            get
            {
                if (droupServiceHelper == null)
                {
                    droupServiceHelper = new GroupServiceHelper();
                }
                return droupServiceHelper;
            }
        }
        #endregion

        #region UnitServiceHelper
        static UnitServiceHelper unitServiceHelper;
        public static UnitServiceHelper UnitServiceHelper
        {
            get
            {
                if (unitServiceHelper == null)
                {
                    unitServiceHelper = new UnitServiceHelper();
                }
                return unitServiceHelper;
            }
        }
        #endregion

        #region ItemInItemServiceHelper
        static ItemInItemServiceHelper itemInItemServiceHelper;
        public static ItemInItemServiceHelper ItemInItemServiceHelper
        {
            get
            {
                if (itemInItemServiceHelper == null)
                {
                    itemInItemServiceHelper = new ItemInItemServiceHelper();
                }
                return itemInItemServiceHelper;
            }
        }
        #endregion

        #region ItemInItemServiceHelper
        static AttachFileServiceHelper attachFileServiceHelper;
        public static AttachFileServiceHelper AttachFileServiceHelper
        {
            get
            {
                if (attachFileServiceHelper == null)
                {
                    attachFileServiceHelper = new AttachFileServiceHelper();
                }
                return attachFileServiceHelper;
            }
        }
        #endregion

        #region AppConfigServiceHelper
        static AppConfigServiceHelper appConfigServiceHelper;
        public static AppConfigServiceHelper AppConfigServiceHelper
        {
            get
            {
                if (appConfigServiceHelper == null)
                {
                    appConfigServiceHelper = new AppConfigServiceHelper();
                }
                return appConfigServiceHelper;
            }
        }
        #endregion

        #region ContactorServiceHelper
        static ContactorServiceHelper contactorServiceHelper;
        public static ContactorServiceHelper ContactorServiceHelper
        {
            get
            {
                if (contactorServiceHelper == null)
                {
                    contactorServiceHelper = new ContactorServiceHelper();
                }
                return contactorServiceHelper;
            }
        }
        #endregion

        #region ContractServiceHelper
        static ContractServiceHelper contractServiceHelper;
        public static ContractServiceHelper ContractServiceHelper
        {
            get
            {
                if (contractServiceHelper == null)
                {
                    contractServiceHelper = new ContractServiceHelper();
                }
                return contractServiceHelper;
            }
        }
        #endregion

        #region AdvanceRequestServiceHelper
        static AdvanceRequestServiceHelper advanceRequestServiceHelper;
        public static AdvanceRequestServiceHelper AdvanceRequestServiceHelper
        {
            get
            {
                if (advanceRequestServiceHelper == null)
                {
                    advanceRequestServiceHelper = new AdvanceRequestServiceHelper();
                }
                return advanceRequestServiceHelper;
            }
        }
        #endregion

        #region PartnerServiceHelper
        static PartnerServiceHelper partnerServiceHelper;
        public static PartnerServiceHelper PartnerServiceHelper
        {
            get
            {
                if (partnerServiceHelper == null)
                {
                    partnerServiceHelper = new PartnerServiceHelper();
                }
                return partnerServiceHelper;
            }
        }
        #endregion

        #region ProjectServiceHelper
        static ProjectServiceHelper projectServiceHelper;
        public static ProjectServiceHelper ProjectServiceHelper
        {
            get
            {
                if (projectServiceHelper == null)
                {
                    projectServiceHelper = new ProjectServiceHelper();
                }
                return projectServiceHelper;
            }
        }
        #endregion

        #region ProjectPhaseServiceHelper
        static ProjectPhaseServiceHelper projectPhaseServiceHelper;
        public static ProjectPhaseServiceHelper ProjectPhaseServiceHelper
        {
            get
            {
                if (projectPhaseServiceHelper == null)
                {
                    projectPhaseServiceHelper = new ProjectPhaseServiceHelper();
                }
                return projectPhaseServiceHelper;
            }
        }
        #endregion

        #region ProjectPhaseServiceHelper
        static ItemInProjectServiceHelper itemInProjectServiceHelper;
        public static ItemInProjectServiceHelper ItemInProjectServiceHelper
        {
            get
            {
                if (itemInProjectServiceHelper == null)
                {
                    itemInProjectServiceHelper = new ItemInProjectServiceHelper();
                }
                return itemInProjectServiceHelper;
            }
        }
        #endregion

        #region UnitConvertorServiceHelper
        static UnitConvertorServiceHelper unitConvertorServiceHelper;
        public static UnitConvertorServiceHelper UnitConvertorServiceHelper
        {
            get
            {
                if (unitConvertorServiceHelper == null)
                {
                    unitConvertorServiceHelper = new UnitConvertorServiceHelper();
                }
                return unitConvertorServiceHelper;
            }
        }
        #endregion

        #region UnitConvertorServiceHelper
        static UserServiceHelper userServiceHelper;
        public static UserServiceHelper UserServiceHelper
        {
            get
            {
                if (userServiceHelper == null)
                {
                    userServiceHelper = new UserServiceHelper();
                }
                return userServiceHelper;
            }
        }
        #endregion
        
        #region UnitConvertorServiceHelper
        static TaskServiceHelper taskServiceHelper;
        public static TaskServiceHelper TaskServiceHelper
        {
            get
            {
                if (taskServiceHelper == null)
                {
                    taskServiceHelper = new TaskServiceHelper();
                }
                return taskServiceHelper;
            }
        }
        #endregion

        #region StaffServiceHelper
        static StaffServiceHelper staffServiceHelper;
        public static StaffServiceHelper StaffServiceHelper
        {
            get
            {
                if (staffServiceHelper == null)
                {
                    staffServiceHelper = new StaffServiceHelper();
                }
                return staffServiceHelper;
            }
        }
        #endregion

        #region RoleServiceHelper
        static RoleServiceHelper roleServiceHelper;
        public static RoleServiceHelper RoleServiceHelper
        {
            get
            {
                if (roleServiceHelper == null)
                {
                    roleServiceHelper = new RoleServiceHelper();
                }
                return roleServiceHelper;
            }
        }
        #endregion

        #region TaskMemberServiceHelper
        static TaskMemberServiceHelper taskMemberServiceHelper;
        public static TaskMemberServiceHelper TaskMemberServiceHelper
        {
            get
            {
                if (taskMemberServiceHelper == null)
                {
                    taskMemberServiceHelper = new TaskMemberServiceHelper();
                }
                return taskMemberServiceHelper;
            }
        }
        #endregion

        #region TaskMemberServiceHelper
        static CommentServiceHelper commentServiceHelper;
        public static CommentServiceHelper CommentServiceHelper
        {
            get
            {
                if (commentServiceHelper == null)
                {
                    commentServiceHelper = new CommentServiceHelper();
                }
                return commentServiceHelper;
            }
        }
        #endregion

        #region GraphServiceHelper
        static GraphServiceHelper graphServiceHelper;
        public static GraphServiceHelper GraphServiceHelper
        {
            get
            {
                if (graphServiceHelper == null)
                {
                    graphServiceHelper = new GraphServiceHelper();
                }
                return graphServiceHelper;
            }
        }
        #endregion

        #region ResourceDataServiceHelper
        static ResourceDataServiceHelper resourceDataServiceHelper;
        public static ResourceDataServiceHelper ResourceDataServiceHelper
        {
            get
            {
                if (resourceDataServiceHelper == null)
                {
                    resourceDataServiceHelper = new ResourceDataServiceHelper();
                }
                return resourceDataServiceHelper;
            }
        }
        #endregion

        #region ResourceDataServiceHelper
        static ItemIOTicketServiceHelper itemIOTicketServiceHelper;
        public static ItemIOTicketServiceHelper ItemIOTicketServiceHelper
        {
            get
            {
                if (itemIOTicketServiceHelper == null)
                {
                    itemIOTicketServiceHelper = new ItemIOTicketServiceHelper();
                }
                return itemIOTicketServiceHelper;
            }
        }
        #endregion

        #region ItemIOItemServiceHelper
        static ItemIOItemServiceHelper itemIOItemServiceHelper;
        public static ItemIOItemServiceHelper ItemIOItemServiceHelper
        {
            get
            {
                if (itemIOItemServiceHelper == null)
                {
                    itemIOItemServiceHelper = new ItemIOItemServiceHelper();
                }
                return itemIOItemServiceHelper;
            }
        }
        #endregion
        

    }
}
