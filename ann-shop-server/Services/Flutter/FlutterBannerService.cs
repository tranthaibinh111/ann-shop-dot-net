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
                    action = "category",
                    name = "Bao lì xì tết",
                    actionValue = "bao-li-xi-tet",
                    image = "https://khohangsiann.com/wp-content/uploads/si-bao-li-xi-2020.png"
                },
                new FlutterBannerModel()
                {
                    action = "category",
                    name = "Nước hoa",
                    actionValue = "nuoc-hoa",
                    image = "https://khohangsiann.com/wp-content/uploads/si-nuoc-hoa-gia-re-1.png"
                },
            };
        }
    }
}