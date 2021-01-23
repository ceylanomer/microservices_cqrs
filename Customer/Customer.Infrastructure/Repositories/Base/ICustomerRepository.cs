using System;
using System.Collections.Generic;
using System.Text;
using Customer.Core.Repositories.Base;

namespace Customer.Infrastructure.Repositories.Base
{
    public interface ICustomerRepository : IRepository<Entities.Customer>
    {
    }
}
