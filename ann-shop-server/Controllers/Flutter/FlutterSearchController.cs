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
    [RoutePrefix("api/flutter/search")]
    public class FlutterSearchController : ApiController
    {
        private FlutterSearchService _service;

        public FlutterSearchController()
        {
            _service = FlutterSearchService.Instance;
        }

        /// <summary>
        /// Lấy các trường hợp sort
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("hotkey")]
        public IHttpActionResult GetHotKey()
        {
            return Ok<List<FlutterCategoryModel>>(_service.getHotKey());
        }
    }
}
