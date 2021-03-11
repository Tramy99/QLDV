using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDV.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống"), MinLength(8), MaxLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}