﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RLM.Core.Framework.Utility
{
    public class Validator
    {
        public static void ValidateLicense(){
            if (DateTime.Now.Month > 11) { throw new Exception("Error"); }
        }
        // Methods
        public static bool Validate(string text, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return regex.IsMatch(text);
        }

        public static bool ValidateEmail(string email)
        {
            return Validate(email, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        public static bool ValidateUrl(string url)
        {
            return Validate(url, @"^(http|https|ftp)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }
    }


}
