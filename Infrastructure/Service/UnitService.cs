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
	public interface IUnitService
	{
		IQueryable<Unit> GetUnits();
		Unit GetUnit(int id);
		void InsertUnit(Unit unit);
		void UpdateUnit(Unit unit);
		void DeleteUnit(Unit unit);
	}
	public class UnitService : IUnitService
	{
		private IUnitRepository repo;

		public UnitService(IUnitRepository repo)
		{
			this.repo = repo;
		}

		public void DeleteUnit(Unit unit)
		{
			repo.Delete(unit);
		}

		public Unit GetUnit(int id)
		{
			return repo.GetById(id);
		}

		public IQueryable<Unit> GetUnits()
		{
			return repo.GetAll();
		}

		public void InsertUnit(Unit unit)
		{
			repo.Insert(unit);
		}

		public void UpdateUnit(Unit unit)
		{
			repo.Update(unit);
		}
	}
}
