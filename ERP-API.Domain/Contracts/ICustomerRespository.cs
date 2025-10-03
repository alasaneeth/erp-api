using ERP_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Domain.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<Customer>> GetAllProductAsync();

        Task<Customer> GetDetailsAsync(int id);

        Task UpdateAsync(Customer customer);
    }
}
