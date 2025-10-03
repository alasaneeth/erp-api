using ERP_API.Domain.Contracts;
using ERP_API.Domain.Models;
using ERP_API.Infrastucture.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERP_API.Infrastucture.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _dbContext.Customers.Include(x=>x.CustomerType).AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetDetailsAsync(int id)
        {
            return await _dbContext.Customers.Include(x => x.CustomerType).AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task UpdaAsync(Customer customer)
        {
            _dbContext.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
