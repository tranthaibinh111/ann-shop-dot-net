using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class SearchProductFilterModel
    {
        public string search { get; set; }
        public int sort { get; set; }
    }
}