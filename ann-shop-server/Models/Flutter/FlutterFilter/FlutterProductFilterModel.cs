using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class FlutterProductFilterModel: ICloneable
    {
        public string categorySlug { get; set; }
        public List<string> categorySlugList { get; set; }
        public int productBadge { get; set; }
        public string productSearch { get; set; }
        public int productSort { get; set; }
        public string tagSlug { get; set; }
        public int priceMin { get; set; }
        public int priceMax { get; set; }

        public virtual object Clone()
        {
            var clone = (FlutterProductFilterModel)this.MemberwiseClone();

            if (categorySlugList != null)
                clone.categorySlugList = new List<string>(categorySlugList);

            return clone;
        }
    }
}