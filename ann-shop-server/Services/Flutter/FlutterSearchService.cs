using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterSearchService: Service<FlutterSearchService>
    {
        public List<FlutterCategoryModel> getHotKey()
        {
            var result = new List<FlutterCategoryModel>();

            // Bao lì xì
            var redEnvelop = new FlutterCategoryModel()
            {
                name = "Bao lì xì",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "bao-li-xi-tet",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(redEnvelop);

            // Nước hoa
            var perfume = new FlutterCategoryModel()
            {
                name = "Nước hoa",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "nuoc-hoa",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(perfume);

            // Áo thun nữ
            var womenTShirt = new FlutterCategoryModel()
            {
                name = "Áo thun nữ",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "ao-thun-nu",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(womenTShirt);

            // Quần Jean Nam
            var menJean = new FlutterCategoryModel()
            {
                name = "Quần jean nam",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "quan-jeans-nam",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(menJean);

            return result;
        }
    }
}