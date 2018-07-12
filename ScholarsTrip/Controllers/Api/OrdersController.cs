using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScholarsTrip.Data;
using ScholarsTrip.Data.Entities;
using ScholarsTrip.ViewModels;

namespace ScholarsTrip.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IScholarsTripRepository repository;
        private readonly IMapper mapper;

        public OrdersController(IScholarsTripRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                var results = repository.GetAllOrders(includeItems);
                return Ok(mapper.Map<IEnumerable< Order>, IEnumerable<OrderViewModel>>(results));
            }
            catch (Exception)
            {

                return BadRequest("Failed to get Orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = repository.GetOrderById(id);

                if (order != null)
                    return Ok(mapper.Map<Order, OrderViewModel>( order));

                else
                    return NotFound();
            }
            catch (Exception)
            {

                return BadRequest("Failed to get Orders");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            //Add it to db
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = mapper.Map<OrderViewModel, Order>(model);
                    repository.AddEntity(newOrder);
                    repository.SaveAll();

                    return Created($"/api/order/{newOrder.Id}", model);

                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {

                return BadRequest("Failed to save a new order");
            }

        }
    }
}