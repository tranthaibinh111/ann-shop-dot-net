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
