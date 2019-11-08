using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class SearchProductProductModel
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string title { get; set; }
        public List<ThumbnailModel> thumbnails { get; set; }
        public double regularPrice { get; set; }
        public double retailPrice { get; set; }
        public bool availability { get; set; }
        public string materials { get; set; }
        public string slug { get; set; }
    }
}