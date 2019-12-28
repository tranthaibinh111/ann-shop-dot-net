using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterCategoryModel: ICloneable
    {
        public string name { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public FlutterProductFilterModel filter { get; set; }


        public List<FlutterCategoryModel> children { get; set; }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}