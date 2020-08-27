﻿using MediatR;
using Ordering.Application.Command;
using Ordering.Application.Mapper;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handler
{
    public class CheckOutOrderHandler : IRequestHandler<CheckOutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckOutOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);
            if (orderEntity == null)
            {
                throw new ApplicationException("not Mapped");
            }

            var newOrder = await _orderRepository.AddAsync(orderEntity);
            var orderResponse = OrderMapper.Mapper.Map<OrderResponse>(newOrder);
            return orderResponse;
        }
    }
}
