namespace CleanArch.Api.Contracts.ToDo.Requests;

public sealed record UpdateToDoRequest(string Title,
    string? Description);