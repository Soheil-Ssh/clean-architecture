namespace CleanArch.Api.Contracts.ToDo.Responses;

public record GetToDoByIdResponse(long Id,
    string Title,
    string? Description,
    bool IsCompleted,
    DateTime? CompletedDate,
    DateTime CreateDate,
    DateTime? UpdateDate);