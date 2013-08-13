using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RLM.Configuration
{
    public class SettingElement : ConfigurationElement
    {
        #region Group
        [ConfigurationProperty("defaultProjectGroupId", DefaultValue = "100")]
        public int DefaultProjectGroupId
        {
            get { return (int)this["defaultProjectGroupId"]; }
        }
        #endregion

        #region Item photo
        [ConfigurationProperty("itemPhotoThumnailWidth", DefaultValue = "100")]
        public int ItemPhotoThumnailWidth
        {
            get { return (int)this["itemPhotoThumnailWidth"]; }
        }

        [ConfigurationProperty("itemPhotoThumnailHeight", DefaultValue = "100")]
        public int ItemPhotoThumnailHeight
        {
            get { return (int)this["itemPhotoThumnailHeight"]; }
        }

        [ConfigurationProperty("itemPhotoWidth", DefaultValue = "100")]
        public int ItemPhotoWidth
        {
            get { return (int)this["itemPhotoWidth"]; }
        }

        [ConfigurationProperty("itemPhotoHeight", DefaultValue = "100")]
        public int ItemPhotoHeight
        {
            get { return (int)this["itemPhotoHeight"]; }
        }
        #endregion

        #region Mask

        [ConfigurationProperty("contractCodeMask", DefaultValue = "")]
        public string ContractCodeMask
        {
            get { return (string)this["contractCodeMask"]; }
        }
        #endregion

        #region Datalist setting
        [ConfigurationProperty("defaultPageSize", DefaultValue = "20")]
        public int DefaultPageSize
        {
            get { return (int)this["defaultPageSize"]; }
        }
        #endregion

        #region File upload setting
        [ConfigurationProperty("textFilePattern", DefaultValue = "")]
        public string TextFilePattern
        {
            get { return (string)this["textFilePattern"]; }
        }

        [ConfigurationProperty("imageFilePattern", DefaultValue = "")]
        public string ImageFilePattern
        {
            get { return (string)this["imageFilePattern"]; }
        }

        [ConfigurationProperty("videoFilePattern", DefaultValue = "")]
        public string VideoFilePattern
        {
            get { return (string)this["videoFilePattern"]; }
        }

        [ConfigurationProperty("flashFilePattern", DefaultValue = "")]
        public string FlashFilePattern
        {
            get { return (string)this["flashFilePattern"]; }
        }

        [ConfigurationProperty("fileUploadAllowedFileType", DefaultValue = "")]
        public string FileUploadAllowedFileType
        {
            get { return (string)this["fileUploadAllowedFileType"]; }
        }

        [ConfigurationProperty("fileUploadMaxSize", DefaultValue = "102400")]
        public int FileUploadMaxSize
        {
            get { return (int)this["fileUploadMaxSize"]; }
        }

        [ConfigurationProperty("imageThumbnailWidth", DefaultValue = "150")]
        public int ImageThumbnailWidth
        {
            get { return (int)this["imageThumbnailWidth"]; }
        }

        [ConfigurationProperty("imageThumbnailHeight", DefaultValue = "150")]
        public int ImageThumbnailHeight
        {
            get { return (int)this["imageThumbnailHeight"]; }
        }

        [ConfigurationProperty("imageBigWidth", DefaultValue = "102400")]
        public int ImageBigWidth
        {
            get { return (int)this["imageBigWidth"]; }
        }

        [ConfigurationProperty("imageBigHeight", DefaultValue = "102400")]
        public int ImageBigHeight
        {
            get { return (int)this["imageBigHeight"]; }
        }
        #endregion

        #region Unit setting
        [ConfigurationProperty("vndUnitId", DefaultValue = "0")]
        public int VndUnitId
        {
            get { return (int)this["vndUnitId"]; }
        }

        
        #endregion

        //[ConfigurationProperty("fileUploadAllowedFileExtPattern", DefaultValue = "")]
        //public string FileUploadAllowedFileExtPattern
        //{
        //    get { return (string)this["fileUploadAllowedFileExtPattern"]; }
        //}

        //[ConfigurationProperty("shoppingCartKey", DefaultValue = "")]
        //public string ShoppingCartKey
        //{
        //    get { return (string)this["shoppingCartKey"]; }
        //}

        //[ConfigurationProperty("homeTopRightAdvGroupId", DefaultValue = 0)]
        //public int HomeTopRightAdvGroupId
        //{
        //    get { return (int)this["homeTopRightAdvGroupId"]; }
        //}

        //[ConfigurationProperty("classifySearchingByFilterPageSize", DefaultValue = 6)]
        //public int ClassifySearchingByFilterPageSize
        //{
        //    get { return (int)this["classifySearchingByFilterPageSize"]; }
        //}
        //[ConfigurationProperty("genPwdLength", DefaultValue = 6)]
        //public int GenPwdLength
        //{
        //    get { return (int)this["genPwdLength"]; }
        //}
        //[ConfigurationProperty("websideUrl", DefaultValue = "")]
        //public string WebsideUrl
        //{
        //    get { return (string)this["websideUrl"]; }
        //}

        //[ConfigurationProperty("memberActivateDelayBeforeRedirect", DefaultValue = "3")]
        //public int MemberActivateDelayBeforeRedirect
        //{
        //    get { return (int)this["memberActivateDelayBeforeRedirect"]; }
        //}
        
        //[ConfigurationProperty("categoryIdOfProduct", DefaultValue = 1)]
        //public int CategoryIdOfProduct
        //{
        //    get { return (int)this["categoryIdOfProduct"]; }
        //}

        //[ConfigurationProperty("docCategoryIdOfPromotionInfos", DefaultValue = 1)]
        //public int DocCategoryIdOfPromotionInfos
        //{
        //    get { return (int)this["docCategoryIdOfPromotionInfos"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowBottomProductsInDay", DefaultValue = 5)]
        //public int MaxItemOfShowBottomProductsInDay
        //{
        //    get { return (int)this["maxItemOfShowBottomProductsInDay"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowLeftHighlightProducts", DefaultValue = 5)]
        //public int MaxItemOfShowLeftHighlightProducts
        //{
        //    get { return (int)this["maxItemOfShowLeftHighlightProducts"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowLeftNewProducts", DefaultValue = 5)]
        //public int MaxItemOfShowLeftNewProducts
        //{
        //    get { return (int)this["maxItemOfShowLeftNewProducts"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowRightPromotionProducts", DefaultValue = 5)]
        //public int MaxItemOfShowRightPromotionProducts
        //{
        //    get { return (int)this["maxItemOfShowRightPromotionProducts"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowLeftDetailProductCategories", DefaultValue = 5)]
        //public int MaxItemOfShowLeftDetailProductCategories
        //{
        //    get { return (int)this["maxItemOfShowLeftDetailProductCategories"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowRightPromotionInfos", DefaultValue = 5)]
        //public int MaxItemOfShowRightPromotionInfos
        //{
        //    get { return (int)this["maxItemOfShowRightPromotionInfos"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowRightClassifies", DefaultValue = 5)]
        //public int MaxItemOfShowRightClassifies
        //{
        //    get { return (int)this["maxItemOfShowRightClassifies"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowRightAuctions", DefaultValue = 5)]
        //public int MaxItemOfShowRightAuctions
        //{
        //    get { return (int)this["maxItemOfShowRightAuctions"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowBottomHighlightStores", DefaultValue = 5)]
        //public int MaxItemOfShowBottomHighlightStores
        //{
        //    get { return (int)this["maxItemOfShowBottomHighlightStores"]; }
        //}

        #region Money setting
        [ConfigurationProperty("moneyFormat", DefaultValue = "")]
        public string MoneyFormat
        {
            get { return (string)this["moneyFormat"]; }
        }
        #endregion

        #region Datetime setting
        [ConfigurationProperty("shortDateTimeFormat", DefaultValue = "")]
        public string ShortDateTimeFormat
        {
            get { return (string)this["shortDateTimeFormat"]; }
        }

        [ConfigurationProperty("longDateTimeFormat", DefaultValue = "")]
        public string LongDateTimeFormat
        {
            get { return (string)this["longDateTimeFormat"]; }
        }
        #endregion

        //[ConfigurationProperty("maxItemOfShowBottomProductsViewed", DefaultValue = 20)]
        //public int MaxItemOfShowBottomProductsViewed
        //{
        //    get { return (int)this["maxItemOfShowBottomProductsViewed"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowRightProvinces", DefaultValue = 4)]
        //public int MaxItemOfShowRightProvinces
        //{
        //    get { return (int)this["maxItemOfShowRightProvinces"]; }
        //}

        //[ConfigurationProperty("numberOfVisitorKey", DefaultValue = "StoreVisitor")]
        //public string NumberOfVisitorKey
        //{
        //    get { return (string)this["numberOfVisitorKey"]; }
        //}
        //[ConfigurationProperty("friendListPageSize", DefaultValue = 0)]
        //public int FriendListPageSize
        //{
        //    get { return (int)this["friendListPageSize"]; }
        //}
        //[ConfigurationProperty("storeProductPageSize", DefaultValue = 0)]
        //public int StoreProductPageSize
        //{
        //    get { return (int)this["storeProductPageSize"]; }
        //}

        

        //[ConfigurationProperty("visitorNumberConfigName", DefaultValue = "VisitorNumber")]
        //public string VisitorNumberConfigName
        //{
        //    get { return (string)this["visitorNumberConfigName"]; }
        //}

        //[ConfigurationProperty("visitorInDayConfigName", DefaultValue = "VisitorInDay")]
        //public string VisitorInDayConfigName
        //{
        //    get { return (string)this["visitorInDayConfigName"]; }
        //}

        //[ConfigurationProperty("sessionNameForPagging", DefaultValue = "sessionNameForPagging")]
        //public string SessionNameForPagging
        //{
        //    get { return (string)this["sessionNameForPagging"]; }
        //}

        //[ConfigurationProperty("storeCommentPageSize", DefaultValue = "10")]
        //public int StoreCommentPageSize
        //{
        //    get { return (int)this["storeCommentPageSize"]; }
        //}
        //[ConfigurationProperty("storeAuctionPageSize", DefaultValue = "10")]
        //public int StoreAuctionPageSize
        //{
        //    get { return (int)this["storeAuctionPageSize"]; }
        //}

        //[ConfigurationProperty("sessionNameForSearch", DefaultValue = "sessionNameForSearch")]
        //public string SessionNameForSearch
        //{
        //    get { return (string)this["sessionNameForSearch"]; }
        //}

        //[ConfigurationProperty("rangeTimeOfNewProduct", DefaultValue = 30)]
        //public int RangeTimeOfNewProduct
        //{
        //    get { return (int)this["rangeTimeOfNewProduct"]; }
        //}

        //[ConfigurationProperty("rangeTimeOfProductInDay", DefaultValue = 30)]
        //public int RangeTimeOfProductInDay
        //{
        //    get { return (int)this["rangeTimeOfProductInDay"]; }
        //}

        //[ConfigurationProperty("maxItemOfShowLeftProductList", DefaultValue = 10)]
        //public int MaxItemOfShowLeftProductList
        //{
        //    get { return (int)this["maxItemOfShowLeftProductList"]; }
        //}

        //[ConfigurationProperty("storeAdvGroupId", DefaultValue = 10)]
        //public int StoreAdvGroupId
        //{
        //    get { return (int)this["storeAdvGroupId"]; }
        //}
        //[ConfigurationProperty("productInTheSameCategoryPageSize", DefaultValue = 10)]
        //public int ProductInTheSameCategoryPageSize
        //{
        //    get { return (int)this["productInTheSameCategoryPageSize"]; }
        //}
        //[ConfigurationProperty("maxItemOfShowRightAdvs", DefaultValue = 4)]
        //public int MaxItemOfShowRightAdvs
        //{
        //    get { return (int)this["maxItemOfShowRightAdvs"]; }
        //}

        //[ConfigurationProperty("searchPriceList", DefaultValue = "500000, 1000000, 2000000, 3000000, 5000000")]
        //public string SearchPriceList
        //{
        //    get { return (string)this["searchPriceList"]; }
        //}
        //[ConfigurationProperty("productInTheSamePricePageSize", DefaultValue = "10")]
        //public int ProductInTheSamePricePageSize
        //{
        //    get { return (int)this["productInTheSamePricePageSize"]; }
        //}
        //[ConfigurationProperty("profilePageSize", DefaultValue = "10")]
        //public int ProfilePageSize
        //{
        //    get { return (int)this["profilePageSize"]; }
        //}

        //[ConfigurationProperty("docCategoryIdOfContact", DefaultValue = 2)]
        //public int DocCategoryIdOfContact
        //{
        //    get { return (int)this["docCategoryIdOfContact"]; }
        //}

        //[ConfigurationProperty("docCategoryIdOfSupport", DefaultValue = 2)]
        //public int DocCategoryIdOfSupport
        //{
        //    get { return (int)this["docCategoryIdOfSupport"]; }
        //}

        //[ConfigurationProperty("docCategoryIdOfShoppingGuide", DefaultValue = 2)]
        //public int DocCategoryIdOfShoppingGuide
        //{
        //    get { return (int)this["docCategoryIdOfShoppingGuide"]; }
        //}

        //[ConfigurationProperty("docCategoryIdOfTermsOfSecurity", DefaultValue = 2)]
        //public int DocCategoryIdOfTermsOfSecurity
        //{
        //    get { return (int)this["docCategoryIdOfTermsOfSecurity"]; }
        //}

        //[ConfigurationProperty("docCategoryIdOfTermsOfUse", DefaultValue = 2)]
        //public int DocCategoryIdOfTermsOfUse
        //{
        //    get { return (int)this["docCategoryIdOfTermsOfUse"]; }
        //}

        //[ConfigurationProperty("docCategoryIdOfUseGuide", DefaultValue = 2)]
        //public int DocCategoryIdOfUseGuide
        //{
        //    get { return (int)this["docCategoryIdOfUseGuide"]; }
        //}
        //[ConfigurationProperty("fileUploadAllowExtension", DefaultValue = "")]
        //public string FileUploadAllowExtension
        //{
        //    get { return (string)this["fileUploadAllowExtension"]; }
        //}

        //[ConfigurationProperty("maxFileUploadSize", DefaultValue = "1024")]
        //public int MaxFileUploadSize
        //{
        //    get { return (int)this["maxFileUploadSize"]; }
        //}

        //[ConfigurationProperty("memberAvatarWidth", DefaultValue = "1024")]
        //public int MemberAvatarWidth
        //{
        //    get { return (int)this["memberAvatarWidth"]; }
        //}

        //[ConfigurationProperty("memberAvatarHeight", DefaultValue = "1024")]
        //public int MemberAvatarHeight
        //{
        //    get { return (int)this["memberAvatarHeight"]; }
        //}

        //[ConfigurationProperty("memberSmallAvatarWidth", DefaultValue = "1024")]
        //public int MemberSmallAvatarWidth
        //{
        //    get { return (int)this["memberSmallAvatarWidth"]; }
        //}

        //[ConfigurationProperty("memberSmallAvatarHeight", DefaultValue = "1024")]
        //public int MemberSmallAvatarHeight
        //{
        //    get { return (int)this["memberSmallAvatarHeight"]; }
        //}


        //[ConfigurationProperty("storeBannerWidth", DefaultValue = "1024")]
        //public int StoreBannerWidth
        //{
        //    get { return (int)this["storeBannerWidth"]; }
        //}
        //[ConfigurationProperty("storeBannerHeight", DefaultValue = "1024")]
        //public int StoreBannerHeight
        //{
        //    get { return (int)this["storeBannerHeight"]; }
        //}
        //[ConfigurationProperty("storeLogoWidth", DefaultValue = "1024")]
        //public int StoreLogoWidth
        //{
        //    get { return (int)this["storeLogoWidth"]; }
        //}
        //[ConfigurationProperty("storeLogoHeight", DefaultValue = "1024")]
        //public int StoreLogoHeight
        //{
        //    get { return (int)this["storeLogoHeight"]; }
        //}


        //[ConfigurationProperty("productPhotoListThumnailWidth", DefaultValue = "1024")]
        //public int ProductPhotoListThumnailWidth
        //{
        //    get { return (int)this["productPhotoListThumnailWidth"]; }
        //}
        //[ConfigurationProperty("productPhotoListThumnailHeight", DefaultValue = "1024")]
        //public int ProductPhotoListThumnailHeight
        //{
        //    get { return (int)this["productPhotoListThumnailHeight"]; }
        //}


        //[ConfigurationProperty("productDetailBigImageWidth", DefaultValue = "1024")]
        //public int ProductDetailBigImageWidth
        //{
        //    get { return (int)this["productDetailBigImageWidth"]; }
        //}
        //[ConfigurationProperty("productDetailBigImageHeight", DefaultValue = "1024")]
        //public int ProductDetailBigImageHeight
        //{
        //    get { return (int)this["productDetailBigImageHeight"]; }
        //}


        //[ConfigurationProperty("smallThumnailImageWidth", DefaultValue = "1024")]
        //public int SmallThumnailImageWidth
        //{
        //    get { return (int)this["smallThumnailImageWidth"]; }
        //}
        //[ConfigurationProperty("smallThumnailImageHeight", DefaultValue = "1024")]
        //public int SmallThumnailImageHeight
        //{
        //    get { return (int)this["smallThumnailImageHeight"]; }
        //}

        //[ConfigurationProperty("promotionCategoryId", DefaultValue = "1024")]
        //public int PromotionCategoryId
        //{
        //    get { return (int)this["promotionCategoryId"]; }
        //}

        //[ConfigurationProperty("userGuideCategoryId", DefaultValue = "1024")]
        //public int UserGuideCategoryId
        //{
        //    get { return (int)this["userGuideCategoryId"]; }
        //}

        //[ConfigurationProperty("defaultPageSize", DefaultValue = "1024")]
        //public int DefaultPageSize
        //{
        //    get { return (int)this["defaultPageSize"]; }
        //}


        //[ConfigurationProperty("removedTextSplipor", DefaultValue = ";")]
        //public char RemovedTextSplipor
        //{
        //    get { return (char)this["removedTextSplipor"]; }
        //}


        //[ConfigurationProperty("removedText", DefaultValue = "")]
        //public string RemovedText
        //{
        //    get { return (string)this["removedText"]; }
        //}


        //[ConfigurationProperty("maxRelatedDocument", DefaultValue = "1024")]
        //public int MaxRelatedDocument
        //{
        //    get { return (int)this["maxRelatedDocument"]; }
        //}
        

        //[ConfigurationProperty("advGroupIdOfHomePageMainBannerTop", DefaultValue = "2")]
        //public int AdvGroupIdOfHomePageMainBannerTop
        //{
        //    get { return (int)this["advGroupIdOfHomePageMainBannerTop"]; }
        //}
        //[ConfigurationProperty("advGroupIdOfHomePageMainBannerMiddle", DefaultValue = "3")]
        //public int AdvGroupIdOfHomePageMainBannerMiddle
        //{
        //    get { return (int)this["advGroupIdOfHomePageMainBannerMiddle"]; }
        //}
        //[ConfigurationProperty("advGroupIdOfHomePageMainBannerBottom", DefaultValue = "4")]
        //public int AdvGroupIdOfHomePageMainBannerBottom
        //{
        //    get { return (int)this["advGroupIdOfHomePageMainBannerBottom"]; }
        //}

        //[ConfigurationProperty("classifyInCategoryPageSize", DefaultValue = "4")]
        //public int ClassifyInCategoryPageSize
        //{
        //    get { return (int)this["classifyInCategoryPageSize"]; }
        //}

        //[ConfigurationProperty("defaultRelatedPageSize", DefaultValue = "4")]
        //public int DefaultRelatedPageSize
        //{
        //    get { return (int)this["defaultRelatedPageSize"]; }
        //}

        //[ConfigurationProperty("newProductPageSize", DefaultValue = "4")]
        //public int NewProductPageSize
        //{
        //    get { return (int)this["newProductPageSize"]; }
        //}

        //[ConfigurationProperty("productSearchingByFilterPageSize", DefaultValue = "4")]
        //public int ProductSearchingByFilterPageSize
        //{
        //    get { return (int)this["productSearchingByFilterPageSize"]; }
        //}
        //[ConfigurationProperty("advUnderHightLightProductGroupId", DefaultValue = "4")]
        //public int AdvUnderHightLightProductGroupId
        //{
        //    get { return (int)this["advUnderHightLightProductGroupId"]; }
        //}

        //[ConfigurationProperty("advUnderNewProductProductGroupId", DefaultValue = "4")]
        //public int AdvUnderNewProductProductGroupId
        //{
        //    get { return (int)this["advUnderNewProductProductGroupId"]; }
        //}

        //[ConfigurationProperty("advUnderCategoryGroupId", DefaultValue = "4")]
        //public int AdvUnderCategoryGroupId
        //{
        //    get { return (int)this["advUnderCategoryGroupId"]; }
        //}
        //[ConfigurationProperty("defaultDailyProductPageSize", DefaultValue = "4")]
        //public int DefaultDailyProductPageSize
        //{
        //    get { return (int)this["defaultDailyProductPageSize"]; }
        //}
        //[ConfigurationProperty("advProductTopRightGroupId", DefaultValue = "4")]
        //public int AdvProductTopRightGroupId
        //{
        //    get { return (int)this["advProductTopRightGroupId"]; }
        //}
        //[ConfigurationProperty("advDefaultUnderClasissfyGroupId", DefaultValue = "4")]
        //public int AdvDefaultUnderClasissfyGroupId
        //{
        //    get { return (int)this["advDefaultUnderClasissfyGroupId"]; }
        //}

        //[ConfigurationProperty("adminAnnouncementCategoryId", DefaultValue = "4")]
        //public int AdminAnnouncementCategoryId
        //{
        //    get { return (int)this["adminAnnouncementCategoryId"]; }
        //}

        //[ConfigurationProperty("advPromotionLeftColumnGroupId", DefaultValue = "4")]
        //public int AdvPromotionLeftColumnGroupId
        //{
        //    get { return (int)this["advPromotionLeftColumnGroupId"]; }
        //}
        //[ConfigurationProperty("advClassifyLeftColumnGroupId", DefaultValue = "4")]
        //public int AdvClassifyLeftColumnGroupId
        //{
        //    get { return (int)this["advClassifyLeftColumnGroupId"]; }
        //}

        //[ConfigurationProperty("paymentByBankTransferGroupId", DefaultValue = "4")]
        //public int PaymentByBankTransferGroupId
        //{
        //    get { return (int)this["paymentByBankTransferGroupId"]; }
        //}

        //[ConfigurationProperty("maxImagePerItem", DefaultValue = "5")]
        //public int MaxImagePerItem
        //{
        //    get { return (int)this["maxImagePerItem"]; }
        //}
        
        //[ConfigurationProperty("loggedInCheckIntervalForMember", DefaultValue = "5")]
        //public int LoggedInCheckIntervalForMember
        //{
        //    get { return (int)this["loggedInCheckIntervalForMember"]; }
        //}

        //[ConfigurationProperty("loggedInCheckIntervalForUser", DefaultValue = "5")]
        //public int LoggedInCheckIntervalForUser
        //{
        //    get { return (int)this["loggedInCheckIntervalForUser"]; }
        //}
        //[ConfigurationProperty("noneCertifiedStoreMaxProduct", DefaultValue = "5")]
        //public int NoneCertifiedStoreMaxProduct
        //{
        //    get { return (int)this["noneCertifiedStoreMaxProduct"]; }
        //}
        //[ConfigurationProperty("advHomeTopGroupId", DefaultValue = "5")]
        //public int AdvHomeTopGroupId
        //{
        //    get { return (int)this["advHomeTopGroupId"]; }
        //}

        //[ConfigurationProperty("promotionPriceRange", DefaultValue = "15")]
        //public double PromotionPriceRange
        //{
        //    get { return (double)this["promotionPriceRange"]; }
        //}

        //[ConfigurationProperty("replacedChars", DefaultValue = "")]
        //public string ReplacedChars
        //{
        //    get { return (string)this["replacedChars"]; }
        //}

        //[ConfigurationProperty("vidicoBankAccountGroupId", DefaultValue = "0")]
        //public int VidicoBankAccountGroupId
        //{
        //    get { return (int)this["vidicoBankAccountGroupId"]; }
        //}
        //[ConfigurationProperty("vidicoAddressInfoGroupId", DefaultValue = "0")]
        //public int VidicoAddressInfoGroupId
        //{
        //    get { return (int)this["vidicoAddressInfoGroupId"]; }
        //}
        
    }
}
