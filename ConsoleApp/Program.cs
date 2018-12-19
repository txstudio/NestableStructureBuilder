using Newtonsoft.Json;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var _productCategory = new ProductCategoryRepository();
            var _relations = _productCategory.GetParents();

            //將上層節點的資訊物件轉換成節點物件
            var _toChildren = new ParentToChildren();
            var _nodes = _toChildren.GetNodes(_relations);

            Console.WriteLine(JsonConvert.SerializeObject(_nodes, Formatting.Indented));
            Console.WriteLine();

            //將包含 children 屬性的物件轉換成路徑 (Hierarchy) 結構物件
            var _toHierarchy = new ChildrenToHierarchy();
            var _hierarchies = _toHierarchy.GetHierarchies(_nodes, null);

            Console.WriteLine(JsonConvert.SerializeObject(_hierarchies, Formatting.Indented));
            Console.WriteLine();

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }

}
