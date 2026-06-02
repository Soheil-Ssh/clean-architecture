using CleanArch.Api.Contracts.ToDo.Requests;
using CleanArch.Api.Contracts.ToDo.Responses;
using CleanArch.Application.Features.ToDo.Commands.CreateToDo;
using CleanArch.Application.Features.ToDo.Commands.UpdateToDo;
using CleanArch.Application.Features.ToDo.Common;

namespace CleanArch.Api.Mappers;

public class ToDoMapperProfile : Profile
{
    public ToDoMapperProfile()
    {
        // Map ToDoDto => GetAllToDosResponse
        CreateMap<ToDoDto, GetAllToDosResponse>();

        // Map ToDoDto => GetToDoByIdResponse
        CreateMap<ToDoDto, GetToDoByIdResponse>();

        // Map CreateToDoRequest => CreateToDoCommand
        CreateMap<CreateToDoRequest, CreateToDoCommand>();

        // Map UpdateToDoRequest => UpdateToDoCommand
        CreateMap<UpdateToDoRequest, UpdateToDoCommand>();
    }
}