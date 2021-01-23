using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Customer.Application.Commands;
using Customer.Application.Queries;
using Customer.Application.Responses;
using MediatR;

namespace Customer.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerResponse>> GetCustomerByName(int customerId)
        {
            var query = new GetCustomerByNameQuery(customerId);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}
