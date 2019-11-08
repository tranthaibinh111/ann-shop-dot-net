using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class InvoiceOrderFeeOtherModel
    {
        public Guid uuid { get; set; }
        public string feeName { get; set; }
        public double feePrice { get; set; }
    }
}