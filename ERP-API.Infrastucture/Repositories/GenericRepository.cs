using ERP_API.Domain.Common;
using ERP_API.Domain.Contracts;
using ERP_API.Infrastucture.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Infrastucture.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        public readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var addedEntitt = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return addedEntitt.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> condition)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
        }
    }
}
