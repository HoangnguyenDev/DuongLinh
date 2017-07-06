using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainProject.Data;
using MainProject.Models;

namespace MainProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class BookChappterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookChappterController(ApplicationDbContext context)
        {
            _context = context;    
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
                
                _context.Add(bookChappter);
                await _context.SaveChangesAsync();
                _context.History.AddRange(new History {DateTime = DateTime.Now,BookChappterID= bookChappter.ID });
                _context.SaveChanges();
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
    }
}
