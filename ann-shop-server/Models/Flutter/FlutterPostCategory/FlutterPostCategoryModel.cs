using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterPostCategoryModel
    {
        public string name { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public FlutterPostFilterModel filter { get; set; }


        public List<FlutterPostCategoryModel> children { get; set; }
    }
}