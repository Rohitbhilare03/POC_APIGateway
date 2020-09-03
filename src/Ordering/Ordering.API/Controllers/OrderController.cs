using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Command;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrderByUserName(string UserName)
        {
            var query = new GetOrderByUserNameQuery(UserName);
            var orders = await _mediator.Send(query);
            return Ok(orders);

        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderResponse>> CheckOutOrder([FromBody] CheckOutOrderCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}
