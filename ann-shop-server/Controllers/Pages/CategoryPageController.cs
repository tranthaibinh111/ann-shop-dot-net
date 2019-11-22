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
    public class CategoryPageController : ApiController
    {
        private CategoryPageService _service;

        public CategoryPageController()
        {
            _service = CategoryPageService.Instance;
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

        private IHttpActionResult getProduct(string slug, string preOrder, int sort, [FromUri]PagingParameterModel pagingParameterModel)
        {
            var pagination = new PaginationMetadataModel()
            {
                currentPage = pagingParameterModel.pageNumber,
                pageSize = pagingParameterModel.pageSize
            };
            List<ProductCardModel> products;

            if (!String.IsNullOrEmpty(slug))
            {
                if (!String.IsNullOrEmpty(preOrder))
                    products = _service.getProductListByCategoryPreOrderSort(slug, preOrder, sort, ref pagination);
                else
                    products = _service.getProductListByCategorySort(slug, sort, ref pagination);
            }
            else
            {
                if (!String.IsNullOrEmpty(preOrder))
                    products = _service.getProductListByPreOrderSort(preOrder, sort, ref pagination);
                else
                    products = _service.getProductListBySort(sort, ref pagination);
            }

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
        /// <param name="pagingParameterModel"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/product")]
        public IHttpActionResult GetProductByCategory(string slug, [FromUri]PagingParameterModel pagingParameterModel, int sort = (int)ProductSortKind.ProductNew)
        {
            return this.getProduct(slug, String.Empty, sort, pagingParameterModel);
        }

        /// <summary>
        /// Lấy tất cả sản phẩm
        /// </summary>
        /// <param name="pagingParameterModel"></param>
        /// <param name="preOrder"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [Route("product")]
        public IHttpActionResult GetProductAll([FromUri]PagingParameterModel pagingParameterModel, int sort = (int)ProductSortKind.ProductNew)
        {
            return this.getProduct(String.Empty, String.Empty, sort, pagingParameterModel);
        }

        /// <summary>
        /// Lấy sản phẩm order theo danh mục
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="preOrder"></param>
        /// <param name="pagingParameterModel"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/product/{preOrder}")]
        public IHttpActionResult GetProductOrderByCategory(string slug, string preOrder, [FromUri]PagingParameterModel pagingParameterModel, int sort = (int)ProductSortKind.ProductNew)
        {
            return this.getProduct(slug, preOrder, sort, pagingParameterModel);
        }

        /// <summary>
        /// Lấy sản phẩm order
        /// </summary>
        /// <param name="preOrder"></param>
        /// <param name="pagingParameterModel"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [Route("product/{preOrder}")]
        public IHttpActionResult GetProductOrderAll(string preOrder, [FromUri]PagingParameterModel pagingParameterModel,int sort = (int)ProductSortKind.ProductNew)
        {
            return this.getProduct(String.Empty, preOrder, sort, pagingParameterModel);
        }
    }
}
