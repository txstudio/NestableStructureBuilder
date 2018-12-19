using System;
using System.Collections.Generic;

namespace ConsoleApp
{

    public interface IChildren<TChildren>
    {
        void AddChildren(TChildren children);

        List<TChildren> Children { get; }
    }

    public abstract class ChildrenProvider<TChildren>
    {
        private readonly List<TChildren> _childrens;

        protected ChildrenProvider()
        {
            this._childrens = new List<TChildren>();
        }

        public void AddChildren(TChildren children)
        {
            this._childrens.Add(children);
        }

        public List<TChildren> Childrens
        {
            get
            {
                return this._childrens;
            }
        }
    }



    public class ProductCategory
    {
        public int No { get; set; }
        public string Name { get; set; }
    }

    public class ProductCategoryParent : ProductCategory, IRelation
    {
        public Nullable<int> ParentNo { get; set; }
    }



    public interface IHierarchy
    {
        void AddNode(int no);

        int[] GetNodes();

        string Path { get; }
    }

    public interface INode<TChildren>
    {
        void AddChildren(TChildren children);

        List<TChildren> GetChildrens();
    }



    public sealed class ProductCategoryNode : ProductCategory
    {
        private List<ProductCategoryNode> _children;

        public ProductCategoryNode()
        {
            this._children = new List<ProductCategoryNode>();
        }

        public void AddChildren(ProductCategoryNode children)
        {
            this._children.Add(children);
        }

        public List<ProductCategoryNode> Childrens
        {
            get
            {
                if (this._children.Count == 0)
                    return null;

                return this._children;
            }
        }
    }





    public class ProductCategoryHierarchy : ProductCategory, IHierarchy
    {
        private List<int> _nodePath;

        public ProductCategoryHierarchy()
        {
            this._nodePath = new List<int>();
        }

        public void AddNode(int no)
        {
            this._nodePath.Add(no);
        }

        public int[] GetNodes()
        {
            return this._nodePath.ToArray();
        }

        public string Path
        {
            get
            {
                if (this._nodePath.Count == 0)
                    return string.Empty;

                string _path;

                _path = String.Join('/', this._nodePath.ToArray());
                _path = string.Format("/{0}/", _path);

                return _path;
            }
        }

    }

}
