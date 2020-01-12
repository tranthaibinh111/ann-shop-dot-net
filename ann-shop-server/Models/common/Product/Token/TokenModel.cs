using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }
        [JsonProperty(".issued")]
        public DateTime issued { get; set; }
        [JsonProperty(".expires")]
        public DateTime expires { get; set; }
    }
}