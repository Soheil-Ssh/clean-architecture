namespace CleanArch.Application.Features.ToDo.Commands.CreateToDo;

public sealed record CreateToDoCommand(string Title, string? Description) : IRequest<Result>;