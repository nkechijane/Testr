using System.Collections.Generic;
using System.Threading.Tasks;

namespace Testr.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity, long id);
        Task DeleteAsync(T entity);
    }
}
