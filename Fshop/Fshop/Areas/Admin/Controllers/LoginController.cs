using Fshop.Areas.Admin.Models;
using Fshop.Models;
using Fshop.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Fshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
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
            var kt = _context.AdminUsers.FirstOrDefault(m => m.Email == user.Email && m.IsActive == false);
            if (kt != null)
            {
                // Hiển thị thông báo có thể làm cách khác
                Functions._Message = "Tài khoản bị vô hiệu hóa";
                return RedirectToAction("Index", "Login");
            }
            // Mã hóa mật khẩu trước khi kiểm tra
            string pw = Functions.MD5Password(user.Password);
            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                // Hiển thị thông báo có thể làm cách khác
                Functions._Message = "Sai tài khoản, vui lòng nhập lại";
                return RedirectToAction("Index", "Login");
            }
            // vào trang Admin nếu đúng Username và password
            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}
