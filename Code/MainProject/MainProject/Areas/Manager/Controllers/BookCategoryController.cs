using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainProject.Data;
using MainProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Admin, Manager")]
    public class BookCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCategoryController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Manager/BookCategory
        [Route("quan-ly/danh-muc-sach")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookCategory.ToListAsync());
        }

        // GET: Manager/BookCategory/Details/5
        [Route("quan-ly/danh-muc-sach/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        [Route("quan-ly/danh-muc-sach/tao")]
        // GET: Manager/BookCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/BookCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("quan-ly/danh-muc-sach/tao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CategoryName,CategoryDes,Slug")] BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bookCategory);
        }

        // GET: Manager/BookCategory/Edit/5
        [Route("quan-ly/danh-muc-sach/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory.SingleOrDefaultAsync(m => m.ID == id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        // POST: Manager/BookCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("quan-ly/danh-muc-sach/chinh-sua/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,CategoryName,CategoryDes,Slug")] BookCategory bookCategory)
        {
            if (id != bookCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoryExists(bookCategory.ID))
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
            return View(bookCategory);
        }

        // GET: Manager/BookCategory/Delete/5
        [Route("quan-ly/danh-muc-sach/xoa/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }
        [Route("quan-ly/danh-muc-sach/xoa/{id}")]
        // POST: Manager/BookCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var bookCategory = await _context.BookCategory.SingleOrDefaultAsync(m => m.ID == id);
            _context.BookCategory.Remove(bookCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookCategoryExists(int? id)
        {
            return _context.BookCategory.Any(e => e.ID == id);
        }


    }
}
