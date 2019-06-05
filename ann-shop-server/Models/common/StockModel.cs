using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class StockModel
    {
        public int productID { get; set; }
        public int quantity { get; set; } = 0;
        public bool availability { get; set; } = false;
    }
}