namespace CleanArch.Api.Contracts.ToDo.Requests;

public record GetAllToDosRequest(string? SearchQuery,
    bool? IsCompleted,
    int Page = 1,
    int PageSize = 10);