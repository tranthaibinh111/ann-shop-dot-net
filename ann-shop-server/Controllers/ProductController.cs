﻿using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult Get([FromUri]PagingParameterModel pagingParameterModel, string category = "", string search = "", string sort = "")
        {
            var productPage = _service.getProducts(category, pagingParameterModel.pageNumber, pagingParameterModel.pageSize, search, sort);
            if (productPage != null)
            {
                // Setting Header
                HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
                HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(productPage.paginationMetadata));

                // Returing List of product Collections
                return Ok<List<ProductModel>>(productPage.data);
            }
            else
            {
                return NotFound();
            }
        }

        // Put api/product/id for webpublic
        [Route("api/v1/product/{id:int}/webpublic")]
        [HttpPatch]
        public HttpResponseMessage PutWebPublich(int id)
        {
            var result = this._service.updateWebPublich(id);

            if (result == true)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        // Put api/product/id for webpublic
        [Route("api/v1/product/{id:int}/webupdate")]
        [HttpPatch]
        public HttpResponseMessage PutWebUpdate(int id)
        {
            var result = this._service.updateWebUpdate(id);

            if (result == true)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        // GET api/product
        [Route("api/v1/product/sort")]
        public List<ProductSortModel> GetProductSort()
        {
            return _service.getProductSort();
        }

        // GET api/product/slug
        [Route("api/v1/product/{*slug}")]
        public IHttpActionResult Get(string slug)
        {
            var prod = _service.getProductDetail(slug);

            if (prod != null)
            {
                return Ok<ProductDetailPageModel>(prod);
            }
            else
            {
                return NotFound();
            }
        }

        // Get api/product/productID:int/related
        [Route("api/v1/product/{id:int}/related")]
        public IHttpActionResult GetProductRelated(int id, [FromUri]PagingParameterModel pagingParameterModel)
        {
            var relatedProduct = _service.getProductRelated(id, pagingParameterModel.pageNumber, pagingParameterModel.pageSize);

            if (relatedProduct.data.Count > 0)
            {
                // Setting Header
                HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
                HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(relatedProduct.paginationMetadata));

                // Returing List of relate product Collections
                return Ok<List<ProductVariableModel>>(relatedProduct.data);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/product/productID:int
        [Route("api/v1/product/{id:int}/image")]
        public string GetImageWithVariable(int id, [FromUri]List<int> variables)
        {
            return _service.getImageWithVariable(id, variables);
        }
    }
}
