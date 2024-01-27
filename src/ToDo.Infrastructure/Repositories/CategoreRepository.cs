using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Infrastructure.Repositories
{
    public class CategoreRepository : RepositoryBase<Categorey>, ICategoryRepository
    {
        private readonly ToDoDbContext dbContext;

        public CategoreRepository(ToDoDbContext dbContext) 
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CheckCategoryDuplicate(string name)
        {
            var isDuplicate = dbContext.Categories.Where(x=>x.DeleteAt.HasValue)
               .Any(x => x.Name.Equals(name));
            return isDuplicate;
        }

        public IQueryable<Categorey> GetAll()
        {
            return dbContext.Categories;
        }
    }
}
