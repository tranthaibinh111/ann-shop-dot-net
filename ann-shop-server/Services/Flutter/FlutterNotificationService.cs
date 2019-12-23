using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterNotificationService: Service<FlutterNotificationService>
    {
        public string getHomeNotification()
        {
            return "<img alt='Thông báo thời gian làm việc mùa tết' src='https://khohangsiann.com/wp-content/uploads/thoi-gian-lam-viec-tet-small.png'>";
        }
    }
}