using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class ConfirmOTPModel
    {
        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Số điện thoại tối thiểu 10 số")]
        public string phone { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Mã OTP gồm 6 ký tự")]
        public string otp { get; set; }
    }
}