using ann_shop_server.Models;
using ann_shop_server.Services;
using ann_shop_server.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/v1/product")]
    public class AngularProductController : ApiController
    {
        private AngularProductService _service;

        public AngularProductController()
        {
            _service = ANNFactoryService.getInstance<AngularProductService>();
        }

        /// <summary>
        /// Lấy thông tin sản phẩm
        /// </summary>
        /// <param name="slug">slug của sản phẩm</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}")]
        public IHttpActionResult GetProductByCategory(string slug)
        {
            var prod = _service.getProductByCategory(slug);

            if (prod != null)
            {
                return Ok<ProductModel>(prod);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Lấy thông tin các sản phẩm con
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{slug}/related")]
        public IHttpActionResult GetProductRelatedBySlug(string slug, [FromUri]PagingParameterModel pagingParameterModel)
        {
            var pagination = new PaginationMetadataModel()
            {
                currentPage = pagingParameterModel.pageNumber,
                pageSize = pagingParameterModel.pageSize
            };

            var productrelateds = _service.getProductRelatedBySlug(slug, ref pagination);

            if (productrelateds.Count > 0)
            {
                // Setting Header
                HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
                HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

                // Returing List of relate product Collections
                return Ok<List<ProductRelatedModel>>(productrelateds);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Lấy avatar đại điện cho sản phẩm biến thể
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/image")]
        public string GetImageWithVariable(int id, int color, int size)
        {
            return _service.getImageWithVariable(id, color, size);
        }

        /// <summary>
        /// Lấy ra danh sách image cho việc download về làm quản cáo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/advertisement-image")]
        public IHttpActionResult GetAdvertisementImages(int id)
        {
            var images = _service.getAdvertisementImages(id);

            if (images != null && images.Count > 0)
                return Ok<List<string>>(images);
            else
                return NotFound();
        }
    }
}
