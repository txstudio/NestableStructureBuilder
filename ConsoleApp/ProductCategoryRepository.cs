using System.Collections.Generic;

namespace ConsoleApp
{
    public class ProductCategoryRepository
    {
        public IEnumerable<ProductCategoryParent> GetParents()
        {
            List<ProductCategoryParent> _items;

            _items = new List<ProductCategoryParent>();

            //level: 1
            _items.Add(new ProductCategoryParent() { No = 1, ParentNo = null, Name = "運動" });

            //level: 2
            _items.Add(new ProductCategoryParent() { No = 2, ParentNo = 1, Name = "運動女裝" });
            _items.Add(new ProductCategoryParent() { No = 3, ParentNo = 1, Name = "運動男裝" });
            _items.Add(new ProductCategoryParent() { No = 4, ParentNo = 1, Name = "運動童裝" });

            //level: 3
            _items.Add(new ProductCategoryParent() { No = 5, ParentNo = 2, Name = "上身類-女" });
            _items.Add(new ProductCategoryParent() { No = 6, ParentNo = 2, Name = "褲&裙裝-女" });
            _items.Add(new ProductCategoryParent() { No = 7, ParentNo = 2, Name = "外套類-女" });
            _items.Add(new ProductCategoryParent() { No = 8, ParentNo = 2, Name = "配件類-女" });

            _items.Add(new ProductCategoryParent() { No = 9, ParentNo = 3, Name = "上身類-男" });
            _items.Add(new ProductCategoryParent() { No = 10, ParentNo = 3, Name = "褲裝類-男" });
            _items.Add(new ProductCategoryParent() { No = 11, ParentNo = 3, Name = "外套類-男" });
            _items.Add(new ProductCategoryParent() { No = 12, ParentNo = 3, Name = "配件類-男" });

            _items.Add(new ProductCategoryParent() { No = 13, ParentNo = 4, Name = "上身類-童" });
            _items.Add(new ProductCategoryParent() { No = 14, ParentNo = 4, Name = "褲&裙裝-童" });
            _items.Add(new ProductCategoryParent() { No = 15, ParentNo = 4, Name = "配件類-童" });

            return _items.ToArray();
        }
    }
}
