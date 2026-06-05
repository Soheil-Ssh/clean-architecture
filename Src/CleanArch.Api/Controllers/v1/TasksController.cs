using CleanArch.Api.Contracts.ToDo.Requests;
using CleanArch.Api.Contracts.ToDo.Responses;
using CleanArch.Application.Features.ToDo.Commands.CreateToDo;
using CleanArch.Application.Features.ToDo.Commands.DeleteToDo;
using CleanArch.Application.Features.ToDo.Commands.ToggleComplete;
using CleanArch.Application.Features.ToDo.Commands.UpdateToDo;
using CleanArch.Application.Features.ToDo.Common;
using CleanArch.Application.Features.ToDo.Queries.GetAllToDos;
using CleanArch.Application.Features.ToDo.Queries.GetToDoById;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class TasksController(IMediator mediator, IMapper mapper) : BaseController
{
    /// <summary>
    /// Get action for get all to dos with pagination and filter by search query and completion status
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllToDosRequest request)
    {
        var result = await mediator
            .Send(new GetAllToDosQuery(request.SearchQuery, request.IsCompleted, request.Page, request.PageSize));
        return result.ToActionResult<Pagination<ToDoDto>, Pagination<GetAllToDosResponse>>(mapper);
    }

    /// <summary>
    /// Get action for get to do by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await mediator.Send(new GetToDoByIdQuery(id));
        return result.ToActionResult<ToDoDto, GetToDoByIdResponse>(mapper);
    }

    /// <summary>
    /// Post action for create to do
    /// </summary>
    /// <param name="request"></param>
    [HttpPost]
    public async Task<IActionResult> Create(CreateToDoRequest request)
    {
        var result = await mediator.Send(new CreateToDoCommand(request.Title, request.Description));
        return result.ToActionResult();
    }

    /// <summary>
    /// Put action for update to do by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateToDoRequest request)
    {
        var result = await mediator
            .Send(new UpdateToDoCommand(id, request.Title, request.Description));
        return result.ToActionResult();
    }

    /// <summary>
    /// Delete action for delete to do by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await mediator.Send(new DeleteToDoCommand(id));
        return result.ToActionResult();
    }

    /// <summary>
    /// Post action for toggle state of is complete todo
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("ToggleComplete/{id:long}")]
    public async Task<IActionResult> ToggleComplete(long id)
    {
        var result = await mediator.Send(new ToggleCompleteCommand(id));
        return result.ToActionResult();
    }
}