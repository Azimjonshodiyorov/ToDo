using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Categorey>
    {
        bool CheckCategoryDuplicate(string name);

        IQueryable<Categorey> GetAll();
    }

}
