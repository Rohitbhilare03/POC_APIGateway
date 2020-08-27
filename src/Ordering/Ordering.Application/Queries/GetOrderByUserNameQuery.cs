using MediatR;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Queries
{
    public class GetOrderByUserNameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public GetOrderByUserNameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
