using System;
using System.Collections.Generic;
using System.Text;
using Customer.Core.Repositories;
using Customer.Infrastructure.Data;
using Customer.Infrastructure.Repositories.Base;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Entities.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) : base(customerContext)
        {
            
        }
    }
}
