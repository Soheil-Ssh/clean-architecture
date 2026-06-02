namespace CleanArch.Api.Contracts.ToDo.Requests;

public sealed record CreateToDoRequest(string Title, string? Description);