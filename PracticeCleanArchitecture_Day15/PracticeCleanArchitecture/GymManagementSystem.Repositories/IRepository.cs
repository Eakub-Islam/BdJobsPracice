using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);     
        Task<int> UpdateAsync(T entity);  
        Task<int> DeleteAsync(T entity); 
    }
}
