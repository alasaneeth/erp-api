using ERP_API.Application.DTO.CustomerDto;
using ERP_API.Application.InputModel;
using ERP_API.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Application.Services.Interface
{
    public interface ICustomerService
    {
        Task<PaginationVM<CustomerDto>> GetPagination(PaginationInputModel pagination);
        Task<CustomerDto> GetByIdAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> CreateAsync(CreateCustomerDto createCustomerDto);
        Task UpdateAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteAsync(int id);
    }
}
