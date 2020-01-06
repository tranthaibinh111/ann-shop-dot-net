using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterUserModel
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string fullName { get; set; }
        public Nullable<System.DateTime> birthDay { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }
}