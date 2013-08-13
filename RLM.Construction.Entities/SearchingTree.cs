using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RLM.Construction.Entities
{
   
    // each node have array of weight node of all child
    public class SearchingTree<T> where T:IEntity,new()
    {
        #region Properties
        public TList<T> ChildNodes { get; set; }
        public T CurrentNode { get; set; }
        public TList<SearchTreeNodeWeight<T>> Weights { get; set; }
        public T ParentNode { get; set; }
        public bool IsComputed { get; set; }
        public SearchTreeNodeWeight<T> CurrentNodeWeight { get; set; }
        #endregion

        #region Virtual
        protected virtual void Compute()
        {
            this.LoadChildNodes();
            this.ComputeNodeWeight();
        }

        protected virtual void ComputeNodeWeight()
        {
            this.Weights = new TList<SearchTreeNodeWeight<T>>();
            foreach (T item in this.ChildNodes)
            {
                SearchTreeNodeWeight<T> nodeWeight = new SearchTreeNodeWeight<T>();
                nodeWeight.Node = item;
                nodeWeight.TotalNodes=this.CurrentNodeWeight==null?1:CurrentNodeWeight.TotalNodes+1;
                if (this.IsTheSameType(this.CurrentNode, item))
                {
                    nodeWeight.TheSameTypeNodes = this.CurrentNodeWeight == null ? 1 : CurrentNodeWeight.TheSameTypeNodes + 1;
                }
                this.Weights.Add(nodeWeight);
            }
        }

        // select the node that have the smallest total node and have the maximun amount of the same node type
        protected virtual T GetNextNode()
        {
            if (this.ChildNodes == null || this.ChildNodes.Count == 0) { return this.ParentNode; }
            SearchTreeNodeWeight<T> currentWeight = null;
            foreach (SearchTreeNodeWeight<T> item in this.Weights)
            {
                if (currentWeight == null)
                {
                    currentWeight = item;
                    continue;
                }
                if (item.TheSameTypeNodes < currentWeight.TheSameTypeNodes)
                {
                    currentWeight = item;
                    continue;
                }
                if (item.TheSameTypeNodes == currentWeight.TheSameTypeNodes && item.TotalNodes < currentWeight.TotalNodes)
                {
                    currentWeight = item;
                    continue;
                }
            }
            return currentWeight != null ? currentWeight.Node : default(T);
        }

        protected virtual bool IsTheSameType(T currentNode, T node)
        {
            throw new NotImplementedException();
        }

        protected virtual void LoadChildNodes()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
