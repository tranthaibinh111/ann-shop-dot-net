using ann_shop_server.Models;
using ann_shop_server.Services.Searches;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers.Searches
{
    [RoutePrefix("api/v1/search")]
    public class SearchProductController : ApiController
    {
        private SearchProductService _service;

        public SearchProductController()
        {
            _service = SearchProductService.Instance;
        }

        #region Modal tìm kiếm sản phẩm để đặt hàng
        /// <summary>
        /// Màn hình search sản phẩm trong đơn hàng
        /// </summary>
        /// <param name="orderType"></param>
        /// <param name="sku"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getProductOrdered")]
        public IHttpActionResult getProductOrdered(int orderType, string sku)
        {
            var products = _service.getProductOrdered(orderType, sku);
            return Ok(products);
        }
        #endregion

        #region Màn hình tìm kiếm sản phẩm
        /// <summary>
        /// Lấy danh sách sort cho manh hình 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("search-product/sort")]
        public IHttpActionResult GetProductSort()
        {
            var sorts = _service.getProductSort();

            if (sorts == null)
                return NotFound();
            else
                return Ok<List<ProductSortModel>>(sorts);
        }

        /// <summary>
        /// Màn hình search tìm kiếm sản phẩm
        /// </summary>
        /// <param name="slug">Trường hợp nếu lấy tất cả thì slug == string empty</param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search-product/{search}")]
        public IHttpActionResult GetProductBySearchSort(string search, [FromUri]PagingParameterModel pagingParameterModel, int sort = (int)ProductSortKind.ProductNew)
        {
            if (String.IsNullOrEmpty(search))
            {
                throw new Exception("Bạn đang search rỗng");
            }

            var pagination = new PaginationMetadataModel()
            {
                currentPage = pagingParameterModel.pageNumber,
                pageSize = pagingParameterModel.pageSize
            };
            var products = _service.getProductBySearchSort(search, sort, ref pagination);

            if (products == null || products.Count == 0)
                return NotFound();

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            // Returing List of product Collections
            return Ok<List<ProductCardModel>>(products);
        }
        #endregion
    }
}
