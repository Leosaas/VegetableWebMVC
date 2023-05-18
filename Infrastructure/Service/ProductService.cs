using Infrastructure.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
	public interface IProductService
	{
		IQueryable<Product> GetProducts();
		Product GetProduct(int id);
		void DeleteProduct(Product product);
		void UpdateProduct(Product product);
		void InsertProduct(Product product);
    }
	public class ProductService : IProductService
	{
		private IProductRepository repo;

		public ProductService(IProductRepository repo)
		{
			this.repo = repo;
		}

		public void DeleteProduct(Product product)
		{
			repo.Delete(product);
		}

		public Product GetProduct(int id)
		{
            return repo.GetById(id);
		}

		public IQueryable<Product> GetProducts()
		{
			return repo.GetAll();
		}

		public void InsertProduct(Product product)
		{
			repo.Insert(product);
		}

		public void UpdateProduct(Product product)
		{
			repo.Update(product);
		}
	}
}
