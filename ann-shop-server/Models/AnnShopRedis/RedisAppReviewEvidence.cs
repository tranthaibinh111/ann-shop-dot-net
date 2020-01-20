using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class RedisAppReviewEvidence
    {
        public string userPhone { get; set; }
        public string imageBase64 { get; set; }
        public string status { get; set; }
        public string staff { get; set; }
        public Nullable<DateTime> approvalDate { get; set; }
        public DateTime createdDate { get; set; }
    }
}