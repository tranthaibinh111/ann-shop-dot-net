using ann_shop_server.Services;
using System.Web.Http;
using System.Collections.Generic;
using ann_shop_server.Models;
using System.Web;
using Newtonsoft.Json;

namespace ann_shop_server.Controllers.Pages
{
    [RoutePrefix("api/v1/tag")]
    public class TagPageController : ApiController
    {
        private TagPageService _service;

        public TagPageController()
        {
            _service = TagPageService.Instance;
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
            var tag = _service.getTagBySlug(slug);

            if (tag == null)
                return NotFound();

            return Ok<TagModel>(tag);
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

        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pagingParameterModel"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/product")]
        public IHttpActionResult GetProductByCategory(string slug, [FromUri]TagPageParameterModel parameter)
        {
            var pagination = new PaginationMetadataModel()
            {
                currentPage = parameter.pageNumber,
                pageSize = parameter.pageSize
            };
            var filter = new TagPageFilterModel()
            {
                tagSlug = slug,
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
    }
}
