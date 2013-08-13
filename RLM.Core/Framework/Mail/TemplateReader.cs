using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Core.Framework.Log;
using System.IO;

namespace RLM.Core.Framework.Mail
{
    public class TemplateReader
    {
        internal static string GetContent(string templatePath, Dictionary<string, string> parameters)
        {
            try
            {
                StreamReader stream = new StreamReader(templatePath);
                string result = stream.ReadToEnd();
                stream.Close();
                foreach (string keyword in parameters.Keys)
                {

                    string value = parameters[keyword];
                    string keyword2 = string.Concat("{#", keyword, "#}");
                    result = result.Replace(keyword2, value);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
