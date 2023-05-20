using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using VegetableWebMVC.Models;
using Microsoft.AspNetCore.Http;

namespace VegetableWebMVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService accountService;
		readonly IMapper mapper;

		public AccountController(IAccountService accountService, IMapper mapper)
		{
			this.accountService = accountService;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{	
			return View(accountService.GetAll());
		}
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Edit(string username = null)
		{
			AccountViewModel data = new AccountViewModel();
			ViewBag.RenderedHtmlTitle = "CẬP NHẬT TÀI KHOẢN";
				Account res = accountService.GetByUsername(username);
				data = mapper.Map<AccountViewModel>(res);
				if (data == null)
				{
					return NotFound();
				}
			

			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(AccountViewModel data)
		{
			ViewBag.RenderedHtmlTitle = "CẬP NHẬT TÀI KHOẢN";
			if (ModelState.IsValid)
			{
				try
				{
					Account res = mapper.Map<Account>(data);
					accountService.Update(res);

				}
				catch (DbUpdateConcurrencyException)
				{
					return NotFound();
				}

				return RedirectToAction("Index", "Account");
			}

			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ResetPassword(string username)
		{
			Account res = accountService.GetByUsername(username);
			res.password = "123";
			accountService.Update(res);

			return RedirectToAction("Index", "Account");
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountViewModel accountView)
		{
			Account account = accountService.VerifyAccount(accountView.username, accountView.password);
			// TempData["account"] = JsonConvert.SerializeObject(accountView); ;
			if (account == null)
			{
				return View(accountView);
			}
			HttpContext.Session.SetString("User", JsonConvert.SerializeObject(account));
            return RedirectToAction("Index", "Home");
		}
	}
}
