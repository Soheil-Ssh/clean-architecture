using CleanArch.Application.Features.ToDo.Common;

namespace CleanArch.Application.Features.ToDo.Queries.GetToDoById;

public sealed record GetToDoByIdQuery(long Id) : IRequest<Result<ToDoDto>>;