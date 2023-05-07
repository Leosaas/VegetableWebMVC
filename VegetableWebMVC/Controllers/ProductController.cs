using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using VegetableWebMVC.Models;

namespace VegetableWebMVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService productService;
		private readonly IUnitService unitService;
		readonly IMapper mapper;

		public ProductController(IProductService productService,IUnitService unitService, IMapper mapper)
		{
			this.unitService = unitService;
			this.productService = productService;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{
			List<ProductViewModel> lst = new List<ProductViewModel>();
			foreach(Product pro in productService.GetProducts())
			{
				ProductViewModel temp = mapper.Map<ProductViewModel>(pro);
				if(temp.unID != 0)
				{
					Unit u = unitService.GetUnit(temp.unID);
					temp.unName = u.unName;
				}
				lst.Add(temp);
			}
			return View(lst);
		}
		public IActionResult AddOrEdit(int id = 0)
		{
			ProductViewModel data = new ProductViewModel();
			ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI RAU CỦ" : "CẬP NHẬT RAU CỦ";

			if (id != 0)
			{
				Product res = productService.GetProduct(id);
				data = mapper.Map<ProductViewModel>(res);
				if (data == null)
				{
					return NotFound();
				}
			}
			data.Units = unitService.GetUnits();
			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrEdit(int id, ProductViewModel data)
		{
			ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI RAU CỦ" : "CẬP NHẬT RAU CỦ";

			if (ModelState.IsValid)
			{
				try
				{
					Product res = mapper.Map<Product>(data);
					if (id != 0)
					{
						productService.UpdateProduct(res);
					}
					else
					{

						productService.InsertProduct(res);

					}
				}
				catch (DbUpdateConcurrencyException)
				{
					return NotFound();
				}

				return RedirectToAction("Index", "Product");
			}
            data.Units = unitService.GetUnits();
            return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			Product res = productService.GetProduct(id);
			productService.DeleteProduct(res);

			return RedirectToAction("Index", "Product");
		}
	}
}
