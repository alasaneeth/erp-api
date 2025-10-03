using AutoMapper;
using ERP_API.Application.DTO.CustomerDto;
using ERP_API.Application.InputModel;
using ERP_API.Application.Services.Interface;
using ERP_API.Application.ViewModels;
using ERP_API.Domain.Contracts;
using ERP_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IPaginationService<CustomerDto,Customer> _pagination;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepostory, IMapper mapper, IPaginationService<CustomerDto, Customer> pagination)
        {
            _repository = customerRepostory;
            _mapper = mapper;
            _pagination = pagination;
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            var createdEntity = await _repository.CreateAsync(customer);
            var entity = _mapper.Map<CustomerDto>(createdEntity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(x=>x.Id == id);
            await _repository.DeleteAsync(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllCustomerAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }


        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _repository.GetDetailsAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<PaginationVM<CustomerDto>> GetPagination(PaginationInputModel pagination)
        {
            var source = await _repository.GetAllCustomerAsync();
            var result = _pagination.GetPagination(source, pagination); 

            return result;
        }

        public async Task UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            var customer = _mapper.Map<Customer>(updateCustomerDto);
            await _repository.UpdateAsync(customer);
        }
    }
}
