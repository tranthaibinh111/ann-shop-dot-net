using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ProductCardModel
    {
        public int productID { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string materials { get; set; }
        public List<ColorModel> colors { get; set; }
        public List<SizeModel> sizes { get; set; }
        public int badge { get; set; }
        public bool availability { get; set; }
        public List<ThumbnailModel> thumbnails { get; set; }
        public double regularPrice { get; set; }
        public double oldPrice { get; set; }
        public double retailPrice { get; set; }
        public string content { get; set; }
    }
}