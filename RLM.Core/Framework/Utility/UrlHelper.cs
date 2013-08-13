using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RLM.Core.Entity;
using System.Web;

namespace RLM.Core.Framework.Utility
{
    public class UrlHelper
    {
        #region Param
        // return  format of param on query string with pair of (name, vaue)
        public static string ParamFormat<T>(string name, T value)
        {
            return string.Format("{0}={1}",name,value);
        }
        /// <summary>
        /// return true if pattern is exist in url
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsParamExist(string pattern, string url)
        {
            return Regex.IsMatch(url, pattern, RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        }
        /// <summary>
        /// add pair of param (name, value) into url
        /// add new if pair of param is not exist. otherwise replace old value
        /// </summary>
        public static string AddParam<T>(string name, T value, string pattern, string url)
        {
            try
            {
                string paramValue = UrlHelper.ParamFormat<T>(name, value);
                string paramPattern = UrlHelper.ParamFormat<string>(name,pattern);
                if (!UrlHelper.IsParamExist(paramPattern, url))
                {
                    return string.Format("{0}{1}{2}", url, (url.IndexOf("?") >= 0 ? "&" : "?"), paramValue);
                }

                return StringHelper.Replace(paramPattern, paramValue, url);
            }
            catch (Exception ex)
            {
                return string.Format("{0}{1}{2}", url, (url.IndexOf("?") >= 0 ? "&" : "?"), UrlHelper.ParamFormat<T>(name, value));
            }
        }
        #endregion
        #region Create Url
        public static string GetUrl(string baseUrl, IEntity entity, string action)
        {
            try
            {
                return string.Format(
                    "{0}/{1}/{2}/{3}/{4}",
                    baseUrl,
                    entity.EntityType,
                    action,
                    entity.EntityId,
                    entity.EntityName
                    );
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex);
                return baseUrl;
            }
        }
        #endregion
        #region Url
        public static string ResolveUrl(string originalUrl)
        {
            if (originalUrl == null)
                return null;
            // *** Absolute path - just return    
            if (originalUrl.IndexOf("://") != -1)
                return originalUrl;
            // *** Fix up image path for ~ root app dir directory   
            if (originalUrl.StartsWith("~"))
            {
                string newUrl = "";
                if (HttpContext.Current != null)
                {
                    newUrl = (HttpContext.Current.Request.ApplicationPath + originalUrl.Substring(1).Replace("//", "/")).Replace("//", "/");
                }
                else            // *** Not context: assume current directory is the base directory           
                    throw new ArgumentException("Invalid URL: Relative URL not allowed.");
                // *** Just to be sure fix up any double slashes       
                return ReplaceBackslash(newUrl);
            }
            return ReplaceBackslash(originalUrl);
        }
        #endregion
        public static string ReplaceBackslash(string url)
        {
            if (string.IsNullOrEmpty(url)) { return url; }
            url= url.Replace('\\', '/');
            return url;

        }
    }
}
