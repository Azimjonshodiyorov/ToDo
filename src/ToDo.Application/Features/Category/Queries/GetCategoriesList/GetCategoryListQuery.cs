﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Category.Queries.GetCategoriesList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
