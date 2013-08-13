using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using RLM.Core.Entity;

namespace RLM.Configuration
{
    public class SmtpElement : ConfigurationElement,ISmtp
    {
        [ConfigurationProperty("serverName", DefaultValue = "localhost")]
        public string ServerName
        {
            get { return (string)this["serverName"]; }
        }
        [ConfigurationProperty("defaultSender", DefaultValue = "")]
        public string DefaultSender
        {
            get { return (string)this["defaultSender"]; }
        }
        [ConfigurationProperty("enableSSL")]
        public bool EnableSSL
        {
            get { return (bool)this["enableSSL"]; }
        }
        [ConfigurationProperty("port", DefaultValue = 25)]
        public int Port
        {
            get { return (int)this["port"]; }
        }

        [ConfigurationProperty("userName", DefaultValue = "")]
        public string UserName
        {
            get { return (string)this["userName"]; }
        }

        [ConfigurationProperty("password", DefaultValue = "")]
        public string Password
        {
            get { return (string)this["password"]; }
        }
    }
}
