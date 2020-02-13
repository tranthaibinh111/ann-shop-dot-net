using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Services
{
    public class Service<T> where T : new()
    {
        protected static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }

        public string imageURL
        {
            get
            {
                return String.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority);
            }
        }

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