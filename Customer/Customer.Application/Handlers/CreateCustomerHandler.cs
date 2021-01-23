using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Customer.Application.Commands;
using Customer.Application.Mapper;
using Customer.Application.Responses;
using Customer.Infrastructure.Repositories.Base;
using MediatR;

namespace Customer.Application.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = CustomerMapper.Mapper.Map<Infrastructure.Entities.Customer>(request);

            if (customerEntity == null)
            {
                throw new ApplicationException("not mapped");
            }

            var newCustomer = await _customerRepository.AddAsync(customerEntity);

            var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(newCustomer);

            return customerResponse;
        }
    }
}
