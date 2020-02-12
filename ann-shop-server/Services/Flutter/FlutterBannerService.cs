using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterBannerService: Service<FlutterBannerService>
    {
        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getHomeBanners()
        {
            return new List<FlutterBannerModel>()
            {
                new FlutterBannerModel()
                {
                    action = "view_more",
                    name = "Sỉ gel rửa tay khô 24h",
                    actionValue = "si-gel-rua-tay-kho-24h",
                    image = "https://khohangsiann.com/wp-content/uploads/si-gel-rua-tay-kho-24h.jpg"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Nước hoa",
                    actionValue = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
                new FlutterBannerModel()
                {
                    action = "view_more",
                    name = "May áo thun đồng phục",
                    actionValue = "may-ao-thun-dong-phuc",
                    image = "https://khohangsiann.com/banner/xuong-may-ao-thun-dong-phuc-gia-re-ann.jpg"
                },
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
                    name = "Áo thun cá sấu",
                    actionValue ="ao-thun-ca-sau",
                    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Đồ bộ nữ",
                    actionValue = "do-bo-nu",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
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

            return new List<FlutterBannerModel>()
            {
                new FlutterBannerModel()
                {
                    action = "category",
                    name = position == "header" ? "Áo thun nam" : "Váy đầm",
                    actionValue = position == "header" ? "ao-thun-nam" : "vay-dam",
                    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = position == "header" ? "Quần jean nam" : "Quần jean nữ",
                    actionValue = position == "header" ? "quan-jeans-nam" : "quan-jeans-nu",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
            };
        }
        #endregion
    }
}