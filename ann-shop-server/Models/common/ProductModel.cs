using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string categorySlug { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public List<ThumbnailModel> thumbnails { get; set; } = new List<ThumbnailModel>();
        public string materials { get; set; }
        public List<VariableModel> colors { get; set; } = new List<VariableModel>();
        public List<VariableModel> sizes { get; set; } = new List<VariableModel>();
        public int quantity { get; set; } = 0;
        public bool availability { get; set; } = false;
        public double regularPrice { get; set; } = 0;
        public double retailPrice { get; set; } = 0;
        public string content { get; set; }
        public string slug { get; set; }
    }
}