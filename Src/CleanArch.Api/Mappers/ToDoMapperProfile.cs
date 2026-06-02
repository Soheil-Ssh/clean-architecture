using CleanArch.Api.Contracts.ToDo.Requests;
using CleanArch.Api.Contracts.ToDo.Responses;
using CleanArch.Application.Features.ToDo.Commands.CreateToDo;
using CleanArch.Application.Features.ToDo.Common;

namespace CleanArch.Api.Mappers;

public class ToDoMapperProfile : Profile
{
    public ToDoMapperProfile()
    {
        // Map CreateToDoRequest => CreateToDoCommand
        CreateMap<CreateToDoRequest, CreateToDoCommand>();

        // Map ToDoDto => GetToDoByIdResponse
        CreateMap<ToDoDto, GetToDoByIdResponse> ();
    }
}