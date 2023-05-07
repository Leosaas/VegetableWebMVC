using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VegetableWebMVC.Models
{
    public class UnitViewModel
	{
        public UnitViewModel()
        {
        }

        [DisplayName("ID")]
        public int unID { get; set; }

        [DisplayName("Tên đơn vị tính")]
        [MaxLength(125, ErrorMessage = "Tên không quá 125 ký tự.")]
        public string unName { get; set; }

       
    }
}
