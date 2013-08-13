using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace RLM.Core.Web.UI.ValidationRule
{
    public class ValidationRuleRequired:AbstractValidationRule
    {
        // Fields
        private string pattern;

        // Methods
        public ValidationRuleRequired(Control controlToValidate, string pattern, string errorMessage)
            : this(controlToValidate, pattern, errorMessage, "")
        {
        }

        public ValidationRuleRequired(Control controlToValidate, string pattern, string errorMessage, string hint)
            : base(controlToValidate, errorMessage, hint)
        {
            this.pattern = "";
            this.pattern = pattern;
            base.AddObject("pattern", "new RegExp(\"" + JavascriptUtility.EscapeString(pattern) + "\", \"i\")");
        }

        public override ValidationError Validate()
        {
            string input = HttpContext.Current.Request[base.ControlToValidate.UniqueID];
            Regex regex = new Regex(this.pattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(input))
            {
                return new ValidationError(base.ControlToValidate, base.ErrorMessage, base.Hint, this);
            }
            return null;
        }

        // Properties
        public override string Name
        {
            get
            {
                return "PatternMatchedRule";
            }
        }
    }
}
