using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterBannerService: IANNService
    {
        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getHomeBanners()
        {
            return new List<FlutterBannerModel>()
            {
                //new FlutterBannerModel()
                //{
                //    action = FlutterPageNavigation.ViewMore,
                //    name = "Sỉ khẩu trang vải",
                //    actionValue = "si-khau-trang-vai",
                //    image = "https://khohangsiann.com/wp-content/uploads/xuong-si-khau-trang-1.jpg"
                //},
                //new FlutterBannerModel()
                //{
                //    action = FlutterPageNavigation.ViewMore,
                //    name = "Sỉ gel rửa tay khô 24h",
                //    actionValue = "si-gel-rua-tay-kho-24h",
                //    image = "https://khohangsiann.com/wp-content/uploads/si-gel-rua-tay-kho-24h.jpg"
                //},
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Thảo mộc giảm cân Cenly",
                    actionValue = "thao-moc-giam-can-cenly-cho-voc-dang-hoan-hao",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-thao-moc-giam-can-cenly.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cần tây mật ong Motree",
                    actionValue = "can-tay-mat-ong",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-can-tay-mat-ong.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cà phê sâm",
                    actionValue = "cafe-sam-khang-mo",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ca-phe-sam.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Ngũ cốc Beone",
                    actionValue = "ngu-coc-beone-250k",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ngu-coc-beone.jpg"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Mỹ phẩm",
                    actionValue = "my-pham",
                    image = "https://khohangsiann.com/wp-content/uploads/si-my-pham-lam-dep.png"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Nước hoa",
                    actionValue = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
                //new FlutterBannerModel()
                //{
                //    action = FlutterPageNavigation.ViewMore,
                //    name = "May áo thun đồng phục",
                //    actionValue = "may-ao-thun-dong-phuc",
                //    image = "https://khohangsiann.com/banner/xuong-may-ao-thun-dong-phuc-gia-re-ann.jpg"
                //},
            };
        }

        #region Lấy banner cho danh mục
        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getCategoryBanners(string slug)
        {
            if (String.IsNullOrEmpty(slug))
                return null;

            return new List<FlutterBannerModel>()
            {
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Áo khoác nam",
                    actionValue = "ao-khoac-nam",
                    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Áo khoác nữ",
                    actionValue = "ao-khoac-nu",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
            };
        }
        #endregion

        #region Lấy banner cho tag
        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getTagBanners(string slug)
        {
            if (String.IsNullOrEmpty(slug))
                return null;

            return new List<FlutterBannerModel>()
            {
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Nước hoa",
                    actionValue = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Đồ lót nữ",
                    actionValue = "do-lot-nu",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
            };
        }
        #endregion

        #region Lấy banner cho search
        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getSearchBanners()
        {
            return new List<FlutterBannerModel>()
            {
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Nước hoa",
                    actionValue = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Ngũ cốc Beone",
                    actionValue = "ngu-coc-beone-250k",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ngu-coc-beone.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cần tây mật ong Motree",
                    actionValue = "can-tay-mat-ong",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-can-tay-mat-ong.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cà phê sâm",
                    actionValue = "cafe-sam-khang-mo",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ca-phe-sam.jpg"
                },
            };
        }
        #endregion

        #region Lấy banner cho sản phẩm
        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getProductBanners(string slug, string position)
        {
            if (String.IsNullOrEmpty(slug))
                return null;

            var header = new List<FlutterBannerModel>()
            {
                //new FlutterBannerModel()
                //{
                //    action = FlutterPageNavigation.ViewMore,
                //    name = "Sỉ khẩu trang vải",
                //    actionValue = "si-khau-trang-vai",
                //    image = "https://khohangsiann.com/wp-content/uploads/xuong-si-khau-trang-1.jpg"
                //},
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Mỹ phẩm",
                    actionValue = "my-pham",
                    image = "https://khohangsiann.com/wp-content/uploads/si-my-pham-lam-dep.png",
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cần tây mật ong Motree",
                    actionValue = "can-tay-mat-ong",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-can-tay-mat-ong.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cà phê sâm",
                    actionValue = "cafe-sam-khang-mo",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ca-phe-sam.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Ngũ cốc Beone",
                    actionValue = "ngu-coc-beone-250k",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ngu-coc-beone.jpg"
                },
            };

            var footer = new List<FlutterBannerModel>()
            {

                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cà phê sâm",
                    actionValue = "cafe-sam-khang-mo",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ca-phe-sam.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Ngũ cốc Beone",
                    actionValue = "ngu-coc-beone-250k",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-ngu-coc-beone.jpg"
                },
                new FlutterBannerModel()
                {
                    action = FlutterPageNavigation.Product,
                    name = "Cần tây mật ong Motree",
                    actionValue = "can-tay-mat-ong",
                    image = "https://khohangsiann.com/wp-content/uploads/banner-can-tay-mat-ong.jpg"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Nước hoa",
                    actionValue = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
                //new FlutterBannerModel()
                //{
                //    action = FlutterPageNavigation.ViewMore,
                //    name = "Sỉ gel rửa tay khô 24h",
                //    actionValue = "si-gel-rua-tay-kho-24h",
                //    image = "https://khohangsiann.com/wp-content/uploads/si-gel-rua-tay-kho-24h.jpg"
                //},
            };

            if (String.IsNullOrEmpty(position))
            {
                return header.Union(footer).ToList();
            }
            else
            {
                if (position == FlutterBannerProductPosition.Header)
                {
                    return header;
                }
                else
                {
                    return footer;
                }
            }
        }
        #endregion
    }
}