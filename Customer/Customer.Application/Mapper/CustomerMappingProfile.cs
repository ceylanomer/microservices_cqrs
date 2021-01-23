using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Customer.Application.Commands;
using Customer.Application.Responses;

namespace Customer.Application.Mapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Infrastructure.Entities.Customer, CustomerResponse>().ReverseMap();
            CreateMap<Infrastructure.Entities.Customer, CreateCustomerCommand>().ReverseMap();
        }
    }
}
