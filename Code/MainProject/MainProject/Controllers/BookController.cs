using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MainProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.Controllers
{
    [Authorize(Roles = "Admin, Manager, Member")]
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

            //xac dinh xem co ai doc cuon sach nay chua
            var IsReaded = _Context.HistoryofRedingBook
                .Where(p => p.BookChappterID == chappterID).ToList();

            //Xac dinh xem user nay da co doc cuon sach nay chua
            var oldHistory = _Context.HistoryofRedingBook
                .Where(p => p.BookChappterID == chappterID && 
                p.ApplicationUserID == user.Id).FirstOrDefault();
            if (oldHistory == null)
            {
                _Context.Add(new HistoryofRedingBook { BookChappterID = chappterID, DateTime = DateTime.Now, ApplicationUserID = user.Id });
                
                // cong diem x2 neu la nguoi doc dau tien
                if (!IsReaded.Any())
                    user.Score += 2;
                else
                    user.Score += 1;
                _Context.Update(user);
            }

            // tang luot doc sach khi click
            var applicationDbcontext = _Context.BookChappter.Include(p => p.CategoryID).Where(p => p.Slug == slugCh);
            BookChappter book = await applicationDbcontext.FirstAsync();
            book.View++;
            _Context.Update(book);

            //thong bao da doc cuon sach nay
            _Context.Add(new Notifications { DateTime = DateTime.Now, IsReaded = true, BookChappterID = book.BookCategoryID, ApplicationUserID = user.Id });
            await _Context.SaveChangesAsync();
            return View(book);
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}