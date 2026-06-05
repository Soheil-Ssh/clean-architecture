using CleanArch.Core.Entities.ToDo;

namespace CleanArch.Application.Features.ToDo.Commands.ToggleComplete;

/// <summary>
/// Toggle state of is complete to do command handler
/// </summary>
/// <param name="unitOfWork"></param>
public class ToggleCompleteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ToggleCompleteCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(ToggleCompleteCommand request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.ToDoRepository
            .GetAsync(t => t.Id == request.Id, cancellationToken);

        if (todo is null)
            return ToDoErrors.NotFound;

        todo.IsCompleted = !todo.IsCompleted;
        todo.CompletedDate = todo.IsCompleted ? DateTime.UtcNow : null;

        unitOfWork.ToDoRepository.Update(todo);
        await unitOfWork.SaveAsync(cancellationToken);

        return todo.IsCompleted;
    }
}