using ann_shop_server.Services.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [HttpGet]
        [Route("getProductOrdered")]
        public IHttpActionResult getProductOrdered(int orderType, string sku)
        {
            var products = _service.getProductOrdered(orderType, sku);
            return Ok(products);
        }
    }
}
