using CleanArch.Core.Entities.ToDo;

namespace CleanArch.Application.Features.ToDo.Commands.DeleteToDo;

/// <summary>
/// Delete to do command handler
/// </summary>
/// <param name="unitOfWork"></param>
/// <param name="mapper"></param>
public class DeleteToDoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<DeleteToDoCommand, Result>
{
    public async Task<Result> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.ToDoRepository
            .GetAsync(t => t.Id == request.Id, cancellationToken);
        if (todo is null)
            return ToDoErrors.NotFound;

        unitOfWork.ToDoRepository.DeletePermanently(todo);
        await unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}