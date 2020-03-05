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

            // Nước rửa tay
            var key03 = new FlutterCategoryModel()
            {
                name = "nước rửa tay khô",
                filter = new FlutterProductFilterModel()
                {
                    productSKU = "XIT",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(key03);

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

            // Váy đầm
            var key02 = new FlutterCategoryModel()
            {
                name = "váy đầm",
                filter = new FlutterProductFilterModel()
                {
                    categorySlug = "vay-dam",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(key02);

            // Mỹ phẩm
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

            // Quần áo nữ bigsize
            var key05 = new FlutterCategoryModel()
            {
                name = "đồ nữ big size",
                filter = new FlutterProductFilterModel()
                {
                    tagSlug = "quan-ao-nu-big-size",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(key05);

            // kem body x3
            var key06 = new FlutterCategoryModel()
            {
                name = "kem body x3",
                filter = new FlutterProductFilterModel()
                {
                    productSKU = "BODY",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(key06);

            // kích trắng x3
            var key07 = new FlutterCategoryModel()
            {
                name = "kích trắng x3",
                filter = new FlutterProductFilterModel()
                {
                    productSKU = "KICHX3",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(key07);

            // trị mụn dr mai
            var key08 = new FlutterCategoryModel()
            {
                name = "trị mụn Dr Mai",
                filter = new FlutterProductFilterModel()
                {
                    productSKU = "DRMAI",
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
            result.Add(key08);

            return result;
        }
    }
}