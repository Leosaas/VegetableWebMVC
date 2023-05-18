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
	public interface IUserService
	{
		IQueryable<User> GetAll();
		User GetByUsername(string username);
		void Insert(User user);
		void Update(User user);
		void Delete(User user);
	}
	public class UserService : IUserService
    {
		private IUserRepository repo;

		public UserService(IUserRepository repo)
		{
			this.repo = repo;
		}

        public void Delete(User user)
        {
            repo.Delete(user);
        }

        public IQueryable<User> GetAll()
        {
            return repo.GetAll();
        }

        public User GetByUsername(string username)
        {
            return repo.GetById(username);
        }

        public void Insert(User user)
        {
            repo.Insert(user);
        }

        public void Update(User user)
        {
            repo.Update(user);
        }
    }
}
