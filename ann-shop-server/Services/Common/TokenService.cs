using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Services
{
    public class TokenService: IANNService
    {
        public string getPhoneByToken(ApiController controller)
        {
            var identity = (ClaimsIdentity)controller.User.Identity;
            var phone = identity.Claims.FirstOrDefault(x => x.Type == "Phone").Value;

            if (!String.IsNullOrEmpty(phone))
                return phone;
            else
                throw new Exception("Không tìm thấy số điện thoại trong token");
        }
    }
}