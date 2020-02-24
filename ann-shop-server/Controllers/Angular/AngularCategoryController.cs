using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/v1/category")]
    public class AngularCategoryController : ApiController
    {
        private AngularCategoryService _service;

        public AngularCategoryController()
        {
            _service = ANNFactoryService.getInstance<AngularCategoryService>();
        }

        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}")]
        public IHttpActionResult GetCategoryBySlug(string slug)
        {
            var category = _service.getCategoryBySlug(slug);

            if (category == null)
                return NotFound();

            return Ok<CategoryModel>(category);
        }

        /// <summary>
        /// Lấy danh sách sort
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sort")]
        public IHttpActionResult GetProductSort()
        {
            var sorts = _service.getProductSort();

            if (sorts == null)
                return NotFound();
            else
                return Ok<List<ProductSortModel>>(sorts);
        }

        private IHttpActionResult getProduct(string slug, string productBadge, [FromUri]CategoryPageParameterModel parameter)
        {
            var pagination = new PaginationMetadataModel()
            {
                currentPage = parameter.pageNumber,
                pageSize = parameter.pageSize
            };
            var filter = new CategoryPageFilterModel()
            {
                categorySlug = slug,
                productBadge = productBadge,
                priceMin = parameter.priceMin,
                priceMax = parameter.priceMax,
                sort = parameter.sort
            };
            var products = _service.getProducts(filter, ref pagination);

            if (products == null || products.Count == 0)
                return NotFound();

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            // Returing List of product Collections
            return Ok<List<ProductCardModel>>(products);

        }

        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/product")]
        public IHttpActionResult GetProductByCategory(string slug, [FromUri]CategoryPageParameterModel parameter)
        {
            return this.getProduct(slug, String.Empty, parameter);
        }

        /// <summary>
        /// Lấy tất cả sản phẩm
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [Route("product")]
        public IHttpActionResult GetProductAll([FromUri]CategoryPageParameterModel parameter)
        {
            return this.getProduct(String.Empty, String.Empty, parameter);
        }

        /// <summary>
        /// Lấy sản phẩm order theo danh mục
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="productBadge"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/product/{productBadge}")]
        public IHttpActionResult GetProductOrderByCategory(string slug, string productBadge, [FromUri]CategoryPageParameterModel parameter)
        {
            return this.getProduct(slug, productBadge, parameter);
        }

        /// <summary>
        /// Lấy sản phẩm order
        /// </summary>
        /// <param name="productBadge"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [Route("product/{productBadge}")]
        public IHttpActionResult GetProductOrderAll(string productBadge, [FromUri]CategoryPageParameterModel parameter)
        {
            return this.getProduct(String.Empty, productBadge, parameter);
        }
    }
}
