using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace ann_shop_server.Controllers.Flutter
{
    [Authorize]
    [RoutePrefix("api/flutter/upload")]
    public class FlutterUploadController : ApiController
    {
        private TokenService _token;
        private RedisAppReviewEvidenceService _redisService;

        public FlutterUploadController()
        {
            _token = ANNFactoryService.getInstance<TokenService>();
            _redisService = ANNFactoryService.getInstance<RedisAppReviewEvidenceService>();
        }

        /// <summary>
        /// Lấy thông tin về việc user review
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("app-review-evidence")]
        public IHttpActionResult getAppReviewEvidence()
        {
            try
            {
                var phone = _token.getPhoneByToken(this);
                var evidence = _redisService.get(phone);

                return Ok<RedisAppReviewEvidence>(evidence);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gửi bằng chứng về đánh giá app
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("app-review-evidence")]
        public IHttpActionResult postAppReviewEvidence(FlutterAppReviewEvidenceModel evidence)
        {
            try
            {
                var phone = _token.getPhoneByToken(this);
                var data = new RedisAppReviewEvidence()
                {
                    userPhone = phone,
                    imageBase64 = evidence.imageBase64,
                    status = "wait",
                    staff = null,
                    approvalDate = null,
                    createdDate = DateTime.Now
                };

                return Ok<RedisAppReviewEvidence>(_redisService.set(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Nhân viên xác thực về đánh giá của khác hàng
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Route("app-review-evidence")]
        public IHttpActionResult updateAppReviewEvidenceStatus(string status)
        {
            if (String.IsNullOrEmpty(status))
                return Ok<RedisAppReviewEvidence>(null);

            try
            {
                var phone = _token.getPhoneByToken(this);

                return Ok<RedisAppReviewEvidence>(_redisService.updateStatus(phone, status));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
