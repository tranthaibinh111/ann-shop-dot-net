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
    [RoutePrefix("api/flutter/post-category")]
    public class FlutterPostCategoryController : ApiController
    {
        private FlutterPostCategoryService _service;

        public FlutterPostCategoryController()
        {
            _service = FlutterPostCategoryService.Instance;
        }

        /// <summary>
        /// Lấy danh sách category cho blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/post-categories")]
        public IHttpActionResult GetCategories()
        {
            return Ok<List<FlutterPostCategoryModel>>(_service.getCategories());
        }
    }
}
