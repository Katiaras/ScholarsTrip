using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScholarsTrip.Data;

namespace ScholarsTrip.Controllers
{
    public class ShopController : Controller
    {
        private readonly IScholarsTripRepository repository;
        public ShopController(IScholarsTripRepository repository)
        {
            this.repository = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var results = repository.GetAllBooks();

            return View(results);
        }
    }
}