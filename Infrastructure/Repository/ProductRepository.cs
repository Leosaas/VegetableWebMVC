using Infrastructure.EF;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public interface IProductRepository : IRepository<Product>
	{

	}
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(EXDbContext context) : base(context)
		{
		}
	}
}
