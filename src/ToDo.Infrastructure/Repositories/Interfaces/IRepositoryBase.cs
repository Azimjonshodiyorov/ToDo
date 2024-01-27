using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<T?> GetByIdAsync(long id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
