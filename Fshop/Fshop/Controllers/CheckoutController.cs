using Microsoft.AspNetCore.Mvc;

namespace Fshop.Controllers
{
	public class CheckoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
