using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var aplicationDbContext = _context.History.Include(b => b.ChappterID)
                .OrderBy(p => p.DateTime).Take(6);
            return View(await aplicationDbContext.ToListAsync());
        }
        [Route("{slug}")]
        public async Task<IActionResult> ListChappter(string slug)
        {

            var BookCategoryDbContext = _context.BookCategory.FirstOrDefault(p => p.Slug == slug);
            ViewData["BookName"] = BookCategoryDbContext.CategoryName;

            var applicationDbContext = _context.BookChappter.Include(b => b.CategoryID).Where(p => p.BookCategoryID == BookCategoryDbContext.ID);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ViewChappter()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
