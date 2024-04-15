using Fshop.Areas.Admin.Models;
using Fshop.Models;
using Fshop.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Fshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }

            // Kiểm tra xem trường Email có được điền không
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                ModelState.AddModelError("Email", "Vui lòng nhập địa chỉ email!");
                return View(user); // Trả về View với thông báo lỗi
            }

            // kiểm tra sự tồn tại của email trong CSDL
            var check = _context.AdminUsers.FirstOrDefault(m => m.Email == user.Email);
            if (check != null)
            {
                // Hiển thị thông báo, có thể làm cách khác
                Functions._MessageEmail = "Email trùng lặp!";
                return RedirectToAction("Index", "Register");
            }
            // nếu không có thì thêm vào CSDL
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }

    }
}
