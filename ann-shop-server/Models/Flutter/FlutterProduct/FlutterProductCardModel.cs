using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterProductCardModel
    {
        public int productID { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string materials { get; set; }
        public int badge { get; set; }
        public bool availability { get; set; }
        public string avatar { get; set; }
        public double regularPrice { get; set; }
        public double oldPrice { get; set; }
        public double retailPrice { get; set; }
    }
}