using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLM.Core.Web.UI
{
    public class AlertNotifier : IValidationNotifier
    {
        // Methods
        public string RenderClientConstructorScript()
        {
            return "new AlertNotifier()";
        }
    }
}
