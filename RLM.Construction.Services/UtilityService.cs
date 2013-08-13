using System;
using System.Collections.Generic;
using System.Text;
using RLM.Construction.Entities;

namespace RLM.Construction.Services
{
    public delegate string GetEnumValuesCallback(Type type, string value);
    public class UtilityService
    {
        #region Enum to collection
        public static TList<EnumPair> GetEnumValues<T>(Type enumType,GetEnumValuesCallback callback)
        {
            try
            {
                
                Array values = Enum.GetValues(enumType);

                TList<RLM.Construction.Entities.EnumPair> items = new TList<RLM.Construction.Entities.EnumPair>();
                for (int index = 0; index < values.Length; index++)
                {
                    EnumPair item = new EnumPair();
                    item.Value = ((int)values.GetValue(index)).ToString();
                    item.Name = callback(enumType, values.GetValue(index).ToString());
                    items.Add(item);
                }
                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
