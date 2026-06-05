namespace CleanArch.Application.Features.ToDo.Commands.ToggleComplete;

public sealed record ToggleCompleteCommand(long Id) : IRequest<Result<bool>>;