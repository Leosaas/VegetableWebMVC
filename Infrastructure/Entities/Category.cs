using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
	[Table("wsCategory")]
	public class Category
    {
		[Key]
		public int cID { get; set; }
		public string cName { get; set; }
		public bool cActive { get; set; }

	}
}
