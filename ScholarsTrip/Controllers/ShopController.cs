using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScholarsTrip.Data;

namespace ScholarsTrip.Controllers
{
    public class ShopController : Controller
    {
        private ScholarsTripDbContext _context;
        public ShopController(ScholarsTripDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var results = _context.Books
                .OrderBy(p => p.Price)
                .ToList();

            return View(results);
        }
    }
}