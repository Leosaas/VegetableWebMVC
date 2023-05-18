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
	public interface IAccountRepository : IRepository<Account>
	{

	}
	public class AccountRepository : Repository<Account>, IAccountRepository
	{
		public AccountRepository(EXDbContext context) : base(context)
		{
		}
	}
}
