using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class SendIntroApp
    {
        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Số điện thoại tối thiểu 10 số")]
        public string phone { get; set; }
    }
}