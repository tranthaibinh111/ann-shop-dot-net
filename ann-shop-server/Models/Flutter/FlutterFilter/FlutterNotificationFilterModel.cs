using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterNotificationFilterModel
    {
        public string kind { get; set; }
        public string categorySlug { get; set; }
        public string phone { get; set; }
    }
}