﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class PostModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string content { get; set; }
        public int? featured { get; set; }
        public int? categoryID { get; set; }
        public string categoryName { get; set; }
        public DateTime? createdDate { get; set; }
    }
}