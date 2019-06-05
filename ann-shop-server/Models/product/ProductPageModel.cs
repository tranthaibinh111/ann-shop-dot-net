using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductPageModel
    {
        public PaginationMetadataModel paginationMetadata { get; set; }
        public IEnumerable<ProductModel> data { get; set; }
    }
}