using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(x=> x.MovieId).GreaterThan(0);
        }
    }
}