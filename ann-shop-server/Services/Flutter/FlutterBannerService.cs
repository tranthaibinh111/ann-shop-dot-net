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
                    type = "category",
                    name = "Bao lì xì tết",
                    value = "bao-li-xi-tet",
                    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png"
                },
                new FlutterBannerModel()
                {
                    type = "category",
                    name = "Nước hoa",
                    value = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
            };
        }

        /// <summary>
        /// Lấy danh sách newsletter dạng banner
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getHomePosts()
        {
            var now = DateTime.Now;

            return new List<FlutterBannerModel>()
            {
                new FlutterBannerModel()
                {
                    type = "post",
                    name = "Bao lì xì tết",
                    value = "bao-li-xi-tet",
                    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png",
                    createdDate = now

                },
                new FlutterBannerModel()
                {
                    type = "post",
                    name = "Nước hoa",
                    value = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png",
                    createdDate = now
                },
            };
        }
    }
}