using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterBlockProductService : IANNService
    {
        private readonly FlutterCategoryService _category = ANNFactoryService.getInstance<FlutterCategoryService>();

        /// <summary>
        /// Lấy danh sách block product cho trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBlockProductModel> getHomeBlocks()
        {
            var blockProducts = new List<FlutterBlockProductModel>();

            //#region Bao lì xì tết
            //var block1 = _categoryService.createCategoryBlockProduct("bao-li-xi-tet");
            //if (block1 != null)
            //{
            //    blockProducts.Add(new FlutterBlockProductModel()
            //    {
            //        //banner = new FlutterBannerModel() {
            //        //    action = "category",
            //        //    name = "Bao lì xì tết",
            //        //    actionValue = "bao-li-xi-tet",
            //        //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
            //        //    createdDate = DateTime.Now
            //        //},
            //        category = block1
            //    });
            //}
            //#endregion

            #region Tag Hot
            var block14 = _category.createCategoryByTag("Đang hot", String.Empty, "hot");
            if (block14 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    //banner = new FlutterBannerModel()
                    //{
                    //    action = "category",
                    //    name = "Mỹ phẩm",
                    //    actionValue = "my-pham",
                    //    image = "https://khohangsiann.com/wp-content/uploads/si-my-pham-lam-dep.png",
                    //    createdDate = DateTime.Now
                    //},
                    category = block14
                });
            }
            #endregion

            #region Mỹ phẩm
            var block11 = _category.createCategoryBlockProduct("my-pham");
            if (block11 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = new FlutterBannerModel()
                    {
                        action = "category",
                        name = "Mỹ phẩm",
                        actionValue = "my-pham",
                        image = "https://khohangsiann.com/wp-content/uploads/si-my-pham-lam-dep.png",
                        createdDate = DateTime.Now
                    },
                    category = block11
                });
            }
            #endregion

            #region Đồ bộ nữ
            var block3 = _category.getWomenOutfit();
            if (block3 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    //banner = new FlutterBannerModel()
                    //{
                    //    action = "category",
                    //    name = "Đồ bộ nữ",
                    //    actionValue = "do-bo-nu",
                    //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                    //    createdDate = DateTime.Now
                    //},
                    category = block3
                });
            }
            #endregion

            #region Váy đầm
            var block2 = _category.getWomenDresses();
            if (block2 != null)
            {
                block2.name = "Váy đầm";
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    //banner = new FlutterBannerModel()
                    //{
                    //    action = "category",
                    //    name = "Váy đầm",
                    //    actionValue = "vay-dam",
                    //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                    //    createdDate = DateTime.Now
                    //},
                    category = block2
                });
            }
            #endregion

            //#region Áo dài cách tân
            //var block4 = _categoryService.createCategoryBlockProduct("ao-dai-cach-tan");
            //if (block4 != null)
            //{
            //    blockProducts.Add(new FlutterBlockProductModel()
            //    {
            //        //banner = new FlutterBannerModel()
            //        //{
            //        //    action = "category",
            //        //    name = "Áo dài cách tân",
            //        //    actionValue = "ao-dai-cach-tan",
            //        //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
            //        //    createdDate = DateTime.Now
            //        //},
            //        category = block4
            //    });
            //}
            //#endregion

            #region Áo thun nữ
            var block12 = _category.getWomenTShirts();
            blockProducts.Add(new FlutterBlockProductModel()
            {
                //banner = new FlutterBannerModel()
                //{
                //    action = "category",
                //    name = "Áo thun nữ - Sơ mi nữ",
                //    actionValue = "ao-thun-nu",
                //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                //    createdDate = DateTime.Now
                //},
                category = block12
            });
            #endregion

            #region Áo kiểu nữ - Sơ mi nữ
            var block5 = _category.createCategoryBySlugs(
                "Áo kiểu nữ - Sơ mi nữ",
                new List<string>() { "ao-kieu-nu", "ao-so-mi-nu" }
            );
            blockProducts.Add(new FlutterBlockProductModel()
            {
                //banner = new FlutterBannerModel()
                //{
                //    action = "category",
                //    name = "Áo thun nữ - Sơ mi nữ",
                //    actionValue = "ao-thun-nu",
                //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                //    createdDate = DateTime.Now
                //},
                category = block5
            });
            #endregion

            #region Áo khoác nữ
            var block6 = _category.createCategoryBlockProduct("ao-khoac-nu");
            if (block6 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    //banner = new FlutterBannerModel()
                    //{
                    //    action = "category",
                    //    name = "Áo khoác nữ",
                    //    actionValue = "ao-khoac-nu",
                    //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                    //    createdDate = DateTime.Now
                    //},
                    category = block6
                });
            }
            #endregion

            #region Quần nữ - Đồ lót nữ
            var block7 = _category.createCategoryBySlugs(
                "Quần nữ - Đồ lót nữ",
                new List<string>() { "quan-nu", "quan-jeans-nu", "do-lot-nu" }
            );
            blockProducts.Add(new FlutterBlockProductModel()
            {
                //banner = new FlutterBannerModel()
                //{
                //    action = "category",
                //    name = "Quần nữ - Đồ lót nữ",
                //    actionValue = "quan-nu",
                //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                //    createdDate = DateTime.Now
                //},
                category = block7
            });
            #endregion

            #region Áo thun nam
            var block8 = _category.getMenTShirt();
            if (block8 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = new FlutterBannerModel()
                    {
                        action = FlutterPageNavigation.ViewMore,
                        name = "May áo thun đồng phục",
                        actionValue = "may-ao-thun-dong-phuc",
                        image = "https://khohangsiann.com/banner/xuong-may-ao-thun-dong-phuc-gia-re-ann.jpg",
                        createdDate = DateTime.Now
                    },
                    category = block8
                });
            }
            #endregion

            #region Áo khoác nam - Sơ mi nam
            var block13 = _category.createCategoryBySlugs(
                "Áo khoác nam - Sơ mi nam",
                new List<string>() { "ao-khoac-nam", "ao-so-mi-nam" }
            );
            blockProducts.Add(new FlutterBlockProductModel()
            {
                //banner = new FlutterBannerModel()
                //{
                //    action = "category",
                //    name = "Quần nam - Quần lót nam",
                //    actionValue = "quan-nam",
                //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                //    createdDate = DateTime.Now
                //},
                category = block13
            });
            #endregion

            #region Quần nam - Quần lót nam
            var block9 = _category.createCategoryBySlugs(
                "Quần nam - Quần lót nam",
                new List<string>() { "quan-nam", "quan-jeans-nam", "quan-lot-nam" }
            );
            blockProducts.Add(new FlutterBlockProductModel()
            {
                //banner = new FlutterBannerModel()
                //{
                //    action = "category",
                //    name = "Quần nam - Quần lót nam",
                //    actionValue = "quan-nam",
                //    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                //    createdDate = DateTime.Now
                //},
                category = block9
            });
            #endregion

            #region Nước hoa
            var block10 = _category.getPerfume();
            if (block10 != null)
            {
                blockProducts.Add(new FlutterBlockProductModel()
                {
                    banner = new FlutterBannerModel()
                    {
                        action = "category",
                        name = "Nước hoa",
                        actionValue = "nuoc-hoa",
                        image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png",
                        createdDate = DateTime.Now
                    },
                    category = block10
                });
            }
            #endregion

            return blockProducts;
        }
    }
}