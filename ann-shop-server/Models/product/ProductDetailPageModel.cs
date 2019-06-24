using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductDetailPageModel : ProductModel
    {
        public List<string> images { get; set; } = new List<string>();
    }
}