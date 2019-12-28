using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class NotificationModel
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string action { get; set; }
        public string actionValue { get; set; }
        public string avatar { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
        public DateTime createdDate { get; set; }
    }
}