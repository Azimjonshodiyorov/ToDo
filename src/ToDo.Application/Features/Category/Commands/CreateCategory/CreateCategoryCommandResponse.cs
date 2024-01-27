using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Responses;

namespace ToDo.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse()
        {

        }

        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
