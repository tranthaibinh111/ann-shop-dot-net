using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [Authorize]
    [RoutePrefix("api/flutter/shop")]
    public class FlutterShopController : ApiController
    {
        /// <summary>
        /// Lấy thông tin liên hệ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("contact")]
        public IHttpActionResult GetBanners()
        {
            return Ok(new
            {
                address = "68 Đường C12, Phường 13, Quận Tân Bình, TP.HCM",
                urlMap = "https://www.google.com/maps?cid=5068651584244638837&hl=vi",
                urlFB = "fb://profile/100012594165130",
                urlWebsite = "http://xuongann.com/",
                phone = new List<string>() { "0918569400", "0918567409", "0913268406", "0936786404" },
                timeWork = "8h30 - 19h30 (Chủ Nhật 8h30 - 17h00)"
            });
        }
    }
}
