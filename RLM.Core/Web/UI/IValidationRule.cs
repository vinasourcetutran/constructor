using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLM.Core.Web.UI
{
    public interface IValidationRule
    {
        // Methods
        string RenderClientConstructorScript();
        ValidationError Validate();
        ValidationError Validate(string validationGroup);

        // Properties
        string Name { get; }
        ValidationLocation ValidationLocation { get; set; }
    }



}
