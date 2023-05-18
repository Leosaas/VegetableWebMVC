using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VegetableWebMVC.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }

        [DisplayName("Tên hiển thị")]
        public string displayname { get; set; }
        [DisplayName("Địa chỉ")]
        public string address { get; set; }
        public byte[] image { get; set; }
        public string ImageByBase64 { get; set; }
       
    }
}
