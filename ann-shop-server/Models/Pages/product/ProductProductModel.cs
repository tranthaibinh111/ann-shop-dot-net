using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductProductModel
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string categorySlug { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string avatar { get; set; }
        public List<ThumbnailModel> thumbnails { get; set; }
        public string materials { get; set; }
        public double regularPrice { get; set; }
        public double retailPrice { get; set; }
        public string content { get; set; }
        public string slug { get; set; }
        public List<string> images { get; set; }
        public List<ProductColorModel> colors { get; set; }
        public List<ProductSizeModel> sizes { get; set; }
        public bool availability { get; set; }
    }
}