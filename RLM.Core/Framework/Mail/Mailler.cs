using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using RLM.Core.Framework.Log;
using RLM.Core.Entity;
using System.Net;

namespace RLM.Core.Framework.Mail
{
   public class Mailler : MailMessage
    {
       public string TemplatePath { get; set; }
       public Dictionary<string,string> Parameters { get; set; }
       public Mailler(string from, string to, string subject, string templateParth, Dictionary<string, string> parameters)
       {
           try
           {
               this.From = new MailAddress(from);
               string[] toemails = to.Split(';');
               foreach (string item in toemails)
               {
                   this.To.Add(item);
               }
               this.Subject = subject;
               this.TemplatePath = templateParth;
               this.Parameters = parameters;

               this.Body = TemplateReader.GetContent(this.TemplatePath, this.Parameters);
               this.IsBodyHtml = true;
           }
           catch (Exception ex)
           {
               Logger.Error(ex);
               throw;
           }
       }
       
    }
}
