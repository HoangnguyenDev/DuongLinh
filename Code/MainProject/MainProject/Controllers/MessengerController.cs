using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainProject.Models;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.Controllers
{
    [Authorize(Roles = "Admin, Manager, Member")]
    public class MessengerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessengerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<PartialViewResult> Index()
        {
            return PartialView(await _context.Message.Include(p => p.User).ToListAsync());
        }
        [HttpPost]
        [Route("sendMessaging")]
        public async Task<IActionResult> Submit(string content)
        {
            if (content != null)
            {
                var user = await GetCurrentUserAsync();
                _context.Add(new Message { ApplicationUserID = user.Id, Content = content, DateTime = DateTime.Now });
                await _context.SaveChangesAsync();
                return PartialView("Index");
            }
            //await _context.SaveChangesAsync();
            return Json("error");
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}