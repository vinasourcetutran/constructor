using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Construction.Entities
{
    public class SearchTreeNodeWeight<T>:IEntity where T:new()
    {
        #region Properties
        public int TheSameTypeNodes { get; set; }
        public int TotalNodes { get; set; }
        public T Node { get; set; }
        #endregion

        #region Constructor
        public SearchTreeNodeWeight(T node, int totalNodes, int theSameTypeNodes)
        {
            this.TheSameTypeNodes = theSameTypeNodes;
            this.TotalNodes = totalNodes;
            this.Node = node;
        }
        public SearchTreeNodeWeight()
        {
            this.TheSameTypeNodes = 0;
            this.TotalNodes = 0;
            this.Node = default(T);
        }
        #endregion

        #region IEntity Members

        public string TableName
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDirty
        {
            get { return false; }
        }

        public bool IsNew
        {
            get { return true; }
        }

        public bool IsDeleted
        {
            get { return false; }
        }

        public bool IsValid
        {
            get { return true; }
        }

        public EntityState EntityState
        {
            get { return EntityState.Unchanged; }
        }

        public void AcceptChanges()
        {
        }

        public void MarkToDelete()
        {
        }

        public object ParentCollection
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public string[] TableColumns
        {
            get { return new string[1]; }
        }

        public object Tag
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public bool IsEntityTracked
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public string EntityTrackingKey
        {
            get
            {
                return string.Empty;
            }
            set
            {
            }
        }

        #endregion
    }
}
