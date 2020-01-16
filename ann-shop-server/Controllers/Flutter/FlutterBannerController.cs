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
    [Authorize]
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
        [Route("~/api/flutter/banners")]
        public IHttpActionResult GetBanners([FromUri]FlutterBannerFilterModel filter)
        {
            if (String.IsNullOrEmpty(filter.page))
                return Ok<List<FlutterBannerModel>>(null);

            if (filter.page == "home")
                return Ok<List<FlutterBannerModel>>(_service.getHomeBanners());

            //if (filter.page == "category")
            //    return Ok<List<FlutterBannerModel>>(_service.getCategoryBanners(filter.slug));

            //if (filter.page == "tag")
            //    return Ok<List<FlutterBannerModel>>(_service.getTagBanners(filter.slug));

            //if (filter.page == "search")
            //    return Ok<List<FlutterBannerModel>>(_service.getSearchBanners());

            //if (filter.page == "product")
            //    return Ok<List<FlutterBannerModel>>(_service.getProductBanners(filter.slug, filter.position));

            return Ok<List<FlutterBannerModel>>(null);
        }
    }
}
