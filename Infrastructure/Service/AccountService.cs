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
	public interface IAccountService
    {
		IQueryable<Account> GetAll();
		Account GetByUsername(string username);
		void Insert(Account account);
		void Update(Account account);
		void Delete(Account account);
        User GetUserByAccount(Account account);
	}
	public class AccountService : IAccountService
    {
        private IUserRepository userRepo;
        private IAccountRepository accountRepo;

		public AccountService(IUserRepository userRepo,IAccountRepository accountRepo)
		{
			this.userRepo = userRepo;
            this.accountRepo = accountRepo;
		}

        public void Delete(Account account)
        {
            accountRepo.Delete(account);
        }

        public IQueryable<Account> GetAll()
        {
            return accountRepo.GetAll();
        }

        public Account GetByUsername(string username)
        {
            return accountRepo.GetById(username);
        }

        public User GetUserByAccount(Account account)
        {
            return userRepo.GetById(account.username);
        }

        public void Insert(Account account)
        {
            accountRepo.Insert(account);
        }

        public void Update(Account account)
        {
            accountRepo.Update(account);
        }
    }
}
