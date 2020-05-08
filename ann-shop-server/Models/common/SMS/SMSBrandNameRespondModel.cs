using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class SMSBrandNameRespondModel
    {
        public SMSBrandNameSendMessageModel sendMessage {get; set;}
        public int msgLength {get; set;}
        public int mtCount {get; set;}
        public string account {get; set;}
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string referentId { get; set; }
    }
}