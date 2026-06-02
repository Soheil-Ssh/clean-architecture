using CleanArch.Application.Features.ToDo.Common;
using CleanArch.Core.Entities.ToDo;

namespace CleanArch.Application.Features.ToDo.Queries.GetToDoById;

/// <summary>
/// Get single ToDo by Id query handler
/// </summary>
/// <param name="unitOfWork"></param>
/// <param name="mapper"></param>
public class GetToDoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetToDoByIdQuery, Result<ToDoDto>>
{
    public async Task<Result<ToDoDto>> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.ToDoRepository
            .GetAsync(expression: t => t.Id == request.Id,
                selector: t => mapper.Map<ToDoDto>(t));

        if (todo is null)
            return ToDoErrors.NotFound;   

        return todo;
    }
}