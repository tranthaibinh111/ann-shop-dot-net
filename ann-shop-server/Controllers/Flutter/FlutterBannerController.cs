using ann_shop_server.Models;
using ann_shop_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/flutter/banner")]
    public class FlutterBannerController : ApiController
    {
        private FlutterBannerService _service;

        public FlutterBannerController()
        {
            _service = FlutterBannerService.Instance;
        }

        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/home/banners")]
        public IHttpActionResult GetHomeBanners()
        {
            return Ok<List<FlutterBannerModel>>(_service.getHomeBanners());
        }
    }
}
