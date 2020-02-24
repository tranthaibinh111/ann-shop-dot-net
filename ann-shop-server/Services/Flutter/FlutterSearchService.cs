using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterSearchService: IANNService
    {
        public List<FlutterCategoryModel> getHotKey()
        {
            var result = new List<FlutterCategoryModel>();

            // Đồ bộ nữ
            var key01 = new FlutterCategoryModel()
            {
                name = "đồ bộ nữ",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "do-bo-nu",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(key01);

            // Kem
            var cosmetic = new FlutterCategoryModel()
            {
                name = "mỹ phẩm",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "my-pham",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(cosmetic);

            // Nước hoa
            var perfume = new FlutterCategoryModel()
            {
                name = "nước hoa",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "nuoc-hoa",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(perfume);

            // Áo thun nam
            var menTShirt = new FlutterCategoryModel()
            {
                name = "áo thun nam",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "ao-thun-nam",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(menTShirt);

            // Áo thun nữ
            var womenTShirt = new FlutterCategoryModel()
            {
                name = "áo thun nữ",
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
                name = "quần jean nam",
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