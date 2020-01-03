using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [Authorize]
    [RoutePrefix("api/flutter/notification")]
    public class FlutterNotificationController : ApiController
    {
        private FlutterNotificationService _service;

        public FlutterNotificationController()
        {
            _service = FlutterNotificationService.Instance;
        }

        /// <summary>
        /// Lấy thông báo dạng HTML cho trang Home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/home/notifications")]
        public IHttpActionResult GetHomeBanners()
        {
            return Ok<List<FlutterBannerModel>>(_service.getHomeNotification());
        }

        /// <summary>
        /// Lấy tất cả thông báo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/flutter/notifications")]
        public IHttpActionResult GetNotifications([FromUri]FlutterNotificationFilterModel filter, [FromUri] PagingParameterModel paging)
        {
            if (filter == null)
                filter = new FlutterNotificationFilterModel();

            if (paging == null)
                paging = new PagingParameterModel();

            var pagination = new PaginationMetadataModel()
            {
                currentPage = paging.pageNumber,
                pageSize = paging.pageSize
            };

            var notifications = _service.getNotifications(filter, ref pagination);

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "X-Paging-Headers");
            HttpContext.Current.Response.Headers.Add("X-Paging-Headers", JsonConvert.SerializeObject(pagination));

            return Ok<List<FlutterNotificationCardModel>>(notifications);
        }

        /// <summary>
        /// Lấy chi tiết thông báo theo slug
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{*slug}")]
        public IHttpActionResult GetNotificationBySlug(string slug)
        {
            return Ok<FlutterNotificationModel>(_service.getNotificationBySlug(slug));
        }
    }
}
