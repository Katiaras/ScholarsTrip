using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScholarsTrip.Data;
using ScholarsTrip.Data.Entities;
using ScholarsTrip.ViewModels;

namespace ScholarsTrip.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Controller
    {
        private readonly IScholarsTripRepository repository;
        private readonly IMapper mapper;
        private readonly UserManager<StoreUser> userManager;

        public OrdersController(IScholarsTripRepository repository, IMapper mapper, UserManager<StoreUser> userManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                var username = User.Identity.Name;

                var results = repository.GetAllOrdersByUser(username, includeItems);
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
                var order = repository.GetOrderById(User.Identity.Name,id);

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
        public async Task<IActionResult> Post([FromBody]OrderViewModel model)
        {
            //Add it to db
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = mapper.Map<OrderViewModel, Order>(model);
                    if(newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                    newOrder.User = currentUser;


                    repository.AddEntity(newOrder);
                    repository.SaveAll();


                    return Created($"/api/order/{newOrder.Id}",mapper.Map<Order, OrderViewModel>(newOrder));

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