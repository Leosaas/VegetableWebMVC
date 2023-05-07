using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using VegetableWebMVC.Models;

namespace VegetableWebMVC.Controllers
{
	public class UnitController : Controller
	{
		private readonly IUnitService unitService;
		readonly IMapper mapper;

		public UnitController(IUnitService unitService, IMapper mapper)
		{
			this.unitService = unitService;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{
			return View(unitService.GetUnits());
		}
		public IActionResult AddOrEdit(int id = 0)
		{
			UnitViewModel data = new UnitViewModel();
			ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

			if (id != 0)
			{
				Unit res = unitService.GetUnit(id);
				data = mapper.Map<UnitViewModel>(res);
				if (data == null)
				{
					return NotFound();
				}
			}

			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrEdit(int id, UnitViewModel data)
		{
			ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

			if (ModelState.IsValid)
			{
				try
				{
					Unit res = mapper.Map<Unit>(data);
					if (id != 0)
					{
						unitService.UpdateUnit(res);
					}
					else
					{

						unitService.InsertUnit(res);
					}
				}
				catch (DbUpdateConcurrencyException)
				{
					return NotFound();
				}

				return RedirectToAction("Index", "Unit");
			}

			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			Unit res = unitService.GetUnit(id);
			unitService.DeleteUnit(res);

			return RedirectToAction("Index", "Unit");
		}
	}
}
