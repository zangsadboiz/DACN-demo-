﻿using Microsoft.AspNetCore.Mvc;

namespace Fshop.Controllers
{
	public class BlogNbController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
