using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly MovieStoreDbContext _dbContext;

        public DeleteMovieCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x=> x.Id == MovieId);

            if(movie is null)
                throw new InvalidOperationException("Film zaten mevcut değil!");
             
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}