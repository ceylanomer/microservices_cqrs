using System;
using System.Collections.Generic;
using System.Text;
using Customer.Application.Responses;
using MediatR;

namespace Customer.Application.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
