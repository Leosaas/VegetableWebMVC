using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
	[Table("wsProduct")]
	public class Product
	{
		[Key]
		public int pID { get; set; }
		public string pName { get; set; }
		public float pPrice { get; set; }
		public int pStorageQuantity { get; set; }
		public int cID { get; set; }
		public int unID { get; set; }
	}
}
