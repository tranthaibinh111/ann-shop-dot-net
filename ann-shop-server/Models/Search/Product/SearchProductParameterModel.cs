﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class SearchProductParameterModel
    {
        public int sort { get; set; } = (int)ProductSortKind.ProductNew;
        public int pageSize { get; set; } = 10;
        public int pageNumber { get; set; } = 1;
    }
}