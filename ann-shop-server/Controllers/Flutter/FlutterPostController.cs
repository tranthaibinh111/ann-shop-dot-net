using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [Authorize]
    [RoutePrefix("api/flutter/post")]
    public class FlutterPostController : ApiController
    {
        private FlutterPostService _service;

        public FlutterPostController()
        {
            _service = FlutterPostService.Instance;
        }

        /// <summary>
        /// Lấy danh sách banner tại đầu trang home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/home/posts")]
        public IHttpActionResult GetHomePosts()
        {
            return Ok<List<FlutterBannerModel>>(null);
            //return Ok<List<FlutterBannerModel>>(_service.getHomePosts());
        }

        /// <summary>
        /// Lấy tất cả thông báo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/posts")]
        public IHttpActionResult GetPosts([FromUri]FlutterPostFilterModel filter, [FromUri] PagingParameterModel paging)
        {
            if (filter == null)
                filter = new FlutterPostFilterModel();

            if (paging == null)
                paging = new PagingParameterModel();

            var pagination = new PaginationMetadataModel()
            {
                currentPage = paging.pageNumber,
                pageSize = paging.pageSize
            };

            if (!(!String.IsNullOrEmpty(filter.categorySlug) && filter.categorySlug == "chinh-sach"))
                return Ok<List<FlutterPostCardModel>>(null);

            var posts = _service.getPosts(filter, ref pagination);

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            return Ok<List<FlutterPostCardModel>>(posts);
        }

        /// <summary>
        /// Lấy các viết về chính sách
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("policies")]
        public IHttpActionResult GetPolicies([FromUri] PagingParameterModel paging)
        {
            var filter = new FlutterPostFilterModel()
            {
                categorySlug = "chinh-sach"
            };

            return GetPosts(filter, paging);
        }

        /// <summary>
        /// Lấy chi tiết thông báo theo slug
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("{*slug}")]
        public IHttpActionResult GetPostBySlug(string slug)
        {
            return Ok<FlutterPostModel>(_service.getPostBySlug(slug));
        }
    }
}
