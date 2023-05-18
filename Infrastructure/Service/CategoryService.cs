using Infrastructure.Entities;
using Infrastructure.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
	public interface ICategoryService
    {
		IQueryable<Category> GetCategories();
		Category GetCategory(int id);
		void InsertCategory(Category category);
		void UpdateCategory(Category category);
		void DeleteCategory(Category category);
	}
	public class CategoryService : ICategoryService
    {
		private ICategoryRepository repo;

		public CategoryService(ICategoryRepository repo)
		{
			this.repo = repo;
		}

        public void DeleteCategory(Category category)
        {
            repo.Delete(category);
        }

        public IQueryable<Category> GetCategories()
        {
            return repo.GetAll();
        }

        public Category GetCategory(int id)
        {
            return repo.GetById(id);
        }

        public void InsertCategory(Category category)
        {
            repo.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            repo.Update(category);
        }
    }
}
