using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Infrastructure.PaginatedLists;

namespace ToDo.Infrastructure.Repositories.Interfaces
{
    public interface ITodoRepository : IRepositoryBase<Todo>
    {
        public Task<PaginatedList<Todo>> GetTodoPaginatedList(TodoStatus status, int pageSize, int pageIndex, string keyword, long? categoryId);

    }
}
