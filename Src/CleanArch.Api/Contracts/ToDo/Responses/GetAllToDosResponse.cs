namespace CleanArch.Api.Contracts.ToDo.Responses;

public record GetAllToDosResponse(long Id,
    string Title,
    string? Description,
    bool IsCompleted,
    DateTime? CompletedDate,
    DateTime CreateDate,
    DateTime? UpdateDate);