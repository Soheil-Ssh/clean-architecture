using CleanArch.Core.Entities.ToDo;

namespace CleanArch.Application.Features.ToDo.Commands.DeleteToDo;

public class DeleteToDoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<DeleteToDoCommand, Result>
{
    public async Task<Result> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.ToDoRepository
            .GetAsync(t => t.Id == request.Id);
        if (todo is null)
            return ToDoErrors.NotFound;

        unitOfWork.ToDoRepository.DeletePermanently(todo);
        await unitOfWork.SaveAsync();

        return Result.Success();
    }
}