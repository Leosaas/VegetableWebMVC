using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
	[Table("wsAccount")]
	public class Account
    {
		[Key]
		public string username { get; set; }
		public string password { get; set; }
		public int type { get; set; }

	}
}
