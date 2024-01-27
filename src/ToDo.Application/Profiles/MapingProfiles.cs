using AutoMapper;
using ToDo.Application.Features.Category.Commands.CreateCategory;
using ToDo.Application.Features.Category.Commands.UpdateCategory;
using ToDo.Application.Features.Category.Queries.GetCategoriesList;
using ToDo.Application.Features.Category.Queries.GetCategoryDetail;
using ToDo.Application.Features.Todo.Commands.CreateTodo;
using ToDo.Application.Features.Todo.Commands.UpdateTodo;
using ToDo.Application.Features.Todo.Queries.GetTodoList;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.PaginatedLists;

namespace ToDo.Application.Profiles
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles()
        {
            CreateMap<Domain.Entities.Todo, TodoVm>().ReverseMap();
            CreateMap<PaginatedList<Domain.Entities.Todo>, PaginatedList<TodoVm>>().ReverseMap();
            CreateMap<Domain.Entities.Todo, CreateTodoDto>().ReverseMap();
            CreateMap<Domain.Entities.Todo, UpdateTodoDto>().ReverseMap();
            CreateMap<CreateTodoDto, CreateTodoCommand>().ReverseMap();
            CreateMap<UpdateTodoDto, UpdateCategoryComand>().ReverseMap();
            CreateMap<Domain.Entities.Todo, CreateTodoCommand>().ReverseMap();
            CreateMap<Domain.Entities.Todo, UpdateTodoCommand>().ReverseMap();
            CreateMap<UpdateTodoDto, UpdateTodoCommand>().ReverseMap();

            CreateMap<Categorey, CategoryListVm>().ReverseMap();
            CreateMap<Categorey, CreateCategoryDto>().ReverseMap();
            CreateMap<Categorey, CategoryVm>().ReverseMap();
            CreateMap<Categorey, CreateCategoryCommand>().ReverseMap();
            CreateMap<Categorey, UpdateCategoryComand>().ReverseMap();
            CreateMap<CreateCategoryDto, CreateCategoryCommand>().ReverseMap();
            CreateMap<UpdateCategoryCommondDto, UpdateCategoryComand>().ReverseMap();
        }
    }
}
