namespace CleanArch.Application.Features.ToDo.Commands.DeleteToDo;

public sealed record DeleteToDoCommand(long Id) : IRequest<Result>;