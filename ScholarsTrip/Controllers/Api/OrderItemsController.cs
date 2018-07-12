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
    [Route("api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IScholarsTripRepository repository;
        private readonly IMapper mapper;

        public OrderItemsController(IScholarsTripRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = repository.GetOrderById(orderId);
            if (order != null)
            {
                return Ok(mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int orderId, int Id)
        {
            var order = repository.GetOrderById(orderId);
            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == Id).SingleOrDefault();
                if (item != null)
                {
                    return Ok(mapper.Map<OrderItem, OrderItemViewModel>(item));
                }
                else return NotFound();
            }
            else
            {
                return NotFound();
            }
        }
    }
}