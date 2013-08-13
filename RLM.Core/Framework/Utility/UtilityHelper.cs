using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLM.Core.Framework.Utility
{
    public class UtilityHelper
    {
        #region Collection
        public static V Merge<V,T>(V from, V to) where V:ICollection<T>
        {
            foreach (T item in to)
            {
                from.Add(item);
            }
            return from;
        }
        #endregion
    }
}
