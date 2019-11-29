using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductModel
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
        public double oldPrice { get; set; }
        public double retailPrice { get; set; }
        public string content { get; set; }
        public string slug { get; set; }
        public List<string> images { get; set; }
        public List<ColorModel> colors { get; set; }
        public List<SizeModel> sizes { get; set; }
        public int badge { get; set; }
        public List<TagModel> tags { get; set; }
    }
}