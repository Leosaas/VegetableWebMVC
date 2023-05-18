using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
	[Table("wsUser")]
	public class User
    {
		[Key]
		public string username { get; set; }
		public string displayname { get; set; }
		public string address { get; set; }
		public byte[] image { get; set; }
	}
}
