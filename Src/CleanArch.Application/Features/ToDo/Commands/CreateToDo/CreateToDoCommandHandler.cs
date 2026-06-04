namespace CleanArch.Application.Features.ToDo.Commands.CreateToDo;

/// <summary>
/// Create ToDo command handler
/// </summary>
/// <param name="unitOfWork"></param>
/// <param name="mapper"></param>
public class CreateToDoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateToDoCommand, Result>
{
    public async Task<Result> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.ToDoRepository.AddAsync(mapper.Map<Core.Entities.ToDo.ToDo>(request), cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Result.Success();
    }
}