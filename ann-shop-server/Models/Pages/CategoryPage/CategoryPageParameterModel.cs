using System;

namespace ann_shop_server.Models
{
    public class CategoryPageParameterModel
    {
        public int priceMin { get; set; } = 0;
        public int priceMax { get; set; } = 0;
        public int sort { get; set; } = (int)ProductSortKind.ProductNew;
        public int pageSize { get; set; } = 10;
        public int pageNumber { get; set; } = 1;
    }
}