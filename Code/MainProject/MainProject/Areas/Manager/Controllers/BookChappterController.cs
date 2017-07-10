using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MainProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Admin, Manager")]
    public class BookChappterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookChappterController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Manager/BookChappter
        [Route("quan-ly/chuong-sach/")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookChappter.Include(b => b.CategoryID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manager/BookChappter/Details/5
        [Route("quan-ly/chuong-sach/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookChappter = await _context.BookChappter
                .Include(b => b.CategoryID)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bookChappter == null)
            {
                return NotFound();
            }

            return View(bookChappter);
        }

        // GET: Manager/BookChappter/Create
        [Route("quan-ly/chuong-sach/tao")]
        public IActionResult Create()
        {
            ViewData["BookCategoryID"] = new SelectList(_context.BookCategory, "ID", "CategoryName");
            return View();
        }

        // POST: Manager/BookChappter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("quan-ly/chuong-sach/tao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Content,BookCategoryID,Slug")] BookChappter bookChappter)
        {
            if (ModelState.IsValid)
            {

                bookChappter.View = 0;
                _context.Add(bookChappter);
                _context.HistoryOfChappter.AddRange(new HistoryOfChappter {DateTime = DateTime.Now,BookChappterID= bookChappter.ID });
                var  user = await GetCurrentUserAsync();
                _context.Notifications.AddRange(new Notifications { DateTime = DateTime.Now, BookChappterID = bookChappter.ID ,  ApplicationUserID = user.Id, IsChapter=true});
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BookCategoryID"] = new SelectList(_context.BookCategory, "ID", "CategoryName", bookChappter.BookCategoryID);
            return View(bookChappter);
        }

        // GET: Manager/BookChappter/Edit/5
        [Route("quan-ly/chuong-sach/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookChappter = await _context.BookChappter.SingleOrDefaultAsync(m => m.ID == id);
            if (bookChappter == null)
            {
                return NotFound();
            }
            ViewData["BookCategoryID"] = new SelectList(_context.BookCategory, "ID", "CategoryName", bookChappter.BookCategoryID);
            return View(bookChappter);
        }

        // POST: Manager/BookChappter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("quan-ly/chuong-sach/chinh-sua/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Content,BookCategoryID,Slug")] BookChappter bookChappter)
        {
            if (id != bookChappter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookChappter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookChappterExists(bookChappter.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["BookCategoryID"] = new SelectList(_context.BookCategory, "ID", "CategoryName", bookChappter.BookCategoryID);
            return View(bookChappter);
        }

        // GET: Manager/BookChappter/Delete/5
        [Route("quan-ly/chuong-sach/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookChappter = await _context.BookChappter
                .Include(b => b.CategoryID)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bookChappter == null)
            {
                return NotFound();
            }

            return View(bookChappter);
        }

        // POST: Manager/BookChappter/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("quan-ly/chuong-sach/xoa/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookChappter = await _context.BookChappter.SingleOrDefaultAsync(m => m.ID == id);
            _context.BookChappter.Remove(bookChappter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookChappterExists(int id)
        {
            return _context.BookChappter.Any(e => e.ID == id);
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
