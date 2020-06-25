using ann_shop_server.Models;
using ann_shop_server.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ann_shop_server.Services
{
    public class SMSService: IANNService
    {
        protected const string VMGBRAND = "ann.com.vn";
        protected const string SMSBRAND_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c24iOiJoa2Rhbm4iLCJzaWQiOiJmNzdlYTcyZC1iMzFhLTRkNzYtYjA5Ny03NjkxMTRiYjM3NDkiLCJvYnQiOiIiLCJvYmoiOiIiLCJuYmYiOjE1ODg4NDU5NDksImV4cCI6MTU4ODg0OTU0OSwiaWF0IjoxNTg4ODQ1OTQ5fQ.CQWgHqxBqgs1Ikq29DbqD2MQrDjrfCf0FDzcn8pyf4A";

        public bool bulkSendSms(string phone, string message, int unicode, out string error)
        {
            error = String.Empty;

            if (!Phone.isNumberMobilePhone(phone, out error))
                return false;

            if (String.IsNullOrEmpty(message))
            {
                error = "Nội dung tin nhắn rỗng";
                return false;
            }

            // Execute API
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.brandsms.vn:8018/api/SMSBrandname/SendSMS");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("token", SMSBRAND_TOKEN);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new SMSBrandNameSendMessageModel()
                {
                    to = "0" + phone.Substring(2),
                    type = 1, // Chăm sóc khách hàng
                    from = VMGBRAND,
                    message = message,
                    scheduled = String.Empty,
                    useUnicode = unicode // Gửi tin unicode
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = JsonConvert.DeserializeObject<SMSBrandNameRespondModel>(streamReader.ReadToEnd());

                if (result == null)
                {
                    error = "Đã có lỗi trong quá trính convert giá trị JSON API SMS trả về";
                    return false;
                }

                if (result.errorCode == "000")
                    error = String.Empty;
                else if (result.errorCode == "001")
                   error = "Có lỗi giá trị không phù hợp với kiểu dữ liệu mô tả";
                else if (result.errorCode == "002")
                   error = "Loại tin không hợp lệ";
                else if (result.errorCode == "003")
                   error = "Loại tin không được phép gửi";
                else if (result.errorCode == "005")
                   error = "Số điện thoại nhận không hợp lệ";
                else if (result.errorCode == "006")
                   error = "Mã nhà mạng không hợp lệ";
                else if (result.errorCode == "007")
                   error = "Nội dung chứa từ bị khóa";
                else if (result.errorCode == "008")
                   error = "Nội dung chứa ký tự unicode";
                else if (result.errorCode == "009")
                   error = "Nội dung có ký tự không hợp lệ";
                else if (result.errorCode == "010")
                   error = "Độ dài nội dung không hợp lệ";
                else if (result.errorCode == "011")
                   error = "Nội dung không khớp với mẫu khai";
                else if (result.errorCode == "012")
                   error = "Tài khoản không được phân gửi tới nhà mạng";
                else if (result.errorCode == "013")
                   error = "Số điện thoại nhận trong danh sách cấm gửi";
                else if (result.errorCode == "014")
                   error = "Tài khoản không đủ tiền để chi trả";
                else if (result.errorCode == "015")
                   error = "Tài khoảng không đủ tin để gửi";
                else if (result.errorCode == "016")
                   error = "Thời gian gửi tin không hợp lệ";
                else if (result.errorCode == "017")
                   error = "Mã order không hợp lệ";
                else if (result.errorCode == "018")
                   error = "Mã gói không hợp lệ";
                else if (result.errorCode == "019")
                   error = "Số điện thoại không hợp lệ";
                else if (result.errorCode == "020")
                   error = "Số điện thoại không trong danh sách nhà mạng được lọc";
                else if (result.errorCode == "021")
                   error = "Gửi vào thời điểm bị cấm gửi quảng cáo";
                else if (result.errorCode == "022")
                   error = "Định dạnh nội dung không hợp lệ";
                else if (result.errorCode == "100")
                   error = "Token không hợp lệ";
                else if (result.errorCode == "101")
                   error = "Tài khoản bị khóa";
                else if (result.errorCode == "102")
                   error = "Tài khoản không đúng";
                else if (result.errorCode == "304")
                   error = "Tin bị lặp trong 5 phút";
                else if (result.errorCode == "801")
                   error = "Mẫu tin chưa được thiết lập";
                else if (result.errorCode == "802")
                   error = "Tài khoản chưa được thiết lập profile";
                else if (result.errorCode == "803")
                   error = "Tài khoản chưa được thiết lập giá";
                else if (result.errorCode == "804")
                   error = "Đường gửi tin chưa được thiết lập";
                else if (result.errorCode == "805")
                   error = "Đường gửi tin không hỗ trợ unicode";
                else if (result.errorCode == "904")
                   error = "Brandname không hợp lệ";
                else if (result.errorCode == "999")
                   error = "Lỗi khác trên hệ thống";
                else
                   error = "Đã có vấn đề trong post API SMS BrandName";
            }

            if (String.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }
    }
}