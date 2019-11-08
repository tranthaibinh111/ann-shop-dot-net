using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class InvoiceOrderOrderItemModel
    {
        public int id { get; set; }
        public InvoiceOrderProductModel product { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double totalPrice { get; set; }
    }
}