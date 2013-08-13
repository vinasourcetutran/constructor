using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RLM.Configuration
{
    public class StorageElement : ConfigurationElement
    {

        [ConfigurationProperty("fileIconUrl", DefaultValue = "~/")]
        public string FileIconUrl
        {
            get { return (string)this["fileIconUrl"]; }
        }

        [ConfigurationProperty("advMaskFolderUrl", DefaultValue = "~/")]
        public string AdvMaskFolderUrl
        {
            get { return (string)this["advMaskFolderUrl"]; }
        }
        [ConfigurationProperty("storeBackgroundFolderUrl", DefaultValue = "~/")]
        public string StoreBackgroundFolderUrl
        {
            get { return (string)this["storeBackgroundFolderUrl"]; }
        }
        [ConfigurationProperty("noImageUrl", DefaultValue = "~/")]
        public string NoImageUrl
        {
            get { return (string)this["noImageUrl"]; }
        }
        [ConfigurationProperty("advFolderUrl", DefaultValue = "~/")]
        public string AdvFolderUrl
        {
            get { return (string)this["advFolderUrl"]; }
        }
        [ConfigurationProperty("mediaPlayerUrl", DefaultValue = "~/")]
        public string MediaPlayerUrl
        {
            get { return (string)this["mediaPlayerUrl"]; }
        }
        [ConfigurationProperty("rlmMaskUrl", DefaultValue = "~/")]
        public string RLMMaskUrl
        {
            get { return (string)this["rlmMaskUrl"]; }
        }

        [ConfigurationProperty("productFolderUrl", DefaultValue = "~/")]
        public string ProductFolderUrl
        {
            get { return (string)this["productFolderUrl"]; }
        }
        [ConfigurationProperty("memberAvatarFolderUrl", DefaultValue = "~/")]
        public string MemberAvatarFolderUrl
        {
            get { return (string)this["memberAvatarFolderUrl"]; }
        }

        [ConfigurationProperty("htmlTemplateUrl", DefaultValue = "~/")]
        public string HtmlTemplateUrl
        {
            get { return (string)this["htmlTemplateUrl"]; }
        }
        

        //[ConfigurationProperty("storeFolderUrl", DefaultValue = "~/")]
        //public string StoreFolderUrl
        //{
        //    get { return (string)this["storeFolderUrl"]; }
        //}
        #region File upload folder setting
        [ConfigurationProperty("attachFileFolderUrl", DefaultValue = "~/")]
        public string AttachFileFolderUrl
        {
            get { return (string)this["attachFileFolderUrl"]; }
        }
        [ConfigurationProperty("imageFolderUrl", DefaultValue = "~/")]
        public string ImageFolderUrl
        {
            get { return (string)this["imageFolderUrl"]; }
        }
        [ConfigurationProperty("tempUploadFolder", DefaultValue = "~/")]
        public string TempUploadFolder
        {
            get { return (string)this["tempUploadFolder"]; }
        }

        [ConfigurationProperty("storeLogoFolderUrl", DefaultValue = "~/")]
        public string StoreLogoFolderUrl
        {
            get { return (string)this["storeLogoFolderUrl"]; }
        }

        [ConfigurationProperty("storeBannerFolderUrl", DefaultValue = "~/")]
        public string StoreBannerFolderUrl
        {
            get { return (string)this["storeBannerFolderUrl"]; }
        }

        [ConfigurationProperty("documentFolderUrl", DefaultValue = "~/")]
        public string DocumentFolderUrl
        {
            get { return (string)this["documentFolderUrl"]; }
        }
        #endregion

    }
}
