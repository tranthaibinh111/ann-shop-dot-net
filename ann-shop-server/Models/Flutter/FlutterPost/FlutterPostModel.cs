﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterPostModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public DateTime createdDate { get; set; }
    }
}