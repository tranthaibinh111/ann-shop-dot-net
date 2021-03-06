﻿using ann_shop_server.Models;
using ann_shop_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ann_shop_server.Controllers.Flutter
{
    [Authorize]
    [RoutePrefix("api/flutter/coupon")]
    public class FlutterCouponController : ApiController
    {
        private TokenService _token;
        private FlutterCouponService _service;

        public FlutterCouponController()
        {
            _token = ANNFactoryService.getInstance<TokenService>();
            _service = ANNFactoryService.getInstance<FlutterCouponService>();
        }

        /// <summary>
        /// Lấy danh sách các chương trình khuyến mãi đang chạy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("promotions")]
        public IHttpActionResult getPromotions()
        {
            try
            {
                var phone = _token.getPhoneByToken(this);
                return Ok<List<FlutterPromotionModel>>(_service.getPromotions(phone));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lấy phiếu khuyến mãi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("customer")]
        public IHttpActionResult getCouponList()
        {
            try
            {
                var phone = _token.getPhoneByToken(this);
                return Ok<List<FlutterCouponModel>>(_service.getCustomerCoupon(phone));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lấy phiếu khuyến mãi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{code}")]
        public IHttpActionResult getCoupon(string code)
        {
            try
            {
                var phone = _token.getPhoneByToken(this);
                var message = String.Empty;
                var coupon = _service.getCoupon(code, phone, out message);

                if (coupon != null)
                    return Ok<FlutterCouponModel>(coupon);
                else
                    return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
