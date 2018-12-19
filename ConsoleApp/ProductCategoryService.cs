using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp
{

    public class ParentToChildren
    {

        private readonly List<ProductCategoryNode> _nodes;

        //要新增節點的 node
        private ProductCategoryNode _activeNode;

        public ParentToChildren()
        {
            this._nodes = new List<ProductCategoryNode>();
        }


        public IEnumerable<ProductCategoryNode> GetNodes(IEnumerable<ProductCategoryParent> parents)
        {
            ProductCategoryNode _newNode;

            foreach (var _parent in parents)
            {
                this._activeNode = null;

                _newNode = new ProductCategoryNode();
                _newNode.No = _parent.No;
                _newNode.Name = _parent.Name;

                if(_parent.ParentNo.HasValue == true)
                {
                    this.SetActiveNode(_nodes, _parent.ParentNo.Value);
                }
                
                if (this._activeNode == null)
                {
                    this._nodes.Add(_newNode);

                    continue;
                }
                else
                {
                    this._activeNode.AddChildren(_newNode);
                }

            }

            return this._nodes.ToArray();
        }

        private void SetActiveNode(IEnumerable<ProductCategoryNode> nodes, int parentNo)
        {
            if (this._nodes.Count == 0)
            {
                return;
            }

            var _matchNode = nodes.Where(x => x.No == parentNo).FirstOrDefault();

            if(_matchNode != null)
            {
                this._activeNode = _matchNode;

                return;
            }

            foreach (var node in nodes)
            {
                if (node.Childrens != null)
                {
                    this.SetActiveNode(node.Childrens, parentNo);
                }
            }
        }
    }


    public class ChildrenToHierarchy
    {
        private readonly List<ProductCategoryHierarchy> _hierarchies;

        public ChildrenToHierarchy()
        {
            this._hierarchies = new List<ProductCategoryHierarchy>();
        }

        public IEnumerable<ProductCategoryHierarchy> GetHierarchies(IEnumerable<ProductCategoryNode> childrens, int[] nodes)
        {
            int _index = 0;

            ProductCategoryHierarchy _hierarchy;
            
            foreach (var children in childrens)
            {
                _index = _index + 1;

                _hierarchy = new ProductCategoryHierarchy();
                _hierarchy.No = children.No;
                _hierarchy.Name = children.Name;

                if(nodes != null)
                    foreach (var node in nodes)
                        _hierarchy.AddNode(node);

                _hierarchy.AddNode(_index);

                this._hierarchies.Add(_hierarchy);

                if (children.Childrens != null)
                { 
                    this.GetHierarchies(children.Childrens, _hierarchy.GetNodes());
                }
            }

            return this._hierarchies.ToArray();
        }

    }

}
