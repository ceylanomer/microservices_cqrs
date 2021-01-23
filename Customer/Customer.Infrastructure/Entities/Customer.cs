using System;
using System.Collections.Generic;
using System.Text;
using Customer.Core.Entities.Base;

namespace Customer.Infrastructure.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
