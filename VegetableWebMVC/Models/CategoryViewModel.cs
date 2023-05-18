using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VegetableWebMVC.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
        }

        [DisplayName("ID")]
        public int cID { get; set; }

        [DisplayName("Tên thể loại")]
        [MaxLength(125, ErrorMessage = "Tên không quá 125 ký tự.")]
        public string cName { get; set; }
        [DefaultValue(true)]
        public bool cActive { get; set; }
       
    }
}
