using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ProductVariableModel: ProductModel
    {
        public string color { get; set; }
        public string size { get; set; }
    }
}