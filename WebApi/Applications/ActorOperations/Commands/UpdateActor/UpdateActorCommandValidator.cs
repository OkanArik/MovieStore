using System;
using FluentValidation;

namespace WebApi.Applications.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x=> x.Model.Fullname).NotEmpty().MinimumLength(3);
            RuleFor(x=> x.Model.Birthday).NotEmpty().LessThan(DateTime.Now.Date.AddDays(-1));
        }
    }
}