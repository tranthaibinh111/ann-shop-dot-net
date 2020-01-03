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
    [RoutePrefix("api/flutter/product")]
    public class FlutterProductController : ApiController
    {
        private FlutterProductService _service;

        public FlutterProductController()
        {
            _service = FlutterProductService.Instance;
        }

        /// <summary>
        /// Lấy các trường hợp sort
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/product-sort")]
        public IHttpActionResult GetProductSort()
        {
            return Ok<List<ProductSortModel>>(_service.getProductSort());
        }

        /// <summary>
        /// Lấy danh sách sản phẩm theo filter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/products")]
        public IHttpActionResult getProducts([FromUri]FlutterProductFilterModel filter, [FromUri] PagingParameterModel paging)
        {
            if (filter == null)
                filter = new FlutterProductFilterModel();

            if (paging == null)
                paging = new PagingParameterModel();

            var pagination = new PaginationMetadataModel()
            {
                currentPage = paging.pageNumber,
                pageSize = paging.pageSize
            };

            var products = _service.getProducts(filter, ref pagination);

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            // Returing List of product Collections
            return Ok<List<FlutterProductCardModel>>(products);
        }

        /// <summary>
        /// Lấy thông tin sản phẩm
        /// </summary>
        /// <param name="slug">slug của sản phẩm</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}")]
        public IHttpActionResult GetProductByCategory(string slug)
        {
            return Ok<FlutterProductModel>(_service.getProductByCategory(slug));
        }

        /// <summary>
        /// Lấy thông tin các sản phẩm con
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/related")]
        public IHttpActionResult GetProductRelatedBySlug(string slug, [FromUri]PagingParameterModel paging)
        {
            if (paging == null)
                paging = new PagingParameterModel();

            var pagination = new PaginationMetadataModel()
            {
                currentPage = paging.pageNumber,
                pageSize = paging.pageSize
            };

            var productrelateds = _service.getProductRelatedBySlug(slug, ref pagination);

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            // Returing List of relate product Collections
            return Ok<List<ProductRelatedModel>>(productrelateds);
        }

        /// <summary>
        /// Lấy avatar đại điện cho sản phẩm biến thể
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/image")]
        public IHttpActionResult GetImageWithVariable(int id, int color = 0, int size = 0)
        {
            return Ok<String>(_service.getImageWithVariable(id, color, size));
        }

        /// <summary>
        /// Lấy ra danh sách image cho việc download về làm quản cáo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/advertisement-image")]
        public IHttpActionResult GetAdvertisementImages(int id)
        {
            return Ok<List<string>>(_service.getAdvertisementImages(id));
        }

        /// <summary>
        /// Lấy ra thông tin quảng cáo sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/advertisement-content")]
        public IHttpActionResult GetAdvertisementContent(int id)
        {
            return Ok<string>(_service.getAdvertisementContent(id));
        }
    }
}
