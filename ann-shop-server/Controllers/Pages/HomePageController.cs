using ann_shop_server.Models;
using ann_shop_server.Services.Pages;
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
    [RoutePrefix("api/v1/home")]
    public class HomePageController : ApiController
    {
        private HomePageService _service;

        public HomePageController()
        {
            _service = HomePageService.Instance;
        }

        private IHttpActionResult GetProducts(string slug, string[] slugList, PagingParameterModel pagingParameterModel)
        {
            var pagination = new PaginationMetadataModel()
            {
                currentPage = pagingParameterModel.pageNumber,
                pageSize = pagingParameterModel.pageSize
            };
            var filter = new HomePageFilterModel();

            if (String.IsNullOrEmpty(slug) && slugList != null && slugList.Length > 0)
            {
                filter.categorySlug = String.Empty;
                filter.categorySlugList = slugList.ToList();
            }
            else
            {
                filter.categorySlug = slug;
                filter.categorySlugList = new List<string>();
            }

            var products = _service.getProducts(filter, ref pagination);
            if (products == null)
                return NotFound();

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            // Returing List of product Collections
            return Ok<List<ProductCardModel>>(products);
        }

        /// <summary>
        /// Lấy sản phẩm theo slug category
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("category/{*slug}")]
        public IHttpActionResult GetProductListByCategory(string slug, [FromUri]PagingParameterModel pagingParameterModel)
        {
            return GetProducts(slug, null, pagingParameterModel);
        }

        /// <summary>
        /// Lấy sản phẩm theo slug category
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("category")]
        public IHttpActionResult GetProductListByCategoryList([FromUri]string[] slugList, [FromUri]PagingParameterModel pagingParameterModel)
        {
            return GetProducts(String.Empty, slugList, pagingParameterModel);
        }
    }
}