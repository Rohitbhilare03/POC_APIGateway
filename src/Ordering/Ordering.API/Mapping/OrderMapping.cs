using AutoMapper;
using EventBusRabbitMQ.Events;
using Ordering.Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<BasketCheckoutEvent, CheckOutOrderCommand>().ReverseMap();
        }
    }
}
