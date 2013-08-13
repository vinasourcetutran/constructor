using System;
using System.Collections.Generic;

using System.Web;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;

namespace RLM.Construction.WebApplication.CommonLib
{
    public class RLMContext
    {
        #region Error
        public static string ErrorMessage { get; set; }

        public static ErrorType ErrorType { get; set; }

        public static Exception Error { get; set; }
        #endregion

        #region User
        static RLM.Construction.Entities.User currentUser = null;
        public static RLM.Construction.Entities.User CurrentUser {
            get
            {
                try
                {
                    if (currentUser == null && HttpContext.Current.Session[SessionVariableEnum.CurrentUser.ToString()]!=null)
                    {
                        currentUser = (User)HttpContext.Current.Session[SessionVariableEnum.CurrentUser.ToString()];
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
                return currentUser;
            }
            set
            {
                HttpContext.Current.Session[SessionVariableEnum.CurrentUser.ToString()] = currentUser = value;
            }
        }
        #endregion
    }
}
