using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Features.Category.Commands.CreateCategory;
using ToDo.Application.Features.Category.Commands.DeleteCategory;
using ToDo.Application.Features.Category.Commands.UpdateCategory;
using ToDo.Application.Features.Category.Queries.GetCategoriesList;
using ToDo.Application.Features.Category.Queries.GetCategoryDetail;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Gets", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }

        [HttpGet("Get", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CategoryListVm>> GetCategory(long categoryId)
        {
            var category = await _mediator.Send(new GetCategoryDetailQuery()
            {
                CategoryId = categoryId
            });
            return Ok(category);
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var categoryCommandResponse = await _mediator.Send(createCategoryCommand);
            return Ok(categoryCommandResponse);
        }

        [HttpPut(Name = "UpdateCategory")]
        public async Task<ActionResult<UpdateCategoryCommandResponse>> UpdateCategory([FromBody] UpdateCategoryComand updateCategoryCommand)
        {
            var updateReponse = await _mediator.Send(updateCategoryCommand);
            return Ok(updateReponse);
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        public async Task<ActionResult<bool>> DeleteCategory(long id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand() { CategoryId = id };
            var deletedSuccess = await _mediator.Send(deleteCategoryCommand);
            return Ok(deletedSuccess);
        }
    }
}
