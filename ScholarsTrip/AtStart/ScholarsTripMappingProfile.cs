using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ScholarsTrip.Data.Entities;
using ScholarsTrip.ViewModels;

namespace ScholarsTrip.AtStart
{
    public class ScholarsTripMappingProfile : Profile
    {
        public ScholarsTripMappingProfile() 
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o=> o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
