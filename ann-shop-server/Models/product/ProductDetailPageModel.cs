using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductDetailPageModel: ProductModel
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        
    }
}