using CleanArch.Application.Features.ToDo.Common;
using CleanArch.Core.Specifications.ToDo;

namespace CleanArch.Application.Features.ToDo.Queries.GetAllToDos;

/// <summary>
/// Get all to dos with pagination and filter query handler
/// </summary>
/// <param name="unitOfWork"></param>
/// <param name="mapper"></param>
public class GetAllToDosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllToDosQuery, Result<Pagination<ToDoDto>>>
{
    public async Task<Result<Pagination<ToDoDto>>> Handle(GetAllToDosQuery request, CancellationToken cancellationToken)
    {
        var filter =
            new ToDoFilterSpecification(request.SearchQuery, request.IsCompleted, request.Page, request.PageSize);
        return await unitOfWork.ToDoRepository.GetAll(filter: filter,
            selector: t => mapper.Map<ToDoDto>(t),
            cancellationToken: cancellationToken);
    }
}