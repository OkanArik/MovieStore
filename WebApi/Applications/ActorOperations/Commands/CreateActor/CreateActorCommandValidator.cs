using System;
using FluentValidation;

namespace WebApi.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x=> x.Model.Fullname).NotEmpty().MinimumLength(3);
            RuleFor(x=> x.Model.Birthday).NotEmpty().LessThan(DateTime.Now.Date.AddYears(-1));
        }
    }
}