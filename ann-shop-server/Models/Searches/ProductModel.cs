using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models.Searches
{
    public class ProductOrderedModel: Models.common.Product.ProductModel
    {
        public double price { get; set; }
        public DateTime createdDate { get; set; }
    }
}