using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductCategoryPageModel: ProductCategoryModel
    {
        public List<ProductCategoryModel> child { get; set; }
    }
}