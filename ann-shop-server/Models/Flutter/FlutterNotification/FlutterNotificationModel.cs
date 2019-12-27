using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterNotificationModel
    {
        public string title { get; set; }
        public string slug { get; set; }
        public string content { get; set; }
        public DateTime createdDate { get; set; }
    }
}