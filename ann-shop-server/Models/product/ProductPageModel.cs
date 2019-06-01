using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductPageModel
    {
        public PaginationMetadataModel paginationMetadata { get; set; }
        public List<ProductDetailPageModel> data { get; set; }
    }
}