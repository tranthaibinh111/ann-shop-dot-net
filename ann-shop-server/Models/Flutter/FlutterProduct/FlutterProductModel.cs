using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterProductModel
    {
        public int productID { get; set; }
        public string categoryName { get; set; }
        public string categorySlug { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string sku { get; set; }
        public string avatar { get; set; }
        public List<FlutterCarouselModel> images { get; set; }
        public List<ColorModel> colors { get; set; }
        public List<SizeModel> sizes { get; set; }
        public string materials { get; set; }
        public double regularPrice { get; set; }
        public double oldPrice { get; set; }
        public double retailPrice { get; set; }
        public int badge { get; set; }
        public List<TagModel> tags { get; set; }
        public List<FlutterDiscountModel> discounts { get; set; }
        public string content { get; set; }
    }
}