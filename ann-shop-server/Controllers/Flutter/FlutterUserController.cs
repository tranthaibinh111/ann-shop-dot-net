using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IHttpActionResult register(SendOTPModel sms)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://brandsms.vn:8018/vmgApi");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new {
                        cmdCode = "BulkSendSms",
                        alias = "ann.com.vn",
                        message = String.Format("OTP cua ban la: {0}. Ma se het han trong vong 1p", sms.otp),
                        sendTime = String.Empty,
                        authenticateUser = "hkdann",
                        authenticatePass = "Vmg@123456",
                        msisdn = sms.phone
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = JsonConvert.DeserializeObject<RespondOTPModel>(streamReader.ReadToEnd());

                    return Ok<RespondOTPModel>(result);
                }
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
