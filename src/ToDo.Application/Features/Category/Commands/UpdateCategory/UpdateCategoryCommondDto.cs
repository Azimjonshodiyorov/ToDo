using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommondDto
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }

    }
}
