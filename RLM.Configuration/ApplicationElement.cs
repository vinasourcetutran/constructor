using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RLM.Configuration
{
    public class ApplicationElement : ConfigurationElement
    {
        #region Admin config
        [ConfigurationProperty("rootUserId", DefaultValue = 0)]
        public int RootUserId
        {
            get { return (int)this["rootUserId"]; }
        }

        #endregion

        #region Common
        [ConfigurationProperty("applicationName", DefaultValue = "RMS")]
        public string ApplicationName
        {
            get { return (string)this["applicationName"]; }
        }

        [ConfigurationProperty("author", DefaultValue = "RLM")]
        public string Author
        {
            get { return (string)this["author"]; }
        }

        [ConfigurationProperty("webSiteTitle", DefaultValue = "Market24h.net")]
        public string WebSiteTitle
        {
            get { return (string)this["webSiteTitle"]; }
        }
        #endregion

        //#region Mobivi Payment
        //[ConfigurationProperty("mobiviPaymentUrl", DefaultValue = "~/")]
        //public string MobiviPaymentUrl
        //{
        //    get { return (string)this["mobiviPaymentUrl"]; }
        //}

        //[ConfigurationProperty("mobiviPaymentConfigurationUrl", DefaultValue = "~/")]
        //public string MobiviPaymentConfigurationUrl
        //{
        //    get { return (string)this["mobiviPaymentConfigurationUrl"]; }
        //}

        //[ConfigurationProperty("mobiviAccountName", DefaultValue = "test")]
        //public string MobiviAccountName
        //{
        //    get { return (string)this["mobiviAccountName"]; }
        //}
        //#endregion

        //#region Payoo payment settings
        //[ConfigurationProperty("payooCheckOutUrl", DefaultValue = "~/")]
        //public string PayooCheckOutUrl
        //{
        //    get { return (string)this["payooCheckOutUrl"]; }
        //}

        //[ConfigurationProperty("payooPaymentConfigurationUrl", DefaultValue = "~/")]
        //public string PayooPaymentConfigurationUrl
        //{
        //    get { return (string)this["payooPaymentConfigurationUrl"]; }
        //}

        //[ConfigurationProperty("payooBusinessUserName", DefaultValue = "")]
        //public string PayooBusinessUserName
        //{
        //    get { return (string)this["payooBusinessUserName"]; }
        //}

        //[ConfigurationProperty("payooShopId", DefaultValue = "0")]
        //public long PayooShopId
        //{
        //    get { return (long)this["payooShopId"]; }
        //}

        //[ConfigurationProperty("payooAPIUserName", DefaultValue = "")]
        //public string PayooAPIUserName
        //{
        //    get { return (string)this["payooAPIUserName"]; }
        //}

        //[ConfigurationProperty("payooAPIUserPwd", DefaultValue = "")]
        //public string PayooAPIUserPwd
        //{
        //    get { return (string)this["payooAPIUserPwd"]; }
        //}

        //[ConfigurationProperty("payooAPISignature", DefaultValue = "")]
        //public string PayooAPISignature
        //{
        //    get { return (string)this["payooAPISignature"]; }
        //}

        //[ConfigurationProperty("payooShippingDay", DefaultValue = "0")]
        //public short PayooShippingDay
        //{
        //    get { return (short)this["payooShippingDay"]; }
        //}
        //#endregion
    }
}
