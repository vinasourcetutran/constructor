using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Construction.Entities
{
    [Serializable]
    public class DataSourceItem<T> where T:IEntity,new ()
    {
        #region Variables
        int totalItems = 0;
        #endregion
        public TList<T> Items { get; set; }
        public int TotalItems
        {
            get
            {
                return this.totalItems < 0 ? 0 : this.totalItems;
            }
            set
            {
                this.totalItems = value;
            }
        }
    }
}
