using ann_shop_server.Models;
using ann_shop_server.Services;
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
    [RoutePrefix("api/flutter/user")]
    public class FlutterUserController : ApiController
    {
        private UserService _service;

        public FlutterUserController()
        {
            _service = UserService.Instance;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/flutter/sendSMS")]
        public IHttpActionResult register(SMSModel sms)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                WebClient w = new WebClient();
                string message = HttpUtility.UrlEncode(String.Format("OTP cua ban la: {0}. Ma se het han trong vong 1p", sms.otp));
                string brandname = HttpUtility.UrlEncode("ann.com.vn");
                string ret = w.DownloadString(String.Format(
                    "http://brandsms.vn:8018/VMGAPI.asmx/BulkSendSms?msisdn={0}&alias={1}&message={2}&sendTime=&authenticateUser={3}&authenticatePass={4}",
                    sms.phone,
                    brandname,
                    message,
                    "hkdann",
                    "@HoangAnh123"
                    ));

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IHttpActionResult register(UserRegisterModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok<User>(_service.register(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("update-info")]
        public IHttpActionResult updateInfo(UserInfoModel info)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok<User>(_service.updateInfo(info));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("change-password")]
        public IHttpActionResult changePassword(UserRegisterModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok<string>(_service.changePassword(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPatch]
        [Route("password-new")]
        public IHttpActionResult passwordNew(UserPhoneModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok<string>(_service.passwordNew(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
