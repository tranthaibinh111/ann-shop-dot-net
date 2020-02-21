using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public sealed class NotificationKind
    {
        public static string Promotion { get { return "promotion"; } }
        public static string Notification { get { return "notification"; } }
        public static string News { get { return "news"; } }
    }
}