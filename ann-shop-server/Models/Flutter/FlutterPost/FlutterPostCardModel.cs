﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterPostCardModel
    {
        public string title { get; set; }
        public string slug { get; set; }
        public string avatar { get; set; }
        public string summary { get; set; }
        public DateTime createdDate { get; set; }
    }
}