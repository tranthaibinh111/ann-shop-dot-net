using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterCopyModel
    {
        public string shopPhone { get; set; }
        public string shopAddress { get; set; }
        public bool showSKU { get; set; } = true;
        public bool showProductName { get; set; } = true;
        public int increntPrice { get; set; }
    }
}