using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Construction.Entities
{
    public class AlphaBetaTree<T>  where T: IEntity,new()
    {
        #region Properties
        public T Node { get; set; }
        public double Weight { get; set; }
        public IList<AlphaBetaTree<T>> ChildNodes { get; set; }
        public bool IsChecked { get; set; }
        public AlphaBetaTree<T> ParentNode { get; set; }
        public bool IsBuildTree { get; set; }
        public bool IsLeaf
        {
            get
            {
                return this.ChildNodes == null || this.ChildNodes.Count == 0;
            }
        }
        #endregion

        #region Constructor
        public AlphaBetaTree()
        {
            this.Node = default(T);
            this.Weight = 0.0;
            this.ChildNodes = null;
            this.ParentNode = null;
        }

        public AlphaBetaTree(T node, double weight, AlphaBetaTree<T> parent)
        {
            this.Node = node;
            this.Weight = weight != 0 ? weight : 1;
            this.ChildNodes = null;
            this.ParentNode = parent;
        }
        #endregion

        #region Methods
        public void BuildTree()
        {
            if (this.IsBuildTree) { return; }
            this.IsBuildTree = true;
            // get list of sub item of current itme
            TList<T> items = this.GetChildItems(this.Node);
            // if nothing was found
            if (items == null || items.Count == 0) { return; }

            this.ChildNodes = new List<AlphaBetaTree<T>>();
            foreach (T item in items)
            {
                // weight of new node
                double childWeight = this.Weight * this.GetWeight(item);
                //create new node
                AlphaBetaTree<T> newNode = this.CreateNode(item, childWeight);
                // add new node into current tree
                this.ChildNodes.Add(newNode);
            }
        }

        
        public AlphaBetaTree<T> GetNextNode()
        {
            this.BuildTree();
            if (this.ChildNodes == null) { return null; }
            AlphaBetaTree<T> currentNode = null;
            foreach (AlphaBetaTree<T> item in this.ChildNodes)
            {
                if (item.IsChecked) { continue; }
                if (currentNode == null || currentNode.Weight > item.Weight)
                {
                    currentNode = item;
                    continue;
                }
            }
            return currentNode;
        }
        public AlphaBetaTree<T> Translate(T newNode)
        {
            this.BuildTree();
            if (this.IsLeaf)
            {
                if (this.IsEqual(this.Node, newNode)) { return this; }
                return null;
            }
            AlphaBetaTree<T> nextNode = this.GetNextNode();
            while (nextNode != null)
            {
                if (this.IsEqual(nextNode.Node, newNode)) { return nextNode; }
                AlphaBetaTree<T> newNextNode = nextNode.GetNextNode();
                if (newNextNode == null)
                {
                    newNextNode = nextNode.ParentNode;
                    nextNode.IsChecked = true;
                }
                nextNode = newNextNode;
            }
            return nextNode;
        }
        #endregion

        #region Private
        #endregion

        #region Virtual
        protected virtual AlphaBetaTree<T> CreateNode(T item, double childWeight)
        {
            throw new NotImplementedException();
        }

        protected virtual bool IsEqual(T first, T second)
        {
            throw new NotImplementedException();
        }

        protected virtual double GetWeight(T item)
        {
            throw new NotImplementedException();
        }

        protected virtual TList<T> GetChildItems(T item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
