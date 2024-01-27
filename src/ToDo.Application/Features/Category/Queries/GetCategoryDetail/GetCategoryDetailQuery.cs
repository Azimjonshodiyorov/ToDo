using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Category.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<CategoryVm>
    {
        public long CategoryId { get; set; }

    }
}
