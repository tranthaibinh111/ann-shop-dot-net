using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    public class ProductController : ApiController
    {
        private ProductService _service;

        public ProductController()
        {
            _service = ProductService.Instance;
        }

        // GET api/product
        public IEnumerable<ProductDetailPageModel> Get([FromUri]PagingParameterModel pagingParameterModel, int? category = null)
        {
            var categoryID = category.HasValue ? category.Value : 0;
            var productPage = _service.getProducts(categoryID, pagingParameterModel.pageNumber, pagingParameterModel.pageSize);

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(productPage.paginationMetadata));

            // Returing List of Customers Collections
            return productPage.data;
        }

        // GET api/product/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
