using ann_shop_server.Models;
using ann_shop_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/sms")]
    public class SMSController : ApiController
    {

        private SMSService _service;

        public SMSController()
        {
            _service = ANNFactoryService.getInstance<SMSService>();
        }

        /// <summary>
        /// Dịch vụ gửi tin nhắn SMS Brand
        /// </summary>
        /// <param name="sms"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("otp")]
        public IHttpActionResult register(SendOTPModel sms)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var error = String.Empty;
            var message = String.Format("ANN.COM.VN - Ma OTP cua ban la: {0}. Ma se het han trong vong 5 phut. Cam on!", sms.otp);

            try
            {
                var result = _service.bulkSendSms(sms.phone, message, 0, out error);

                if (!result)
                    return BadRequest(error);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Dịch vụ gửi tin nhắn SMS Brand
        /// </summary>
        /// <param name="sms"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("intro-app")]
        public IHttpActionResult introApp(SendIntroApp sms)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var error = String.Empty;
            string[] messageRandom = {
                "Kho Sỉ ANN đã có ứng dụng điện thoại. Link tải app: http://bit.ly/sANN",
                "ANN.COM.VN đã có ứng dụng điện thoại xem sản phẩm: http://bit.ly/sANN",
                "Kho Hàng Sỉ ANN xin mời khách tải App xem sản phẩm: http://bit.ly/sANN",
                "ANN xin mời QKhách tải App điện thoại xem sản phẩm: http://bit.ly/sANN",
                "Kho Hàng Sỉ ANN xin mời tải ứng dụng điện thoại: http://bit.ly/sANN",
                "ANN đã có App điện thoại xem sản phẩm. Link tải: http://bit.ly/sANN",
                "Mời QKhách tải ứng dụng điện thoại của Kho Sỉ ANN: http://bit.ly/sANN",
                "Shop Sỉ ANN đã có App điện thoại. Link tải app: http://bit.ly/sANN",
                "Kho Hàng ANN đã có ứng dụng điện thoại. Link tải: http://bit.ly/sANN",
                "Kho Sỉ ANN xin mời khách tải App xem sản phẩm: http://bit.ly/sANN"
            };
            Random random = new Random();
            int rand = random.Next(0, messageRandom.Length);
            string message = messageRandom[rand];

            try
            {
                var result = _service.bulkSendSms(sms.phone, message, 1, out error);

                if (!result)
                    return BadRequest(error);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
