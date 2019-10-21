using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models.Pages.InvoiceCustomer
{
    public class ProductModel
    {
        public int productID { get; set; }
        public int productVariableID { get; set; }
        public string sku { get; set; }
        public string title { get; set; }
        public string avatar { get; set; }
        public string color { get; set; }
        public string size { get; set; }
    }
}