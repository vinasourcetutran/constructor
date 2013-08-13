using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace RLM.Core.Web.UI
{
    public class ValidationManager : Control
    {
        // Fields
        private List<ValidationError> errors = new List<ValidationError>();
        private string formToValidate;
        private IValidationNotifier notifier = new AlertNotifier();
        private List<IValidationRule> rules = new List<IValidationRule>();
        private string supportFolder = "~/Resources/xValidation";
        public string ValidationGroup { get; set; }

        // Methods
        public void AddRule(IValidationRule validationRule)
        {
            if (validationRule != null)
            {
                this.rules.Add(validationRule);
            }
        }

        public void ClearRules()
        {
            this.rules.Clear();
        }

        private bool HasClientValidation()
        {
            foreach (ValidationError error in this.errors)
            {
                if (error.ValidationLocation != ValidationLocation.Server)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.Page.ClientScript.RegisterClientScriptInclude("XValidation_Common", base.ResolveClientUrl(this.supportFolder + "/pyco.common/pyco.common-dom.js"));
            this.Page.ClientScript.RegisterClientScriptInclude("XValidation_Core", base.ResolveClientUrl(this.supportFolder + "/pyco.xvalidation-core.js"));
            this.Page.ClientScript.RegisterClientScriptInclude("XValidation_Notifiers", base.ResolveClientUrl(this.supportFolder + "/pyco.xvalidation-notifiers.js"));
            this.Page.ClientScript.RegisterClientScriptInclude("XValidation_Rules", base.ResolveClientUrl(this.supportFolder + "/pyco.xvalidation-rules.js"));
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (this.rules.Count != 0)
            {
                string format = "<script language=\"javascript\" type=\"text/javascript\">\r\n                                var rules = new RuleSet();\r\n                                // add rules to validate\r\n                                {0}\r\n                                var form = document.getElementById(\"{1}\");\r\n                                rules.install(form);\r\n                                var behavior = new ValidationBehavior();\r\n                                behavior.notifier = {2};\r\n                                behavior.apply(form);\r\n                                {3}\r\n                            </script>";
                string str2 = "";
                foreach (IValidationRule rule in this.rules)
                {
                    if (rule.ValidationLocation != ValidationLocation.Server)
                    {
                        string str5 = str2;
                        str2 = str5 + "rules.add(" + rule.RenderClientConstructorScript() + ");" + Environment.NewLine;
                    }
                }
                string str3 = "";
                if ((this.errors.Count > 0) && this.HasClientValidation())
                {
                    str3 = " // notify errors on postback\r\n                                        Dom.registerEvent(window, \"load\", notifyValidationErrors);\r\n                                        function notifyValidationErrors() {{\r\n                                            var validationErrors = new ValidationErrors();\r\n                                            {0}\r\n                                            var notifier = {1};\r\n                                            notifier.notify(document.getElementById('{2}'), validationErrors);\r\n                                        }}";
                    string str4 = "";
                    foreach (ValidationError error in this.errors)
                    {
                        if (error.ValidationLocation != ValidationLocation.Server)
                        {
                            string str6 = str4;
                            str4 = str6 + "validationErrors.add(" + error.RenderClientConstructorScript() + ");" + Environment.NewLine;
                        }
                    }
                    str3 = string.Format(str3, str4, this.notifier.RenderClientConstructorScript(), this.formToValidate);
                }
                writer.Write(string.Format(format, new object[] { str2, this.formToValidate, this.notifier.RenderClientConstructorScript(), str3 }));
            }
        }

        public bool Validate()
        {
            foreach (IValidationRule rule in this.rules)
            {
                ValidationError item = rule.Validate(this.ValidationGroup);
                if (item != null)
                {
                    this.errors.Add(item);
                }
            }
            return (this.errors.Count == 0);
        }


        // Properties
        public string FormToValidate
        {
            get
            {
                return this.formToValidate;
            }
            set
            {
                this.formToValidate = value;
            }
        }

        public IValidationNotifier Notifier
        {
            get
            {
                return this.notifier;
            }
            set
            {
                this.notifier = value;
            }
        }

        public string SupportFolder
        {
            get
            {
                return this.supportFolder;
            }
            set
            {
                this.supportFolder = value;
            }
        }
    }


}
