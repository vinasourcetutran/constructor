using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Core.Framework.Log;

namespace RLM.Core.Framework.Utility
{
    public class NumberHelper
    {
        #region Nullable to value
        public static T GetValue<T>(Nullable<T> value)where T:struct{
            try
            {
                return value.HasValue ? value.Value : default(T);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return default(T);
            }
        }
        #endregion
    }
}
