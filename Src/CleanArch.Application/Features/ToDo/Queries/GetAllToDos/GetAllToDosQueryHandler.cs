using CleanArch.Application.Features.ToDo.Common;
using CleanArch.Core.Specifications.ToDo;

namespace CleanArch.Application.Features.ToDo.Queries.GetAllToDos;

public class GetAllToDosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllToDosQuery, Result<Pagination<ToDoDto>>>
{
    public async Task<Result<Pagination<ToDoDto>>> Handle(GetAllToDosQuery request, CancellationToken cancellationToken)
    {
        var filter =
            new ToDoFilterSpecification(request.SearchQuery, request.IsCompleted, request.Page, request.PageSize);
        return await unitOfWork.ToDoRepository.GetAll(filter, t => mapper.Map<ToDoDto>(t));
    }
}