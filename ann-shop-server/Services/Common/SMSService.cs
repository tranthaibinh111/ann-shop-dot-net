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
    public class SMSService: Service<SMSService>
    {
        private const string VMGBRAND = "ann.com.vn";
        private const string VMGACCOUNT = "hkdann";
        private const string VMGPASSWORD = "Vmg@123456";

        public bool bulkSendSms(string phone, string message, out string error)
        {
            error = String.Empty;

            if (!Phone.isNumberMobilePhone(phone, out error))
                return false;

            if (String.IsNullOrEmpty(message))
            {
                error = "Nội dung tin nhắn rỗng";
                return false;
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://brandsms.vn:8018/vmgApi");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    cmdCode = "BulkSendSms",
                    alias = VMGBRAND,
                    message = message,
                    sendTime = String.Empty,
                    authenticateUser = VMGACCOUNT,
                    authenticatePass = VMGPASSWORD,
                    msisdn = phone
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = JsonConvert.DeserializeObject<RespondOTPModel>(streamReader.ReadToEnd());

                if (result == null)
                {
                    error = "Đã có lỗi trong quá trính convert giá trị JSON API SMS trả về";
                    return false;
                }

                if (result.error_code == 0)
                    error = String.Empty;
                else if (result.error_code == -1)
                   error = "Nội dung tin nhắn có chứa ký tự unicode";
                else if (result.error_code == -2)
                   error = "Lỗi hệ thống VMG";
                else if (result.error_code == 100)
                   error = "Xác thực tài khoản VMG không thành công";
                else if (result.error_code == 101)
                   error = "Tài khoản VMG bị deactived";
                else if (result.error_code == 102)
                   error = "Tài khoản VMG bị hết hạn";
                else if (result.error_code == 103)
                   error = "Tài khoản VMG bị khóa";
                else if (result.error_code == 104)
                   error = "Template chưa được kích hoạt";
                else if (result.error_code == 105)
                   error = "Template chưa tồn tại";
                else if (result.error_code == 106)
                   error = "List user is empty";
                else if (result.error_code == 107)
                   error = "List user is full";
                else if (result.error_code == 108)
                   error = "Số điện thoại nhận tin nằm trong danh sách từ chối nhận tin(black list)";
                else if (result.error_code == 109)
                   error = "Processed (ads message only)";
                else if (result.error_code == 110)
                   error = "Thời gian gửi tin không hợp lệ";
                else if (result.error_code == 111)
                   error = "ProgExisted";
                else if (result.error_code == 112)
                   error = "Nội dung tin nhắn không hợp lệ";
                else if (result.error_code == 304)
                   error = "Send the same content in short time";
                else if (result.error_code == 400)
                   error = "Không thể trừ tiền";
                else if (result.error_code == 801)
                   error = "ParamsInvalid";
                else if (result.error_code == 802)
                   error = "Can Not Identify Method";
                else if (result.error_code == 900)
                   error = "Lỗi lưu tin nhắn vào CSDL";
                else if (result.error_code == 901)
                   error = "Độ dài tin nhắn vượt quá 612(Viettel: 480) với ký tự thường và 355 ký tự unicode";
                else if (result.error_code == 902)
                   error = "Số điện thoại không đúng";
                else if (result.error_code == 904)
                   error = "BrandName chưa được khai báo";
                else if (result.error_code == 905)
                   error = "Nội dung không hợp lệ (gửi tin đầu số dài)";
                else
                   error = "Đã có vấn đề lỗi trong post API SMS";
            }

            if (String.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }
    }
}