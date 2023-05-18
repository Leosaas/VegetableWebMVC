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
		public DbSet<Product> products { get; set; }
		public DbSet<Unit> units { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<User> users { get; set; }
		public DbSet<Account> accounts { get; set; }
    }
}
