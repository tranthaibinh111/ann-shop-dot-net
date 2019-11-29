﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class CategoryPageFilterModel
    {
        public string categorySlug { get; set; }
        public string productBadge { get; set; }
        public int priceMin { get; set; }
        public int priceMax { get; set; }
        public int sort { get; set; }
    }
}