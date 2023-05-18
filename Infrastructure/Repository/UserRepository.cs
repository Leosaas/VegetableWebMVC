﻿using Infrastructure.EF;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public interface IUserRepository : IRepository<User>
	{

	}
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(EXDbContext context) : base(context)
		{
		}
	}
}
