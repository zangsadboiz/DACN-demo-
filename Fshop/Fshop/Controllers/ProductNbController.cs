using Microsoft.AspNetCore.Mvc;

namespace Fshop.Controllers
{
    public class ProductNbController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
