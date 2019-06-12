using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ProductRelatedPageModel
    {
        public PaginationMetadataModel paginationMetadata { get; set; }
        public List<ProductVariableModel> data { get; set; }
    }
}