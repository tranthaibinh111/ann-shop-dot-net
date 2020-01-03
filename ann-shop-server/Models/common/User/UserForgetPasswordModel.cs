using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class UserPhoneModel
    {
        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "phone must be mininum 10 charaters")]
        public string phone { get; set; }
    }
}