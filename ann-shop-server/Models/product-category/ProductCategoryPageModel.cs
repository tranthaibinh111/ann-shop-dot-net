using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductCategoryPageModel: ProductCategoryModel
    {
        public IEnumerable<ProductCategoryModel> child { get; set; }
    }
}