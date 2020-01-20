using ann_shop_server.Models;
using ann_shop_server.Services;
using ann_shop_server.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [Authorize]
    [RoutePrefix("api/flutter/user")]
    public class FlutterUserController : ApiController
    {
        private FlutterUserService _service;

        public FlutterUserController()
        {
            _service = FlutterUserService.Instance;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IHttpActionResult login(UserRegisterModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TokenModel token;
            FlutterUserModel userLogin;

            try
            {
                userLogin = _service.getUser(user);

                if (userLogin == null)
                    throw new Exception("Số điện thoại hoặc mật khẩu không đúng");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ann-shop-server.com/Token");
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string data = String.Empty;

                    data += String.Format("username={0}&", HttpUtility.UrlEncode(user.phone));
                    data += String.Format("password={0}&", HttpUtility.UrlEncode(user.password));
                    data += "grant_type=password";

                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    token = JsonConvert.DeserializeObject<TokenModel>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (token != null && userLogin != null)
                return Ok(new { token = token, user = userLogin });
            else
                return BadRequest("Đăng nhập thất bại");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("confirm-otp")]
        public IHttpActionResult confirmOTP(ConfirmOTPModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userNew = _service.confirmOTP(data);

                return Ok<FlutterUserModel>(userNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create-password")]
        public IHttpActionResult createPassword(FlutterCreatePasswordModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var password = _service.createdPassword(data);

                return login(new UserRegisterModel() { phone = data.phone, password = password });
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
                return Ok<FlutterUserModel>(_service.updateInfo(info));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("change-password")]
        public IHttpActionResult changePassword(string passwordNew)
        {
            try
            {
                var phone = _service.getPhoneByToken(this);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(new { password = _service.changePassword(phone, passwordNew) });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("check")]
        public IHttpActionResult checkUser(string phone)
        {
            var message = String.Empty;

            if (!Phone.isNumberMobilePhone(phone, out message))
                throw new Exception(message);

            try
            {
                var exists = _service.checkUser(phone);

                return Ok(new { exists = exists });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPatch]
        [Route("password-new-by-birthday")]
        public IHttpActionResult passwordNewByBirthday(FlutterPasswordNewBirthdayModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(new { password = _service.passwordNewByBirthday(data) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
