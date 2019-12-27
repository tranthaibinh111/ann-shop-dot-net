using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterBannerModel
    {
        public string action { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string actionValue { get; set; }
        public string image { get; set; }
        public string message { get; set; }
        public Nullable<DateTime> createdDate { get; set; }
    }
}