using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Category.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }

        public bool CanDelete { get; set; }

    }
}
