using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Utils
{
    public class Phone
    {
        public static bool isNumberMobilePhone(string phone, out string message)
        {
            message = String.Empty;

            if (String.IsNullOrEmpty(phone) || phone.Length < 10)
            {
                message = "Số điện thoại tối thiểu 10 số";
                return false;
            }

            return true;
        }
    }
}