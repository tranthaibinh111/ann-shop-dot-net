using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class TagPageFilterModel
    {
        public string tagSlug { get; set; }
        public int sort { get; set; } = (int)ProductSortKind.ProductNew;
    }
}