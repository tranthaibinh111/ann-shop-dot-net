using ann_shop_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ann_shop_server.Controllers.Flutter
{
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
        [Route("~/api/flutter/home/notification")]
        public IHttpActionResult GetHomeBanners()
        {
            return Ok<string>(_service.getHomeNotification());
        }
    }
}
