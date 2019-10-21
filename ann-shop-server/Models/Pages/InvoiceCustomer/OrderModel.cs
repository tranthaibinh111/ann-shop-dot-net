using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models.Pages.InvoiceCustomer
{
    public class OrderModel
    {
        public int id { get; set; }
        public DateTime createdDate { get; set; } 
        public Nullable<DateTime> dateDone { get; set; }
        public string staffName { get; set; }
        public int quantity { get; set; }
        public double priceNotDiscount { get; set; }
        public double discountPerItem { get; set; }
        public double discount { get; set; }
        public double priceDiscount { get; set; }
        public RefundModel refund { get; set; }
        public double remainderMoney { get; set; }
        public double feeShipping { get; set; }
        public List<FeeOtherModel> feeOthers { get; set; }
        public double price { get; set; }
    }
}