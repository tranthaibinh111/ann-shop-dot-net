using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    public class ProductCategoryController : ApiController
    {
        private ProductCategoryService _service;

        public ProductCategoryController()
        {
            _service = ProductCategoryService.Instance;
        }

        // GET api/product/productID:int
        [Route("api/v1/product-category/{*slug}")]
        public ProductCategoryPageModel Get(string slug)
        {
            return _service.getProductCategoryDetail(slug);
        }

    }
}
