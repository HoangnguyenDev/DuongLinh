using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainProject.Data;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.Areas.Manager.Controllers
{
    [Area("manager")]
    [Authorize(Roles = "Admin, Manager")]
    public class ScoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ScoreController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        [Route("quan-ly/diem-so")]
        public IActionResult Index()
        {
            return View(_context.Users.OrderBy(p=>p.Score).ToList());
        }
    }
}