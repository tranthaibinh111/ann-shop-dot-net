using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ann_shop_server.Utils
{
    public class ANNImage
    {
        public static string extractImage(string url)
        {
            var result = String.Empty;
            var rgx = new Regex(@"[a-z0-9_\-\.]+$");
            var match = rgx.Match(url);

            if (match.Success)
                result = match.Value;

            return result;
        }
    }
}