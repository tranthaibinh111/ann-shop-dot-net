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
            _service = SMSService.Instance;
        }

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
                var result = _service.bulkSendSms(sms.phone, message, out error);

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
