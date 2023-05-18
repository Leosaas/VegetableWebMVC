using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using VegetableWebMVC.Models;

namespace VegetableWebMVC.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService userService;
		private readonly IAccountService accountService;
		readonly IMapper mapper;

		public UserController(IUserService userService,IAccountService accountService, IMapper mapper)
		{
			this.userService = userService;
			this.mapper = mapper;
			this.accountService = accountService;
			
		}

		public IActionResult Index()
		{	
			return View(userService.GetAll());
		}
		public IActionResult AddOrEdit(string username = null) //route mặc định là id nên không đổi tên biến của hàm get được
		{
			UserViewModel data = new UserViewModel();
			ViewBag.RenderedHtmlTitle = string.IsNullOrEmpty(username)  ? "THÊM MỚI NGƯỜI DÙNG" : "CẬP NHẬT NGƯỜI DÙNG";

			if (!string.IsNullOrEmpty(username))
			{
				User res = userService.GetByUsername(username);
				data = mapper.Map<UserViewModel>(res);
				if (data == null)
				{
					return NotFound();
				}
			}

			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrEdit(string username, UserViewModel data)
		{
			User user = userService.GetByUsername(username);
			ViewBag.RenderedHtmlTitle = user == null ? "THÊM MỚI NGƯỜI DÙNG" : "CẬP NHẬT NGƯỜI DÙNG";

			if (ModelState.IsValid)
			{
				try
				{
					IFormFile image = Request.Form.Files["ImageData"];
					if (image != null)
					{
						using (var memoryStream = new MemoryStream())
						{
							Stream stream = image.OpenReadStream();
							stream.CopyTo(memoryStream);
							data.image = memoryStream.ToArray();
						}
					}



					User res = mapper.Map<User>(data);
					if (user != null)
					{
						if (image == null && data.ImageByBase64 != null)
						{
							//	byte[] dbImage = productService.GetProduct(id).pImage;
							byte[] dbImage = Convert.FromBase64String(data.ImageByBase64);
							res.image = dbImage;
						}

						userService.Update(res);
					}
					else
					{
						Account account = new Account();
						account.username = data.username;
						account.password = "";
						account.type = 0;
						accountService.Insert(account);
						userService.Insert(res);

					}
				}
				catch (DbUpdateConcurrencyException)
				{
					return NotFound();
				}
                return RedirectToAction("Index", "User");
            }
			return View(data);
			
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(string username)
		{
			User res = userService.GetByUsername(username);
            userService.Delete(res);

			return RedirectToAction("Index", "User");
		}
	}
}
