using ann_shop_server.Models;
using ann_shop_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ann_shop_server.Controllers.Flutter
{
    [RoutePrefix("api/flutter/category")]
    public class FlutterCategoryController : ApiController
    {
        private FlutterCategoryService _service;

        public FlutterCategoryController()
        {
            _service = FlutterCategoryService.Instance;
        }

        /// <summary>
        /// Lấy danh sách category cho trang home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/home/categories")]
        public IHttpActionResult GetHomeCategories()
        {
            return Ok<List<FlutterCategoryModel>>(_service.getHomeCategories());
        }

        /// <summary>
        /// Lấy danh sách category cho trang home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/categories")]
        public IHttpActionResult GetCategories()
        {
            return Ok<List<FlutterCategoryModel>>(_service.getCategories());
        }
    }
}
