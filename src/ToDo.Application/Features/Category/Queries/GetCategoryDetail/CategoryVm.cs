using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Category.Queries.GetCategoryDetail
{
    public class CategoryVm
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public bool CanDeleteCategory { get; set; }
    }
}
