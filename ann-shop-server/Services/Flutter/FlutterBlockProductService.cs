using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterBlockProductService : Service<FlutterBlockProductService>
    {
        /// <summary>
        /// Lấy danh sách block product cho trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBlockProductModel> getHomeBlocks()
        {
            var blockProducts = new List<FlutterBlockProductModel>();

            #region Bao lì xì tết
            var block1 = FlutterCategoryService.Instance.getCategoryBySlug("bao-li-xi-tet");
            if (block1 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = String.Empty,
                    category = block1
                });
            }
            #endregion

            #region Váy đầm
            var block2 = FlutterCategoryService.Instance.getCategoryBySlug("vay-dam");
            if (block2 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = String.Empty,
                    category = block2
                });
            }
            #endregion

            #region Đồ bộ nữ
            var block3 = FlutterCategoryService.Instance.getCategoryBySlug("do-bo-nu");
            if (block3 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = String.Empty,
                    category = block3
                });
            }
            #endregion

            #region Áo dài cách tân
            var block4 = FlutterCategoryService.Instance.getCategoryBySlug("ao-dai-cach-tan");
            if (block4 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = String.Empty,
                    category = block4
                });
            }
            #endregion

            #region Áo thung nữ - Sơ mi nữ
            var block5 = FlutterCategoryService.Instance.createCategoryBySlugs(
                "Áo thung nữ - Sơ mi nữ",
                new List<string>() { "ao-thun-nu", "ao-so-mi-nu" }
            );
            blockProducts.Add(new FlutterBlockProductModel()
            {
                banner = String.Empty,
                category = block5
            });
            #endregion

            #region Áo khoác nữ
            var block6 = FlutterCategoryService.Instance.getCategoryBySlug("ao-khoac-nu");
            if (block6 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = String.Empty,
                    category = block6
                });
            }
            #endregion

            #region Quần nữ - Đồ lót nữ
            var block7 = FlutterCategoryService.Instance.createCategoryBySlugs(
                "Quần nữ - Đồ lót nữ",
                new List<string>() { "quan-nu", "do-lot-nu" }
            );
            blockProducts.Add(new FlutterBlockProductModel()
            {
                banner = String.Empty,
                category = block7
            });
            #endregion

            #region Áo thung nam
            var block8 = FlutterCategoryService.Instance.getCategoryBySlug("ao-thun-nam");
            if (block8 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = String.Empty,
                    category = block8
                });
            }
            #endregion

            #region Quần nam - Quần lót nam
            var block9 = FlutterCategoryService.Instance.createCategoryBySlugs(
                "Quần nam - Quần lót nam",
                new List<string>() { "quan-nam", "quan-lot-nam" }
            );
            blockProducts.Add(new FlutterBlockProductModel()
            {
                banner = String.Empty,
                category = block9
            });
            #endregion

            return blockProducts;
        }
    }
}