using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models.Pages.InvoiceCustomer
{
    public class FeeOtherModel
    {
        public Guid uuid { get; set; }
        public string feeName { get; set; }
        public double feePrice { get; set; }
    }
}