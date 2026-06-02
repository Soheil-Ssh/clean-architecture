namespace CleanArch.Application.Features.ToDo.Commands.UpdateToDo;

public class UpdateToDoCommandValidator : AbstractValidator<UpdateToDoCommand>
{
    public UpdateToDoCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Description)
            .MaximumLength(1000);
    }
}