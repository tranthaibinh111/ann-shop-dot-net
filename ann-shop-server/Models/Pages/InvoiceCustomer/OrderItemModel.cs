using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models.Pages.InvoiceCustomer
{
    public class OrderItemModel
    {
        public int id { get; set; }
        public ProductModel product { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double totalPrice { get; set; }
    }
}