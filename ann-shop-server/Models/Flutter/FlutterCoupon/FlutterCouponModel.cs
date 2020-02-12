using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterCouponModel
    {
        public string code { get; set; }
        public decimal value { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}