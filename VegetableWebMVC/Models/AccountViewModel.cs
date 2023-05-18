using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VegetableWebMVC.Models
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
        }

        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }

        [DisplayName("Mật khẩu")]
        public string password { get; set; }
        [DisplayName("Loại tài khoản")]
        [DefaultValue(0)]
        public int type { get; set; }
        public UserViewModel User { get; set; }
       
    }
}
