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
	public interface IUnitRepository : IRepository<Unit>
	{

	}
	public class UnitRepository : Repository<Unit>, IUnitRepository
	{
		public UnitRepository(EXDbContext context) : base(context)
		{
		}
	}
}
