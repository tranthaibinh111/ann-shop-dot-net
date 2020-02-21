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
        public IHttpActionResult GetNotifications([FromUri] PagingParameterModel paging, string kind = "")
        {
            try
            {
                
                if (paging == null)
                    paging = new PagingParameterModel();

                var phone = _service.getPhoneByToken(this);
                var filter = new FlutterNotificationFilterModel()
                {
                    kind = kind,
                    categorySlug = String.Empty,
                    phone = phone
                };
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lấy chi tiết thông báo khuyến mãi theo slug
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("promotion/{*slug}")]
        public IHttpActionResult GetNotifyPromotionBySlug(string slug)
        {
            try
            {
                var phone = _service.getPhoneByToken(this);
                return Ok<FlutterNotificationModel>(_service.getNotifyPromotionBySlug(phone, slug));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lấy chi tiết thông báo hoạt động user theo slug
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{*slug}")]
        public IHttpActionResult GetNotifyUserBySlug(string slug)
        {
            try
            {
                var phone = _service.getPhoneByToken(this);
                return Ok<FlutterNotificationModel>(_service.getNotifyUserBySlug(phone, slug));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lấy chi tiết thông báo tin tức theo slug
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("news/{*slug}")]
        public IHttpActionResult GetNotifyNewsBySlug(string slug)
        {
            return Ok<FlutterNotificationModel>(_service.getNotifyNewsBySlug(slug));
        }
    }
}
