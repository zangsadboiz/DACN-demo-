using Microsoft.AspNetCore.Mvc;

namespace Fshop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
