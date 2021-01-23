using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Core.Entities.Base
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
