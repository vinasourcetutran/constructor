using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Construction.Entities
{
    public class ErrorPair
    {
        public ErrorPair()
        {
            this.ErrorType = RLM.Construction.Entities.ErrorType.None;
            this.ErrorMessage = string.Empty;
        }

        public ErrorType ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
