using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using Infrastructure.Entities;

namespace VegetableWebMVC.Models
{
	public class ProductViewModel
	{

	
		[DisplayName("ID")]
		public int pID { get; set; }
		[DisplayName("Tên rau củ")]
		
		[MaxLength(125, ErrorMessage = "Tên không quá 125 ký tự.")]
        [Required(ErrorMessage = "Tên rau củ không được bỏ trống")]
        public string pName { get; set; }
		[DisplayName("Giá bán")]
		[Range(1000,999999,ErrorMessage = "Giá bán phải lớn hơn 1000")]
		public double pPrice { get; set; }
		[DisplayName("Số lượng tồn kho")]
		public int pStorageQuantity { get; set; }
		[DisplayName("Mã đơn vị tính")]
		public int cID { get; set; }
		[DisplayName("Đơn vị tính")]
		[Required]
		public int unID { get; set; }
		[DisplayName("Tên đơn vị tính")]
		[MaxLength(125, ErrorMessage = "Tên không quá 125 ký tự.")]
		public string unName { get; set; }
		[DefaultValue(true)]
		public bool pActive { get; set; }
		public byte[] pImage { get; set; }
		public string ImageByBase64 { get;  set; }
		public IEnumerable<Unit> Units { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
