using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
	public class EXDbContext : DbContext
	{
		public EXDbContext(DbContextOptions<EXDbContext> options) : base(options) 
		{ 
		}
		public DbSet<User> user { get; set; }
		public DbSet<Product> products { get; set; }
		public DbSet<Unit> units { get; set; }
	}
}
