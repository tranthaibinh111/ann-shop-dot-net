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
    [RoutePrefix("api/flutter/block")]
    public class FlutterBlockProductController : ApiController
    {
        private FlutterBlockProductService _service;

        public FlutterBlockProductController()
        {
            _service = FlutterBlockProductService.Instance;
        }

        /// <summary>
        /// Lấy danh sách block product thể hiện ở home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/home/blocks")]
        public IHttpActionResult GetHomeBlocks()
        {
            return Ok<List<FlutterBlockProductModel>>(_service.getHomeBlocks()); ;
        }
    }
}
