using System;
using System.Collections.Generic;
using System.Text;
using Customer.Application.Responses;
using MediatR;

namespace Customer.Application.Queries
{
    public class GetCustomerByNameQuery : IRequest<CustomerResponse>
    {
        public int CustomerId { get; set; }

        public GetCustomerByNameQuery(int customerId)
        {
            CustomerId = customerId == 0 ? throw new ArgumentNullException(nameof(customerId)) : customerId;
        }
    }
}
