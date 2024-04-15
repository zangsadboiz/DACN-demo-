using Fshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly DataContext _context;

        public AboutController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            var mnList = _context.Abouts.OrderBy(m => m.FeaturesID).ToList();
            return View(mnList);

        }

        public IActionResult Create()
        {
            var mnList = (from m in _context.Abouts
                          select new SelectListItem()
                          {
                              Text = m.FeaturesTitle,
                              Value = m.FeaturesID.ToString(),
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

        public IActionResult Create(About mn)
        {
            //Validate dữ liệu xem dữ liệu nhập vào đúng k
            if (ModelState.IsValid)
            {
                _context.Abouts.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Abouts.Find(id);
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
            var deleab = _context.Abouts.Find(id);
            if (deleab == null)
            {
                return NotFound();
            }
            _context.Abouts.Remove(deleab);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return View();
			}
            
            var ab = _context.Abouts.Find(id);
			if (ab == null)
			{
				return View();
			}

			var abList = _context.Abouts
				.Select(m => new SelectListItem
				{
					Text = m.FeaturesTitle,
					Value = m.FeaturesID.ToString()
				})
				.ToList();

			abList.Insert(0, new SelectListItem
			{
				Text = "----Select----",
				Value = string.Empty
			});

			ViewBag.mnList = abList;

			return View(ab);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(About ab)
		{
			if (ModelState.IsValid)
			{
				_context.Abouts.Update(ab);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.mnList = _context.Abouts
				.Select(m => new SelectListItem
				{
					Text = m.FeaturesTitle,
					Value = m.FeaturesID.ToString()
				})
				.ToList();

			return View(ab);
		}
	}
}



