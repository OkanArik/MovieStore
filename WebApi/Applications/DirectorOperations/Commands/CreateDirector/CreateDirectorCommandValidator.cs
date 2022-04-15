using System;
using FluentValidation;

namespace WebApi.Applications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x=> x.Model.FullName).NotEmpty().MinimumLength(3);
            RuleFor(x=> x.Model.BirthDay).NotEmpty().LessThan(DateTime.Now.Date.AddYears(-10));
        }
    }
}