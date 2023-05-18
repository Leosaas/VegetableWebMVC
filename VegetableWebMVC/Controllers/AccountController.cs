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
	public class AccountController : Controller
	{
		private readonly ICategoryService categoryService;
		readonly IMapper mapper;

		public AccountController(ICategoryService categoryService, IMapper mapper)
		{
			this.categoryService = categoryService;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{	
			return View(categoryService.GetCategories());
		}
		public IActionResult AddOrEdit(int id = 0)
		{
			CategoryViewModel data = new CategoryViewModel();
			ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI THỂ LOẠI" : "CẬP NHẬT THỂ LOẠI";

			if (id != 0)
			{
				Category res = categoryService.GetCategory(id);
				data = mapper.Map<CategoryViewModel>(res);
				if (data == null)
				{
					return NotFound();
				}
			}

			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrEdit(int id, CategoryViewModel data)
		{
			ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI THỂ LOẠI" : "CẬP NHẬT THỂ LOẠI";

			if (ModelState.IsValid)
			{
				try
				{
					Category res = mapper.Map<Category>(data);
					if (id != 0)
					{
						categoryService.UpdateCategory(res);
					}
					else
					{

						categoryService.InsertCategory(res);
					}
				}
				catch (DbUpdateConcurrencyException)
				{
					return NotFound();
				}

				return RedirectToAction("Index", "Category");
			}

			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			Category res = categoryService.GetCategory(id);
			categoryService.DeleteCategory(res);

			return RedirectToAction("Index", "Category");
		}
	}
}
