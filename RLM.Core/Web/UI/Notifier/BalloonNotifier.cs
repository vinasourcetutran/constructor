using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLM.Core.Web.UI.Notifier
{
    public class BalloonNotifier : IValidationNotifier
    {
        // Methods
        public string RenderClientConstructorScript()
        {
            return "new BalloonNotifier()";
        }
    }


}
