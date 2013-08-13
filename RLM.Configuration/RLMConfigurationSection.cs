using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RLM.Configuration
{
    public class RLMConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("smtp")]
        public SmtpElement Smtp
        {
            get { return (SmtpElement)this["smtp"]; }
        }
        [ConfigurationProperty("emailer")]
        public EmailerElement Emailer
        {
            get { return (EmailerElement)this["emailer"]; }
        }
        [ConfigurationProperty("application")]
        public ApplicationElement Application
        {
            get { return (ApplicationElement)this["application"]; }
        }
        [ConfigurationProperty("storage")]
        public StorageElement Storage
        {
            get { return (StorageElement)this["storage"]; }
       }
        [ConfigurationProperty("setting")]
        public SettingElement Setting
        {
            get { return (SettingElement)this["setting"]; }
        }
    }
}
