using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ann_shop_redis : RedisClient
    {
        public ann_shop_redis(string host = "127.0.0.1", int port = 6379) : base(host, port) { }
    }
}