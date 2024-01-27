using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Infrastructure.PaginatedLists;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Infrastructure.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
    {
        private readonly ToDoDbContext dbContext;

        public TodoRepository(ToDoDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PaginatedList<Todo>> GetTodoPaginatedList(TodoStatus status, int pageSize, int pageIndex, string keyword, long? categoryId)
        {
            var query = this.dbContext.Todos.Where(x => x.DeleteAt.HasValue);
            if (categoryId.HasValue && categoryId.Value != 0)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Title.Contains(keyword));
            }

            query = query.Where(x=>x.TodoStatus == status);

            var totalCount = query.Count();

            var listPostCatgorys = await query.OrderBy(x=>x.Title)
                .Include(x=>x.Category)
                .Skip((pageIndex-1)*pageIndex).Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            var pageList = new PaginatedList<Todo>
            {
                PageIndex = pageIndex,
                Items = listPostCatgorys,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                TotalRecords = totalCount
            };

            return pageList;
        } 
    }

}
