using System;
using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x=> x.Model.GenreId).GreaterThan(0);
            //RuleFor(x=> x.Model.ActorId).GreaterThan(0);
            RuleFor(x=> x.Model.DirectorId).GreaterThan(0);
            RuleFor(x=> x.Model.MovieName).NotEmpty().MinimumLength(3);
            RuleFor(x=> x.Model.Price).GreaterThan(0);
            RuleFor(x=> x.Model.PublisDate).NotEmpty().LessThan(DateTime.Now.Date.AddDays(-1));
        }
    }
}