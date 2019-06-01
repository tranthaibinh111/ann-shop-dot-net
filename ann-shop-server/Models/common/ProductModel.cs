using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public int? categoryID { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public int quantity { get; set; } = 0;
        public bool availability { get; set; } = false;
        public string materials { get; set; }
        public double regularPrice { get; set; } = 0;
        public double retailPrice { get; set; } = 0;
        public List<string> images { get; set; } = new List<string>();
    }
}