using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class UserRegisterModel
    {
        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "phone must be mininum 10 charaters")]
        public string phone { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "pass must be mininum 6 charaters")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}