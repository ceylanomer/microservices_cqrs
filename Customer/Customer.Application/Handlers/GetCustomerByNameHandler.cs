using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Customer.Application.Mapper;
using Customer.Application.Queries;
using Customer.Application.Responses;
using Customer.Infrastructure.Repositories.Base;
using MediatR;

namespace Customer.Application.Handlers
{
    public class GetCustomerByNameHandler : IRequestHandler<GetCustomerByNameQuery, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByNameHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerResponse> Handle(GetCustomerByNameQuery request, CancellationToken cancellationToken)
        {
            var customerEntity = await _customerRepository.GetByIdAsync(request.CustomerId);
            var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(customerEntity);
            return customerResponse;
        }
    }
}
