using Fshop.Areas.Admin.Models;
using Fshop.Models;
using Fshop.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private readonly DataContext _context;

        public AdminUserController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.AdminUsers.OrderBy(m => m.UserID).ToList();
            return View(mnList);

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.AdminUsers.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        // 
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleMn = _context.AdminUsers.Find(id);
            if (deleMn == null)
            {
                return NotFound();
            }
            _context.AdminUsers.Remove(deleMn);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var mnList = (from m in _context.AdminUsers
                          select new SelectListItem()
                          {
                              Text = m.UserName,
                              Value = m.UserID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
        }
        // xử lý dữ liệu khi người dùng gửi lên 1 request bằng phương thức post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(AdminUser mn)
        {
            //Validate dữ liệu xem dữ liệu nhập vào đúng k
            if (ModelState.IsValid)
            {
                // kiểm tra sự tồn tại của email trong CSDL
                var check = _context.AdminUsers.FirstOrDefault(m => m.Email == mn.Email);
                if (check != null)
                {
                    // Hiển thị thông báo, có thể làm cách khác
                    Functions._MessageEmail = "Email trùng lặp!";
                    return RedirectToAction("Index", "AdminUser");
                }
                Functions._MessageEmail = string.Empty;
                mn.Password = Functions.MD5Password(mn.Password);
                _context.Add(mn);
                _context.SaveChanges();
            }
            return View(mn);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }

            var au = _context.AdminUsers.Find(id);
            if (au == null)
            {
                return View();
            }

            var auList = _context.AdminUsers
                .Select(m => new SelectListItem
                {
                    Text = m.UserName,
                    Value = m.UserID.ToString()
                })
                .ToList();

            auList.Insert(0, new SelectListItem
            {
                Text = "----Select----",
                Value = string.Empty
            });

            ViewBag.mnList = auList;

            return View(au);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AdminUser au)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem mật khẩu mới đã được nhập
                if (!string.IsNullOrWhiteSpace(au.Password))
                {
                    // Mã hóa mật khẩu mới
                    au.Password = Functions.MD5Password(au.Password);
                }
                else
                {
                    // Giữ nguyên mật khẩu hiện tại nếu không có mật khẩu mới được cung cấp
                    var existingUser = _context.AdminUsers.FirstOrDefault(u => u.UserID == au.UserID);
                    if (existingUser != null)
                    {
                        au.Password = existingUser.Password;
                    }
                }
                var check = _context.AdminUsers.FirstOrDefault(m => m.Email == au.Email);
                if (check != null)
                {
                    // Hiển thị thông báo, có thể làm cách khác
                    Functions._MessageEmail = "Email trùng lặp!";
                    return RedirectToAction("Index", "AdminUser");
                }
                // Cập nhật thông tin người dùng trong cơ sở dữ liệu
                _context.AdminUsers.Update(au);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.mnList = _context.AdminUsers
                .Select(m => new SelectListItem
                {
                    Text = m.UserName,
                    Value = m.UserID.ToString()
                })
                .ToList();

            return View(au);
        }


    }
}
