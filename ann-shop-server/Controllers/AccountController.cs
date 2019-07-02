using System.Net.Http;
using System.Web.Http;
using ann_shop_server.Utils;
using System.Net;
using System;
using ann_shop_server.Models;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/v1/account")]
    public class AccountController : ApiController
    {
        // Put api/product/id for webpublic
        [Route("login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody]LoginModel login)
        {
            var security = Security.Encrypt("ann828327");

            var hmacsha256 = Security.Encrypt(login.password);

            if (security.Equals(hmacsha256))
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
