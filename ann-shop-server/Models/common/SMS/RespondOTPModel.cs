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

    public class SMSBrandNameSendMessageModel {
        public string to {get; set;}
        public string telco {get; set;}
        public string orderCode {get; set;}
        public string packageCode {get; set;}
        public int type {get; set;}
        public string from {get; set;}
        public string message {get; set;}
        public string scheduled {get; set;}
        public string requestId {get; set;}
        public int useUnicode {get; set;}
        public object? ext {get; set;}
    }
}