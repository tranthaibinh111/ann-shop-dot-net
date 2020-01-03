using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class UserInfoModel
    {
        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "phone must be mininum 10 charaters")]
        public string phone { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public DateTime birthday { get; set; }
        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "gender must be mininum 1 charaters")]
        public string gender { get; set; }
        public string address { get; set; }
        [Required]
        public string city { get; set; }
    }
}