using Microsoft.AspNetCore.Mvc;

namespace Fshop.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
