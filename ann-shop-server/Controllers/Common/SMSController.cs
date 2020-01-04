using ann_shop_server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/sms")]
    public class SMSController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("otp")]
        public HttpResponseMessage register(SendOTPModel sms)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://brandsms.vn:8018/vmgApi");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        cmdCode = "BulkSendSms",
                        alias = "ann.com.vn",
                        message = String.Format("OTP cua ban la: {0}. Ma se het han trong vong 1p", sms.otp),
                        sendTime = String.Empty,
                        authenticateUser = "hkdann",
                        authenticatePass = "Vmg@123456",
                        msisdn = sms.phone
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = JsonConvert.DeserializeObject<RespondOTPModel>(streamReader.ReadToEnd());

                    if (result != null)
                    {
                        if (result.error_code == 0)
                            return Request.CreateResponse(HttpStatusCode.NoContent);
                        else if (result.error_code == -1)
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Nội dung tin nhắn có chứa ký tự unicode");
                        else if (result.error_code == -2)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Lỗi hệ thống VMG");
                        else if (result.error_code == 100)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Xác thực tài khoản VMG không thành công");
                        else if (result.error_code == 101)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Tài khoản VMG bị deactived");
                        else if (result.error_code == 102)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Tài khoản VMG bị hết hạn");
                        else if (result.error_code == 103)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Tài khoản VMG bị khóa");
                        else if (result.error_code == 104)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Template chưa được kích hoạt");
                        else if (result.error_code == 105)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Template chưa tồn tại");
                        else if (result.error_code == 106)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "List user is empty");
                        else if (result.error_code == 107)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "List user is full");
                        else if (result.error_code == 108)
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Số điện thoại nhận tin nằm trong danh sách từ chối nhận tin(black list)");
                        else if (result.error_code == 109)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Processed (ads message only)");
                        else if (result.error_code == 110)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Thời gian gửi tin không hợp lệ");
                        else if (result.error_code == 111)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "ProgExisted");
                        else if (result.error_code == 112)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Nội dung tin nhắn không hợp lệ");
                        else if (result.error_code == 304)
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Send the same content in short time");
                        else if (result.error_code == 400)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Không thể trừ tiền");
                        else if (result.error_code == 801)
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "ParamsInvalid");
                        else if (result.error_code == 802)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can Not Identify Method");
                        else if (result.error_code == 900)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Lỗi lưu tin nhắn vào CSDL");
                        else if (result.error_code == 901)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Độ dài tin nhắn vượt quá 612(Viettel: 480) với ký tự thường và 355 ký tự unicode");
                        else if (result.error_code == 902)
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Số điện thoại không đúng");
                        else if (result.error_code == 904)
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "BrandName chưa được khai báo");
                        else if (result.error_code == 905)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Nội dung không hợp lệ (gửi tin đầu số dài)");
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Đã có vấn đề lỗi trong post API SMS");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Đã có lỗi trong quá trính convert giá trị JSON API SMS trả về");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
