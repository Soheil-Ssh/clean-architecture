namespace CleanArch.Application.Features.ToDo.Common;

public sealed record ToDoDto(long Id,
    string Title,
    string? Description,
    bool IsCompleted,
    DateTime? CompletedDate,
    DateTime CreateDate,
    DateTime? UpdateDate);