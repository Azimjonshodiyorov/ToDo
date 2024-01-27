using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Responses;

namespace ToDo.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse : BaseResponse
    {
        public UpdateCategoryCommandResponse()
        {
            
        }

        public UpdateCategoryCommondDto Category { get; set; }
    }
}
