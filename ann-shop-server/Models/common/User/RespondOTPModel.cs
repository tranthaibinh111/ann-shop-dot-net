using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class RespondOTPModel
    {
        public int error_code { get; set; }
        public string error_detail { get; set; }
        public Int64 messageId { get; set; }
        public Nullable<Int64> requestId { get; set; }
    }
}