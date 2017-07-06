using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MainProject.Models;

namespace MainProject.Controllers
{
    public class BookController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _Context;
        
        public BookController(ApplicationDbContext Context, UserManager<ApplicationUser> userManager)
        {
            _Context = Context;
            _userManager = userManager;
        }
        [Route("{slugCa}/{slugCh}")]
        public async Task<IActionResult> Index(string slugCa, string slugCh)
        {
            var user = await GetCurrentUserAsync();
            var chappter = _Context.BookChappter.Where(p => p.Slug == slugCh).FirstOrDefault();
            int chappterID = chappter.ID;
            int categoryID = chappter.BookCategoryID;

            //Xac dinh xem da co doc cuon sach nay chua
            var oldHistory = _Context.HistoryofRedingBook
                .Where(p => p.BookChappterID == chappterID && 
                p.ApplicationUserID == user.Id).FirstOrDefault();
            if (oldHistory == null)
            {
                _Context.Add(new HistoryofRedingBook { BookChappterID = chappterID, DateTime = DateTime.Now, ApplicationUserID = user.Id });
                await _Context.SaveChangesAsync();
                user.Score += 1;
                _Context.Update(user);
                await _Context.SaveChangesAsync();
            }
            var applicationDbcontext = _Context.BookChappter.Include(p => p.CategoryID).Where(p => p.Slug == slugCh);

            return View(await applicationDbcontext.FirstAsync());
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}