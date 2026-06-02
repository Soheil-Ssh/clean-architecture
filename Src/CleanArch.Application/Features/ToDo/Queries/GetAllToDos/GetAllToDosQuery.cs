using CleanArch.Application.Features.ToDo.Common;

namespace CleanArch.Application.Features.ToDo.Queries.GetAllToDos;

public sealed record GetAllToDosQuery(string? SearchQuery,
    bool? IsCompleted,
    int Page,
    int PageSize) : IRequest<Result<Pagination<ToDoDto>>>;