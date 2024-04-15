using Fshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fshop.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			var ab = _context.Abouts.ToList();
			return View(ab);
		}
		[Route("/list-{slug}-{id:int}.html", Name = "List")]
		public IActionResult List(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var list = _context.Abouts.Where(m => (m.MenuID == id) && (m.IsActive == true)).Take(6).ToList();
			if (list == null)
			{
				return NotFound();
			}

			return View(list);
		}
		private readonly ILogger<HomeController> _logger;
		private readonly DataContext _context;

		public AboutController(ILogger<HomeController> logger, DataContext context)
		{
			_logger = logger;
			_context = context;
		}
	}
}
