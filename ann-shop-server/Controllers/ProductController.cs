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
        [Route("api/v1/product")]
        public IEnumerable<ProductModel> Get([FromUri]PagingParameterModel pagingParameterModel, int? category = null)
        {
            var categoryID = category.HasValue ? category.Value : 0;
            var productPage = _service.getProducts(categoryID, pagingParameterModel.pageNumber, pagingParameterModel.pageSize);

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(productPage.paginationMetadata));

            // Returing List of product Collections
            return productPage.data;
        }

        // GET api/product/productID:int
        [Route("api/v1/product/{id:int}")]
        public ProductDetailPageModel Get(int id)
        {
            return _service.getProductDetail(id);
        }

        // Get api/product/productID:int/related
        [Route("api/v1/product/{id:int}/related")]
        public IEnumerable<ProductVariableModel> GetProductRelated(int id, [FromUri]PagingParameterModel pagingParameterModel)
        {
            var relatedProduct = _service.getProductRelated(id, pagingParameterModel.pageNumber, pagingParameterModel.pageSize);

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(relatedProduct.paginationMetadata));

            // Returing List of relate product Collections
            return relatedProduct.data;
        }

        // GET api/product/productID:int
        [Route("api/v1/product/{id:int}/image")]
        public string GetImageWithVariable(int id, [FromUri]List<int> variables)
        {
            return _service.getImageWithVariable(id, variables);
        }
    }
}
