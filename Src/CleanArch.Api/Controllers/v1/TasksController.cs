using CleanArch.Api.Contracts.ToDo.Requests;
using CleanArch.Api.Contracts.ToDo.Responses;
using CleanArch.Application.Features.ToDo.Commands.CreateToDo;
using CleanArch.Application.Features.ToDo.Common;
using CleanArch.Application.Features.ToDo.Queries.GetToDoById;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class TasksController(IMediator mediator, IMapper mapper) : BaseController
{
    /// <summary>
    /// Get action for get to do by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetToDoById(long id)
    {
        var result = await mediator.Send(new GetToDoByIdQuery(id));
        return result.ToActionResult<ToDoDto, GetToDoByIdResponse>(mapper);
    }

    /// <summary>
    /// Post action for create to do
    /// </summary>
    /// <param name="request"></param>
    [HttpPost]
    public async Task<IActionResult> CreateToDo(CreateToDoRequest request)
    {
        var result = await mediator.Send(new CreateToDoCommand(request.Title, request.Description));
        return result.ToActionResult();
    }
}