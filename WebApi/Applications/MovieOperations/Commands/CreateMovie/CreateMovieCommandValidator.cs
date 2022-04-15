using System;
using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            //RuleFor(x=> x.Model.ActorId).GreaterThan(0);
            RuleFor(x=> x.Model.GenreId).GreaterThan(0);
            //RuleFor(x=> x.Model.ActorId).GreaterThan(0);
            RuleFor(x=> x.Model.DirectorId).GreaterThan(0);
            RuleFor(x=> x.Model.MovieName).NotEmpty().MinimumLength(3);
            RuleFor(x=> x.Model.Price).GreaterThan(0);
            RuleFor(x=> x.Model.PublisDate).NotEmpty().LessThan(DateTime.Now.Date.AddDays(-1));
        }
    }
}