using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RLM.Core.Framework.Log;
using System.Collections;
using System.Globalization;
using System.IO;

namespace RLM.Core.Framework.Utility
{
    public class StringHelper
    {
        #region String function
        public static string Truncat(string input, int maxLenght)
        {
            if (input.Length <= maxLenght) { return input; }
            int pos = input.IndexOf(' ', maxLenght);
            return (pos <= 0 ? input : input.Substring(0, pos) + " ...");
        }

        public static string RemoveQuote(string input)
        {
            return StringHelper.Replace("'","\\'",input);
        }

        public static string RemoveNewline(string input)
        {
            string result=StringHelper.Replace("\r", "", input);
            result=StringHelper.Replace("\n", "<br/>", result);
            result = StringHelper.Replace("\t", " ", result);
            return result;
        }

        public static string RemoveNewlineForText(string input)
        {
            string result = StringHelper.Replace("\r", "\\r", input);
            result = StringHelper.Replace("\n", "\\n", result);
            result = StringHelper.Replace("\t", "\\t", result);
            return result;
        }

        public static string HtmlFormat(string input, bool isHtmlFormat)
        {
            input = StringHelper.RemoveQuote(input);
            if (isHtmlFormat)
            {
                input = StringHelper.RemoveNewline(input);
            }
            else
            {
                input = StringHelper.RemoveNewlineForText(input);
            }
            
            return input;
        }

        public static string JsonFormat(string input, bool isHtmlFormat)
        {
            input = StringHelper.RemoveQuote(input);
            if (isHtmlFormat)
            {
                input = StringHelper.RemoveNewline(input);
            }
            else
            {
                input = StringHelper.RemoveNewlineForText(input);
            }

            return input;
        }

        public static string Replace(string pattern, string replaceText, string input)
        {
            try
            {
                string value = Regex.Replace(input, pattern, replaceText, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Remove(string input, string pattern)
        {
            try
            {
                if (string.IsNullOrEmpty(pattern)) { return input; }
                //return Regex.Replace(input, pattern, replaceText, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string[] indicators = pattern.Split(':');
                if (indicators.Length < 2) { return input; }
                while (input.IndexOf(indicators[0], StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    int startPos = input.IndexOf(indicators[0], StringComparison.OrdinalIgnoreCase);
                    int endPos = input.IndexOf(indicators[1], StringComparison.OrdinalIgnoreCase) + indicators[1].Length;
                    if (endPos < 0) { endPos = input.Length - 1; }
                    if (startPos >= endPos) { break; }
                    input = input.Remove(startPos, endPos - startPos);
                }
                return input;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Remove(string input, string[] patterns)
        {
            try
            {
                foreach (string item in patterns)
                {
                    input = Remove(input, item);
                }
                return input;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Format(string pattern, params object[] values)
        {
            for (int index = 0; index < values.Length; index++)
            {
                try
                {
                    string bookMark = "{" + index + "}";
                    while (pattern.IndexOf(bookMark) >= 0)
                    {
                        pattern = pattern.Replace(bookMark, values[index].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
            return pattern;
        }
        #endregion

        #region Expression
        public static bool IsMatch(string pattern, string input)
        {
            return Regex.IsMatch(input, pattern, RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        public static string GetMatch(string pattern, string input)
        {
            string value = "";

            if (Regex.IsMatch(input, pattern, RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled))
            {
                value = Regex.Match(input, pattern, RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled).Groups[1].Value;
            }
            return value;
        }
        public static MatchCollection GetMatches(string pattern, string input)
        {
            if (Regex.IsMatch(input, pattern, RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled))
            {
                return Regex.Matches(input, pattern, RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            }
            return null;
        }
        #endregion

        #region Random string
        public static string GetGuid(int length)
        {
            string guid=Guid.NewGuid().ToString().Replace("-","");
            if(length>0 && guid.Length>length){ guid=guid.Substring(0, length);}
            return guid;
        }

        public static string GetGuid()
        {
            return StringHelper.GetGuid(32);
        }
        #endregion

        #region Unicode to ascii
        public static string RemoveDiacritics(string stIn)
        {
            try
            {
                string stFormD = stIn.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();

                for (int ich = 0; ich < stFormD.Length; ich++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                    if (uc != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(stFormD[ich]);
                    }
                }

                return (sb.ToString().Normalize(NormalizationForm.FormC));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return stIn;
            }
        }
        #endregion

        public static string FileNameFormat(string fileName)
        {
            try
            {
                fileName = StringHelper.RemoveDiacritics(fileName);
                fileName = fileName.Replace(' ' ,'_');
                return fileName;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return fileName;
        }

        public static string GetFileNameByAction(string fileName, string action)
        {
            if (string.IsNullOrEmpty(fileName)||Path.GetExtension(fileName).Trim().Length==0) { return fileName; }
            string ext = Path.GetExtension(fileName);
            fileName = fileName.Replace(Path.GetExtension(fileName), "_" + action + ext);
            return fileName;
        }
    }
}
