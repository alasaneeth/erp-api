using AutoMapper;
using ERP_API.Application.DTO.CustomerDto;
using ERP_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Application.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.CustomerType, opt => opt.MapFrom(source => source.CustomerType.Name));
        }
    }
}
