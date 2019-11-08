using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/v1/category")]
    public class CategoryController : ApiController
    {
        private CategoryService _service;

        public CategoryController()
        {
            _service = CategoryService.Instance;
        }

        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}")]
        public IHttpActionResult GetCategory(string slug)
        {
            var category = _service.getCategory(slug);

            if (category == null)
                return NotFound();

            return Ok<CategoryCategoryModel>(category);
        }

        /// <summary>
        /// Lấy danh sách sort
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sort")]
        public IHttpActionResult GetSort()
        {
            var sorts = _service.getSort();

            if (sorts == null)
                return NotFound();
            else
                return Ok<List<CategorySortModel>>(sorts);
        }

        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="slug">Trường hợp nếu lấy tất cả thì slug == string empty</param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/product")]
        public IHttpActionResult GetProduct(string slug, [FromUri]PagingParameterModel pagingParameterModel, int sort = (int)CategorySort.ProductNew)
        {
            var pagination = new PaginationMetadataModel()
            {
                currentPage = pagingParameterModel.pageNumber,
                pageSize = pagingParameterModel.pageSize
            };
            var products = _service.getProduct(slug, sort, ref pagination);

            if (products == null || products.Count == 0)
                return NotFound();

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            // Returing List of product Collections
            return Ok<List<CategoryProductModel>>(products);
        }

        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="slug">Trường hợp nếu lấy tất cả thì slug == string empty</param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        [Route("product")]
        public IHttpActionResult GetProduct([FromUri]PagingParameterModel pagingParameterModel, int sort = (int)CategorySort.ProductNew)
        {
            var pagination = new PaginationMetadataModel()
            {
                currentPage = pagingParameterModel.pageNumber,
                pageSize = pagingParameterModel.pageSize
            };
            var products = _service.getProduct(sort, ref pagination);

            if (products == null || products.Count == 0)
                return NotFound();

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            // Returing List of product Collections
            return Ok<List<CategoryProductModel>>(products);
        }
    }
}
