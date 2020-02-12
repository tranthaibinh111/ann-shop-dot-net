using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ann_shop_server.Utils
{
    public class Phone
    {
        public static bool isNumberMobilePhone(string phone, out string message)
        {
            message = String.Empty;

            // Check giá trị số điện thoại truyền vào
            if (String.IsNullOrEmpty(phone))
            {
                message = "Số điện thoại đang rỗng";
                return false;
            }

            // Check độ dài số điện thoại
            phone = phone.Trim();
            if (phone.Length != 10)
            {
                message = "Số điện thoại phải 10 số";
                return false;
            }

            // Check đầu số điện thoại Việt Nam
            var phoneHeads = new List<string>
            {
                "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039", "089", "090", "093", "070",
                "079", "077", "076", "078", "088", "091", "094", "083", "084", "085", "081", "082", "092", "056", "058"
            };

            var phoneHead = phone.Substring(0, 3);
            var existphoneHead = phoneHeads.Where(x => x == phoneHead).Count() > 0;
            if (!existphoneHead)
            {
                message = String.Format("Đầu số {0} này không phải ở Việt Nam", phoneHead);
                return false;
            }

            return true;
        }
    }
}