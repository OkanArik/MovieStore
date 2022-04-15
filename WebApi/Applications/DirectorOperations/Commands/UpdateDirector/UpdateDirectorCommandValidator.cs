using System;
using FluentValidation;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x=> x.DirectorId).GreaterThan(0);
            RuleFor(x=> x.Model.FullName).NotEmpty().MinimumLength(5);
            RuleFor(x=> x.Model.BirthDay).LessThan(DateTime.Now.Date.AddYears(-10));
        }
    }
}