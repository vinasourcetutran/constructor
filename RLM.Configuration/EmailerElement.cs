using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RLM.Configuration
{
    public class EmailerElement : ConfigurationElement
    {
        #region email template url
        [ConfigurationProperty("emailTemplateUrl", DefaultValue = "~/Resources/EmailTemplate/")]
        public string EmailTemplateUrl
        {
            get { return (string)this["emailTemplateUrl"]; }
        }
        //[ConfigurationProperty("activateEmailSubject", DefaultValue = "Activate Email")]
        //public string ActivateEmailSubject
        //{
        //    get { return (string)this["activateEmailSubject"]; }
        //}
        //[ConfigurationProperty("forgotPwdEmailSubject", DefaultValue = "Forgot pwd")]
        //public string ForgotPwdEmailSubject
        //{
        //    get { return (string)this["forgotPwdEmailSubject"]; }
        //}
        //[ConfigurationProperty("memberActivateSuccess", DefaultValue = "3")]
        //public string MemberActivateSuccess
        //{
        //    get { return (string)this["memberActivateSuccess"]; }
        //}
        #endregion
    }
}
