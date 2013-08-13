using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RLM.Configuration
{
    public class RLMConfiguration
    {

        #region Variables
        static RLMConfigurationSection instance;
        #endregion

        #region Properties
        public static SmtpElement Smtp
        {
            get
            {
                return GetInstance().Smtp;
            }
        }
        public static StorageElement Storage
        {
            get
            {
                return GetInstance().Storage;
            }
        }
        public static EmailerElement Emailer
        {
            get
            {
                return GetInstance().Emailer;
            }
        }
        public static ApplicationElement Application
        {
            get
            {
                return GetInstance().Application;
            }
        }
        public static SettingElement Setting
        {
            get
            {
                return GetInstance().Setting;
            }
        }
        #endregion

        #region Static methods
        static RLMConfigurationSection GetInstance()
        {
            try
            {
                if (instance == null)
                {
                    instance = (RLMConfigurationSection)ConfigurationManager.GetSection("rlmConfiguration");
                }
                return instance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }

}
