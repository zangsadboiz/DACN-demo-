using Microsoft.AspNetCore.Mvc;

namespace Fshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/file-manager")]

    public class FileManagerController : Controller
    {
        // hiển thị cái quản lý file
        public IActionResult Index()
        {
            return View();
        }
    }
}
