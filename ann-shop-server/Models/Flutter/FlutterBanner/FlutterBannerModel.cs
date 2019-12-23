using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterBannerModel
    {
        public string type { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string image { get; set; }
        public DateTime createdDate { get; set; }
    }
}