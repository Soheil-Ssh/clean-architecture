using CleanArch.Core.Entities.ToDo;

namespace CleanArch.Application.Features.ToDo.Commands.UpdateToDo;

/// <summary>
/// Update ToDo Command Handler
/// </summary>
/// <param name="unitOfWork"></param>
/// <param name="mapper"></param>
public class UpdateToDoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<UpdateToDoCommand, Result>
{
    public async Task<Result> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.ToDoRepository
            .GetAsync(t => t.Id == request.Id, cancellationToken);
        if (todo is null)
            return ToDoErrors.NotFound;

        unitOfWork.ToDoRepository.Update(mapper.Map(request, todo));
        await unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}