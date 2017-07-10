using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MainProject.Models;
using Microsoft.AspNetCore.Identity;

namespace MainProject.Controllers
{
    [Authorize(Roles = "Admin, Manager, Member")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public PartialViewResult Chatting()
        {
            return PartialView(new Message());
        }
        #pragma warning disable 1998
        public async Task<IActionResult> Index()
        {
            var HistoryofReading = _context.HistoryofRedingBook
                .Include(b => b.BookChappter);
            var HistoryofChappter = _context.HistoryOfChappter
                .Include(b => b.ChappterID)
                //.Include(b => b.ChappterID.CategoryID)
                .OrderBy(p => p.DateTime).Take(6);
            var Messenger = _context.Message
                .Include(p => p.User)
                .OrderBy(p => p.DateTime).Take(20);
            var Notifications = _context.Notifications
                .Include(p => p.User)
                .OrderBy(p => p.DateTime).Take(20);
            ViewData["HistoryofReading"] = await HistoryofReading.ToListAsync();
            ViewData["Notifications"] = await Notifications.ToListAsync();
            ViewData["Messenger"] = await Messenger.ToListAsync(); 
            ViewData["HistoryofChappter"] = await HistoryofChappter.ToListAsync();
            return View();
        }
        [Route("{slug}")]
        public async Task<IActionResult> ListChappter(string slug)
        {
            var HistoryofReading = _context.HistoryofRedingBook
               .Include(b => b.BookChappter);

            var Messenger = _context.Message
                .Include(p => p.User)
                .OrderBy(p => p.DateTime).Take(20);

            ViewData["HistoryofReading"] = await HistoryofReading.ToListAsync();
            ViewData["Messenger"] = await Messenger.ToListAsync();

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
