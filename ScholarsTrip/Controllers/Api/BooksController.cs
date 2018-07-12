using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScholarsTrip.Data;
using ScholarsTrip.Data.Entities;

namespace ScholarsTrip.Controllers.Api
{
    [Route("api/[Controller]")]
    public class BooksController : Controller
    {
        private readonly IScholarsTripRepository repository;

        public BooksController(IScholarsTripRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.GetAllBooks());
            }
            catch (Exception)
            {
                return BadRequest("Failed to get books");
            }
        }
    }
}