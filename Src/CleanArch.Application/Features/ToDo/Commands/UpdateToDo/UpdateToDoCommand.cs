
namespace CleanArch.Application.Features.ToDo.Commands.UpdateToDo;

public sealed record UpdateToDoCommand(long Id,
    string Title,
    string? Description) : IRequest<Result>;