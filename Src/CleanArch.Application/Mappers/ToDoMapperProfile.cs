using CleanArch.Application.Features.ToDo.Commands.CreateToDo;
using CleanArch.Application.Features.ToDo.Common;
using CleanArch.Core.Entities.ToDo;

namespace CleanArch.Application.Mappers;

public class ToDoMapperProfile : Profile
{
    public ToDoMapperProfile()
    {
        // Map CreateToDoCommand => ToDo
        CreateMap<CreateToDoCommand, ToDo>();

        // Map ToDo => ToDoDto
        CreateMap<ToDo, ToDoDto>();
    }
}