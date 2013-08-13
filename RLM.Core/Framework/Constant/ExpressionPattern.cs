using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLM.Core.Framework.Constant
{
    public class ExpressionPattern
    {
        public const string URL = @"([a-z,A-Z,0-9, ,%,.,/,\,-,%,:,?,{,},=,~]+)";
        public const string EMAIL = @"[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))";
        public const string PHONE = @"^([0-9, ]+)$";
        public const string DATETIME = @"([0-9,/]+)";
        public const string NUMBER = @"(\d+)";
        public const string STRING = @"([a-z,A-Z,0-9, ,%,.,(,),;,',,{,}]+)";
        public const string ALPHABET = @"([a-z,A-Z,0-9, ,%,.,(,),;,',,{,}]+)";
    }
}
