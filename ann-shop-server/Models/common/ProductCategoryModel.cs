using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ProductCategoryModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
    }
}