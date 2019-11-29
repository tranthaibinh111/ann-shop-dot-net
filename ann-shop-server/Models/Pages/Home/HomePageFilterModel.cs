using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class HomePageFilterModel
    {
        public string categorySlug { get; set; }
        public List<string> categorySlugList { get; set; }
        public int sort { get; set; } = (int)ProductSortKind.ProductNew;
    }
}